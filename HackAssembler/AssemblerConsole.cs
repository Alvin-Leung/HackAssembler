using System;
using System.IO;

namespace HackAssembler
{
    static public class AssemblerConsole
    {
        static public string GetValidFilepathFromUser()
        {
            string userInput;

            bool isValidFilepath;

            do
            {
                Console.Write("Assembly language filepath (.asm): ");

                userInput = Console.ReadLine();

                isValidFilepath = IsValidFilepath(userInput);

                if (!isValidFilepath)
                {
                    if (IsHelpRequested(userInput))
                    {
                        DisplayRuntimeHelp();
                    }
                    else
                    {
                        Console.WriteLine(
                            Environment.NewLine + 
                            "Filepath is not valid. " + Environment.NewLine +
                            "Please check that the file exists and that it is an .asm file." + Environment.NewLine);
                    }
                }
            }
            while (!isValidFilepath);

            Console.WriteLine();

            return userInput;
        }

        static public void DisplayCommandLineHelp()
        {
            string newLine = Environment.NewLine;

            Console.WriteLine(
                newLine +
                "Usage: HackAssembler [filepath]" + newLine +
                newLine +
                "Options:" + newLine +
                "\tfilepath\t\tThe filepath to an .asm file" + newLine +
                newLine
                );

            ExplainExpectedProgramOutputs();
        }

        static public void DisplayExitMessage()
        {
            Console.WriteLine();

            Console.WriteLine("Press enter to exit...");

            Console.ReadLine();
        }

        static public bool IsCommandLineUsed(string[] args)
        {
            if (args.Length >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static public bool IsArgumentArrayValid(string[] args)
        {
            return IsValidNumberOfArguments(args) && IsValidFilepath(args[0]);
        }

        static public bool IsHelpRequested(string[] args)
        {
            if (args.Length == 1)
            {
                return IsHelpRequested(args[0]);
            }
            else
            {
                return false;
            }
        }

        static private void DisplayRuntimeHelp()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();

            System.Diagnostics.FileVersionInfo fileVersionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);

            string version = fileVersionInfo.FileVersion;

            Console.WriteLine(
                Environment.NewLine + 
                "HackAssembler v" + version + Environment.NewLine);

            ExplainExpectedProgramOutputs();

            Console.WriteLine();
        }

        static private void ExplainExpectedProgramOutputs()
        {
            Console.WriteLine(
                "As input, the HackAssembler program expects a filepath to an .asm file. " +
                "It converts assembly language contained in the .asm file to machine code contained in a .hack file. " +
                "The .hack file will be created in the folder of the .asm file and will take the name of the .asm file. " +
                "At assembly time, if there is a .hack file with the same filename in the folder, it will be overwritten.");
        }

        static private bool IsHelpRequested(string userInput)
        {
            if (userInput == "/?" ||
                userInput == "-h" ||
                userInput == "-help" ||
                userInput == "--help" ||
                userInput == "help")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static private bool IsValidNumberOfArguments(string [] args)
        {
            if (args.Length == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static private bool IsValidFilepath(string filepath)
        {
            bool isValid;

            if (File.Exists(filepath))
            {
                if (IsFileAsm(filepath))
                {
                    isValid = true;
                }
                else
                {
                    isValid = false;
                }
            }
            else
            {
                isValid = false;
            }

            return isValid;
        }

        static private bool IsFileAsm(string filepath)
        {
            FileInfo fileInfo = new FileInfo(filepath);

            string expectedInputFileExtension = ".asm";

            bool fileIsAsm;

            if (fileInfo.Extension != expectedInputFileExtension)
            {
                fileIsAsm = false;
            }
            else
            {
                fileIsAsm = true;
            }

            return fileIsAsm;
        }
    }
}
