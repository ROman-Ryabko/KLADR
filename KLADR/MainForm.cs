using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace KLADR
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Выходная CodePage
        /// </summary>
        private static readonly Encoding CpOutEncoding = Encoding.GetEncoding(Properties.Settings.Default.CpOutEncoding);
        /// <summary>
        /// Входная CodePage
        /// </summary>
        private static readonly Encoding CpInEncoding = Encoding.GetEncoding(Properties.Settings.Default.CpInEncoding);
        /// <summary>
        /// Строка соединения для sql БД
        /// </summary>
        private static readonly string Cs = Properties.Settings.Default.dbconnect;
        /// <summary>
        /// Имя таблицы для хранения записей о населенных пунктах
        /// </summary>
        private static readonly string TblKladrKladr = Properties.Settings.Default.tblKladrKladr;
        /// <summary>
        /// Имя таблицы для хранения записей о улицах
        /// </summary>
        private static readonly string TblKladrStreet = Properties.Settings.Default.tblKladrStreet;
        /// <summary>
        /// Имя таблицы для хранения записей о домах
        /// </summary>
        private static readonly string TblKladrDoma = Properties.Settings.Default.tblKladrDoma;
        /// <summary>
        /// Размер блока для загрузки в БД
        /// </summary>
        private static readonly int BlockSize = Properties.Settings.Default.BlockSize;
        /// <summary>
        /// Шаблон для подключения к DBF
        /// </summary>
        private static readonly string DbfConnectTemplate = Properties.Settings.Default.DBF_Template;
        /// <summary>
        /// Имя файла KLADR.DBF
        /// </summary>
        private static readonly string DbfKladr = Properties.Settings.Default.KladrDbf;
        /// <summary>
        /// Имя файла STREEET.DBF
        /// </summary>
        private static readonly string DbfStreet = Properties.Settings.Default.StreetDbf;
        /// <summary>
        /// Имя файла DOMA.DBF
        /// </summary>
        private static readonly string DbfDoma = Properties.Settings.Default.DomaDbf;
        /// <summary>
        /// Путь к папке с dbf файлами КЛАДР
        /// </summary>
        private string _dbfFolder;

        public MainForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Выбор папки с файлами и запуск процесса загрузки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadButtonClick(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Выберите папку с файлами КЛАДР";
            if (fbd.ShowDialog() != DialogResult.OK) return;
            LoadButton.Enabled = false;
            StopButton.Enabled = true;
            _dbfFolder = fbd.SelectedPath;
            BwKladr.RunWorkerAsync(_dbfFolder);
        }
        /// <summary>
        /// Процесс обработки DOMA.DBF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BwDomaDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string kladrFolderPath = (string)e.Argument;
            using (SqlConnection connect = new SqlConnection(Cs))
            using (var dBaseConnection = new System.Data.Odbc.OdbcConnection())
            {
                connect.Open();
                using (SqlCommand sqlCommand = connect.CreateCommand())
                {
                    sqlCommand.CommandText = @"CREATE TABLE #doma (
  [District] int NOT NULL,
  [Region] int NOT NULL,
  [Country] int NOT NULL,
  [Settlement] int NOT NULL,
  [Street] int NOT NULL,
  [Building] int NOT NULL,
  [Name] varchar(40) COLLATE Cyrillic_General_CI_AS NULL,
  [Korp] varchar(10) COLLATE Cyrillic_General_CI_AS NOT NULL,
  [Socr] varchar(10) COLLATE Cyrillic_General_CI_AS NULL,
  [PostIndex] int NOT NULL) ";
                    sqlCommand.ExecuteNonQuery();
                }
                dBaseConnection.ConnectionString = string.Format(DbfConnectTemplate, kladrFolderPath, DbfDoma);
                dBaseConnection.Open();
                System.Data.Odbc.OdbcCommand cmd = dBaseConnection.CreateCommand();
                cmd.CommandText = string.Format(@"SELECT * FROM {0}\{1}", kladrFolderPath, DbfDoma);
                DataTable table = MakeTableTblKladrBuildings();
                using (var reader = cmd.ExecuteReader())
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connect))
                {
                    bulkCopy.DestinationTableName = "#doma";
                    int count = 0;
                    while (reader.Read())
                    {
                        if (BwDoma.CancellationPending) { e.Cancel = true; return; }
                        var code = new DomaCode(CodePageConvertor(reader["CODE"]));
                        int index;
                        Int32.TryParse(CodePageConvertor(reader["INDEX"]), out index);
                        string name = CodePageConvertor(reader["NAME"]);
                        string socr = CodePageConvertor(reader["SOCR"]);
                        string korp = CodePageConvertor(reader["KORP"]);

                        DataRow row = table.NewRow();
                        row["District"] = code.District;
                        row["Region"] = code.Region;
                        row["Country"] = code.Country;
                        row["Settlement"] = code.Settlement;
                        row["Street"] = code.Street;
                        row["Building"] = code.Building;
                        row["Name"] = name;
                        row["Socr"] = socr;
                        row["Korp"] = korp;
                        row["Index"] = index;
                        table.Rows.Add(row);
                        BwDoma.ReportProgress(count + 1);
                        if (++count % BlockSize != 0) continue;
                        bulkCopy.WriteToServer(table);
                        table = MakeTableTblKladrBuildings();
                    }
                    bulkCopy.WriteToServer(table);
                    using (SqlCommand sqlCommand = connect.CreateCommand())
                    {
                        sqlCommand.CommandTimeout = 0;
                        sqlCommand.CommandText = string.Format(@" MERGE {0} AS t
 USING #doma AS s
 ON t.District = s.District
	AND t.Region = s.Region
	AND t.Country = s.Country
	AND t.Settlement = s.Settlement
	AND t.Street = s.Street
    AND t.Building = s.Building
WHEN MATCHED THEN UPDATE
	SET Name = s.Name
        ,Korp = s.Korp
		,Socr = s.Socr
		,PostIndex = s.PostIndex
WHEN NOT MATCHED BY TARGET THEN	INSERT 
	(District,Region,Country,Settlement,Street,Building,Name,Korp,Socr,PostIndex) 
	VALUES(s.District,s.Region,s.Country,s.Settlement,s.Street,s.Building,s.Name,s.Korp,s.Socr,s.PostIndex)
WHEN NOT MATCHED BY SOURCE THEN DELETE;", TblKladrDoma);
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
        }
        /// <summary>
        /// Процесс обработки STREET.DBF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BwStreetDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string kladrFolderPath = (string)e.Argument;
            using (SqlConnection connect = new SqlConnection(Cs))
            using (var dBaseConnection = new System.Data.Odbc.OdbcConnection())
            {
                connect.Open();
                using (SqlCommand sqlCommand = connect.CreateCommand())
                {
                    sqlCommand.CommandText = @"
CREATE TABLE #street  (
  [District] int NOT NULL,
  [Region] int NOT NULL,
  [Country] int NOT NULL,
  [Settlement] int NOT NULL,
  [Street] int NOT NULL,
  [Name] varchar(40) COLLATE Cyrillic_General_CI_AS NULL,
  [Socr] varchar(10) COLLATE Cyrillic_General_CI_AS NULL,
  [PostIndex] int NOT NULL) ";
                    sqlCommand.ExecuteNonQuery();
                }
                dBaseConnection.ConnectionString =
                       string.Format(DbfConnectTemplate, kladrFolderPath, DbfStreet);

                dBaseConnection.Open();
                System.Data.Odbc.OdbcCommand cmd = dBaseConnection.CreateCommand();
                cmd.CommandText = string.Format(@"SELECT * FROM {0}\{1}", kladrFolderPath, DbfStreet);

                DataTable table = MakeTableTblKladrStreets();
                using (var reader = cmd.ExecuteReader())
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connect))
                {
                    bulkCopy.DestinationTableName = "#street";
                    int count = 0;
                    while (reader.Read())
                    {
                        if (BwStreet.CancellationPending) { e.Cancel = true; return; }
                        int index;
                        var code = new StreetCode(CodePageConvertor(reader["CODE"]));
                        Int32.TryParse(CodePageConvertor(reader["INDEX"]), out index);
                        var name = CodePageConvertor(reader["NAME"]);
                        var socr = CodePageConvertor(reader["SOCR"]);

                        if (code.Update != 0) continue; //update 
                        BwStreet.ReportProgress(count + 1);
                        DataRow row = table.NewRow();
                        row["District"] = code.District;
                        row["Region"] = code.Region;
                        row["Country"] = code.Country;
                        row["Settlement"] = code.Settlement;
                        row["Street"] = code.Street;
                        row["Name"] = name;
                        row["Socr"] = socr;
                        row["Index"] = index;
                        table.Rows.Add(row);
                        if (++count % BlockSize != 0) continue;
                        bulkCopy.WriteToServer(table);
                        table = MakeTableTblKladrStreets();
                    }
                    bulkCopy.WriteToServer(table);
                    using (SqlCommand sqlCommand = connect.CreateCommand())
                    {
                        sqlCommand.CommandText = string.Format(@" 
MERGE {0} AS t
 USING #street AS s
 ON t.District = s.District
	AND t.Region = s.Region
	AND t.Country = s.Country
	AND t.Settlement = s.Settlement
	AND t.Street = s.Street
WHEN MATCHED THEN UPDATE
	SET Name = s.Name
		,Socr = s.Socr
		,PostIndex = s.PostIndex
WHEN NOT MATCHED BY TARGET THEN	INSERT 
	(District,Region,Country,Settlement,Street,Name,Socr,PostIndex) 
	VALUES(s.District,s.Region,s.Country,s.Settlement,s.Street,s.Name,s.Socr,s.PostIndex)
WHEN NOT MATCHED BY SOURCE THEN DELETE;", TblKladrStreet);
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
        }
        /// <summary>
        /// Процесс обработки KLADR.DBF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BwKladrDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string kladrFolderPath = (string)e.Argument;
            using (SqlConnection connect = new SqlConnection(Cs))
            using (var dBaseConnection = new System.Data.Odbc.OdbcConnection())
            {
                connect.Open();
                using (SqlCommand sqlCommand = connect.CreateCommand())
                {
                    sqlCommand.CommandText = @"
CREATE TABLE #kladr (
  [District] int NOT NULL,
  [Region] int NOT NULL,
  [Country] int NOT NULL,
  [Settlement] int NOT NULL,
  [Name] varchar(40) COLLATE Cyrillic_General_CI_AS NULL,
  [Socr] varchar(10) COLLATE Cyrillic_General_CI_AS NULL,
  [PostIndex] int NOT NULL)";
                    sqlCommand.ExecuteNonQuery();
                }
                dBaseConnection.ConnectionString =
                        string.Format(DbfConnectTemplate, kladrFolderPath, DbfKladr);

                dBaseConnection.Open();
                System.Data.Odbc.OdbcCommand cmd = dBaseConnection.CreateCommand();
                cmd.CommandText = string.Format(@"SELECT * FROM {0}\{1}", kladrFolderPath, DbfKladr);
                DataTable table = MakeTableTblKladr();
                using (var reader = cmd.ExecuteReader())
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connect))
                {
                    bulkCopy.DestinationTableName = "#kladr";
                    int count = 0;
                    while (reader.Read())
                    {
                        if (BwKladr.CancellationPending) { e.Cancel = true; return; }
                        int index;
                        var code = new KladrCode(CodePageConvertor(reader["CODE"]));
                        Int32.TryParse(CodePageConvertor(reader["INDEX"]), out index);
                        var name = CodePageConvertor(reader["NAME"]);
                        var socr = CodePageConvertor(reader["SOCR"]);
                        if (code.Update != 0) continue;
                        BwKladr.ReportProgress(count + 1);
                        DataRow row = table.NewRow();
                        row["District"] = code.District;
                        row["Region"] = code.Region;
                        row["Country"] = code.Country;
                        row["Settlement"] = code.Settlement;
                        row["Name"] = name;
                        row["Socr"] = socr;
                        row["Index"] = index;
                        table.Rows.Add(row);
                        if (++count % BlockSize != 0) continue;

                        bulkCopy.WriteToServer(table);
                        table = MakeTableTblKladr();
                    }
                    bulkCopy.WriteToServer(table);
                    using (SqlCommand sqlCommand = connect.CreateCommand())
                    {
                        sqlCommand.CommandText = string.Format(@" 
 MERGE {0} AS t
 USING #kladr AS s
 ON t.District = s.District
	AND t.Region = s.Region
	AND t.Country = s.Country
	AND t.Settlement = s.Settlement
WHEN MATCHED THEN UPDATE
	SET Name = s.Name
		,Socr = s.Socr
		,PostIndex = s.PostIndex
WHEN NOT MATCHED BY TARGET THEN	INSERT 
	(District,Region,Country,Settlement,Name,Socr,PostIndex) VALUES(s.District,s.Region,s.Country,s.Settlement,s.Name,s.Socr,s.PostIndex)
WHEN NOT MATCHED BY SOURCE THEN DELETE;", TblKladrKladr);
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
        }
        /// <summary>
        /// Создание DataTable для таблицы doma, требуется для SqlBulkLoad
        /// </summary>
        /// <returns></returns>
        private static DataTable MakeTableTblKladrBuildings()
        {
            DataTable table = new DataTable(TblKladrDoma);
            DataColumn district = new DataColumn
            {
                DataType = Type.GetType("System.Int32"),
                ColumnName = "District"
            };
            table.Columns.Add(district);

            DataColumn region = new DataColumn
            {
                DataType = Type.GetType("System.Int32"),
                ColumnName = "Region"
            };
            table.Columns.Add(region);

            DataColumn country = new DataColumn
            {
                DataType = Type.GetType("System.Int32"),
                ColumnName = "Country"
            };
            table.Columns.Add(country);

            DataColumn settlement = new DataColumn
            {
                DataType = Type.GetType("System.Int32"),
                ColumnName = "Settlement"
            };
            table.Columns.Add(settlement);

            DataColumn street = new DataColumn
            {
                DataType = Type.GetType("System.Int32"),
                ColumnName = "Street"
            };
            table.Columns.Add(street);

            DataColumn building = new DataColumn
            {
                DataType = Type.GetType("System.Int32"),
                ColumnName = "Building"
            };
            table.Columns.Add(building);

            DataColumn name = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                MaxLength = 40,
                ColumnName = "Name"
            };
            table.Columns.Add(name);

            DataColumn korp = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                MaxLength = 10,
                ColumnName = "Korp"
            };
            table.Columns.Add(korp);

            DataColumn socr = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                MaxLength = 10,
                ColumnName = "Socr"
            };
            table.Columns.Add(socr);

            DataColumn index = new DataColumn
            {
                DataType = Type.GetType("System.Int32"),
                ColumnName = "Index"
            };
            table.Columns.Add(index);
            return table;
        }
        /// <summary>
        /// Создание DataTable для таблицы street, требуется для SqlBulkLoad
        /// </summary>
        /// <returns></returns>
        private static DataTable MakeTableTblKladrStreets()
        {
            DataTable table = new DataTable(TblKladrStreet);

            DataColumn district = new DataColumn
            {
                DataType = Type.GetType("System.Int32"),
                ColumnName = "District"
            };
            table.Columns.Add(district);

            DataColumn region = new DataColumn
            {
                DataType = Type.GetType("System.Int32"),
                ColumnName = "Region"
            };
            table.Columns.Add(region);

            DataColumn country = new DataColumn
            {
                DataType = Type.GetType("System.Int32"),
                ColumnName = "Country"
            };
            table.Columns.Add(country);

            DataColumn settlement = new DataColumn
            {
                DataType = Type.GetType("System.Int32"),
                ColumnName = "Settlement"
            };
            table.Columns.Add(settlement);

            DataColumn street = new DataColumn
            {
                DataType = Type.GetType("System.Int32"),
                ColumnName = "Street"
            };
            table.Columns.Add(street);

            DataColumn name = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                MaxLength = 40,
                ColumnName = "Name"
            };
            table.Columns.Add(name);


            DataColumn socr = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                MaxLength = 10,
                ColumnName = "Socr"
            };
            table.Columns.Add(socr);

            DataColumn index = new DataColumn
            {
                DataType = Type.GetType("System.Int32"),
                ColumnName = "Index"
            };
            table.Columns.Add(index);
            return table;
        }
        /// <summary>
        /// Создание DataTable для таблицы KLADR, требуется для SqlBulkLoad
        /// </summary>
        /// <returns></returns>
        private static DataTable MakeTableTblKladr()
        {
            DataTable table = new DataTable(TblKladrKladr);

            DataColumn district = new DataColumn
            {
                DataType = Type.GetType("System.Int32"),
                ColumnName = "District"
            };
            table.Columns.Add(district);

            DataColumn region = new DataColumn
            {
                DataType = Type.GetType("System.Int32"),
                ColumnName = "Region"
            };
            table.Columns.Add(region);

            DataColumn country = new DataColumn
            {
                DataType = Type.GetType("System.Int32"),
                ColumnName = "Country"
            };
            table.Columns.Add(country);

            DataColumn settlement = new DataColumn
            {
                DataType = Type.GetType("System.Int32"),
                ColumnName = "Settlement"
            };
            table.Columns.Add(settlement);

            DataColumn name = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                MaxLength = 40,
                ColumnName = "Name"
            };
            table.Columns.Add(name);

            DataColumn socr = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                MaxLength = 10,
                ColumnName = "Socr"
            };
            table.Columns.Add(socr);

            DataColumn index = new DataColumn
            {
                DataType = Type.GetType("System.Int32"),
                ColumnName = "Index"
            };
            table.Columns.Add(index);
            return table;
        }
        /// <summary>
        /// Конвертор из одной кодировки в другую, драйвер dbf может работать по разному на различных ОС
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string CodePageConvertor(object input)
        {
            return CpOutEncoding.GetString(CpInEncoding.GetBytes(input.ToString()));
        }
        /// <summary>
        /// Обновление отображения кол-ва обработаных записей в STREET.DBF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BwStreetProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            StreetBox.Text = e.ProgressPercentage.ToString();
        }

        private void BwStreetRunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("Остановлен");
                EnableStart();
            }
            else if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
                EnableStart();
            }
            else BwDoma.RunWorkerAsync(_dbfFolder);
        }

        /// <summary>
        /// блокировка кнопки stop и разблокировка кнопки start
        /// </summary>
        private void EnableStart()
        {
            LoadButton.Enabled = true;
            StopButton.Enabled = false;
        }
        /// <summary>
        /// Обработка нажатия на кнопку stop
        /// прерывание всех процессов обработки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopButtonClick(object sender, EventArgs e)
        {
            BwKladr.CancelAsync();
            BwStreet.CancelAsync();
            BwDoma.CancelAsync();
        }

        /// <summary>
        /// Обновление отображения кол-ва обработаных записей в KLADR.DBF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BwKladrProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            KladrBox.Text = e.ProgressPercentage.ToString();
        }

        private void BwKladrRunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("Остановлен");
                EnableStart();
            }
            else if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
                EnableStart();
            }
            else BwStreet.RunWorkerAsync(_dbfFolder);
        }

        /// <summary>
        /// Обновление отображения кол-ва обработаных записей в DOMA.DBF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BwDomaProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            DomaBox.Text = e.ProgressPercentage.ToString();
        }

        /// <summary>
        /// Окончание обработки всех файлов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BwDomaRunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("Остановлен");
            }
            else if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else MessageBox.Show("Всё загруженно");

            EnableStart();
        }
    }
}
