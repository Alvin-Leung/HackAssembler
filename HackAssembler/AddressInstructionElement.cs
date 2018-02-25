using System;

namespace HackAssembler
{
    public class AddressInstructionElement : InstructionElement
    {
        public AddressInstructionElement(string instruction) : base(instruction) { }

        public override string GetBinary()
        {
            throw new NotImplementedException();
        }
    }
}
