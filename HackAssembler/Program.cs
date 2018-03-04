using System;

namespace HackAssembler
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath;

            if (AssemblerConsole.IsCommandLineUsed(args))
            {
                if (AssemblerConsole.IsArgumentArrayValid(args))
                {
                    filepath = args[0];
                }
                else
                {
                    if (!AssemblerConsole.IsHelpRequested(args))
                    {
                        Console.WriteLine(Environment.NewLine +
                            "Error: HackAssembler could not assemble the .asm file specified by the filepath input");
                    }

                    AssemblerConsole.DisplayCommandLineHelp();

                    return;
                }
            }
            else
            {
                filepath = AssemblerConsole.GetValidFilepathFromUser();
            }

            Assembler.TryConvertAsmToHack(filepath);

            AssemblerConsole.DisplayExitMessage();
        }
    }
}
