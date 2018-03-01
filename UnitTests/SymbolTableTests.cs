using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HackAssembler;

namespace UnitTests
{
    [TestClass]
    public class SymbolTableTests
    {
        private int minimumROMAddress = 1;

        private int middleROMAddress = 1567;

        private int maximumROMAddress = 65536;

        private int expectedStartingRAMAddress = 16;

        private string labelMinimumROMAddress = "testLabelMin";

        private string labelMiddleROMAddress = "testLabelMid";

        private string labelMaximumROMAddress = "testLabelMax";

        [TestMethod]
        public void Constructor_InstantiateSymbolTable_SymbolTableShouldContainPredefinedSymbols()
        {
            Dictionary<string, int> labelDictionary = GetTestLabelDictionary();

            SymbolTable symbolTable = new SymbolTable(labelDictionary);

            Assert.AreEqual(true, symbolTable.Contains("R0"));

            Assert.AreEqual(true, symbolTable.Contains("THAT"));

            Assert.AreEqual(true, symbolTable.Contains("SCREEN"));

            Assert.AreEqual(true, symbolTable.Contains("R11"));
        }

        [TestMethod]
        public void Constructor_InstantiateSymbolTable_SymbolTableShouldContainPredefinedSymbolsWithCorrectValues()
        {
            Dictionary<string, int> labelDictionary = GetTestLabelDictionary();

            SymbolTable symbolTable = new SymbolTable(labelDictionary);

            Assert.AreEqual("0", symbolTable.GetValue("R0"));

            Assert.AreEqual("4", symbolTable.GetValue("THAT"));

            Assert.AreEqual("16384", symbolTable.GetValue("SCREEN"));

            Assert.AreEqual("11", symbolTable.GetValue("R11"));
        }

        [TestMethod]
        public void Constructor_InstantiateWithLabels_SymbolTableShouldContainLabels()
        {
            Dictionary<string, int> labelDictionary = GetTestLabelDictionary();

            SymbolTable symbolTable = new SymbolTable(labelDictionary);

            Assert.AreEqual(true, symbolTable.Contains(labelMinimumROMAddress));

            Assert.AreEqual(true, symbolTable.Contains(labelMiddleROMAddress));

            Assert.AreEqual(true, symbolTable.Contains(labelMaximumROMAddress));
        }

        [TestMethod]
        public void Constructor_InstantiateWithLabels_SymbolTableShouldContainLabelsWithCorrectValues()
        {
            Dictionary<string, int> labelDictionary = GetTestLabelDictionary();

            SymbolTable symbolTable = new SymbolTable(labelDictionary);

            Assert.AreEqual(minimumROMAddress.ToString(), symbolTable.GetValue(labelMinimumROMAddress));

            Assert.AreEqual(middleROMAddress.ToString(), symbolTable.GetValue(labelMiddleROMAddress));

            Assert.AreEqual(maximumROMAddress.ToString(), symbolTable.GetValue(labelMaximumROMAddress));
        }

        [TestMethod]
        public void AddVariable_AddNewVariableToTable_SymbolTableShouldContainVariableAndCorrectRAMAddress()
        {
            Dictionary<string, int> labelDictionary = GetTestLabelDictionary();

            SymbolTable symbolTable = new SymbolTable(labelDictionary);

            string testVariable1 = "testVariable1";

            string testVariable2 = "testVariable2";

            string testVariable3 = "testVariable3";

            int expectedRAMAddress = this.expectedStartingRAMAddress;

            symbolTable.AddVariable(testVariable1);

            symbolTable.AddVariable(testVariable2);

            symbolTable.AddVariable(testVariable3);

            Assert.AreEqual(expectedRAMAddress.ToString(), symbolTable.GetValue(testVariable1));

            expectedRAMAddress++;

            Assert.AreEqual(expectedRAMAddress.ToString(), symbolTable.GetValue(testVariable2));

            expectedRAMAddress++;

            Assert.AreEqual(expectedRAMAddress.ToString(), symbolTable.GetValue(testVariable3));
        }

        [TestMethod]
        public void AddVariable_AddDuplicateVariableToTable_VariableROMAddressCorrespondsToFirstAdd()
        {
            Dictionary<string, int> labelDictionary = GetTestLabelDictionary();

            SymbolTable symbolTable = new SymbolTable(labelDictionary);

            string variableToAddTwice = "variableToAddTwice";

            symbolTable.AddVariable(variableToAddTwice);

            symbolTable.AddVariable(variableToAddTwice);

            Assert.AreEqual(expectedStartingRAMAddress.ToString(), symbolTable.GetValue(variableToAddTwice));
        }

        [TestMethod]
        public void GetValue_TryToGetSymbolThatDoesNotExist_GetBackEmptyString()
        {
            Dictionary<string, int> labelDictionary = GetTestLabelDictionary();

            SymbolTable symbolTable = new SymbolTable(labelDictionary);

            string symbolThatDoesNotExist = "symbolThatDoesNotExist";

            Assert.AreEqual(String.Empty, symbolTable.GetValue(symbolThatDoesNotExist));
        }

        private Dictionary<string, int> GetTestLabelDictionary()
        {
            Dictionary<string, int> testLabelDictionary = new Dictionary<string, int>()
            {
                {labelMinimumROMAddress, minimumROMAddress},
                {labelMiddleROMAddress, middleROMAddress},
                {labelMaximumROMAddress, maximumROMAddress}
            };

            return testLabelDictionary;
        }
    }
}
