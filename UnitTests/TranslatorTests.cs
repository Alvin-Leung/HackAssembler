using System;
using HackAssembler;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class TranslatorTests
    {
        [TestMethod]
        public void GetBinaryAddressInstruction_InputValidAddress_GetAInstruction()
        {
            string aInstruction = Translator.GetAddressInstructionAsMachineCode("1234");

            Assert.AreEqual("0000010011010010", aInstruction);
        }

        [TestMethod]
        public void GetBinaryAddressInstruction_InputSmallestValidAddress_GetAInstruction()
        {
            string aInstruction = Translator.GetAddressInstructionAsMachineCode("0");

            Assert.AreEqual("0000000000000000", aInstruction);
        }

        [TestMethod]
        public void GetBinaryAddressInstruction_InputLargestValidAddress_GetAInstruction()
        {
            string aInstruction = Translator.GetAddressInstructionAsMachineCode("24576");

            Assert.AreEqual("0110000000000000", aInstruction);
        }

        [TestMethod]
        public void GetBinaryDestinationInstruction_InputValidDestinationInstruction_GetBinaryEquivalent()
        {
            string binaryDestinationInstruction = Translator.GetDestinationInstructionAsMachineCode("D");

            Assert.AreEqual("010", binaryDestinationInstruction);
        }

        [TestMethod]
        public void GetBinaryComputationInstruction_InputValidComputationInstruction_GetBinaryEquivalent()
        {
            string binaryComputationInstruction = Translator.GetComputationInstructionAsMachineCode("D&A");

            Assert.AreEqual("0000000", binaryComputationInstruction);
        }

        [TestMethod]
        public void GetBinaryJumpInstruction_InputValidJumpInstruction_GetBinaryEquivalent()
        {
            string binaryJumpInstruction = Translator.GetJumpInstructionAsMachineCode("JGE");

            Assert.AreEqual("011", binaryJumpInstruction);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetBinaryDestinationInstruction_InputInvalidInstruction_ThrowException()
        {
            Translator.GetComputationInstructionAsMachineCode("HelloWorld");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetBinaryComputationInstruction_InputInvalidInstruction_ThrowException()
        {
            Translator.GetComputationInstructionAsMachineCode("HelloWorld");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetBinaryJumpInstruction_InputInvalidInstruction_ThrowException()
        {
            Translator.GetJumpInstructionAsMachineCode("HelloWorld");
        }
    }
}
