using System;

namespace HackAssembler
{
    public class JumpInstructionElement : InstructionElement
    {
        public JumpInstructionElement(string instruction) : base(instruction) { }

        public override string GetBinary()
        {
            throw new NotImplementedException();
        }
    }
}
