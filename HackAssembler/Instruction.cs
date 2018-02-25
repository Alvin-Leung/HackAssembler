using System.Collections.Generic;

namespace HackAssembler
{
    public interface Instruction
    {
        string GetInstructionAsBinary();

        Queue<InstructionElement> GetInstructionElementQueue();
    }
}
