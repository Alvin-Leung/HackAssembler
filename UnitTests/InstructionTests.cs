using HackAssembler;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class InstructionTests
    {
        [TestMethod]
        public void AInstruction_InstantiateWithValidAddress_BinaryInstructionIsCorrect()
        {
            AInstruction aInstruction = new AInstruction("4578");

            Assert.AreEqual("0001000111100010", aInstruction.GetInstructionAsMachineCode());
        }

        [TestMethod]
        public void CInstruction_InstantiateWithValidInputs_BinaryInstructionIsCorrect()
        {
            CInstruction cInstruction = new CInstruction("M", "M+1", "JMP");

            Assert.AreEqual("1111110111001111", cInstruction.GetInstructionAsMachineCode());
        }

        [TestMethod]
        public void CInstruction_InstantiateWithValidInputs2_BinaryInstructionIsCorrect()
        {
            CInstruction cInstruction = new CInstruction("AM", "D&M", "JLE");

            Assert.AreEqual("1111000000101110", cInstruction.GetInstructionAsMachineCode());
        }
    }
}
