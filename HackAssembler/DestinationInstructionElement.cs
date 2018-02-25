namespace HackAssembler
{
    public class DestinationInstructionElement : InstructionElement
    {
        public DestinationInstructionElement(string instruction) : base(instruction) { }

        public override string GetBinary()
        {
            return Translator.GetBinaryDestinationInstruction(this.instructionElement);
        }
    }
}
