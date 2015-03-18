namespace KLADR
{
    partial class MainForm
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
            this.LoadButton = new System.Windows.Forms.Button();
            this.KladrBox = new System.Windows.Forms.TextBox();
            this.StreetBox = new System.Windows.Forms.TextBox();
            this.DomaBox = new System.Windows.Forms.TextBox();
            this.BwStreet = new System.ComponentModel.BackgroundWorker();
            this.BwKladr = new System.ComponentModel.BackgroundWorker();
            this.BwDoma = new System.ComponentModel.BackgroundWorker();
            this.StopButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(12, 12);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(75, 23);
            this.LoadButton.TabIndex = 0;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButtonClick);
            // 
            // KladrBox
            // 
            this.KladrBox.Location = new System.Drawing.Point(166, 50);
            this.KladrBox.Name = "KladrBox";
            this.KladrBox.ReadOnly = true;
            this.KladrBox.Size = new System.Drawing.Size(100, 22);
            this.KladrBox.TabIndex = 1;
            // 
            // StreetBox
            // 
            this.StreetBox.Location = new System.Drawing.Point(166, 79);
            this.StreetBox.Name = "StreetBox";
            this.StreetBox.ReadOnly = true;
            this.StreetBox.Size = new System.Drawing.Size(100, 22);
            this.StreetBox.TabIndex = 2;
            // 
            // DomaBox
            // 
            this.DomaBox.Location = new System.Drawing.Point(166, 107);
            this.DomaBox.Name = "DomaBox";
            this.DomaBox.ReadOnly = true;
            this.DomaBox.Size = new System.Drawing.Size(100, 22);
            this.DomaBox.TabIndex = 3;
            // 
            // BwStreet
            // 
            this.BwStreet.WorkerReportsProgress = true;
            this.BwStreet.WorkerSupportsCancellation = true;
            this.BwStreet.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BwStreetDoWork);
            this.BwStreet.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BwStreetProgressChanged);
            this.BwStreet.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BwStreetRunWorkerCompleted);
            // 
            // BwKladr
            // 
            this.BwKladr.WorkerReportsProgress = true;
            this.BwKladr.WorkerSupportsCancellation = true;
            this.BwKladr.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BwKladrDoWork);
            this.BwKladr.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BwKladrProgressChanged);
            this.BwKladr.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BwKladrRunWorkerCompleted);
            // 
            // BwDoma
            // 
            this.BwDoma.WorkerReportsProgress = true;
            this.BwDoma.WorkerSupportsCancellation = true;
            this.BwDoma.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BwDomaDoWork);
            this.BwDoma.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BwDomaProgressChanged);
            this.BwDoma.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BwDomaRunWorkerCompleted);
            // 
            // StopButton
            // 
            this.StopButton.Enabled = false;
            this.StopButton.Location = new System.Drawing.Point(93, 12);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 23);
            this.StopButton.TabIndex = 4;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButtonClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "KLADR.DBF";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "STREET.DBF";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "DOMA.DBF";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 144);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.DomaBox);
            this.Controls.Add(this.StreetBox);
            this.Controls.Add(this.KladrBox);
            this.Controls.Add(this.LoadButton);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(330, 189);
            this.Name = "MainForm";
            this.Text = "KLADR Loader";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.TextBox KladrBox;
        private System.Windows.Forms.TextBox StreetBox;
        private System.Windows.Forms.TextBox DomaBox;
        private System.ComponentModel.BackgroundWorker BwStreet;
        private System.ComponentModel.BackgroundWorker BwKladr;
        private System.ComponentModel.BackgroundWorker BwDoma;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

