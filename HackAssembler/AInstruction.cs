using System;
using System.Collections.Generic;

namespace HackAssembler
{
    public class AInstruction : Instruction
    {
        private readonly string address = String.Empty;

        public AInstruction(string address)
        {
            this.address = address;
        }

        public string GetInstructionAsBinary()
        {
            return String.Empty;
        }

        public Queue<string> GetInstructionQueue()
        {
            Queue<string> instructionQueue = new Queue<string>();

            instructionQueue.Enqueue("@");

            instructionQueue.Enqueue(this.address);

            return instructionQueue;
        }
    }
}
