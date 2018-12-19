using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Task_1
{
    public static class DrownItDownClass
    {
        public static void PrintInstruction()
        {
            Console.WriteLine("Create a file in nested folder.");
        }

        /// <summary>
        /// Create a file in nested folder.
        /// </summary>
        /// <param name="number">Level of nested directory, in which file should be created.</param>
        public static void DrownItDown(UInt16 number)
        {
            try
            {
                IEnumerable<string> directories = Directory.EnumerateDirectories(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                if (directories.Count() == 0)
                {
                    HandleIfNoDirectories(number);
                    directories = Directory.EnumerateDirectories(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

                    if (directories.Count() == 0)
                    {
                        return;
                    }
                }

                PrintAvailableDirectories(directories);
                StartFileCreation(number, directories);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static void HandleIfNoDirectories(UInt16 number)
        {
            Console.WriteLine("Found 0 directories here. Would you like to create nested directories using DeepDive method?");
            Console.WriteLine("1) Yes");
            Console.WriteLine("2) No");

            int decision;

            do
            {
                Console.Write($"Your choice: ");
                int.TryParse(Console.ReadLine(), out decision);

                if (decision == 1)
                {
                    UInt16 selectedNumber = Helper.AskForNumber(number, 5);
                    DeepDiveClass.DeepDive(selectedNumber);

                    break;
                }
                else if (decision == 2)
                {
                    break;
                }
            } while ((decision != 1));
        }

        private static void PrintAvailableDirectories(IEnumerable<string> directories)
        {
            Console.WriteLine("Available directories:");
            for (int i = 0; i < directories.Count(); i++)
            {
                try
                {
                    Console.WriteLine($"{i + 1}) {new DirectoryInfo(directories.ElementAt(i)).Name}");
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        private static void StartFileCreation(int nestingLevel, IEnumerable<string> directories)
        {
            int selectFolder;

            do
            {
                Console.Write($"Select folder: ");
                int.TryParse(Console.ReadLine(), out selectFolder);

                if ((selectFolder > 0) && (selectFolder <= directories.Count()))
                {
                    Console.WriteLine($"You have selected: {new DirectoryInfo(directories.ElementAt(selectFolder - 1)).Name}");
                    Console.Write($"Provided name of the file: ");
                    string fileName = Console.ReadLine();

                    CreateNestedFile(nestingLevel, directories.ElementAt(selectFolder - 1), fileName);
                    return;
                }
                else
                {
                    continue;
                }

            } while (true);
        }

        private static void CreateNestedFile(int nestingLevel, string nextDirectory, string fileName)
        {
            if (nestingLevel == 0)
            {
                if (File.Exists(Path.Combine(nextDirectory, fileName)))
                {
                    Console.WriteLine("File {0} exists. Would you like to override it?", fileName);
                    Console.WriteLine("1) Yes");
                    Console.WriteLine("2) No");

                    int decision;

                    do
                    {
                        Console.Write($"Your choice: ");
                        int.TryParse(Console.ReadLine(), out decision);

                        if (decision == 1)
                        {
                            File.Create(Path.Combine(nextDirectory, fileName));
                            Console.WriteLine("Created: {0}", fileName);
                            return;
                        }
                        else if (decision == 2)
                        {
                            CreateFileNotOverride(nextDirectory, fileName);
                            return;
                        }
                        else
                        {
                            continue;
                        }
                    } while (true);
                }
                else
                {
                    File.Create(Path.Combine(nextDirectory, fileName));
                }
            }
            else
            {
                IEnumerable<string> directories = Directory.EnumerateDirectories(nextDirectory);
                if (directories.Count() == 0)
                {
                    Console.WriteLine("Given too many nested directories. Aborted.");
                    return;
                }
                --nestingLevel;
                CreateNestedFile(nestingLevel, directories.ElementAt(0), fileName);
            }
        }

        private static void CreateFileNotOverride(string directory, string fileName)
        {
            bool stop = false;
            int i = 0;
            string newName;
            try
            {

                do
                {
                    newName = Path.GetFileNameWithoutExtension(fileName) + $"({i})" + Path.GetExtension(fileName);

                    if (File.Exists(Path.Combine(directory, newName)))
                    {
                        i++;
                        continue;
                    }
                    else
                    {
                        File.Create(Path.Combine(directory, newName));
                        Console.WriteLine("Created: {0}", newName);
                        return;
                    }
                } while (!stop || i > 1000);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
