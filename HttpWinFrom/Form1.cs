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
        string main_url = "";
        MyWebRequest mwr;
        List<IndeedDetails> data;
        List<IndeedDetails> jobsToKeep;
        BindingList<IndeedDetails> mainJobList;

        public Form1()
        {
            InitializeComponent();
            mainJobList = new BindingList<IndeedDetails>();
            string file_name = @"C:\Users\apersinger\Documents\Misc\jsonjobs.txt";
            if(System.IO.File.Exists(file_name) == true) {
                System.IO.StreamReader objReader;
                objReader = new System.IO.StreamReader(file_name);
                string retVal = objReader.ReadToEnd();
                var serializer = new JavaScriptSerializer();
                data = serializer.Deserialize<List<IndeedDetails>>(retVal);
                mainJobList = new BindingList<IndeedDetails>(data);
                dataGridView1.DataSource = mainJobList;
                dataGridView1.Refresh();
            }
            
            txtURL.Text = "www.indeed.com";
            txtLocation.Text = "california";
            txtJobTitle.Text = "software";
            btnFilterResults.Enabled = false;
        }

        private void btnURLSubmit_Click(object sender, EventArgs e)
        {
            string url = "";

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
            Utility util = new Utility();
            data = mwr.GetListOfJobs();
            List<String> listOfStrings_exp = new List<String>();
            List<int> jobsToRemove = new List<int>();
            for (int i = 0; i < data.Count; i++)
            {
                bool shouldKeep = false;
                string new_res = mwr.GetSpecificResponse(txtURL.Text.ToString() + "/rc/clk?jk=" + data[i].jk);
                data[i].url = txtURL.Text.ToString() + "/rc/clk?jk=" + data[i].jk;
                listOfStrings_exp = util.FilterExperience(new_res);
                //within those strings, find years of experience
                for (int j = 0; j < listOfStrings_exp.Count; j++)
                {
                    if (listOfStrings_exp[j].IndexOf("0") > -1 ||
                        listOfStrings_exp[j].IndexOf("1") > -1 ||
                        listOfStrings_exp[j].IndexOf("2") > -1)
                    {
                        //keep
                        shouldKeep = true;
                    }
                    else if (listOfStrings_exp[j].IndexOf("3") > -1 ||
                      listOfStrings_exp[j].IndexOf("4") > -1 ||
                      listOfStrings_exp[j].IndexOf("5") > -1 ||
                        listOfStrings_exp[j].IndexOf("6") > -1 ||
                        listOfStrings_exp[j].IndexOf("7") > -1 ||
                        listOfStrings_exp[j].IndexOf("8") > -1 ||
                        listOfStrings_exp[j].IndexOf("9") > -1)
                    {
                        shouldKeep = false;
                        break;
                    }
                }
                if (shouldKeep == false)
                {
                    jobsToRemove.Add(i);
                }
            }
            jobsToKeep = util.TransferJobsToKeep(data, jobsToRemove);
            //add jobsToKeep to main list
            AddToMainList(jobsToKeep);
            mwr = new MyWebRequest(this.main_url + "&start=" + this.start);
            string temp = mwr.GetResponse();
            if (this.start == 50)
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
            Utility util = new Utility();
            var json = new JavaScriptSerializer().Serialize(this.mainJobList);
            util.WriteToFile(json.ToString());
            Console.WriteLine("fin");
        }

        private void AddToMainList(List<IndeedDetails> newListOfJobs)
        {
            for (int i = 0; i < newListOfJobs.Count; i++ )
            {
                mainJobList.Add(newListOfJobs[i]);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string text = "";
            text = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            Process.Start(@"" + text);
        }
    }
}
