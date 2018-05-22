using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleLexer;

namespace MathLibraryTest
{
    [TestClass]
    public class LexerTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            MathLexer l = new MathLexer();
            List<Token> tokens = new List<Token>(l.Tokenize(" 1234 "));
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual("(literal)", tokens[0].Type);
            Assert.AreEqual("1234", tokens[0].Value);
        }
    }
}
