using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace InfixToPostfix1
{
    class InfixToPostfixConverter
    {
        public static string Convert(string expression)
        {
            string result = string.Empty;

            var regexJuniorOperator = new Regex("[()]");
            var regexMidleOperators = new Regex("[-+]");
            var regexSeniorOperators = new Regex("[*/]");
            var regexNumbers = new Regex(@"\d+\.?\d*");
            var regexMathOperations = new Regex("[-+*/()]");
            var regexFindElements = new Regex(@"\d+\.?\d*|[-+*/()]");

            var stack = new Stack<Element>();
            var elements = new List<Element>();
            var matches = regexFindElements.Matches(expression);
            foreach (var match in matches)
            {
                var content = match.ToString();
                elements.Add(new Element
                {
                    Content = content,
                    Type = regexNumbers.IsMatch(content)
                    ? ElementType.IsNumber : regexMathOperations.IsMatch(content)
                    ? ElementType.IsMathOperator : throw new Exception(string.Format("Элемент {0} не может участвовать в выражении!", content)),
                    Priority = regexJuniorOperator.IsMatch(content)
                    ? 1 : regexMidleOperators.IsMatch(content)
                    ? 2 : regexSeniorOperators.IsMatch(content)
                    ? 3 : 0
                });
            }
            for (int i = 0; i < elements.Count;)
            {
                var element = elements[i];
                switch (element.Type)
                {
                    case ElementType.IsNumber:
                        result += element.Content + ' ';
                        i++;
                        break;
                    case ElementType.IsMathOperator:
                        if (stack.Count == 0)
                        {
                            stack.Push(element);
                            i++;
                            break;
                        }
                        if (stack.Count != 0)
                        {
                            if (element.Content == "(")
                            {
                                stack.Push(element);
                                i++;
                                break;
                            }
                            if (element.Content == ")")
                            {
                                do
                                {
                                    result += stack.Pop().Content + ' ';
                                }
                                while (stack.Peek().Content != "(");
                                stack.Pop();
                                i++;
                                break;
                            }
                            if (element.Priority > stack.Peek().Priority)
                            {
                                stack.Push(element);
                                i++;
                                break;
                            }
                            do
                            {
                                result += stack.Pop().Content + ' ';
                                if (stack.Count == 0)
                                {
                                    break;
                                }
                            }
                            while (element.Priority <= stack.Peek().Priority);
                        }
                        break;
                }
            }
            while (stack.Count != 0)
            {
                result += stack.Pop().Content + ' ';
            }

            return result;
        }
    }
}
