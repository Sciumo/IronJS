﻿using System;
using System.Text;

namespace IronJS.Compiler.Ast
{
    class WhileNode : Node
    {
        private Node Test;
        private Node Body;

        public WhileNode(Node test, Node body)
            : base(NodeType.While)
        {
            Test = test;
            Body = body;
        }

        public override void Print(StringBuilder writer, int indent = 0)
        {
            var indentStr = new String(' ', indent * 2);

            writer.AppendLine(indentStr + "(" + Type);

            Test.Print(writer, indent + 1);
            Body.Print(writer, indent + 1);

            writer.AppendLine(indentStr + ")");
        }

    }
}
