using System.IO;

namespace HackAssembler
{
    public class MachineCodeStreamWriter
    {
        private string filepath;

        public MachineCodeStreamWriter(string filepath)
        {
            this.filepath = filepath;
        }

        public void WriteToFile(string[] machineCodeInstructions)
        {
            using (StreamWriter writer = new StreamWriter(filepath))
            {
                foreach (string instruction in machineCodeInstructions)
                {
                    writer.WriteLine(instruction);
                }
            }
        }
    }
}
