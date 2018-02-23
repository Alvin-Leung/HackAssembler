using System;

namespace HackAssembler
{
    public class Parser
    {
        public Instruction GetInstructionFromAssemblyCommand(string assemblyCommand)
        {
            try
            {
                Instruction instruction = TryGetInstructionFromAssemblyCommand(assemblyCommand);

                return instruction;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private Instruction TryGetInstructionFromAssemblyCommand(string assemblyCommand)
        {
            Instruction instruction;

            if (SyntaxValidator.IsAddressInstruction(assemblyCommand))
            {
                instruction = GetAddressInstruction(assemblyCommand);
            }
            else if (SyntaxValidator.IsComputationInstruction(assemblyCommand))
            {
                instruction = GetComputationInstruction(assemblyCommand);
            }
            else
            {
                throw new Exception("Parser.GetInstructionFromAssemblyCommand - Instruction is not valid");
            }

            return instruction;
        }

        private Instruction GetComputationInstruction(string assemblyCommand)
        {
            Instruction cInstruction;

            string destination = String.Empty;

            string computation;

            string jump = String.Empty;

            string[] destAndCompCommand;

            string[] compAndJumpCommand;

            assemblyCommand = assemblyCommand.Replace(" ", "");

            destAndCompCommand = assemblyCommand.Split('=');

            if (destAndCompCommand.Length == 2)
            {
                destination = destAndCompCommand[0];

                compAndJumpCommand = destAndCompCommand[1].Split(';');
            }
            else
            {
                compAndJumpCommand = destAndCompCommand[0].Split(';');
            }

            computation = compAndJumpCommand[0];

            if (compAndJumpCommand.Length == 2)
            {
                jump = compAndJumpCommand[1];
            }

            cInstruction = new ComputationInstruction(destination, computation, jump);

            return cInstruction;
        }

        private Instruction GetAddressInstruction(string assemblyCommand)
        {
            string address = assemblyCommand.Remove(0, 1);

            Instruction addressInstruction = new AddressInstruction(address);

            return addressInstruction;
        }
    }
}