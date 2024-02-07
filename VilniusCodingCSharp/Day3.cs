using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace VilniusCodingCSharp
{
    public class Day3
    {
        public static void Root()
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string url = @"https://www.snoway.com/feed/wpfmt/trucks/makes";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.UserAgent = "Not a hacker";
            request.Accept = "true";

            try
            {
                System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
                System.IO.Stream dataStream = response.GetResponseStream();
                System.IO.StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                System.Console.WriteLine(responseFromServer);
                System.Console.Read();

            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    var response = ex.Response;
                    var dataStream = response.GetResponseStream();
                    var reader = new StreamReader(dataStream);
                    var details = reader.ReadToEnd();
                }
            }
        }
    }
}
