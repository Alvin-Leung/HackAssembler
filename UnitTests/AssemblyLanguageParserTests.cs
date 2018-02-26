using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HackAssembler;

namespace UnitTests
{
    [TestClass]
    public class AssemblyLanguageParserTests
    {
        [TestMethod]
        public void Parser_InputCorrectlyFormattedAddressCommand_GetCorrectlyParsedInstruction()
        {
            string correctlyFormattedAddressCommand = "@100";

            Instruction instruction = AssemblyLanguageParser.GetInstructionFromAssemblyCommand(correctlyFormattedAddressCommand);

            Queue<InstructionElement> instructionQueue = instruction.GetInstructionElementQueue();

            Assert.AreEqual("100", instructionQueue.Dequeue().instructionElement);
        }

        [TestMethod]
        public void Parser_InputLargestAddressCommandPossible_GetCorrectlyParsedInstruction()
        {
            string largestAddressCommandPossible = "@24576";

            Instruction instruction = AssemblyLanguageParser.GetInstructionFromAssemblyCommand(largestAddressCommandPossible);

            Queue<InstructionElement> instructionQueue = instruction.GetInstructionElementQueue();

            Assert.AreEqual("24576", instructionQueue.Dequeue().instructionElement);
        }

        [TestMethod]
        public void Parser_InputSmallestAddressCommandPossible_GetCorrectlyParsedInstruction()
        {
            string smallestAddressCommandPossible = "@0";

            Instruction instruction = AssemblyLanguageParser.GetInstructionFromAssemblyCommand(smallestAddressCommandPossible);

            Queue<InstructionElement> instructionQueue = instruction.GetInstructionElementQueue();

            Assert.AreEqual("0", instructionQueue.Dequeue().instructionElement);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "An address instruction without an address was inputted")]
        public void Parser_InputAddressCommandWithoutAddress_ThrowException()
        {
            string addressCommandWithoutAddress = "@";

            Instruction instruction = AssemblyLanguageParser.GetInstructionFromAssemblyCommand(addressCommandWithoutAddress);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "An address instruction with an invalid address was inputted")]
        public void Parser_InputAddressCommandWithInvalidAddress_ThrowException()
        {
            string addressCommandWithInvalidAddress = "@InvalidAddress";

            Instruction instruction = AssemblyLanguageParser.GetInstructionFromAssemblyCommand(addressCommandWithInvalidAddress);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "An empty string was inputted")]
        public void Parser_InputEmptyString_ThrowException()
        {
            string emptyString = String.Empty;

            Instruction instruction = AssemblyLanguageParser.GetInstructionFromAssemblyCommand(emptyString);
        }

        [TestMethod]
        public void Parser_InputValidComputationCommandWithSpaces_GetCorrectlyParsedInstruction()
        {
            string validComputationCommandWithSpaces = "M = D+1 ; JEQ";

            Instruction instruction = AssemblyLanguageParser.GetInstructionFromAssemblyCommand(validComputationCommandWithSpaces);

            Queue<InstructionElement> instructionQueue = instruction.GetInstructionElementQueue();

            Assert.AreEqual("D+1", instructionQueue.Dequeue().instructionElement);

            Assert.AreEqual("M", instructionQueue.Dequeue().instructionElement);

            Assert.AreEqual("JEQ", instructionQueue.Dequeue().instructionElement);
        }

        [TestMethod]
        public void Parser_InputValidComputationCommandWithoutSpaces_GetCorrectlyParsedInstruction()
        {
            string validComputationCommandWithoutSpaces = "MD=D+1;JLT";

            Instruction instruction = AssemblyLanguageParser.GetInstructionFromAssemblyCommand(validComputationCommandWithoutSpaces);

            Queue<InstructionElement> instructionQueue = instruction.GetInstructionElementQueue();

            Assert.AreEqual("D+1", instructionQueue.Dequeue().instructionElement);

            Assert.AreEqual("MD", instructionQueue.Dequeue().instructionElement);

            Assert.AreEqual("JLT", instructionQueue.Dequeue().instructionElement);
        }

        [TestMethod]
        public void Parser_InputValidComputationCommandWithWeirdSpacing_GetCorrectlyParsedInstruction()
        {
            string validComputationCommandWithWeirdSpacing = "A =    A+1 ;             JGE";

            Instruction instruction = AssemblyLanguageParser.GetInstructionFromAssemblyCommand(validComputationCommandWithWeirdSpacing);

            Queue<InstructionElement> instructionQueue = instruction.GetInstructionElementQueue();

            Assert.AreEqual("A+1", instructionQueue.Dequeue().instructionElement);

            Assert.AreEqual("A", instructionQueue.Dequeue().instructionElement);

            Assert.AreEqual("JGE", instructionQueue.Dequeue().instructionElement);
        }

        [TestMethod]
        public void Parser_InputValidComputationCommandWithoutJump_GetCorrectlyParsedInstruction()
        {
            string validComputationCommandWithoutJump = "D=D&A";

            Instruction instruction = AssemblyLanguageParser.GetInstructionFromAssemblyCommand(validComputationCommandWithoutJump);

            Queue<InstructionElement> instructionQueue = instruction.GetInstructionElementQueue();

            Assert.AreEqual("D&A", instructionQueue.Dequeue().instructionElement);

            Assert.AreEqual("D", instructionQueue.Dequeue().instructionElement);

            Assert.AreEqual("", instructionQueue.Dequeue().instructionElement);
        }

        [TestMethod]
        public void Parser_InputValidComputationCommandWithoutDestination_GetCorrectlyParsedInstruction()
        {
            string validComputationCommandWithoutDestination = "A-1; JLE";

            Instruction instruction = AssemblyLanguageParser.GetInstructionFromAssemblyCommand(validComputationCommandWithoutDestination);

            Queue<InstructionElement> instructionQueue = instruction.GetInstructionElementQueue();

            Assert.AreEqual("A-1", instructionQueue.Dequeue().instructionElement);

            Assert.AreEqual("", instructionQueue.Dequeue().instructionElement);

            Assert.AreEqual("JLE", instructionQueue.Dequeue().instructionElement);
        }

        [TestMethod]
        public void Parser_InputValidComputationCommandWithoutJumpOrDestination_GetCorrectlyParsedInstruction()
        {
            string validComputationCommandWithoutDestination = "A-D";

            Instruction instruction = AssemblyLanguageParser.GetInstructionFromAssemblyCommand(validComputationCommandWithoutDestination);

            Queue<InstructionElement> instructionQueue = instruction.GetInstructionElementQueue();

            Assert.AreEqual("A-D", instructionQueue.Dequeue().instructionElement);

            Assert.AreEqual("", instructionQueue.Dequeue().instructionElement);

            Assert.AreEqual("", instructionQueue.Dequeue().instructionElement);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "An invalid computation command was used")]
        public void Parser_InputInvalidComputationCommand_ThrowException()
        {
            string invalidComputationCommand = "M=5+A;JUMP";

            Instruction instruction = AssemblyLanguageParser.GetInstructionFromAssemblyCommand(invalidComputationCommand);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "An invalid computation command was used")]
        public void Parser_InputInvalidComputationCommandWithoutDestination_ThrowException()
        {
            string inputInvalidComputationCommandWithoutDestination = "1060;JmP";

            Instruction instruction = AssemblyLanguageParser.GetInstructionFromAssemblyCommand(inputInvalidComputationCommandWithoutDestination);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "An invalid computation command was used")]
        public void Parser_InputInvalidComputationCommandWithoutJump_ThrowException()
        {
            string invalidComputationCommandWithoutJump = "dest=#$%2";

            Instruction instruction = AssemblyLanguageParser.GetInstructionFromAssemblyCommand(invalidComputationCommandWithoutJump);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "An invalid computation command was used")]
        public void Parser_InputInvalidComputationCommandWithoutDestinationOrJump_ThrowException()
        {
            string invalidComputationCommandWithoutDestinationOrJump = "helloWorld";

            Instruction instruction = AssemblyLanguageParser.GetInstructionFromAssemblyCommand(invalidComputationCommandWithoutDestinationOrJump);
        }
    }
}
