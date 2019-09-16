using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace MiniProject
{
    class Command
    {
        public static void Purge(List<User> library)
        {
            var fstream = new FileStream(@"D:\ConsoleProject\Buff\beforePurge.txt", FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
            var sw = new StreamWriter(fstream, Encoding.UTF8);
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

            Console.WriteLine("All data was erased");
        }
        public static void ExportCsv(ref List<User> library, string[] command)
        {
            string pathCsvFile = @"D:\ConsoleProject\Export\users.csv";

            using (var streamReader = new StreamWriter(pathCsvFile))
            {
                using (var csvWriter = new CsvWriter(streamReader))
                {
                    csvWriter.WriteRecords(library);
                }
            }
            Console.WriteLine("Export .csv file finished");
        }
        public static void ImportCsv(ref List<User> library, string[] command)
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
        public static void ShowList(List<User> library, string[] command)
        {
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
            else if (library.Count < 1)
            {
                Console.WriteLine("There is no users in collection");
            }
            else
            {
                foreach (var item in library)
                {
                    Console.Write(item.GetInfo());
                    Console.WriteLine();
                }
            }

        }
        public static void Find(List<User> library, string[] command)
        {
            for (int s = 1; s < command.Length; s++)
            {
                command[s] = command[s].Trim(',');
            }

            int ind = -1;

            foreach (var item in library)
            {
                int singleFinder = item.Finder(command[1], command[2]);
                ind++;
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
                    else if (ind == library.Count)
                    {
                        Console.WriteLine("No users found");
                    }
                }
                else if (singleFinder > 0)
                {
                    Console.WriteLine("#" + singleFinder);
                }
                else if (ind == library.Count)
                {
                    Console.WriteLine("No users found");
                }
            }
        }
        public static void Edit(List<User> library, string[] command)
        {
            if (command.Length > 1)
            {
                command[1] = command[1].TrimStart('#');
                int toEdit = int.Parse(command[1]);
                if (toEdit < 0 || toEdit > library.Count - 1)
                {
                    Console.WriteLine("There is no user with this id");
                }
                else
                {
                    library[toEdit - 1].Edit();
                }
            }
        }
        public static void ExportXml(List<User> library, string[] command)
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
                    string aaa = item.birthDate.ToString("dd.MM.yyyy");
                    xmlWriter.WriteElementString("Birth", aaa);
                    xmlWriter.WriteEndElement();
                }
                xmlWriter.WriteEndElement();
            }
            Console.WriteLine("Export .xml file finished");
        }
        public static void Remove(string[] command, List<User> library, ref int i)
        {
            command[1] = command[1].Trim('#');
            int num = int.Parse(command[1]) - 1;
            if (num > library.Count - 1 || num < 0)
            {
                Console.WriteLine("There is no user with this id");
            }
            else
            {
                library.Remove(library[num]);
                Console.WriteLine("Record #{0} is removed", num + 1);
                for (int l = 0; l < library.Count; l++)
                {
                    if (library[l].number > num)
                    {
                        library[l].number--;
                    }
                }
                i--;
            }

        }
        public static void Help()
        {
            Console.WriteLine("create - creates user");
            Console.WriteLine("list - list of all users in collection");
            Console.WriteLine("also can be extended with properties to show in different order");
            Console.WriteLine("stat - number of records");
            Console.WriteLine("find PROP VALUE - find user and show its id. Prop - property to find. Value - value of property to find");
            Console.WriteLine("also find can be extended to find PROP VALUE, PROP VALUE");
            Console.WriteLine("export csv/xml - exports collection into csv or xml file");
            Console.WriteLine("import csv/xml FILENAME.csv/.xml - imports csv or xml file");
            Console.WriteLine("remove ID - remove user with id");
            Console.WriteLine("purge - clear collection");
        }
        public static void ImportXml(List<User> library, string[] command)
        {
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
}
