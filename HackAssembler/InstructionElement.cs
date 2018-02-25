using System;

namespace HackAssembler
{
    public abstract class InstructionElement
    {
        protected string instruction { get; set; } = String.Empty;

        public InstructionElement(string instruction)
        {
            this.instruction = instruction;
        }

        public abstract string GetBinary();
    }
}
