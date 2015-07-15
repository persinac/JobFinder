namespace HttpWinFrom
{
    partial class Form1
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
            this.btnURLSubmit = new System.Windows.Forms.Button();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFilterResults = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtJobTitle = new System.Windows.Forms.TextBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.url = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.viewed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.applied = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.qualified = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.clearance = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.levelOfInterest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indeedDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtYearsExp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumOfPagesToSearch = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.s = new System.Windows.Forms.Panel();
            this.btnApplyCriteria = new System.Windows.Forms.Button();
            this.cboMinLoI = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkDNRqrClearance = new System.Windows.Forms.CheckBox();
            this.chkRqrClearance = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chkQualIDK = new System.Windows.Forms.CheckBox();
            this.chkQualNo = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkQualYes = new System.Windows.Forms.CheckBox();
            this.btnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.indeedDetailsBindingSource)).BeginInit();
            this.s.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnURLSubmit
            // 
            this.btnURLSubmit.Location = new System.Drawing.Point(37, 39);
            this.btnURLSubmit.Name = "btnURLSubmit";
            this.btnURLSubmit.Size = new System.Drawing.Size(104, 23);
            this.btnURLSubmit.TabIndex = 0;
            this.btnURLSubmit.Text = "Go!";
            this.btnURLSubmit.UseVisualStyleBackColor = true;
            this.btnURLSubmit.Click += new System.EventHandler(this.btnURLSubmit_Click);
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(80, 11);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(206, 22);
            this.txtURL.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "URL:";
            // 
            // btnFilterResults
            // 
            this.btnFilterResults.Location = new System.Drawing.Point(34, 68);
            this.btnFilterResults.Name = "btnFilterResults";
            this.btnFilterResults.Size = new System.Drawing.Size(161, 32);
            this.btnFilterResults.TabIndex = 4;
            this.btnFilterResults.Text = "Filter Web Results";
            this.btnFilterResults.UseVisualStyleBackColor = true;
            this.btnFilterResults.Click += new System.EventHandler(this.btnFilterResults_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(307, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Job Title:";
            // 
            // txtJobTitle
            // 
            this.txtJobTitle.Location = new System.Drawing.Point(380, 11);
            this.txtJobTitle.Name = "txtJobTitle";
            this.txtJobTitle.Size = new System.Drawing.Size(138, 22);
            this.txtJobTitle.TabIndex = 6;
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(612, 11);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(151, 22);
            this.txtLocation.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(543, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Location:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.title,
            this.cmp,
            this.loc,
            this.country,
            this.url,
            this.viewed,
            this.applied,
            this.qualified,
            this.clearance,
            this.levelOfInterest});
            this.dataGridView1.DataSource = this.indeedDetailsBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 142);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1241, 382);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            // 
            // title
            // 
            this.title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.title.DataPropertyName = "title";
            this.title.HeaderText = "Position";
            this.title.Name = "title";
            // 
            // cmp
            // 
            this.cmp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmp.DataPropertyName = "cmp";
            this.cmp.HeaderText = "Company";
            this.cmp.Name = "cmp";
            // 
            // loc
            // 
            this.loc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.loc.DataPropertyName = "loc";
            this.loc.HeaderText = "Location";
            this.loc.Name = "loc";
            // 
            // country
            // 
            this.country.DataPropertyName = "country";
            this.country.HeaderText = "country";
            this.country.Name = "country";
            // 
            // url
            // 
            this.url.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.url.DataPropertyName = "url";
            this.url.HeaderText = "url";
            this.url.Name = "url";
            // 
            // viewed
            // 
            this.viewed.DataPropertyName = "viewed";
            this.viewed.HeaderText = "viewed";
            this.viewed.Name = "viewed";
            this.viewed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // applied
            // 
            this.applied.DataPropertyName = "applied";
            this.applied.HeaderText = "applied";
            this.applied.Name = "applied";
            this.applied.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // qualified
            // 
            this.qualified.DataPropertyName = "qualified";
            this.qualified.HeaderText = "Qualified";
            this.qualified.Items.AddRange(new object[] {
            "IDK",
            "No",
            "Yes"});
            this.qualified.Name = "qualified";
            this.qualified.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.qualified.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // clearance
            // 
            this.clearance.DataPropertyName = "clearance";
            this.clearance.HeaderText = "Clearance";
            this.clearance.Name = "clearance";
            // 
            // levelOfInterest
            // 
            this.levelOfInterest.DataPropertyName = "levelOfInterest";
            this.levelOfInterest.HeaderText = "levelOfInterest";
            this.levelOfInterest.Name = "levelOfInterest";
            // 
            // indeedDetailsBindingSource
            // 
            this.indeedDetailsBindingSource.DataSource = typeof(IndeedDetails);
            // 
            // txtYearsExp
            // 
            this.txtYearsExp.Location = new System.Drawing.Point(424, 40);
            this.txtYearsExp.Name = "txtYearsExp";
            this.txtYearsExp.Size = new System.Drawing.Size(94, 22);
            this.txtYearsExp.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(307, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Up to years exp:";
            // 
            // txtNumOfPagesToSearch
            // 
            this.txtNumOfPagesToSearch.Location = new System.Drawing.Point(713, 39);
            this.txtNumOfPagesToSearch.Name = "txtNumOfPagesToSearch";
            this.txtNumOfPagesToSearch.Size = new System.Drawing.Size(50, 22);
            this.txtNumOfPagesToSearch.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(546, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(165, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Num of pages to Search:";
            // 
            // s
            // 
            this.s.Controls.Add(this.btnReset);
            this.s.Controls.Add(this.btnApplyCriteria);
            this.s.Controls.Add(this.cboMinLoI);
            this.s.Controls.Add(this.label8);
            this.s.Controls.Add(this.chkDNRqrClearance);
            this.s.Controls.Add(this.chkRqrClearance);
            this.s.Controls.Add(this.label7);
            this.s.Controls.Add(this.chkQualIDK);
            this.s.Controls.Add(this.chkQualNo);
            this.s.Controls.Add(this.label6);
            this.s.Controls.Add(this.chkQualYes);
            this.s.Controls.Add(this.label5);
            this.s.Controls.Add(this.btnURLSubmit);
            this.s.Controls.Add(this.txtNumOfPagesToSearch);
            this.s.Controls.Add(this.txtURL);
            this.s.Controls.Add(this.label4);
            this.s.Controls.Add(this.label1);
            this.s.Controls.Add(this.txtYearsExp);
            this.s.Controls.Add(this.btnFilterResults);
            this.s.Controls.Add(this.label2);
            this.s.Controls.Add(this.label3);
            this.s.Controls.Add(this.txtJobTitle);
            this.s.Controls.Add(this.txtLocation);
            this.s.Dock = System.Windows.Forms.DockStyle.Top;
            this.s.Location = new System.Drawing.Point(0, 0);
            this.s.Name = "s";
            this.s.Size = new System.Drawing.Size(1241, 142);
            this.s.TabIndex = 14;
            // 
            // btnApplyCriteria
            // 
            this.btnApplyCriteria.Location = new System.Drawing.Point(844, 99);
            this.btnApplyCriteria.Name = "btnApplyCriteria";
            this.btnApplyCriteria.Size = new System.Drawing.Size(169, 37);
            this.btnApplyCriteria.TabIndex = 23;
            this.btnApplyCriteria.Text = "Apply Criteria";
            this.btnApplyCriteria.UseVisualStyleBackColor = true;
            this.btnApplyCriteria.Click += new System.EventHandler(this.btnApplyCriteria_Click);
            // 
            // cboMinLoI
            // 
            this.cboMinLoI.FormattingEnabled = true;
            this.cboMinLoI.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cboMinLoI.Location = new System.Drawing.Point(1019, 65);
            this.cboMinLoI.Name = "cboMinLoI";
            this.cboMinLoI.Size = new System.Drawing.Size(121, 24);
            this.cboMinLoI.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(841, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(172, 17);
            this.label8.TabIndex = 21;
            this.label8.Text = "Minimum Level of Interest:";
            // 
            // chkDNRqrClearance
            // 
            this.chkDNRqrClearance.AutoSize = true;
            this.chkDNRqrClearance.Location = new System.Drawing.Point(1052, 40);
            this.chkDNRqrClearance.Name = "chkDNRqrClearance";
            this.chkDNRqrClearance.Size = new System.Drawing.Size(48, 21);
            this.chkDNRqrClearance.TabIndex = 20;
            this.chkDNRqrClearance.Text = "No";
            this.chkDNRqrClearance.UseVisualStyleBackColor = true;
            // 
            // chkRqrClearance
            // 
            this.chkRqrClearance.AutoSize = true;
            this.chkRqrClearance.Location = new System.Drawing.Point(992, 39);
            this.chkRqrClearance.Name = "chkRqrClearance";
            this.chkRqrClearance.Size = new System.Drawing.Size(54, 21);
            this.chkRqrClearance.TabIndex = 19;
            this.chkRqrClearance.Text = "Yes";
            this.chkRqrClearance.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(841, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(141, 17);
            this.label7.TabIndex = 18;
            this.label7.Text = "Requires Clearance?";
            // 
            // chkQualIDK
            // 
            this.chkQualIDK.AutoSize = true;
            this.chkQualIDK.Location = new System.Drawing.Point(1030, 10);
            this.chkQualIDK.Name = "chkQualIDK";
            this.chkQualIDK.Size = new System.Drawing.Size(52, 21);
            this.chkQualIDK.TabIndex = 17;
            this.chkQualIDK.Text = "IDK";
            this.chkQualIDK.UseVisualStyleBackColor = true;
            // 
            // chkQualNo
            // 
            this.chkQualNo.AutoSize = true;
            this.chkQualNo.Location = new System.Drawing.Point(975, 10);
            this.chkQualNo.Name = "chkQualNo";
            this.chkQualNo.Size = new System.Drawing.Size(48, 21);
            this.chkQualNo.TabIndex = 16;
            this.chkQualNo.Text = "No";
            this.chkQualNo.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(841, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "Qualified:";
            // 
            // chkQualYes
            // 
            this.chkQualYes.AutoSize = true;
            this.chkQualYes.Location = new System.Drawing.Point(915, 10);
            this.chkQualYes.Name = "chkQualYes";
            this.chkQualYes.Size = new System.Drawing.Size(54, 21);
            this.chkQualYes.TabIndex = 14;
            this.chkQualYes.Text = "Yes";
            this.chkQualYes.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(1019, 99);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(144, 37);
            this.btnReset.TabIndex = 24;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 524);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.s);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.indeedDetailsBindingSource)).EndInit();
            this.s.ResumeLayout(false);
            this.s.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnURLSubmit;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFilterResults;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtJobTitle;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource indeedDetailsBindingSource;
        private System.Windows.Forms.TextBox txtYearsExp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNumOfPagesToSearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel s;
        private System.Windows.Forms.DataGridViewTextBoxColumn title;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmp;
        private System.Windows.Forms.DataGridViewTextBoxColumn loc;
        private System.Windows.Forms.DataGridViewTextBoxColumn country;
        private System.Windows.Forms.DataGridViewTextBoxColumn url;
        private System.Windows.Forms.DataGridViewCheckBoxColumn viewed;
        private System.Windows.Forms.DataGridViewCheckBoxColumn applied;
        private System.Windows.Forms.DataGridViewComboBoxColumn qualified;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clearance;
        private System.Windows.Forms.DataGridViewTextBoxColumn levelOfInterest;
        private System.Windows.Forms.CheckBox chkQualYes;
        private System.Windows.Forms.CheckBox chkQualIDK;
        private System.Windows.Forms.CheckBox chkQualNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboMinLoI;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkDNRqrClearance;
        private System.Windows.Forms.CheckBox chkRqrClearance;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnApplyCriteria;
        private System.Windows.Forms.Button btnReset;
    }
}

