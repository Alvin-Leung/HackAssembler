using System;
using System.Collections.Generic;

namespace HackAssembler
{
    public class CInstruction : Instruction
    {
        private DestinationInstructionElement destinationInstructionElement;

        private ComputationInstructionElement computationInstructionElement;

        private JumpInstructionElement jumpInstructionElement;

        public CInstruction(string destination, string computation, string jump)
        {
            this.destinationInstructionElement = new DestinationInstructionElement(destination);

            this.computationInstructionElement = new ComputationInstructionElement(computation);

            this.jumpInstructionElement = new JumpInstructionElement(jump);
        }

        public string GetInstructionAsBinary()
        {
            return String.Empty;
        }

        public Queue<InstructionElement> GetInstructionElementQueue()
        {
            Queue<InstructionElement> instructionQueue = new Queue<InstructionElement>();

            instructionQueue.Enqueue(this.computationInstructionElement);

            instructionQueue.Enqueue(this.destinationInstructionElement);

            instructionQueue.Enqueue(this.jumpInstructionElement);

            return instructionQueue;
        }
    }
}
