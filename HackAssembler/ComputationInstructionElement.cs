using System;

namespace HackAssembler
{
    public class ComputationInstructionElement : InstructionElement
    {
        public ComputationInstructionElement(string instruction) : base(instruction) { }

        public override string GetBinary()
        {
            throw new NotImplementedException();
        }
    }
}
