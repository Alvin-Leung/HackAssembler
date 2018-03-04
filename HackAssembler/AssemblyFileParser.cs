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
                this.SaveAssemblyCommandLinesToList(filepath);
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

        private void SaveAssemblyCommandLinesToList(string filepath)
        {
            string newLine;

            using (StreamReader streamReader = new StreamReader(filepath))
            {
                while (!streamReader.EndOfStream)
                {
                    newLine = streamReader.ReadLine();

                    newLine = RemoveInlineComments(newLine);

                    newLine = RemoveWhitespacePadding(newLine);

                    if (!IsWhitespace(newLine))
                    {
                        assemblyInstructions.Add(newLine);
                    }
                }
            }

            Console.WriteLine(Environment.NewLine + "Assembly file parsed...");
        }

        private string RemoveInlineComments(string line)
        {
            int indexOfCommentStart;

            if (line.Contains(commentIndicator))
            {
                indexOfCommentStart = line.IndexOf(commentIndicator);

                line = line.Remove(indexOfCommentStart);
            }

            return line;
        }

        private string RemoveWhitespacePadding(string line)
        {
            return line.Trim(' ');
        }

        private bool IsWhitespace(string line)
        {
            if (line == String.Empty || line.StartsWith(commentIndicator))
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
