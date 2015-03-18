namespace TestKladr
{
    partial class TestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.indexBox = new System.Windows.Forms.TextBox();
            this.comboDistrict = new System.Windows.Forms.ComboBox();
            this.tblKladrDistrictBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kladrDs = new TestKladr.KladrDs();
            this.comboRegion = new System.Windows.Forms.ComboBox();
            this.tblKladrRegionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblKladrDistrictTableAdapter = new TestKladr.KladrDsTableAdapters.tblKladrDistrictTableAdapter();
            this.tblKladrRegionTableAdapter = new TestKladr.KladrDsTableAdapters.tblKladrRegionTableAdapter();
            this.comboCountry = new System.Windows.Forms.ComboBox();
            this.tblKladrCountryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblKladrCountryTableAdapter = new TestKladr.KladrDsTableAdapters.tblKladrCountryTableAdapter();
            this.comboSettlement = new System.Windows.Forms.ComboBox();
            this.tblKladrSettlementBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblKladrSettlementTableAdapter = new TestKladr.KladrDsTableAdapters.tblKladrSettlementTableAdapter();
            this.comboStreet = new System.Windows.Forms.ComboBox();
            this.tblKladrStreetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblKladrStreetTableAdapter = new TestKladr.KladrDsTableAdapters.tblKladrStreetTableAdapter();
            this.comboBuilding = new System.Windows.Forms.ComboBox();
            this.tblKladrDomaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tblKladrDomaTableAdapter = new TestKladr.KladrDsTableAdapters.tblKladrDomaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tblKladrDistrictBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kladrDs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblKladrRegionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblKladrCountryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblKladrSettlementBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblKladrStreetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblKladrDomaBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // indexBox
            // 
            this.indexBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.indexBox.Location = new System.Drawing.Point(177, 6);
            this.indexBox.Name = "indexBox";
            this.indexBox.Size = new System.Drawing.Size(193, 22);
            this.indexBox.TabIndex = 0;
            this.indexBox.TextChanged += new System.EventHandler(this.IndexBoxChange);
            // 
            // comboDistrict
            // 
            this.comboDistrict.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboDistrict.DataSource = this.tblKladrDistrictBindingSource;
            this.comboDistrict.DisplayMember = "Name";
            this.comboDistrict.FormattingEnabled = true;
            this.comboDistrict.ItemHeight = 16;
            this.comboDistrict.Location = new System.Drawing.Point(176, 34);
            this.comboDistrict.Name = "comboDistrict";
            this.comboDistrict.Size = new System.Drawing.Size(194, 24);
            this.comboDistrict.TabIndex = 3;
            this.comboDistrict.ValueMember = "District";
            this.comboDistrict.SelectedIndexChanged += new System.EventHandler(this.DistrictBoxChange);
            this.comboDistrict.Leave += new System.EventHandler(this.DistrictBoxChange);
            // 
            // tblKladrDistrictBindingSource
            // 
            this.tblKladrDistrictBindingSource.DataMember = "tblKladrDistrict";
            this.tblKladrDistrictBindingSource.DataSource = this.kladrDs;
            // 
            // kladrDs
            // 
            this.kladrDs.DataSetName = "KladrDs";
            this.kladrDs.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // comboRegion
            // 
            this.comboRegion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboRegion.DataSource = this.tblKladrRegionBindingSource;
            this.comboRegion.DisplayMember = "Name";
            this.comboRegion.FormattingEnabled = true;
            this.comboRegion.Location = new System.Drawing.Point(176, 64);
            this.comboRegion.Name = "comboRegion";
            this.comboRegion.Size = new System.Drawing.Size(194, 24);
            this.comboRegion.TabIndex = 4;
            this.comboRegion.ValueMember = "Region";
            this.comboRegion.SelectedIndexChanged += new System.EventHandler(this.RegionBoxChange);
            this.comboRegion.Leave += new System.EventHandler(this.RegionBoxChange);
            // 
            // tblKladrRegionBindingSource
            // 
            this.tblKladrRegionBindingSource.DataMember = "tblKladrRegion";
            this.tblKladrRegionBindingSource.DataSource = this.kladrDs;
            // 
            // tblKladrDistrictTableAdapter
            // 
            this.tblKladrDistrictTableAdapter.ClearBeforeFill = true;
            // 
            // tblKladrRegionTableAdapter
            // 
            this.tblKladrRegionTableAdapter.ClearBeforeFill = true;
            // 
            // comboCountry
            // 
            this.comboCountry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboCountry.DataSource = this.tblKladrCountryBindingSource;
            this.comboCountry.DisplayMember = "Name";
            this.comboCountry.FormattingEnabled = true;
            this.comboCountry.Location = new System.Drawing.Point(176, 94);
            this.comboCountry.Name = "comboCountry";
            this.comboCountry.Size = new System.Drawing.Size(194, 24);
            this.comboCountry.TabIndex = 5;
            this.comboCountry.ValueMember = "Country";
            this.comboCountry.SelectedIndexChanged += new System.EventHandler(this.CountryBoxChange);
            this.comboCountry.Leave += new System.EventHandler(this.CountryBoxChange);
            // 
            // tblKladrCountryBindingSource
            // 
            this.tblKladrCountryBindingSource.DataMember = "tblKladrCountry";
            this.tblKladrCountryBindingSource.DataSource = this.kladrDs;
            // 
            // tblKladrCountryTableAdapter
            // 
            this.tblKladrCountryTableAdapter.ClearBeforeFill = true;
            // 
            // comboSettlement
            // 
            this.comboSettlement.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboSettlement.DataSource = this.tblKladrSettlementBindingSource;
            this.comboSettlement.DisplayMember = "Name";
            this.comboSettlement.IntegralHeight = false;
            this.comboSettlement.Location = new System.Drawing.Point(177, 124);
            this.comboSettlement.Name = "comboSettlement";
            this.comboSettlement.Size = new System.Drawing.Size(193, 24);
            this.comboSettlement.TabIndex = 6;
            this.comboSettlement.ValueMember = "Settlement";
            this.comboSettlement.SelectedIndexChanged += new System.EventHandler(this.SettlementBoxChange);
            this.comboSettlement.Leave += new System.EventHandler(this.SettlementBoxChange);
            // 
            // tblKladrSettlementBindingSource
            // 
            this.tblKladrSettlementBindingSource.DataMember = "tblKladrSettlement";
            this.tblKladrSettlementBindingSource.DataSource = this.kladrDs;
            // 
            // tblKladrSettlementTableAdapter
            // 
            this.tblKladrSettlementTableAdapter.ClearBeforeFill = true;
            // 
            // comboStreet
            // 
            this.comboStreet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboStreet.DataSource = this.tblKladrStreetBindingSource;
            this.comboStreet.DisplayMember = "Name";
            this.comboStreet.IntegralHeight = false;
            this.comboStreet.Location = new System.Drawing.Point(177, 154);
            this.comboStreet.Name = "comboStreet";
            this.comboStreet.Size = new System.Drawing.Size(193, 24);
            this.comboStreet.TabIndex = 7;
            this.comboStreet.ValueMember = "Street";
            this.comboStreet.SelectedIndexChanged += new System.EventHandler(this.StreetBoxChange);
            this.comboStreet.Leave += new System.EventHandler(this.StreetBoxChange);
            // 
            // tblKladrStreetBindingSource
            // 
            this.tblKladrStreetBindingSource.DataMember = "tblKladrStreet";
            this.tblKladrStreetBindingSource.DataSource = this.kladrDs;
            // 
            // tblKladrStreetTableAdapter
            // 
            this.tblKladrStreetTableAdapter.ClearBeforeFill = true;
            // 
            // comboBuilding
            // 
            this.comboBuilding.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBuilding.IntegralHeight = false;
            this.comboBuilding.Items.AddRange(new object[] {
            "1"});
            this.comboBuilding.Location = new System.Drawing.Point(177, 184);
            this.comboBuilding.Name = "comboBuilding";
            this.comboBuilding.Size = new System.Drawing.Size(193, 24);
            this.comboBuilding.TabIndex = 8;
            // 
            // tblKladrDomaBindingSource
            // 
            this.tblKladrDomaBindingSource.DataMember = "tblKladrDoma";
            this.tblKladrDomaBindingSource.DataSource = this.kladrDs;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Индекс";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Субъект РФ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Террит. пр.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Город";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Нас. пункт";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "Улица";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 184);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "Дом";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.indexBox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.comboDistrict);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.comboRegion);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.comboCountry);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboSettlement);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboStreet);
            this.panel1.Controls.Add(this.comboBuilding);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(391, 230);
            this.panel1.TabIndex = 16;
            // 
            // tblKladrDomaTableAdapter
            // 
            this.tblKladrDomaTableAdapter.ClearBeforeFill = true;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 230);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(400, 275);
            this.Name = "TestForm";
            this.Text = "Кладр тест";
            this.Load += new System.EventHandler(this.TestFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.tblKladrDistrictBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kladrDs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblKladrRegionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblKladrCountryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblKladrSettlementBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblKladrStreetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblKladrDomaBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox indexBox;
        private System.Windows.Forms.ComboBox comboDistrict;
        private KladrDsTableAdapters.tblKladrRegionTableAdapter tblKladrTableAdapter;
        private System.Windows.Forms.ComboBox comboRegion;
        private System.Windows.Forms.BindingSource tblKladrDistrictBindingSource;
        private KladrDs kladrDs;
        private System.Windows.Forms.BindingSource tblKladrRegionBindingSource;
        private KladrDsTableAdapters.tblKladrDistrictTableAdapter tblKladrDistrictTableAdapter;
        private KladrDsTableAdapters.tblKladrRegionTableAdapter tblKladrRegionTableAdapter;
        private System.Windows.Forms.ComboBox comboCountry;
        private System.Windows.Forms.BindingSource tblKladrCountryBindingSource;
        private KladrDsTableAdapters.tblKladrCountryTableAdapter tblKladrCountryTableAdapter;
        private System.Windows.Forms.ComboBox comboSettlement;
        private System.Windows.Forms.BindingSource tblKladrSettlementBindingSource;
        private KladrDsTableAdapters.tblKladrSettlementTableAdapter tblKladrSettlementTableAdapter;
        private System.Windows.Forms.ComboBox comboStreet;
        private System.Windows.Forms.BindingSource tblKladrStreetBindingSource;
        private KladrDsTableAdapters.tblKladrStreetTableAdapter tblKladrStreetTableAdapter;
        private System.Windows.Forms.ComboBox comboBuilding;
        private System.Windows.Forms.BindingSource tblKladrDomaBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private KladrDsTableAdapters.tblKladrDomaTableAdapter tblKladrDomaTableAdapter;
    }
}

