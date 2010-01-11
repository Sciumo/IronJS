﻿using System;

namespace IronJS.Compiler.Ast
{
    using Et = System.Linq.Expressions.Expression;

    // 12.6.4
    class ForInNode : Node
    {
        public readonly Node Target;
        public readonly Node Source;
        public readonly Node Body;

        public ForInNode(Node target, Node source, Node body)
            : base(NodeType.ForIn)
        {
            Target = target;
            Source = source;
            Body = body;
        }

        public override Et Walk(EtGenerator etgen)
        {
            throw new NotImplementedException();
        }
    }
}