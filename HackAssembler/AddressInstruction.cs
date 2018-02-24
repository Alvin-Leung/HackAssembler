using System;

namespace HackAssembler
{
    public class AddressInstruction : Instruction
    {
        private readonly string Address = String.Empty;

        public AddressInstruction(string address)
        {
            this.Address = address;
        }

        public string GetInstructionAsBinary()
        {
            return String.Empty;
        }
    }
}
