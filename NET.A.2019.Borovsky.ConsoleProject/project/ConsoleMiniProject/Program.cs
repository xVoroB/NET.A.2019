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

                                using (var xmlWriter = XmlWriter.Create("users.xml", settings))
                                {
                                    foreach (var item in users)
                                    {
                                        xmlWriter.WriteStartElement("User");
                                        xmlWriter.WriteElementString("Id", item.number.ToString());
                                        xmlWriter.WriteElementString("Firstname", item.firstName);
                                        xmlWriter.WriteElementString("Lastname", item.lastName);
                                        string aaa = item.birthDate.ToString();
                                        xmlWriter.WriteElementString("Birth", aaa);
                                        xmlWriter.WriteEndElement();
                                    }

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
                        break;
                    case "purge":
                        int b = users.Count - 1;
                        while (b >= 0)
                        {
                            users.RemoveAt(b--);
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
