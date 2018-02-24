using System;

namespace HackAssembler
{
    public class ComputationInstruction : Instruction
    {
        private readonly string Destination = String.Empty;

        private readonly string Computation = String.Empty;

        private readonly string Jump = String.Empty;

        public ComputationInstruction(string destination, string computation, string jump)
        {
            this.Destination = destination;

            this.Computation = computation;

            this.Jump = jump;
        }

        public string GetInstructionAsBinary()
        {
            return String.Empty;
        }
    }
}
