using Microsoft.VisualStudio.TestTools.UnitTesting;
using HackAssembler;

namespace UnitTests
{
    [TestClass]
    public class SyntaxValidatorTests
    {
        [TestMethod]
        public void IsAddressInstruction_InputValidAddressInstruction_ReturnTrue()
        {
            bool isAddressInstruction = SyntaxValidator.IsAddressInstruction("@1234");
            
            Assert.AreEqual(true, isAddressInstruction);
        }

        [TestMethod]
        public void IsAddressInstruction_InputInvalidAddressInstruction_ReturnFalse()
        {
            bool isAddressInstruction = SyntaxValidator.IsAddressInstruction("@InvalidAddressInstruction");

            Assert.AreEqual(false, isAddressInstruction);
        }

        [TestMethod]
        public void IsAddressInstructionWithSymbol_InputValidAddressInstructionWithSymbol_ReturnTrue()
        {
            bool isAddressInstructionWithLabel = SyntaxValidator.IsAddressInstructionWithSymbol("@R0");
            
            Assert.AreEqual(true, isAddressInstructionWithLabel);
        }

        [TestMethod]
        public void IsAddressInstructionWithSymbol_InputInvalidAddressInstructionWithSymbol_ReturnFalse()
        {
            bool isAddressInstructionWithLabel = SyntaxValidator.IsAddressInstructionWithSymbol("@1InvalidLabel");

            Assert.AreEqual(false, isAddressInstructionWithLabel);
        }

        [TestMethod]
        public void IsComputationInstruction_InputValidComputationInstruction_ReturnTrue()
        {
            bool isComputationInstrucation = SyntaxValidator.IsComputationInstruction("D=D+M");

            Assert.AreEqual(true, isComputationInstrucation);
        }

        [TestMethod]
        public void IsComputationInstruction_InputInvalidComputationInstruction_ReturnFalse()
        {
            bool isComputationInstrucation = SyntaxValidator.IsComputationInstruction("D=SCREEN");

            Assert.AreEqual(false, isComputationInstrucation);
        }

        [TestMethod]
        public void IsLabel_InputValidLabel_ReturnTrue()
        {
            bool isLabel = SyntaxValidator.IsLabel("(TESTLABEL)");

            Assert.AreEqual(true, isLabel);
        }

        [TestMethod]
        public void IsLabel_InputInvalidLabel_ReturnFalse()
        {
            bool isLabel = SyntaxValidator.IsLabel("D=D+1");

            Assert.AreEqual(false, isLabel);
        }
    }
}
