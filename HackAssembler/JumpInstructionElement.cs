namespace HackAssembler
{
    public class JumpInstructionElement : InstructionElement
    {
        public JumpInstructionElement(string instruction) : base(instruction) { }

        public override string GetBinary()
        {
            return Translator.GetBinaryJumpInstruction(this.instructionElement);
        }
    }
}
