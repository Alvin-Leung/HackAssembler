using System.Collections.Generic;

namespace HackAssembler
{
    public class AInstruction : Instruction
    {
        private AddressInstructionElement addressInstructionElement;

        public AInstruction(string address)
        {
            this.addressInstructionElement = new AddressInstructionElement(address);
        }

        public Queue<InstructionElement> GetInstructionElementQueue()
        {
            Queue<InstructionElement> instructionElementQueue = new Queue<InstructionElement>();

            instructionElementQueue.Enqueue(this.addressInstructionElement);

            return instructionElementQueue;
        }

        public string GetInstructionAsMachineCode()
        {
            Queue<InstructionElement> instructionElementQueue = GetInstructionElementQueue();

            return Translator.GetCompleteMachineCodeInstruction(instructionElementQueue);
        }
    }
}
