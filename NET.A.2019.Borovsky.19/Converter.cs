namespace HomeworkDay19
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Xml;
    using NLog;

    /// <summary>
    /// Class with method to convert txt to xml.
    /// </summary>
    internal class Converter
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Reading txt and saving to xml with possibility to log wrong sites.
        /// </summary>
        /// <param name="path"> Filepath. </param>
        public static void Convert(string path)
        {
            var allSites = new List<string>();
            using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    allSites.Add(line);
                }
            }

            var settings = new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = true,
                NewLineOnAttributes = false,
                ConformanceLevel = ConformanceLevel.Auto,
            };

            string pattern = @"^(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)?[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$";

            Write(settings, allSites, pattern);
        }

        /// <summary>
        /// Private method to write .xml file.
        /// </summary>
        /// <param name="settings"> Xml writer settings. </param>
        /// <param name="allSites"> List with sites from txt. </param>
        /// <param name="pattern"> Pattern to check incoming sites. </param>
        private static void Write(XmlWriterSettings settings, List<string> allSites, string pattern)
        {
            using (var xWriter = XmlWriter.Create("sites.xml", settings))
            {
                xWriter.WriteStartElement("urlAdresses");
                foreach (var item in allSites)
                {
                    string[] segments = new string[0];

                    if (Regex.IsMatch(item, pattern))
                    {
                        segments = item.Split('/');
                    }

                    if (segments.Length == 0)
                    {
                        Log.Warn("Wrong site \"{0}\"", item);
                    }
                    else
                    {
                        int index = 0;
                        while (segments[index] == "http:" || segments[index] == "https:" || segments[index] == string.Empty || segments[index] == " ")
                        {
                            index++;
                        }

                        string[] addParams = new string[0];

                        foreach (var param in segments)
                        {
                            if (param.Contains('?'))
                            {
                                addParams = param.Split('?', '=');
                            }
                        }

                        int segLen = segments.Length - 1;

                        if (addParams.Length > 0)
                        {
                            if (segments[segLen] == " " || segments[segLen] == string.Empty)
                            {
                                segments[segLen - 1] = addParams[0];
                            }
                            else
                            {
                                segments[segLen] = addParams[0];
                            }
                        }

                        xWriter.WriteStartElement("urlAdress");
                        xWriter.WriteStartElement("host");
                        xWriter.WriteAttributeString("name", segments[index++]);
                        xWriter.WriteEndElement();

                        if (index < segments.Length)
                        {
                            xWriter.WriteStartElement("uri");
                            while (index < segments.Length)
                            {
                                if (segments[index] != " " && segments[index] != string.Empty)
                                {
                                    xWriter.WriteElementString("segment", segments[index++]);
                                }
                                else
                                {
                                    index++;
                                }
                            }

                            xWriter.WriteEndElement();
                        }

                        if (addParams.Length > 0)
                        {
                            xWriter.WriteStartElement("parameters");
                            int indexParam = 0;
                            while (indexParam < addParams.Length - 2)
                            {
                                xWriter.WriteStartElement("parameter");
                                xWriter.WriteAttributeString("value", addParams[indexParam + 2].Trim());
                                xWriter.WriteAttributeString("key", addParams[indexParam + 1].Trim());
                                xWriter.WriteEndElement();
                                indexParam += 2;
                            }

                            xWriter.WriteEndElement();
                        }

                        xWriter.WriteEndElement();
                    }
                }

                xWriter.WriteEndElement();
            }
        }
    }
}
