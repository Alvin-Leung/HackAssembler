using System;
using System.IO;

namespace HackAssembler
{
    static public class AssemblerConsole
    {
        static public void DisplayIntroductoryMessage()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();

            System.Diagnostics.FileVersionInfo fileVersionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);

            string version = fileVersionInfo.FileVersion;

            Console.WriteLine("HackAssembler v" + version);

            Console.WriteLine("An assembler for the Hack computer architecture. " +
                "Converts assembly language contained in an .asm file to machine code contained in a .hack file");

            Console.WriteLine();
        }

        static public string GetValidFilepathFromUser()
        {
            string expectedInputFileExtension = ".asm";

            FileInfo fileInfo;

            string filepath;

            bool fileExists;

            bool fileIsAsm;

            do
            {
                Console.Write("Assembly language filepath (.asm): ");

                filepath = Console.ReadLine();

                fileExists = File.Exists(filepath);

                if (!fileExists)
                {
                    Console.WriteLine("File does not exist. Please try again.");

                    fileIsAsm = false;
                }
                else
                {
                    fileInfo = new FileInfo(filepath);

                    if (fileInfo.Extension != expectedInputFileExtension)
                    {
                        Console.WriteLine("File is not in the correct format. Please input the path for an .asm file.");

                        fileIsAsm = false;
                    }
                    else
                    {
                        fileIsAsm = true;
                    }
                }
            }
            while (!(fileExists && fileIsAsm));

            Console.WriteLine();

            return filepath;
        }

        static public void DisplayExitMessage()
        {
            Console.WriteLine();

            Console.WriteLine("Press enter to exit...");

            Console.ReadLine();
        }
    }
}
