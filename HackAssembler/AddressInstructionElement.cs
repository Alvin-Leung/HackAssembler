namespace HackAssembler
{
    public class AddressInstructionElement : InstructionElement
    {
        public AddressInstructionElement(string instruction) : base(instruction) { }

        public override string GetBinary()
        {
            return Translator.GetBinaryAddressInstruction(this.instructionElement);
        }
    }
}
