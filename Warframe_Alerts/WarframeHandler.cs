using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net;
using System.Xml;

namespace Warframe_Alerts
{
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class WarframeHandler
    {
        public string GetXml(ref string ret)
        {
            if (ret == null) throw new ArgumentNullException(nameof(ret));
            try
            {
                var request = WebRequest.Create("http://content.warframe.com/dynamic/rss.php");
                var response = request.GetResponse();
                var status = (((HttpWebResponse)response).StatusDescription);
                ret = status;
                var dataStream = response.GetResponseStream();
                if (dataStream != null)
                {
                    var reader = new StreamReader(dataStream);
                    var responseFromServer = reader.ReadToEnd();
                    return responseFromServer;
                }
            }
            catch (Exception ex)
            {
                ret = "ERROR";
            	return "An Error Occurred: " + ex.Message;
            }

            return "";
        }

        public void GetObjects(string response, ref List<Alert> alerts, ref List<Invasion> invasions, ref List<Outbreak> outbreaks)
        {
            var doc = new XmlDocument();
            doc.LoadXml(response);

            var itemList = doc.SelectNodes("/rss/channel/item");

            foreach (XmlNode item in itemList)
            {
                var author = item["author"].InnerText;

                switch (author)
                {
                    case "Alert":
                    {
                        Alert temp;

                        temp.ID = item["guid"].InnerText;
                        temp.Title = item["title"].InnerText;
                        temp.Description = item["description"].InnerText;
                        temp.Start_Date = item["pubDate"].InnerText;

                        var fParse = item["wf:faction"].InnerText.Split('_');
                        var faction = fParse[1].ToLower();

                        temp.Faction = faction.Substring(0, 1).ToUpper() + faction.Substring(1, faction.Length - 1);
                        temp.Expiry_Date = item["wf:expiry"].InnerText;

                        alerts.Add(temp);
                    }
                        break;
                    case "Invasion":
                    {
                        Invasion temp;

                        temp.ID = item["guid"].InnerText;
                        temp.Title = item["title"].InnerText;
                        temp.Start_Date = item["pubDate"].InnerText;

                        invasions.Add(temp);
                    }
                        break;
                    case "Outbreak":
                    {
                        Outbreak temp;

                        temp.ID = item["guid"].InnerText;
                        temp.Title = item["title"].InnerText;
                        temp.Start_Date = item["pubDate"].InnerText;

                        outbreaks.Add(temp);
                    }
                        break;
                }
            }
        }
    }
}
