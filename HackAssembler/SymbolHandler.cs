using System.Collections.Generic;

namespace HackAssembler
{
    public class SymbolHandler
    {
        private SymbolTable symbolTable;

        public SymbolHandler(string[] assemblyInstructions)
        {
            Dictionary<string, int> labelDictionary = new Dictionary<string, int>();

            string label;

            int instructionLineNumber = 0;

            foreach (string instruction in assemblyInstructions)
            {
                if (SyntaxValidator.IsLabel(instruction))
                {
                    label = instruction.Trim('(', ')');

                    labelDictionary.Add(label, instructionLineNumber);
                }
                else
                {
                    instructionLineNumber++;
                }
            }

            symbolTable = new SymbolTable(labelDictionary);
        }

        public string[] SubstituteSymbolsWithValues(string[] assemblyInstructions)
        {
            List<string> assemblyInstructionsWithoutSymbols = new List<string>();

            foreach (string instruction in assemblyInstructions)
            {
                if (!SyntaxValidator.IsLabel(instruction))
                {
                    if (SyntaxValidator.IsAddressInstructionWithSymbol(instruction))
                    {
                        string addressSymbol = instruction.Remove(0, 1);

                        if (!symbolTable.Contains(addressSymbol))
                        {
                            symbolTable.AddVariable(addressSymbol);
                        }

                        assemblyInstructionsWithoutSymbols.Add("@" + symbolTable.GetValue(addressSymbol));
                    }
                    else
                    {
                        assemblyInstructionsWithoutSymbols.Add(instruction);
                    }
                }
            }

            return assemblyInstructionsWithoutSymbols.ToArray();
        }
    }
}
