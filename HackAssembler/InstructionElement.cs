using System;

namespace HackAssembler
{
    public abstract class InstructionElement
    {
        public readonly string instructionElement = String.Empty;

        public InstructionElement(string instructionElement)
        {
            this.instructionElement = instructionElement;
        }

        public abstract string GetBinary();
    }
}
