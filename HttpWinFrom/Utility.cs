using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace HttpWinFrom
{
    class Utility
    {
        string[] experience_keywords = { "experience", "minimum", "at least", "years" };

        public string ParseURL(string url, string html)
        {
            string retVal = "";
            if(url.ToUpper().IndexOf("INDEED") > -1)
            {
                retVal = ParseIndeedURL(html);
            }
            return retVal;
        }

        public string ParseIndeedURL(string html)
        {
            string subStringStart = html.Substring(html.IndexOf("jobmap[0]"));
            string secdonSubstring = subStringStart.Substring(0, subStringStart.IndexOf("</script>"));

            string removeJobMap = Regex.Replace(secdonSubstring, "jobmap\\[.*\\]=", "");
            string removeNewlines = Regex.Replace(removeJobMap, "\n", "");
            string replaceSemiColons = Regex.Replace(removeNewlines, ";", ",");
            replaceSemiColons = replaceSemiColons.Substring(0, replaceSemiColons.Length - 1);
            
            replaceSemiColons = AddCustomFieldsToJSONString(replaceSemiColons);
            replaceSemiColons = "[" + replaceSemiColons + "]";

            //final json string
            return replaceSemiColons;
        }

        /**
         * Adds: viewed, applied, and level of interest to the json string
         * 
         **/
        public string AddCustomFieldsToJSONString(string json_str)
        {
            string temp_string = json_str;
            string holder = "";

            string final_string = "";
            //need to find each '}', and insert my fields before that
            while(temp_string.Length > 0) {
                holder = temp_string.Substring(0, temp_string.IndexOf("}") - 1);
                temp_string = temp_string.Substring(temp_string.IndexOf("}") + 1);
                final_string += holder + "',applied:'false',viewed:'false',levelOfInterest:1}";
            }
            return final_string;
        }

        public Boolean FilterExperience(string html, int years, IndeedDetails job)
        {
            int count = 0;
            bool accept = true;
            List<String> listOfStrings = new List<String>();
            if (html.IndexOf("interns") < 0 &&
                        html.IndexOf("Page Unavailable") < 0)
            {
                for (int i = 0; i < experience_keywords.Length; i++)
                {
                    if (html.IndexOf(experience_keywords[i]) > -1)
                    {

                        string temp_string = html;
                        string search_string = "";
                        int temp_index = temp_string.IndexOf(experience_keywords[i]);
                        while (temp_index > -1)
                        {
                            if (temp_string.Length > 100)
                            {
                                if (temp_index > 50)
                                {
                                    search_string = temp_string.Substring(temp_string.IndexOf(experience_keywords[i]) - 50, 100);
                                }
                                else if (temp_index > 25)
                                {
                                    search_string = temp_string.Substring(temp_string.IndexOf(experience_keywords[i]) - 25, 100);
                                }
                                else
                                {
                                    search_string = temp_string.Substring(temp_string.IndexOf(experience_keywords[i]) - temp_index, 100);
                                }

                            }
                            else
                            {
                                if (temp_index > 50)
                                {
                                    search_string = temp_string.Substring(temp_string.IndexOf(experience_keywords[i]) - 50, temp_string.Length);
                                }
                                else if (temp_index > 25)
                                {
                                    search_string = temp_string.Substring(temp_string.IndexOf(experience_keywords[i]) - 25, temp_string.Length);
                                }
                                else
                                {
                                    search_string = temp_string.Substring(temp_string.IndexOf(experience_keywords[i]) - temp_index, temp_string.Length);
                                }
                            }

                            if (search_string.IndexOf("https") < 0 &&
                                search_string.IndexOf(".com") < 0 &&
                                search_string.IndexOf("url") < 0 &&
                                search_string.IndexOf("://") < 0)
                            {
                                Console.WriteLine("Good: " + search_string);
                                listOfStrings.Add(search_string);
                            }
                            else
                            {
                                Console.WriteLine("Bad: " + search_string);
                            }
                            temp_string = temp_string.Substring(temp_index + 1);
                            temp_index = temp_string.IndexOf(experience_keywords[i]);
                        } //while loop
                    }  //if keyword
                } //for loop through keywords
            }
            else { accept = false; }//if intern
            
            Console.WriteLine("Company: "+job.cmp);
            while(count < listOfStrings.Count && accept == true) 
            {
                accept = FilterYearsOfExp(listOfStrings[count], years);
                Console.WriteLine("listOfStrings[" + count + "]: " + listOfStrings[count] + ", accpet: " + accept);
                count++;
            }
            Console.WriteLine("Company: " + job.cmp + " accept? " + accept);
            return accept;
        }

        public bool FilterYearsOfExp(String strToSearch, int yearsUpTo)
        {
            bool shouldKeep = true;
            bool checkNextNumber = true; //used for scenarios like: 2-4 years
            MatchCollection matches = Regex.Matches(strToSearch, @"\d+");
            try { 
            // Report on each match. 
            foreach (Match match in matches)
            {
                GroupCollection groups = match.Groups;
                String isPlusOrMinus = strToSearch.Substring(match.Index+1, 1);
                String hasYears = strToSearch.Substring(match.Index, 10);
                int resultInt = Int32.Parse(match.Value);
                if (resultInt < 25) //ignore anything over 20 (years, salary)
                {
                    if(checkNextNumber == true) {
                        if (isPlusOrMinus == "+" || isPlusOrMinus == "-")
                        {
                            if (isPlusOrMinus == "-") { checkNextNumber = false; }
                            if (hasYears.IndexOf("yrs") > 0 || hasYears.IndexOf("year") > 0)
                            {
                                if (resultInt > yearsUpTo) { shouldKeep = false; }
                            }
                        }
                        else if (hasYears.IndexOf("yrs") > 0 || hasYears.IndexOf("year") > 0)
                        {
                            if (resultInt > yearsUpTo) { shouldKeep = false; }
                        }
                        //else
                        //{
                        //    shouldKeep = false;
                        //}
                    }
                }

            }
            }
            catch (ArgumentOutOfRangeException aor)
            {
                Console.WriteLine("Argument out of range exception: " + aor.Message);
            }

            return shouldKeep;
        }

        public List<IndeedDetails> TransferJobsToKeep(List<IndeedDetails> original, List<int> toRemove) 
        {
            List<IndeedDetails> retData = new List<IndeedDetails>();

            for (int i = 0; i < original.Count; i++)
            {
                bool indexFound = false;
                for (int j = 0; j < toRemove.Count; j++) 
                {
                    if (i == toRemove[j])
                    {
                        indexFound = true;
                    }
                }
                if (indexFound == false)
                {
                    retData.Add(original[i]);
                }
            }
            return retData;
        }

        public void WriteToFile(String str)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\apersinger\Documents\Misc\jsonjobs.txt");
            file.WriteLine(str.ToString());
            file.Close();
        }

        public string OpenFile(string file_name)
        {
            string retVal = "";
            if (System.IO.File.Exists(file_name) == true)
            {
                System.IO.StreamReader objReader = new System.IO.StreamReader(file_name);
                retVal = objReader.ReadToEnd();
            }
            return retVal;
        }

        public List<IndeedDetails> DeserializeString(string strToSeri)
        {
            string retVal = strToSeri;
            var serializer = new JavaScriptSerializer();
            return serializer.Deserialize<List<IndeedDetails>>(retVal);
        }

        public String SerializeObject(Object obj)
        {
            var json = new JavaScriptSerializer().Serialize(obj);
            return json.ToString();
        }

    }
}
