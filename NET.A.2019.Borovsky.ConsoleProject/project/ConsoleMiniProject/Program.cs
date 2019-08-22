using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleMiniProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            var users = new List<Library>();
            int i = 0;
            

            while (true)
            {
                var fstream = new FileStream(@"D:\buffer.txt", FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                var sw = new StreamWriter(fstream, Encoding.UTF8);
                foreach (var item in users)
                {
                    sw.WriteLine(item.GetInfo());
                }
                sw.Flush();
                sw.Dispose();

                input = Console.ReadLine();
                string[] command = input.ToLower().Split(' ');
                switch (command[0])
                {
                    case "create":
                        users.Add(new Library());
                        users[i].Create();
                        i++;
                        break;
                    case "list":
                        if (command.Length > 1)
                        {
                            for (int k = 1; k < command.Length; k++)
                            {
                                command[k] = command[k].Trim(',');
                            }
                            Console.WriteLine();
                            foreach (var item in users)
                            {
                                byte a = 1;
                                while (a < command.Length)
                                {
                                    Console.Write(item.ExtendedList(command[a]));

                                    if (a + 1 < command.Length)
                                    {
                                        Console.Write(", ");
                                    }
                                    a++;
                                }
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            foreach (var item in users)
                            {
                                Console.Write(item.GetInfo());
                                Console.WriteLine();
                            }
                        }
                        break;
                    case "stat":
                        Console.WriteLine(users.Count + " records");
                        break;
                    case "find":
                        for (int s = 1; s < command.Length; s++)
                        {
                            command[s] = command[s].Trim(',');
                        }
                        foreach (var item in users)
                        {
                            int finder1 = item.Finder(command[1], command[2]);
                            if (command.Length > 3)
                            {
                                int finder2 = item.Finder(command[3], command[4]);
                                if (finder1 > 0 && finder2 > 0 && finder1 == finder2)
                                {
                                    Console.WriteLine("#" + finder1);
                                }
                                else if (finder1 > 0)
                                {
                                    Console.WriteLine("#" + finder1);
                                }
                                else if (finder2 > 0)
                                {
                                    Console.WriteLine("#" + finder2);
                                }
                            }
                            else if (finder1 > 0)
                            {
                                Console.WriteLine("#" + finder1);
                            }
                        }
                        break;
                    case "edit":
                        if (command.Length > 1)
                        {
                            command[1] = command[1].TrimStart('#');
                            users[int.Parse(command[1]) - 1].Edit();
                        }
                        break;
                    case "export":
                        if (command.Length > 1)
                        {
                            string pathCsvFile = "D:\\consoleprojectexport\\users.csv";
                            if (command[1].Equals("csv"))
                            {
                                using (var streamReader = new StreamWriter(pathCsvFile))
                                {
                                    using (var csvWriter = new CsvWriter(streamReader))
                                    {
                                        csvWriter.WriteRecords(users);
                                    }
                                }
                                Console.WriteLine("Export .csv file finished");
                            }
                            else if (command[1].Equals("xml"))
                            {
                                var settings = new XmlWriterSettings();
                                settings.Indent = true;
                                settings.OmitXmlDeclaration = true;
                                settings.NewLineOnAttributes = true;
                                settings.ConformanceLevel = ConformanceLevel.Auto;

                                using (var xmlWriter = XmlWriter.Create("D:\\consoleprojectexport\\users.xml", settings))
                                {
                                    xmlWriter.WriteStartElement("Users");
                                    foreach (var item in users)
                                    {
                                        string idString = item.number.ToString();
                                        xmlWriter.WriteStartElement("User");
                                        xmlWriter.WriteAttributeString("id", idString);
                                        xmlWriter.WriteElementString("Firstname", item.firstName);
                                        xmlWriter.WriteElementString("Lastname", item.lastName);
                                        string aaa = item.birthDate.ToString();
                                        xmlWriter.WriteElementString("Birth", aaa);
                                        xmlWriter.WriteEndElement();
                                    }
                                    xmlWriter.WriteEndElement();
                                }
                                Console.WriteLine("Export .xml file finished");
                            }
                        }
                        break;
                    case "remove":
                        command[1] = command[1].Trim('#');
                        int num = int.Parse(command[1]);
                        users.Remove(users[num]);
                        Console.WriteLine("Record #{0} is removed", num);
                        for (int l = 0; l < users.Count; l++)
                        {
                            if (users[l].number > num)
                            {
                                users[l].number--;
                            }
                        }
                        i--;
                        break;
                    case "purge":
                        fstream = new FileStream(@"D:\beforePurge.txt", FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                        sw = new StreamWriter(fstream, Encoding.UTF8);
                        foreach (var item in users)
                        {
                            sw.WriteLine(item.GetInfo());
                        }
                        sw.Flush();
                        sw.Dispose();

                        int b = users.Count - 1;
                        while (b >= 0)
                        {
                            users.RemoveAt(b--);
                        }

                        Console.WriteLine("All data is erased");
                        break;
                    case "import":
                        if (command.Length > 1)
                        {
                            command[1].Trim();
                            if (command[1].Equals("csv"))
                            {
                                byte index = 1;
                                bool firstEntrance = true;
                                if (command[2].Length > 4)
                                {
                                    var file = command[2].Split('.');
                                    if (file[1].Equals("csv"))
                                    {
                                        using (var reader = new StreamReader("D:\\consoleprojectimport\\" + file[0] + ".csv"))
                                        {
                                            if (users.Count == 0)
                                            {
                                                users.Add(new Library());
                                                users[0].ZeroCount();
                                            }
                                            else
                                            {
                                                users[0].ZeroCount();
                                            }

                                            users = new List<Library>();
                                            while (!reader.EndOfStream)
                                            {
                                                if (!firstEntrance)
                                                {
                                                    var csvInput = reader.ReadLine().Split(';');
                                                    users.Add(new Library(index, csvInput[0], csvInput[1], csvInput[2]));
                                                    index++;
                                                }
                                                else
                                                {
                                                    var csvInput = reader.ReadLine().Split(';');
                                                    firstEntrance = false;
                                                }
                                            }
                                        }
                                    }   
                                
                                }
                                Console.WriteLine("csv import complete");
                            }
                            else if(command[1].Equals("xml"))
                            {
                                users = new List<Library> ();
                                int ind = 0;
                                string fName = "", lName = "", bD = "";
                                var name = command[2].Split('.');
                                var xDoc = new XmlDocument();
                                xDoc.Load("D:\\consoleprojectimport\\" + name[0] + ".xml");
                                var xRoot = xDoc.DocumentElement;
                                foreach (XmlNode xNode in xRoot)
                                {

                                    if (xNode.Attributes.Count > 0)
                                    {
                                        var attr = xNode.Attributes.GetNamedItem("id");
                                        if (attr != null)
                                        {
                                            ind = int.Parse(attr.Value);
                                        }
                                        foreach (XmlNode childNode in xNode.ChildNodes)
                                        {
                                            if (childNode.Name.ToLower().Equals("firstname"))
                                            {
                                                fName = childNode.InnerText;
                                            }
                                            if (childNode.Name.ToLower().Equals("lastname"))
                                            {
                                                lName = childNode.InnerText;
                                            }
                                            if (childNode.Name.ToLower().Equals("birth"))
                                            {
                                                bD = childNode.InnerText;
                                            }
                                        }
                                        users.Add(new Library(ind, fName, lName, bD));
                                    }
                                }
                                Console.WriteLine("xml import complete");
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Wrong command");
                        break;
                }
            }

        }
    }
}
