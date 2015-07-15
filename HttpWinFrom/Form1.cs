using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace HttpWinFrom
{
    public partial class Form1 : Form
    {
        int start = 10;
        int pagesToSearch = 1;
        string main_url = "";
        MyWebRequest mwr;
        List<IndeedDetails> data;
        List<IndeedDetails> jobsToKeep;
        List<IndeedDetails> filtered;
        BindingList<IndeedDetails> mainJobList;
        Utility util;
        BackgroundWorker worker;
        private bool _isRunning;
        private GridSortBy sortKeeper;

        public Form1()
        {
            InitializeComponent();
            util = new Utility();
            mainJobList = new BindingList<IndeedDetails>();
            filtered = new List<IndeedDetails>();
            sortKeeper = new GridSortBy();
            //worker stuff
            worker = new BackgroundWorker();

            worker.DoWork += BackgroundWorkerDoWork;
            worker.RunWorkerCompleted +=
               BackgroundWorkerRunWorkerCompleted;
            
            string file_name = @"C:\Users\apersinger\Documents\Misc\jsonjobs.txt";
            string file_contents = util.OpenFile(file_name);
            if(file_contents.Length > 0) {
                data = util.DeserializeString(file_contents);
                mainJobList = new BindingList<IndeedDetails>(data);
                dataGridView1.DataSource = mainJobList;
            }
            
            txtURL.Text = "www.indeed.com";
            txtLocation.Text = "california";
            txtJobTitle.Text = "software";
            
            btnFilterResults.Enabled = false;
        }

        

        private void btnURLSubmit_Click(object sender, EventArgs e)
        {
            string url = "";
            pagesToSearch = Int32.Parse(txtNumOfPagesToSearch.Text.ToString());
            pagesToSearch *= 10;
            this.start = 10;
            dataGridView1.DataSource = mainJobList;
            data = new List<IndeedDetails>();
            jobsToKeep = new List<IndeedDetails>();
                        
            if (txtURL.Text.ToString().IndexOf("www.") == 0)
            {
                url = "http://" + txtURL.Text.ToString();
            }

            url += "/jobs?q=" + txtJobTitle.Text.ToString() + "&l=" + txtLocation.Text.ToString();
            this.main_url = url;

            mwr = new MyWebRequest(url);

            string temp = mwr.GetResponse();

            btnFilterResults.Enabled = true;
            
        }

        private void btnFilterResults_Click(object sender, EventArgs e)
        {
            //worker.RunWorkerAsync();
            FilterMe();
        }

        private void FilterMe()
        {
            /*
             * Need main list of jobs, and set that grid data source to that
             * */
            string new_page = "";
            data = mwr.GetListOfJobs();
            List<String> listOfStrings_exp = new List<String>();
            List<int> jobsToRemove = new List<int>();
            for (int i = 0; i < data.Count; i++)
            {
                new_page = mwr.GetSpecificResponse(txtURL.Text.ToString() + "/rc/clk?jk=" + data[i].jk);
                data[i].url = txtURL.Text.ToString() + "/rc/clk?jk=" + data[i].jk;
                
                if (util.FilterExperience(HtmlRemoval.StripTagsRegex(new_page), Int32.Parse(txtYearsExp.Text.ToString()), data[i]) == false)
                {
                    jobsToRemove.Add(i);
                }
            }
            jobsToKeep = util.TransferJobsToKeep(data, jobsToRemove);
            //add jobsToKeep to main list
            AddToMainList(jobsToKeep);
            mwr = new MyWebRequest(this.main_url + "&start=" + this.start);
            string temp = mwr.GetResponse();
            
            if (this.start == pagesToSearch)
            {
                FinishUp();
            }
            else 
            {
                this.start += 10;
                dataGridView1.Refresh();
                FilterMe();
            }
           
        }

        private void FinishUp() {
            dataGridView1.DataSource = this.mainJobList;
            var json = util.SerializeObject(this.mainJobList);
            util.WriteToFile(json.ToString());
            btnFilterResults.Enabled = false;
            Console.WriteLine("fin");
        }

        private void AddToMainList(List<IndeedDetails> newListOfJobs)
        {
            foreach (var new_jk in newListOfJobs)
            {
                bool already_exists = false;
                foreach (var existing_jk in mainJobList)
                {
                    if (new_jk.jk == existing_jk.jk)
                    {
                        already_exists = true;
                    }
                }
                if(already_exists != true) {
                    this.mainJobList.Add(new_jk);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string text = "";
            if (e.RowIndex > -1)
            {
                text = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (dataGridView1.Columns[e.ColumnIndex].Name == "url")
                {
                    Process.Start(@"" + text);
                }

                //if user clicks on chk box or something AFTER they filter...
                if (filtered.Count > 0)
                {
                    if (dataGridView1.Columns[e.ColumnIndex].Name == "viewed")
                    {
                        bool value = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        if(value == true) { value = false;  }
                        else {  value = true; }
                        filtered[e.RowIndex].viewed = value;
                        
                    }
                    Utility.UpdateMainList(filtered[e.RowIndex], ref this.mainJobList);
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var json = util.SerializeObject(this.mainJobList);
            if (json != null) { util.WriteToFile(json.ToString()); }
        }

        void BackgroundWorkerDoWork(object sender,
                    DoWorkEventArgs e)
        {
            _isRunning = true;
            FilterMe();
        }

        private void BackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _isRunning = false;
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn newColumn = dataGridView1.Columns[e.ColumnIndex];
            List<IndeedDetails> ordered = new List<IndeedDetails>();
            
            bool descend = false;

            if (newColumn.Name == "levelOfInterest")
            {

                ordered = sortKeeper.levelOfInterest ? (from element in this.mainJobList
                               orderby element.levelOfInterest descending
                               select element).ToList() : (from element in this.mainJobList
                               orderby element.levelOfInterest
                               select element).ToList();
                sortKeeper.levelOfInterest = sortKeeper.levelOfInterest ? false : true;
            }
            else if (newColumn.Name == "applied")
            {

                ordered = sortKeeper.applied ? (from element in this.mainJobList
                                                orderby element.applied descending
                                                        select element).ToList() : (from element in this.mainJobList
                                                                                    orderby element.applied
                                                                                    select element).ToList();
                sortKeeper.applied = sortKeeper.applied ? false : true;
            }
            else if (newColumn.Name == "viewed")
            {
                ordered = sortKeeper.viewed ? (from element in this.mainJobList
                                               orderby element.viewed descending
                                                select element).ToList() : (from element in this.mainJobList
                                                                            orderby element.viewed
                                                                            select element).ToList();
                sortKeeper.viewed = sortKeeper.viewed ? false : true;
            }
            else if (newColumn.Name == "country")
            {
                ordered = sortKeeper.country ? (from element in this.mainJobList
                                                orderby element.country descending
                                               select element).ToList() : (from element in this.mainJobList
                                                                           orderby element.country
                                                                           select element).ToList();
                sortKeeper.country = sortKeeper.country ? false : true;
            }
            else if (newColumn.Name == "loc")
            {
                ordered = sortKeeper.loc ? (from element in this.mainJobList
                                            orderby element.loc descending
                                                select element).ToList() : (from element in this.mainJobList
                                                                            orderby element.loc
                                                                            select element).ToList();
                sortKeeper.loc = sortKeeper.loc ? false : true;
            }
            else if (newColumn.Name == "cmp")
            {
                ordered = sortKeeper.cmp ? (from element in this.mainJobList
                                            orderby element.cmp descending
                                            select element).ToList() : (from element in this.mainJobList
                                                                        orderby element.cmp
                                                                        select element).ToList();
                sortKeeper.cmp = sortKeeper.cmp ? false : true;
            }
            else if (newColumn.Name == "title")
            {
                ordered = sortKeeper.title ? (from element in this.mainJobList
                                              orderby element.title descending
                                            select element).ToList() : (from element in this.mainJobList
                                                                        orderby element.title
                                                                        select element).ToList();
                sortKeeper.title = sortKeeper.title ? false : true;
            }
            else if (newColumn.Name == "qualified")
            {
                ordered = sortKeeper.qualified ? (from element in this.mainJobList
                                              orderby element.qualified descending
                                              select element).ToList() : (from element in this.mainJobList
                                                                          orderby element.qualified
                                                                          select element).ToList();
                sortKeeper.qualified = sortKeeper.qualified ? false : true;
            }
            else if (newColumn.Name == "clearance")
            {
                ordered = sortKeeper.clearance ? (from element in this.mainJobList
                                                  orderby element.clearance descending
                                              select element).ToList() : (from element in this.mainJobList
                                                                          orderby element.clearance
                                                                          select element).ToList();
                sortKeeper.clearance = sortKeeper.clearance ? false : true;
            }
            if (ordered.Count > 0) {
                dataGridView1.DataSource = null;
                this.mainJobList = new BindingList<IndeedDetails>(ordered);
                dataGridView1.DataSource = this.mainJobList;
            }
            dataGridView1.Refresh();
        }

        private void btnApplyCriteria_Click(object sender, EventArgs e)
        {

            if (this.mainJobList.Count > 0)
            {
                //qualified for:
                if(chkQualYes.Checked == true || 
                    chkQualNo.Checked == true ||
                    chkQualIDK.Checked == true)
                {
                    filtered = (from element in this.mainJobList
                                where element.qualified == "Yes"
                                select element).ToList();
                    
                }
                //requires clearance

                //level of interest
            }

            if (filtered.Count > 0)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = filtered;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            //reset the chk boxes
            chkQualYes.Checked = false;
            chkQualNo.Checked = false;
            chkQualIDK.Checked = false;
            chkDNRqrClearance.Checked = false;
            chkRqrClearance.Checked = false;

            //reset level of interest
            cboMinLoI.SelectedIndex = 0;

            //reset grid datasource
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = this.mainJobList;

            //reset filtered
            filtered = new List<IndeedDetails>();
        }
    }

    public class GridSortBy
    {
        public bool cmp { set; get; }
        public bool country { set; get; }
        public bool loc { set; get; }
        public bool title { set; get; }
        public bool viewed { set; get; }
        public bool applied { set; get; }
        public bool levelOfInterest { set; get; }
        public bool qualified { set; get; }
        public bool clearance { set; get; }

        public GridSortBy()
        {
            cmp = false;
            country = false;
            loc = false;
            title = false;
            viewed = false;
            applied = false;
            levelOfInterest = false;
            qualified = false;
            clearance = false;
        } 
    }
}
