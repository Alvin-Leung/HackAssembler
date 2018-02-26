namespace HackAssembler
{
    public class AddressInstructionElement : InstructionElement
    {
        public AddressInstructionElement(string instruction) : base(instruction) { }

        public override string GetMachineCode()
        {
            return Translator.GetAddressInstructionAsMachineCode(this.instructionElement);
        }
    }
}
