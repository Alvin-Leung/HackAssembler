using System;
using System.IO;
using System.Collections.Generic;

namespace HackAssembler
{
    public class AssemblyFileParser
    {
        private List<string> assemblyInstructions = new List<string>();

        private string commentIndicator = "//";

        public AssemblyFileParser(string filepath)
        {
            if (File.Exists(filepath))
            {
                this.SaveFileLinesToList(filepath);
            }
            else
            {
                throw new Exception("AssemblyFileParser::AssemblyFileParser - The specified file does not exist");
            }
        }

        public string[] GetArrayOfAssemblyInstructions()
        {
            return assemblyInstructions.ToArray();
        }

        private void SaveFileLinesToList(string filepath)
        {
            string newLine;

            using (StreamReader streamReader = new StreamReader(filepath))
            {
                while (!streamReader.EndOfStream)
                {
                    newLine = streamReader.ReadLine();

                    if (!IsWhitespace(newLine))
                    {
                        assemblyInstructions.Add(newLine);
                    }
                }
            }
        }

        private bool IsWhitespace(string line)
        {
            if (line == String.Empty || line.StartsWith(commentIndicator) || IsAllSpaces(line))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsAllSpaces(string line)
        {
            string lineWithSpacesRemoved = line.Trim();

            if (lineWithSpacesRemoved.Length == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
