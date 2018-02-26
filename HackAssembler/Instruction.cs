using System.Collections.Generic;

namespace HackAssembler
{
    public interface Instruction
    {
        Queue<InstructionElement> GetInstructionElementQueue();

        string GetInstructionAsMachineCode();
    }
}
