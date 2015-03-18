using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace TestKladr
{
    public partial class TestForm : Form
    {
        private int _index;
        private int? _district;
        private int? _region;
        private int? _country;
        private int? _settlement;
        private int? _street;

        public TestForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Иницилизация после загрузки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TestFormLoad(object sender, EventArgs e)
        {
            tblKladrDistrictTableAdapter.Fill(kladrDs.tblKladrDistrict, -1);
            tblKladrRegionTableAdapter.Fill(kladrDs.tblKladrRegion, -1, -1);
            tblKladrCountryTableAdapter.Fill(kladrDs.tblKladrCountry, -1, -1, -1);
            tblKladrSettlementTableAdapter.Fill(kladrDs.tblKladrSettlement, -1, -1, -1, -1);
            tblKladrStreetTableAdapter.Fill(kladrDs.tblKladrStreet, -1, -1, -1, -1, -1);
        }

        /// <summary>
        /// по введенному индексу, заполняет список субъектов РФ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IndexBoxChange(object sender, EventArgs e)
        {
            if (!int.TryParse(indexBox.Text, out _index)) return;
            tblKladrDistrictTableAdapter.Fill(kladrDs.tblKladrDistrict, _index);
        }

        /// <summary>
        /// по введенному индексу, выбраному субъекту РФ, заполняет список территориальной принадлежности
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void DistrictBoxChange(object sender, EventArgs e)
        {
            _district = (int?)comboDistrict.SelectedValue;
            tblKladrRegionTableAdapter.Fill(kladrDs.tblKladrRegion, _index, _district ?? 0);
        }

        /// <summary>
        /// по введенному индексу, выбранному субъекту РФ, выбранной террит. пр., заполняет список городов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegionBoxChange(object sender, EventArgs e)
        {
            _region = (int?)comboRegion.SelectedValue;
            tblKladrCountryTableAdapter.Fill(kladrDs.tblKladrCountry, _index, _district ?? 0, _region ?? 0);
        }

        /// <summary>
        /// по введенному индексу, выбраному субъекту РФ, выбраной террит. пр., выбраному городу, заполняет список населенных пунктов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CountryBoxChange(object sender, EventArgs e)
        {
            _country = (int?)comboCountry.SelectedValue;
            tblKladrSettlementTableAdapter.Fill(kladrDs.tblKladrSettlement, _index, _district ?? 0, _region ?? 0, _country ?? 0);
        }

        /// <summary>
        /// по введенному индексу, выбраному субъекту РФ, выбраной террит. пр., выбраному городу,
        /// выбранному населенному пункту заполняет список улиц
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettlementBoxChange(object sender, EventArgs e)
        {
            _settlement = (int?)comboSettlement.SelectedValue;
            tblKladrStreetTableAdapter.Fill(kladrDs.tblKladrStreet, _index, _district ?? 0, _region ?? 0, _country ?? 0, _settlement ?? 0);
        }
        /// <summary>
        /// по введенному индексу, выбраному субъекту РФ, выбраной террит. пр., выбраному городу,
        /// террит. принадлежности, выбранной улице, заполняет список домов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StreetBoxChange(object sender, EventArgs e)
        {
            _street = (int?)comboStreet.SelectedValue;
            int i = _index;
            int d = _district ?? 0;
            int r = _region ?? 0;
            int c = _country ?? 0;
            int set = _settlement ?? 0;
            int str = _street ?? 0;
            tblKladrDomaTableAdapter.Fill(kladrDs.tblKladrDoma, i, d, r, c, set, str);
            var buildings = kladrDs.tblKladrDoma.SelectMany(row => ParseDom(row.Field<string>("Name")));

            comboBuilding.DataSource = buildings.ToArray();
        }

        /// <summary>
        /// парсит из строки список домов
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static List<string> ParseDom(string value)
        {
            List<string> result = new List<string>();
            var vals = value.Split(',');
            foreach (var str in vals)
            {
                if (Regex.IsMatch(str, @"^\d+-\d+$"))
                {
                    var n = str.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                    int start = int.Parse(n[0]);
                    int end = int.Parse(n[1]);
                    var c = Enumerable.Range(start, end - start + 1).Select(d => d.ToString());
                    result.AddRange(c);
                }
                else if (Regex.IsMatch(str, @"^Н\(\d+-\d+\)$"))
                {
                    var n = str.Split(new[] { 'Н', '(', '-', ')' }, StringSplitOptions.RemoveEmptyEntries);
                    int start = int.Parse(n[0]);
                    int end = int.Parse(n[1]);
                    var c = Enumerable.Range(start, end - start + 1).Where(d => d % 2 == 1).Select(d => d.ToString());
                    result.AddRange(c);
                }
                else if (Regex.IsMatch(str, @"^Ч\(\d+-\d+\)$"))
                {
                    var n = str.Split(new[] { 'Ч', '(', '-', ')' }, StringSplitOptions.RemoveEmptyEntries);
                    int start = int.Parse(n[0]);
                    int end = int.Parse(n[1]);
                    var c = Enumerable.Range(start, end - start + 1).Where(d => d % 2 == 0).Select(d => d.ToString());
                    result.AddRange(c);
                }
                else if (Regex.IsMatch(str, @"^двлд\d+"))
                {
                    result.Add(str.Substring(4));
                }
                else if (Regex.IsMatch(str, @"^влд\d+"))
                {
                    result.Add(str.Substring(3));
                }
                else
                {
                    result.Add(str);
                }
            }
            return result;
        }
    }
}
