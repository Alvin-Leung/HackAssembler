﻿using System.Text.RegularExpressions;

namespace HackAssembler
{
    static public class SyntaxValidator
    {
        static private Regex addressCommandRegex;

        static private Regex destCompJumpCommandRegex;

        static private Regex destCompCommandRegex;

        static private Regex compJumpCommandRegex;

        static private Regex compCommandRegex;

        static SyntaxValidator()
        {
            string addressCommandRegexPattern = @"@\d+";

            string destinationRegexPattern = @"(M|D|MD|A|AM|AD|AMD)";

            string equalSignRegexPattern = @"\s*=\s*";

            string computationRegexPattern =
                @"(0|1|-1|D|A|!D|!A|-D|-A|D\s*(\+|-)\s*(1|A)|A\s*(\+|-)\s*1|A\s*-\s*D|D\s*&\s*A|D\s*\|\s*A|" +
                @"M|!M|-M|M\s*(\+|-)\s*1|D\s*(\+|-)\s*M|M\s*-\s*D|D\s*&\s*M|D\s*\|\s*M)";

            string semicolonRegexPattern = @"\s*;\s*";

            string jumpRegexPattern = @"(JGT|JEQ|JGE|JLT|JNE|JLE|JMP)";

            string endOfLineAnchor = "$";

            addressCommandRegex = new Regex(addressCommandRegexPattern);

            destCompJumpCommandRegex = new Regex(
                destinationRegexPattern +
                equalSignRegexPattern +
                computationRegexPattern +
                semicolonRegexPattern +
                jumpRegexPattern);

            destCompCommandRegex = new Regex(
                destinationRegexPattern +
                equalSignRegexPattern +
                computationRegexPattern);

            compJumpCommandRegex = new Regex(
                computationRegexPattern +
                semicolonRegexPattern +
                jumpRegexPattern);

            compCommandRegex = new Regex(computationRegexPattern + endOfLineAnchor);
        }

        static public bool IsAddressInstruction(string assemblyCommand)
        {
            return addressCommandRegex.IsMatch(assemblyCommand);
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
    }
}