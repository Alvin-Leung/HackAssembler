using System;
using System.Collections.Generic;

namespace HackAssembler
{
    static public class Translator
    {
        static private Dictionary<string, string> computationInstructionDictionary;

        static private Dictionary<string, string> destinationInstructionDictionary;

        static private Dictionary<string, string> jumpInstructionDictionary;

        static Translator()
        {
            computationInstructionDictionary = new Dictionary<string, string>()
            {
                {"0",   "0101010"},
                {"1",   "0111111"},
                {"-1",  "0111010"},
                {"D",   "0001100"},
                {"A",   "0110000"},
                {"!D",  "0001101"},
                {"!A",  "0110001"},
                {"-D",  "0001111"},
                {"-A",  "0110011"},
                {"D+1", "0011111"},
                {"A+1", "0110111"},
                {"D-1", "0001110"},
                {"A-1", "0110010"},
                {"D+A", "0000010"},
                {"D-A", "0010011"},
                {"A-D", "0000111"},
                {"D&A", "0000000"},
                {"D|A", "0010101"},
                {"M",   "1110000"},
                {"!M",  "1110001"},
                {"-M",  "1110011"},
                {"M+1", "1110111"},
                {"M-1", "1110010"},
                {"D+M", "1000010"},
                {"D-M", "1010011"},
                {"M-D", "1000111"},
                {"D&M", "1000000"},
                {"D|M", "1010101"}
            };

            destinationInstructionDictionary = new Dictionary<string, string>()
            {
                {"",    "000"},
                {"M",   "001"},
                {"D",   "010"},
                {"MD",  "011"},
                {"A",   "100"},
                {"AM",  "101"},
                {"AD",  "110"},
                {"AMD", "111"}
            };

            jumpInstructionDictionary = new Dictionary<string, string>()
            {
                {"",    "000"},
                {"JGT", "001"},
                {"JEQ", "010"},
                {"JGE", "011"},
                {"JLT", "100"},
                {"JNE", "101"},
                {"JLE", "110"},
                {"JMP", "111"}
            };
        }

        static public string GetBinaryAddressInstruction(string address)
        {
            int addressAsInteger = Int32.Parse(address);

            string addressAsBinaryString = Convert.ToString(addressAsInteger, 2);

            return "0" + addressAsBinaryString;
        }

        static public string GetBinaryDestinationInstruction(string destinationInstruction)
        {
            if (Translator.destinationInstructionDictionary.ContainsKey(destinationInstruction))
            {
                return Translator.destinationInstructionDictionary[destinationInstruction];
            }
            else
            {
                throw new Exception("Destination instruction '" + destinationInstruction + "' does not exist in instruction set");
            }
        }

        static public string GetBinaryComputationInstruction(string computationInstruction)
        {
            if (Translator.computationInstructionDictionary.ContainsKey(computationInstruction))
            {
                return Translator.computationInstructionDictionary[computationInstruction];
            }
            else
            {
                throw new Exception("Computation instruction '" + computationInstruction + "' does not exist in instruction set");
            }
        }

        static public string GetBinaryJumpInstruction(string jumpInstruction)
        {
            if (Translator.jumpInstructionDictionary.ContainsKey(jumpInstruction))
            {
                return Translator.jumpInstructionDictionary[jumpInstruction];
            }
            else
            {
                throw new Exception("Jump instruction '" + jumpInstruction + "' does not exist in instruction set");
            }
        }
    }
}
