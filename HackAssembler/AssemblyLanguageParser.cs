using System;
using System.Collections.Generic;

namespace HackAssembler
{
    static public class AssemblyLanguageParser
    {
        static public string[] GetMachineCodeArray(string[] assemblyInstructions)
        {
            int lineNumber = 0;

            try
            {
                SymbolHandler symbolHandler = new SymbolHandler(assemblyInstructions);

                assemblyInstructions = symbolHandler.SubstituteSymbolsWithValues(assemblyInstructions);

                Console.WriteLine("Symbols loaded successfully...");

                List<string> machineCodeInstructionArray = new List<string>();

                Instruction newInstruction;

                string newInstructionAsMachineCode;

                foreach (string assemblyInstruction in assemblyInstructions)
                {
                    if (!SyntaxValidator.IsLabel(assemblyInstruction))
                    {
                        newInstruction = GetInstructionFromAssemblyCommand(assemblyInstruction);

                        newInstructionAsMachineCode = newInstruction.GetInstructionAsMachineCode();

                        machineCodeInstructionArray.Add(newInstructionAsMachineCode);

                        lineNumber++;
                    }
                }

                return machineCodeInstructionArray.ToArray();
            }
            catch (Exception e)
            {
                throw new Exception("Error on line " + lineNumber.ToString() + ": " + e.Message);
            }
        }

        static public Instruction GetInstructionFromAssemblyCommand(string assemblyCommand)
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

        static private Instruction TryGetInstructionFromAssemblyCommand(string assemblyCommand)
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

        static private Instruction GetComputationInstruction(string assemblyCommand)
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

            cInstruction = new CInstruction(destination, computation, jump);

            return cInstruction;
        }

        static private Instruction GetAddressInstruction(string assemblyCommand)
        {
            string address = assemblyCommand.Remove(0, 1);

            Instruction addressInstruction = new AInstruction(address);

            return addressInstruction;
        }
    }
}