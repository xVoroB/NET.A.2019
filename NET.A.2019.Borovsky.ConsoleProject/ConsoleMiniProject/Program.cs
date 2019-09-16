using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace MiniProject
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

                        Command.ShowList(library, command);
                        break;

                    case "stat":

                        Console.WriteLine(library.Count + " records");
                        break;

                    case "find":

                        Command.Find(library, command);
                        break;

                    case "edit":

                        Command.Edit(library, command);
                        break;

                    case "export":

                        if (command.Length > 1)
                        {
                            if (command[1].Equals("csv"))
                            {
                                Command.ExportCsv(ref library, command);
                            }
                            else if (command[1].Equals("xml"))
                            {
                                Command.ExportXml(library, command);
                            }
                        }
                        break;

                    case "remove":

                        Command.Remove(command, library, ref i);
                        break;

                    case "purge":

                        Command.Purge(library);
                        break;

                    case "import":

                        if (command.Length > 1)
                        {
                            command[1] = command[1].Trim();

                            if (command[1].Equals("csv"))
                            {
                                Command.ImportCsv(ref library, command);
                            }
                            else if (command[1].Equals("xml"))
                            {
                                library = new List<User>();
                                Command.ImportXml(library, command);
                            }
                        }

                        break;
                    case "help":

                        Command.Help();
                        break;

                    default:

                        Console.WriteLine("Wrong command");
                        break;
                }
            }
        }

    }
}