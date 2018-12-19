using System;
using System.IO;
using System.Reflection;

namespace Task_1
{
    public static class DeepDiveClass
    {
        public static void PrintInstruction()
        {
            Console.WriteLine("Create nested directories providing level of nesting.");
        }

        /// <summary>
        /// Method which creates nested directories using recurrence.
        /// </summary>
        /// <param name="nestingLevel">Level of nesting</param>
        /// <param name="directoryName">Name of the directory created at current level of nesting</param>
        public static void DeepDive(UInt16 nestingLevel, string directoryName = "")
        {
            if ((nestingLevel < 0) || (nestingLevel > 5))
            {
                throw new Exception("Number must be between 0 - 5");
            }

            try
            {
                if (String.IsNullOrEmpty(directoryName))
                {
                    directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                }

                if (nestingLevel > 0)
                {
                    --nestingLevel;
                    string folderName = Path.Combine(directoryName, Guid.NewGuid().ToString());
                    Directory.CreateDirectory(folderName);
                    Console.WriteLine($"Created folder: {folderName}");

                    DeepDive(nestingLevel, folderName);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return;
        }
    }
}
