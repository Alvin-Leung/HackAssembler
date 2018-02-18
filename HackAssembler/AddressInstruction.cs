namespace HackAssembler
{
    public class AddressInstruction : Instruction
    {
        public AddressInstruction(string address)
        {
            CommandQueue.Enqueue("@");

            CommandQueue.Enqueue(address);
        }
    }
}
