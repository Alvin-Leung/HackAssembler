using System;
using System.Collections.Generic;

namespace HackAssembler
{
    public class SymbolTable
    {
        private Dictionary<string, string> symbolDictionary;

        private int currentVariableRAMAddress = 16;

        public SymbolTable(Dictionary<string, int> labelDictionary)
        {
            symbolDictionary = new Dictionary<string, string>()
            {
                {"R0",  "0"},
                {"R1",  "1"},
                {"R2",  "2"},
                {"R3",  "3"},
                {"R4",  "4"},
                {"R5",  "5"},
                {"R6",  "6"},
                {"R7",  "7"},
                {"R8",  "8"},
                {"R9",  "9"},
                {"R10", "10"},
                {"R11", "11"},
                {"R12", "12"},
                {"R13", "13"},
                {"R14", "14"},
                {"R15", "15"},
                {"SCREEN", "16384"},
                {"KBD", "24576"},
                {"SP", "0"},
                {"LCL", "1"},
                {"ARG", "2"},
                {"THIS", "3"},
                {"THAT", "4"}
            };

            foreach (KeyValuePair<string, int> keyValuePair in labelDictionary)
            {
                this.symbolDictionary.Add(keyValuePair.Key, keyValuePair.Value.ToString());
            }
        }

        public bool Contains(string symbol)
        {
            return this.symbolDictionary.ContainsKey(symbol);
        }

        public void AddVariable(string variable)
        {
            if (!symbolDictionary.ContainsKey(variable))
            {
                string currentVariableRAMAddress = this.currentVariableRAMAddress.ToString();

                this.symbolDictionary.Add(variable, currentVariableRAMAddress);

                this.currentVariableRAMAddress++;
            }
        }

        public string GetValue(string symbol)
        {
            if (symbolDictionary.ContainsKey(symbol))
            {
                return symbolDictionary[symbol];
            }
            else
            {
                return String.Empty;
            }
        }
    }
}
