using System;

namespace HackAssembler
{
    public abstract class InstructionElement
    {
        protected string instructionElement { get; set; } = String.Empty;

        public InstructionElement(string instructionElement)
        {
            this.instructionElement = instructionElement;
        }

        public abstract string GetBinary();
    }
}
