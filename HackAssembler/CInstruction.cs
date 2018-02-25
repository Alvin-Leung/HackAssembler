using System.Collections.Generic;

namespace HackAssembler
{
    public class CInstruction : Instruction
    {
        private DestinationInstructionElement destinationInstructionElement;

        private ComputationInstructionElement computationInstructionElement;

        private JumpInstructionElement jumpInstructionElement;

        private readonly string startBits = "111";

        public CInstruction(string destination, string computation, string jump)
        {
            this.destinationInstructionElement = new DestinationInstructionElement(destination);

            this.computationInstructionElement = new ComputationInstructionElement(computation);

            this.jumpInstructionElement = new JumpInstructionElement(jump);
        }

        public Queue<InstructionElement> GetInstructionElementQueue()
        {
            Queue<InstructionElement> instructionElementQueue = new Queue<InstructionElement>();

            instructionElementQueue.Enqueue(this.computationInstructionElement);

            instructionElementQueue.Enqueue(this.destinationInstructionElement);

            instructionElementQueue.Enqueue(this.jumpInstructionElement);

            return instructionElementQueue;
        }

        public string GetInstructionAsBinary()
        {
            Queue<InstructionElement> instructionElementQueue = GetInstructionElementQueue();

            return startBits + Translator.GetCompleteBinaryInstruction(instructionElementQueue);
        }
    }
}
