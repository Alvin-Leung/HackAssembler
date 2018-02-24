using System;
using System.Collections.Generic;

namespace HackAssembler
{
    public class AddressInstruction : Instruction
    {
        private readonly string address = String.Empty;

        public AddressInstruction(string address)
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
