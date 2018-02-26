namespace HackAssembler
{
    public class ComputationInstructionElement : InstructionElement
    {
        public ComputationInstructionElement(string instruction) : base(instruction) { }

        public override string GetMachineCode()
        {
            return Translator.GetComputationInstructionAsMachineCode(this.instructionElement);
        }
    }
}
