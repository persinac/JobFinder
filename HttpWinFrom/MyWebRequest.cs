using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace HttpWinFrom
{
    public class MyWebRequest
    {
        private WebRequest request;
        private Stream dataStream;
        private Utility util;
        List<IndeedDetails> data;

        private string status;
        private string url;
        public String Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }

        public MyWebRequest(string url)
        {
            // Create a request using a URL that can receive a post.
            this.url = url;
            request = WebRequest.Create(url);
        }

        public MyWebRequest(string url, string method)
            : this(url)
        {

            if (method.Equals("GET") || method.Equals("POST"))
            {
                // Set the Method property of the request to POST.
                request.Method = method;
            }
            else
            {
                throw new Exception("Invalid Method Type");
            }
        }

        public MyWebRequest(string url, string method, string data)
            : this(url, method)
        {

            // Create POST data and convert it to a byte array.
            string postData = data;
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/x-www-form-urlencoded";

            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;

            // Get the request stream.
            dataStream = request.GetRequestStream();

            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);

            // Close the Stream object.
            dataStream.Close();

        }

        public string GetResponse()
        {
            util = new Utility();
            // Get the original response.
            WebResponse response = request.GetResponse();

            this.Status = ((HttpWebResponse)response).StatusDescription;

            // Get the stream containing all content returned by the requested server.
            dataStream = response.GetResponseStream();

            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);

            // Read the content fully up to the end.
            string responseFromServer = reader.ReadToEnd();
            string retVal = util.ParseURL(this.url, responseFromServer);
            data = util.DeserializeString(retVal);
            responseFromServer = retVal;
            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();

            return responseFromServer;
        }

        public string GetSpecificResponse(string url)
        {
            WebRequest new_request;
            WebResponse response;
            StreamReader reader;

            util = new Utility();
            if (url.IndexOf("www.") == 0)
            {
                url = "http://" + url;
            }
            try
            {
                new_request = WebRequest.Create(url);
                // Get the original response.
                response = new_request.GetResponse();

                this.Status = ((HttpWebResponse)response).StatusDescription;

                // Get the stream containing all content returned by the requested server.
                dataStream = response.GetResponseStream();

                // Open the stream using a StreamReader for easy access.
                reader = new StreamReader(dataStream);

                // Read the content fully up to the end.
                string responseFromServer = reader.ReadToEnd();
                // Clean up the streams.
                reader.Close();
                dataStream.Close();
                response.Close();
                return responseFromServer;
                
            }
            catch (System.Net.WebException exc)
            {
                return "EXCEPTION!!! " + exc.ToString();
            }
        }

        public List<IndeedDetails> GetListOfJobs()
        {
            return data;
        }

    }
}
