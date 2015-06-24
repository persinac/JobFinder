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
            this.url = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.viewed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.applied = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.levelOfInterest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtYearsExp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmpDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indeedDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtNumOfPagesToSearch = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.indeedDetailsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnURLSubmit
            // 
            this.btnURLSubmit.Location = new System.Drawing.Point(15, 40);
            this.btnURLSubmit.Name = "btnURLSubmit";
            this.btnURLSubmit.Size = new System.Drawing.Size(104, 23);
            this.btnURLSubmit.TabIndex = 0;
            this.btnURLSubmit.Text = "Go!";
            this.btnURLSubmit.UseVisualStyleBackColor = true;
            this.btnURLSubmit.Click += new System.EventHandler(this.btnURLSubmit_Click);
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(58, 12);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(206, 22);
            this.txtURL.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "URL:";
            // 
            // btnFilterResults
            // 
            this.btnFilterResults.Location = new System.Drawing.Point(12, 69);
            this.btnFilterResults.Name = "btnFilterResults";
            this.btnFilterResults.Size = new System.Drawing.Size(161, 32);
            this.btnFilterResults.TabIndex = 4;
            this.btnFilterResults.Text = "Filter Results";
            this.btnFilterResults.UseVisualStyleBackColor = true;
            this.btnFilterResults.Click += new System.EventHandler(this.btnFilterResults_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(285, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Job Title:";
            // 
            // txtJobTitle
            // 
            this.txtJobTitle.Location = new System.Drawing.Point(358, 12);
            this.txtJobTitle.Name = "txtJobTitle";
            this.txtJobTitle.Size = new System.Drawing.Size(138, 22);
            this.txtJobTitle.TabIndex = 6;
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(590, 12);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(151, 22);
            this.txtLocation.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(521, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Location:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.titleDataGridViewTextBoxColumn,
            this.cmpDataGridViewTextBoxColumn,
            this.locDataGridViewTextBoxColumn,
            this.countryDataGridViewTextBoxColumn,
            this.url,
            this.viewed,
            this.applied,
            this.levelOfInterest});
            this.dataGridView1.DataSource = this.indeedDetailsBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 133);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(902, 391);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
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
            // 
            // applied
            // 
            this.applied.DataPropertyName = "applied";
            this.applied.HeaderText = "applied";
            this.applied.Name = "applied";
            // 
            // levelOfInterest
            // 
            this.levelOfInterest.DataPropertyName = "levelOfInterest";
            this.levelOfInterest.HeaderText = "levelOfInterest";
            this.levelOfInterest.Name = "levelOfInterest";
            // 
            // txtYearsExp
            // 
            this.txtYearsExp.Location = new System.Drawing.Point(402, 41);
            this.txtYearsExp.Name = "txtYearsExp";
            this.txtYearsExp.Size = new System.Drawing.Size(94, 22);
            this.txtYearsExp.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(285, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Up to years exp:";
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "Position";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            // 
            // cmpDataGridViewTextBoxColumn
            // 
            this.cmpDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmpDataGridViewTextBoxColumn.DataPropertyName = "cmp";
            this.cmpDataGridViewTextBoxColumn.HeaderText = "Company";
            this.cmpDataGridViewTextBoxColumn.Name = "cmpDataGridViewTextBoxColumn";
            // 
            // locDataGridViewTextBoxColumn
            // 
            this.locDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.locDataGridViewTextBoxColumn.DataPropertyName = "loc";
            this.locDataGridViewTextBoxColumn.HeaderText = "Location";
            this.locDataGridViewTextBoxColumn.Name = "locDataGridViewTextBoxColumn";
            // 
            // countryDataGridViewTextBoxColumn
            // 
            this.countryDataGridViewTextBoxColumn.DataPropertyName = "country";
            this.countryDataGridViewTextBoxColumn.HeaderText = "country";
            this.countryDataGridViewTextBoxColumn.Name = "countryDataGridViewTextBoxColumn";
            // 
            // indeedDetailsBindingSource
            // 
            this.indeedDetailsBindingSource.DataSource = typeof(IndeedDetails);
            // 
            // txtNumOfPagesToSearch
            // 
            this.txtNumOfPagesToSearch.Location = new System.Drawing.Point(691, 40);
            this.txtNumOfPagesToSearch.Name = "txtNumOfPagesToSearch";
            this.txtNumOfPagesToSearch.Size = new System.Drawing.Size(50, 22);
            this.txtNumOfPagesToSearch.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(524, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(165, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Num of pages to Search:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 524);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNumOfPagesToSearch);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtYearsExp);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.txtJobTitle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnFilterResults);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.btnURLSubmit);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.indeedDetailsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmpDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn url;
        private System.Windows.Forms.DataGridViewCheckBoxColumn viewed;
        private System.Windows.Forms.DataGridViewCheckBoxColumn applied;
        private System.Windows.Forms.DataGridViewTextBoxColumn levelOfInterest;
        private System.Windows.Forms.TextBox txtYearsExp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNumOfPagesToSearch;
        private System.Windows.Forms.Label label5;
    }
}

