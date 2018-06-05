using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfixToPostfix1
{
    class Element
    {
        public string Content { get; set; }
        public ElementType Type { get; set; }
        public int Priority { get; set; }
    }
}
