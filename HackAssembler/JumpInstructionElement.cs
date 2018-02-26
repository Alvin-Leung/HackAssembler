namespace HackAssembler
{
    public class JumpInstructionElement : InstructionElement
    {
        public JumpInstructionElement(string instruction) : base(instruction) { }

        public override string GetMachineCode()
        {
            return Translator.GetJumpInstructionAsMachineCode(this.instructionElement);
        }
    }
}
