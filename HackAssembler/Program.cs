namespace HackAssembler
{
    class Program
    {
        static void Main(string[] args)
        {
            AssemblerConsole.DisplayIntroductoryMessage();

            string filepath = AssemblerConsole.GetValidFilepathFromUser();

            Assembler.TryConvertAsmToHack(filepath);

            AssemblerConsole.DisplayExitMessage();
        }
    }
}
