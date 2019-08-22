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
            var library = new List<User>();
            int i = 0;
            

            while (true)
            {
                var fstream = new FileStream(@"D:\ConsoleProject\Buff\buffer.txt", FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                var sw = new StreamWriter(fstream, Encoding.UTF8);
                foreach (var item in library)
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
                        library.Add(new User());
                        library[i].Create();
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
                            foreach (var item in library)
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
                            foreach (var item in library)
                            {
                                Console.Write(item.GetInfo());
                                Console.WriteLine();
                            }
                        }
                        break;
                    case "stat":
                        Console.WriteLine(library.Count + " records");
                        break;
                    case "find":
                        for (int s = 1; s < command.Length; s++)
                        {
                            command[s] = command[s].Trim(',');
                        }



                        if (command.Length > 3)
                        {
                            for (int k = command.Length - 1; k > 3; k--)
                            {

                            }
                        }

                        foreach (var item in library)
                        {
                            int singleFinder = item.Finder(command[1], command[2]);
                            if (command.Length > 3)
                            {

                                int finder2 = item.Finder(command[3], command[4]);
                                if (singleFinder > 0 && finder2 > 0 && singleFinder == finder2)
                                {
                                    Console.WriteLine("#" + singleFinder);
                                }
                                else if (singleFinder > 0)
                                {
                                    Console.WriteLine("#" + singleFinder);
                                }
                                else if (finder2 > 0)
                                {
                                    Console.WriteLine("#" + finder2);
                                }
                            }
                            else if (singleFinder > 0)
                            {
                                Console.WriteLine("#" + singleFinder);
                            }
                        }
                        break;
                    case "edit":
                        if (command.Length > 1)
                        {
                            command[1] = command[1].TrimStart('#');
                            library[int.Parse(command[1]) - 1].Edit();
                        }
                        break;
                    case "export":
                        if (command.Length > 1)
                        {
                            string pathCsvFile = @"D:\ConsoleProject\Export\users.csv";
                            if (command[1].Equals("csv"))
                            {
                                using (var streamReader = new StreamWriter(pathCsvFile))
                                {
                                    using (var csvWriter = new CsvWriter(streamReader))
                                    {
                                        csvWriter.WriteRecords(library);
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

                                using (var xmlWriter = XmlWriter.Create(@"D:\ConsoleProject\Export\users.xml", settings))
                                {
                                    xmlWriter.WriteStartElement("Users");
                                    foreach (var item in library)
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
                        int num = int.Parse(command[1]) - 1;
                        library.Remove(library[num]);
                        Console.WriteLine("Record #{0} is removed", num);
                        for (int l = 0; l < library.Count; l++)
                        {
                            if (library[l].number > num)
                            {
                                library[l].number--;
                            }
                        }
                        i--;
                        break;
                    case "purge":
                        fstream = new FileStream(@"D:\ConsoleProject\Buff\beforePurge.txt", FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                        sw = new StreamWriter(fstream, Encoding.UTF8);
                        foreach (var item in library)
                        {
                            sw.WriteLine(item.GetInfo());
                        }
                        sw.Flush();
                        sw.Dispose();

                        int b = library.Count - 1;
                        while (b >= 0)
                        {
                            library.RemoveAt(b--);
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
                                        using (var reader = new StreamReader("D:\\ConsoleProject\\Import\\" + file[0] + ".csv"))
                                        {
                                            if (library.Count == 0)
                                            {
                                                library.Add(new User());
                                                library[0].ZeroCount();
                                            }
                                            else
                                            {
                                                library[0].ZeroCount();
                                            }

                                            library = new List<User>();
                                            while (!reader.EndOfStream)
                                            {
                                                if (!firstEntrance)
                                                {
                                                    var csvInput = reader.ReadLine().Split(';');
                                                    library.Add(new User(index, csvInput[0], csvInput[1], csvInput[2]));
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
                                library = new List<User> ();
                                int ind = 0;
                                string fName = "", lName = "", bD = "";
                                var name = command[2].Split('.');
                                var xDoc = new XmlDocument();
                                xDoc.Load("D:\\ConsoleProject\\Import\\" + name[0] + ".xml");
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
                                        library.Add(new User(ind, fName, lName, bD));
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
