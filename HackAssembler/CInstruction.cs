using System;
using System.Collections.Generic;

namespace HackAssembler
{
    public class CInstruction : Instruction
    {
        private readonly string destination = String.Empty;

        private readonly string computation = String.Empty;

        private readonly string jump = String.Empty;

        public CInstruction(string destination, string computation, string jump)
        {
            this.destination = destination;

            this.computation = computation;

            this.jump = jump;
        }

        public string GetInstructionAsBinary()
        {
            return String.Empty;
        }

        public Queue<string> GetInstructionQueue()
        {
            Queue<string> instructionQueue = new Queue<string>();

            instructionQueue.Enqueue(computation);

            instructionQueue.Enqueue(destination);

            instructionQueue.Enqueue(jump);

            return instructionQueue;
        }
    }
}
