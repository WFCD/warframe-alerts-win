using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Xml;

namespace Warframe_Alerts
{
    class Warframe_Handler
    {
        public string GetXML(ref string Ret)
        {
            try
            {
                WebRequest request = WebRequest.Create("http://content.warframe.com/dynamic/rss.php");
                WebResponse response = request.GetResponse();
                string Status = (((HttpWebResponse)response).StatusDescription);
                Ret = Status;
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                return responseFromServer;
            }
            catch (System.Exception ex)
            {
                Ret = "ERROR";
            	return "An Error Occurred: " + ex.Message;
            }
        }

        public void GetObjects(string Response, ref List<Alert> Alerts, ref List<Invasion> Invasions, ref List<Outbreak> Outbreaks)
        {
            XmlDocument Doc = new XmlDocument();
            Doc.LoadXml(Response);

            XmlNodeList ItemList = Doc.SelectNodes("/rss/channel/item");

            foreach (XmlNode Item in ItemList)
            {
                string Author = Item["author"].InnerText;

                if (Author == "Alert")
                {
                    Alert Temp;

                    Temp.ID = Item["guid"].InnerText;
                    Temp.Title = Item["title"].InnerText;
                    Temp.Description = Item["description"].InnerText;
                    Temp.Start_Date = Item["pubDate"].InnerText;

                    //Temp.Faction = Item["wf:faction"].InnerText;

                    string[] F_Parse = Item["wf:faction"].InnerText.Split('_');
                    string Faction = F_Parse[1].ToLower();

                    Temp.Faction = Faction.Substring(0, 1).ToUpper() + Faction.Substring(1, Faction.Length - 1);
                    Temp.Expiry_Date = Item["wf:expiry"].InnerText;

                    //Console.WriteLine(Item["guid"].InnerText);
                    //Console.WriteLine(Item["title"].InnerText);
                    //Console.WriteLine(Item["author"].InnerText);
                    //Console.WriteLine(Item["description"].InnerText);
                    //Console.WriteLine(Item["pubDate"].InnerText);
                    //Console.WriteLine(Item["wf:faction"].InnerText);
                    //Console.WriteLine(Item["wf:expiry"].InnerText);

                    Alerts.Add(Temp);
                }
                else if (Author == "Invasion")
                {
                    Invasion Temp;

                    Temp.ID = Item["guid"].InnerText;
                    Temp.Title = Item["title"].InnerText;
                    Temp.Start_Date = Item["pubDate"].InnerText;

                    //Console.WriteLine(Item["guid"].InnerText);
                    //Console.WriteLine(Item["title"].InnerText);
                    //Console.WriteLine(Item["author"].InnerText);
                    //Console.WriteLine(Item["pubDate"].InnerText);

                    Invasions.Add(Temp);
                }
                else if (Author == "Outbreak")
                {
                    Outbreak Temp;

                    Temp.ID = Item["guid"].InnerText;
                    Temp.Title = Item["title"].InnerText;
                    Temp.Start_Date = Item["pubDate"].InnerText;

                    //Console.WriteLine(Item["guid"].InnerText);
                    //Console.WriteLine(Item["title"].InnerText);
                    //Console.WriteLine(Item["author"].InnerText);
                    //Console.WriteLine(Item["pubDate"].InnerText);

                    Outbreaks.Add(Temp);
                }
            }
        }
    }
}
