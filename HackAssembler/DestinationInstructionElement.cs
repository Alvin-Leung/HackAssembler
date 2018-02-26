namespace HackAssembler
{
    public class DestinationInstructionElement : InstructionElement
    {
        public DestinationInstructionElement(string instruction) : base(instruction) { }

        public override string GetMachineCode()
        {
            return Translator.GetDestinationInstructionAsMachineCode(this.instructionElement);
        }
    }
}
