namespace HackAssembler
{
    public class ComputationInstruction : Instruction
    {
        public ComputationInstruction(string destination, string computation, string jump)
        {
            CommandQueue.Enqueue(destination);

            CommandQueue.Enqueue(computation);

            CommandQueue.Enqueue(jump);
        }
    }
}
