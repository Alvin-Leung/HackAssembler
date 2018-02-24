using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HackAssembler;

namespace UnitTests
{
    [TestClass]
    public class ParserTests
    {
        private Parser parser = new Parser();

        [TestMethod]
        public void Parser_InputCorrectlyFormattedAddressCommand_GetCorrectlyParsedInstruction()
        {
            string correctlyFormattedAddressCommand = "@100";

            Instruction instruction = parser.GetInstructionFromAssemblyCommand(correctlyFormattedAddressCommand);

            Queue<string> instructionQueue = instruction.GetInstructionQueue();

            Assert.AreEqual("@", instructionQueue.Dequeue());

            Assert.AreEqual("100", instructionQueue.Dequeue());
        }

        [TestMethod]
        public void Parser_InputLargestAddressCommandPossible_GetCorrectlyParsedInstruction()
        {
            string largestAddressCommandPossible = "@24576";

            Instruction instruction = parser.GetInstructionFromAssemblyCommand(largestAddressCommandPossible);

            Queue<string> instructionQueue = instruction.GetInstructionQueue();

            Assert.AreEqual("@", instructionQueue.Dequeue());

            Assert.AreEqual("24576", instructionQueue.Dequeue());
        }

        [TestMethod]
        public void Parser_InputSmallestAddressCommandPossible_GetCorrectlyParsedInstruction()
        {
            string smallestAddressCommandPossible = "@0";

            Instruction instruction = parser.GetInstructionFromAssemblyCommand(smallestAddressCommandPossible);

            Queue<string> instructionQueue = instruction.GetInstructionQueue();

            Assert.AreEqual("@", instructionQueue.Dequeue());

            Assert.AreEqual("0", instructionQueue.Dequeue());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "An address instruction without an address was inputted")]
        public void Parser_InputAddressCommandWithoutAddress_ThrowException()
        {
            string addressCommandWithoutAddress = "@";

            Instruction instruction = parser.GetInstructionFromAssemblyCommand(addressCommandWithoutAddress);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "An address instruction with an invalid address was inputted")]
        public void Parser_InputAddressCommandWithInvalidAddress_ThrowException()
        {
            string addressCommandWithInvalidAddress = "@InvalidAddress";

            Instruction instruction = parser.GetInstructionFromAssemblyCommand(addressCommandWithInvalidAddress);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "An empty string was inputted")]
        public void Parser_InputEmptyString_ThrowException()
        {
            string emptyString = String.Empty;

            Instruction instruction = parser.GetInstructionFromAssemblyCommand(emptyString);
        }

        [TestMethod]
        public void Parser_InputValidComputationCommandWithSpaces_GetCorrectlyParsedInstruction()
        {
            string validComputationCommandWithSpaces = "M = D+1 ; JEQ";

            Instruction instruction = parser.GetInstructionFromAssemblyCommand(validComputationCommandWithSpaces);

            Queue<string> instructionQueue = instruction.GetInstructionQueue();

            Assert.AreEqual("D+1", instructionQueue.Dequeue());

            Assert.AreEqual("M", instructionQueue.Dequeue());

            Assert.AreEqual("JEQ", instructionQueue.Dequeue());
        }

        [TestMethod]
        public void Parser_InputValidComputationCommandWithoutSpaces_GetCorrectlyParsedInstruction()
        {
            string validComputationCommandWithoutSpaces = "MD=D+1;JLT";

            Instruction instruction = parser.GetInstructionFromAssemblyCommand(validComputationCommandWithoutSpaces);

            Queue<string> instructionQueue = instruction.GetInstructionQueue();

            Assert.AreEqual("D+1", instructionQueue.Dequeue());

            Assert.AreEqual("MD", instructionQueue.Dequeue());

            Assert.AreEqual("JLT", instructionQueue.Dequeue());
        }

        [TestMethod]
        public void Parser_InputValidComputationCommandWithWeirdSpacing_GetCorrectlyParsedInstruction()
        {
            string validComputationCommandWithWeirdSpacing = "A =    A+1 ;             JGE";

            Instruction instruction = parser.GetInstructionFromAssemblyCommand(validComputationCommandWithWeirdSpacing);

            Queue<string> instructionQueue = instruction.GetInstructionQueue();

            Assert.AreEqual("A+1", instructionQueue.Dequeue());

            Assert.AreEqual("A", instructionQueue.Dequeue());

            Assert.AreEqual("JGE", instructionQueue.Dequeue());
        }

        [TestMethod]
        public void Parser_InputValidComputationCommandWithoutJump_GetCorrectlyParsedInstruction()
        {
            string validComputationCommandWithoutJump = "D=D&A";

            Instruction instruction = parser.GetInstructionFromAssemblyCommand(validComputationCommandWithoutJump);

            Queue<string> instructionQueue = instruction.GetInstructionQueue();

            Assert.AreEqual("D&A", instructionQueue.Dequeue());

            Assert.AreEqual("D", instructionQueue.Dequeue());

            Assert.AreEqual("", instructionQueue.Dequeue());
        }

        [TestMethod]
        public void Parser_InputValidComputationCommandWithoutDestination_GetCorrectlyParsedInstruction()
        {
            string validComputationCommandWithoutDestination = "A-1; JLE";

            Instruction instruction = parser.GetInstructionFromAssemblyCommand(validComputationCommandWithoutDestination);

            Queue<string> instructionQueue = instruction.GetInstructionQueue();

            Assert.AreEqual("A-1", instructionQueue.Dequeue());

            Assert.AreEqual("", instructionQueue.Dequeue());

            Assert.AreEqual("JLE", instructionQueue.Dequeue());
        }

        [TestMethod]
        public void Parser_InputValidComputationCommandWithoutJumpOrDestination_GetCorrectlyParsedInstruction()
        {
            string validComputationCommandWithoutDestination = "A-D";

            Instruction instruction = parser.GetInstructionFromAssemblyCommand(validComputationCommandWithoutDestination);

            Queue<string> instructionQueue = instruction.GetInstructionQueue();

            Assert.AreEqual("A-D", instructionQueue.Dequeue());

            Assert.AreEqual("", instructionQueue.Dequeue());

            Assert.AreEqual("", instructionQueue.Dequeue());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "An invalid computation command was used")]
        public void Parser_InputInvalidComputationCommand_ThrowException()
        {
            string invalidComputationCommand = "M=5+A;JUMP";

            Instruction instruction = parser.GetInstructionFromAssemblyCommand(invalidComputationCommand);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "An invalid computation command was used")]
        public void Parser_InputInvalidComputationCommandWithoutDestination_ThrowException()
        {
            string inputInvalidComputationCommandWithoutDestination = "1060;JmP";

            Instruction instruction = parser.GetInstructionFromAssemblyCommand(inputInvalidComputationCommandWithoutDestination);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "An invalid computation command was used")]
        public void Parser_InputInvalidComputationCommandWithoutJump_ThrowException()
        {
            string invalidComputationCommandWithoutJump = "dest=#$%2";

            Instruction instruction = parser.GetInstructionFromAssemblyCommand(invalidComputationCommandWithoutJump);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "An invalid computation command was used")]
        public void Parser_InputInvalidComputationCommandWithoutDestinationOrJump_ThrowException()
        {
            string invalidComputationCommandWithoutDestinationOrJump = "helloWorld";

            Instruction instruction = parser.GetInstructionFromAssemblyCommand(invalidComputationCommandWithoutDestinationOrJump);
        }
    }
}
