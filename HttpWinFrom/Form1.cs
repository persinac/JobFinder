using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
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
        BindingList<IndeedDetails> mainJobList;
        Utility util;

        public Form1()
        {
            InitializeComponent();
            util = new Utility();
            mainJobList = new BindingList<IndeedDetails>();
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
                if (util.FilterExperience(new_page, Int32.Parse(txtYearsExp.Text.ToString())) == false)
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
                    mainJobList.Add(new_jk);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string text = "";
            text = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            if(dataGridView1.Columns[e.ColumnIndex].Name == "url") {
                Process.Start(@"" + text);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var json = util.SerializeObject(this.mainJobList);
            if (json != null) { util.WriteToFile(json.ToString()); }
        }
    }
}
