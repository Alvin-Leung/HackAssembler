using System;
using System.IO;

namespace HackAssembler
{
    static public class Assembler
    {
        static public void TryConvertAsmToHack(string filepath)
        {
            try
            {
                ConvertAsmToHack(filepath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static public void ConvertAsmToHack(string filepath)
        {
            AssemblyFileParser assemblyFileParser = new AssemblyFileParser(filepath);

            string[] assemblyInstructions = assemblyFileParser.GetArrayOfAssemblyInstructions();

            Console.WriteLine("Assembly file parsed successfully...");

            string[] machineCodeInstructions = AssemblyLanguageParser.GetMachineCodeArray(assemblyInstructions);

            Console.WriteLine("Assembly language converted to machine code successfully...");

            FileInfo fileInfo = new FileInfo(filepath);

            string machineCodeFilePath = Path.Combine(fileInfo.DirectoryName, fileInfo.Name.Replace(fileInfo.Extension, ".hack"));

            MachineCodeStreamWriter machineCodeStreamWriter = new MachineCodeStreamWriter(machineCodeFilePath);

            machineCodeStreamWriter.WriteToFile(machineCodeInstructions);

            Console.WriteLine("Machine code file generation complete");
        }
    }
}
