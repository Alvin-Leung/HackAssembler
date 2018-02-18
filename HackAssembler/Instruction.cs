using System.Collections.Generic;

namespace HackAssembler
{
    public class Instruction
    {
        static public Instruction EmptyInstruction = new Instruction();

        public Queue<string> CommandQueue = new Queue<string>();
    }
}
