using System.Text.RegularExpressions;

namespace HackAssembler
{
    static public class SyntaxValidator
    {
        static private Regex addressCommandRegex;

        static private Regex addressCommandWithSymbolRegex;

        static private Regex destCompJumpCommandRegex;

        static private Regex destCompCommandRegex;

        static private Regex compJumpCommandRegex;

        static private Regex compCommandRegex;

        static private Regex labelRegex;

        static SyntaxValidator()
        {
            string startOfStringAnchor = "^";

            string addressCommandRegexPattern = @"@\d+";

            string addressCommandWithSymbolRegexPattern = @"@[A-z]\S*";

            string destinationRegexPattern = @"(M|D|MD|A|AM|AD|AMD)";

            string equalSignRegexPattern = @"\s*=\s*";

            string computationRegexPattern =
                @"(0|1|-1|D|A|!D|!A|-D|-A|D\s*(\+|-)\s*(1|A)|A\s*(\+|-)\s*1|A\s*-\s*D|D\s*&\s*A|D\s*\|\s*A|" +
                @"M|!M|-M|M\s*(\+|-)\s*1|D\s*(\+|-)\s*M|M\s*-\s*D|D\s*&\s*M|D\s*\|\s*M)";

            string semicolonRegexPattern = @"\s*;\s*";

            string jumpRegexPattern = @"(JGT|JEQ|JGE|JLT|JNE|JLE|JMP)";

            string endOfLineAnchor = "$";

            string labelRegexPattern = @"\([A-z]\S*\)";

            addressCommandRegex = new Regex(
                startOfStringAnchor + 
                addressCommandRegexPattern +
                endOfLineAnchor);

            addressCommandWithSymbolRegex = new Regex(
                startOfStringAnchor + 
                addressCommandWithSymbolRegexPattern +
                endOfLineAnchor);

            destCompJumpCommandRegex = new Regex(
                startOfStringAnchor + 
                destinationRegexPattern +
                equalSignRegexPattern +
                computationRegexPattern +
                semicolonRegexPattern +
                jumpRegexPattern +
                endOfLineAnchor);

            destCompCommandRegex = new Regex(
                startOfStringAnchor +
                destinationRegexPattern +
                equalSignRegexPattern +
                computationRegexPattern +
                endOfLineAnchor);

            compJumpCommandRegex = new Regex(
                startOfStringAnchor +
                computationRegexPattern +
                semicolonRegexPattern +
                jumpRegexPattern +
                endOfLineAnchor);

            compCommandRegex = new Regex(
                startOfStringAnchor + 
                computationRegexPattern + 
                endOfLineAnchor);

            labelRegex = new Regex(
                startOfStringAnchor + 
                labelRegexPattern + 
                endOfLineAnchor);
        }

        static public bool IsAddressInstruction(string assemblyCommand)
        {
            return addressCommandRegex.IsMatch(assemblyCommand);
        }

        static public bool IsAddressInstructionWithSymbol(string assemblyCommand)
        {
            return addressCommandWithSymbolRegex.IsMatch(assemblyCommand);
        }

        static public bool IsComputationInstruction(string assemblyCommand)
        {
            if (destCompCommandRegex.IsMatch(assemblyCommand))
            {
                return true;
            }
            else if (destCompJumpCommandRegex.IsMatch(assemblyCommand))
            {
                return true;
            }
            else if (compJumpCommandRegex.IsMatch(assemblyCommand))
            {
                return true;
            }
            else if (compCommandRegex.IsMatch(assemblyCommand))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static public bool IsLabel(string assemblyCommand)
        {
            return labelRegex.IsMatch(assemblyCommand);
        }
    }
}
