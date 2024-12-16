using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Language;
using Newtonsoft.Json.Linq;
using OmniSharp.Extensions.LanguageServer.Protocol.Document;
using OmniSharp.Extensions.LanguageServer.Protocol.Models;
using parser;

namespace server
{
    public class TokenVisitor : Combined1BaseVisitor<object>
    {
        public SemanticTokensBuilder builder;

        public override object VisitType([NotNull] Combined1Parser.TypeContext context)
        {
            builder.Push(
            context.Start.Line - 1,
            context.Start.Column,
            context.Start.Text.Length,
            SemanticTokenType.Class,
            SemanticTokenModifier.Defaults
            );
            return base.VisitType(context);
        }

        public override object VisitVariable([NotNull] Combined1Parser.VariableContext context)
        {
            if (context.ID() != null && context.ID().GetText() == "RESULT")
            {
                /*builder.Push(
                context.Start.Line - 1,
                context.Start.Column,
                context.Start.Text.Length,
                SemanticTokenType.Keyword,
                SemanticTokenModifier.Defaults
                );*/
            }
            return base.VisitVariable(context);
        }

        public override object VisitConstant([NotNull] Combined1Parser.ConstantContext context)
        {
            if (context.BOOL() != null)
            {
                builder.Push(
                context.Start.Line - 1,
                context.Start.Column,
                context.Start.Text.Length,
                SemanticTokenType.Keyword,
                SemanticTokenModifier.Defaults
                );
            }

            if (context.STRING() != null)
            {
                builder.Push(
                context.Start.Line - 1,
                context.Start.Column,
                context.Start.Text.Length,
                SemanticTokenType.String,
                SemanticTokenModifier.Defaults
                );
            }

            if (context.NULL() != null)
            {
                builder.Push(
                context.Start.Line - 1,
                context.Start.Column,
                context.Start.Text.Length,
                SemanticTokenType.Keyword,
                SemanticTokenModifier.Defaults
                );
            }

            if (context.color() != null)
            {
                builder.Push(
                context.Start.Line - 1,
                context.Start.Column,
                "Color".Length,
                SemanticTokenType.Class,
                SemanticTokenModifier.Defaults
                );
                if(context.color().STRING()!=null)
                {
                    builder.Push(
                    context.color().STRING().Symbol.Line - 1,
                    context.color().STRING().Symbol.Column,
                    context.color().STRING().GetText().Length,
                    SemanticTokenType.String,
                    SemanticTokenModifier.Defaults
                    );
                }
            }

            return base.VisitConstant(context);
        }
        public override object VisitAddOp([NotNull] Combined1Parser.AddOpContext context)
        {
            builder.Push(
            context.Start.Line - 1,
            context.Start.Column,
            context.Start.Text.Length,
            SemanticTokenType.Operator,
            SemanticTokenModifier.Defaults
            );
            return base.VisitAddOp(context);
        }

        public override object VisitMultOp([NotNull] Combined1Parser.MultOpContext context)
        {
            builder.Push(
            context.Start.Line - 1,
            context.Start.Column,
            context.Start.Text.Length,
            SemanticTokenType.Operator,
            SemanticTokenModifier.Defaults
            );
            return base.VisitMultOp(context);
        }

        public override object VisitCompareOp([NotNull] Combined1Parser.CompareOpContext context)
        {
            builder.Push(
            context.Start.Line - 1,
            context.Start.Column,
            context.Start.Text.Length,
            SemanticTokenType.Operator,
            SemanticTokenModifier.Defaults
            );
            return base.VisitCompareOp(context);
        }

        public override object VisitBoolOp([NotNull] Combined1Parser.BoolOpContext context)
        {
            builder.Push(
            context.Start.Line - 1,
            context.Start.Column,
            context.Start.Text.Length,
            SemanticTokenType.Operator,
            SemanticTokenModifier.Defaults
            );
            return base.VisitBoolOp(context);
        }
        public override object VisitIfBlock([NotNull] Combined1Parser.IfBlockContext context)
        {
            foreach (var item in context.children)
            {
                if (item is TerminalNodeImpl t && (item.GetText() == "if" || item.GetText() == "else"))
                {
                    builder.Push(
                    t.Payload.Line - 1,
                    t.Payload.Column,
                    t.Payload.Text.Length,
                    SemanticTokenType.Keyword,
                    SemanticTokenModifier.Defaults
                    );
                }
                else
                    Visit(item);
            }
            return null;
        }

        public override object VisitRepeatUntil([NotNull] Combined1Parser.RepeatUntilContext context)
        {
            foreach (var item in context.children)
            {
                if (item is TerminalNodeImpl t && (item.GetText() == "repeat" || item.GetText() == "until"))
                {
                    builder.Push(
                    t.Payload.Line - 1,
                    t.Payload.Column,
                    t.Payload.Text.Length,
                    SemanticTokenType.Keyword,
                    SemanticTokenModifier.Defaults
                    );
                }
                else
                    Visit(item);
            }
            return null;
        }

        public override object VisitStop([NotNull] Combined1Parser.StopContext context)
        {
            builder.Push(
                context.Start.Line - 1,
                context.Start.Column,
                context.Start.Text.Length,
                SemanticTokenType.Keyword,
                SemanticTokenModifier.Defaults
            );
            return base.VisitStop(context);
        }

        public override object VisitCancel([NotNull] Combined1Parser.CancelContext context)
        {
            builder.Push(
                context.Start.Line - 1,
                context.Start.Column,
                context.Start.Text.Length,
                SemanticTokenType.Keyword,
                SemanticTokenModifier.Defaults
            );
            return base.VisitCancel(context);
        }

        public override object VisitFunctionName([NotNull] Combined1Parser.FunctionNameContext context)
        {
            builder.Push(
                context.Start.Line - 1,
                context.Start.Column,
                context.Start.Text.Length,
                SemanticTokenType.Function,
                SemanticTokenModifier.Defaults
            );
            return base.VisitFunctionName(context);
        }

        public override object VisitCollection([NotNull] Combined1Parser.CollectionContext context)
        {
            builder.Push(
                context.Start.Line - 1,
                context.Start.Column,
                context.Start.Text.Length,
                SemanticTokenType.Keyword,
                SemanticTokenModifier.Defaults
            );
            return base.VisitCollection(context);
        }

        public override object VisitComment([NotNull] Combined1Parser.CommentContext context)
        {
            string[] substrings = context.Start.Text.Split("\n");
            for(int i=0; i < substrings.Length;i++)
            {
                builder.Push(
                    context.Start.Line - 1+i,
                    context.Start.Column,
                    context.Start.Text.Length,
                    SemanticTokenType.Comment,
                    SemanticTokenModifier.Defaults
                );
            }
            return null;
        }

        public override object VisitTurnStages([NotNull] Combined1Parser.TurnStagesContext context)
        {
            if (context.functionCall() == null)
            {
                builder.Push(
                    context.Start.Line - 1,
                    context.Start.Column,
                    context.Start.Text.Length,
                    SemanticTokenType.EnumMember,
                    SemanticTokenModifier.Defaults
                );
            }
            return base.VisitTurnStages(context);
        }

        /*public override object VisitTryTurnStages([NotNull] Combined1Parser.TryTurnStagesContext context)
        {
            if (context.functionCall() == null)
            {
                builder.Push(
                context.Start.Line - 1,
                context.Start.Column,
                context.Start.Text.Length,
                SemanticTokenType.EnumMember,
                SemanticTokenModifier.Defaults
                );
            }
            return base.VisitTryTurnStages(context);
        }*/

        public override object VisitPMoveTypeExp([NotNull] Combined1Parser.PMoveTypeExpContext context)
        {
            builder.Push(
                context.Start.Line - 1,
                context.Start.Column,
                context.Start.Text.Length,
                SemanticTokenType.EnumMember,
                SemanticTokenModifier.Defaults
            );
            return base.VisitPMoveTypeExp(context);
        }

        public override object VisitPhase([NotNull] Combined1Parser.PhaseContext context)
        {
            builder.Push(
                context.Start.Line - 1,
                context.Start.Column,
                context.Start.Text.Length,
                SemanticTokenType.Keyword,
                SemanticTokenModifier.Defaults
            );
            return base.VisitPhase(context);
        }
        public override object VisitField([NotNull] Combined1Parser.FieldContext context)
        {
            builder.Push(
                context.Start.Line - 1,
                context.Start.Column,
                context.Start.Text.Length,
                SemanticTokenType.Property,
                SemanticTokenModifier.Defaults
            );
            return base.VisitField(context);
        }

        public override object VisitInput([NotNull] Combined1Parser.InputContext context)
        {
            builder.Push(
                context.Start.Line - 1,
                context.Start.Column,
                ("Input").Length,
                SemanticTokenType.Class,
                SemanticTokenModifier.Defaults
            );
            return base.VisitInput(context);
        }

        public override object VisitInputTypes([NotNull] Combined1Parser.InputTypesContext context)
        {
            builder.Push(
                context.Start.Line - 1,
                context.Start.Column,
                context.Start.Text.Length,
                SemanticTokenType.Function,
                SemanticTokenModifier.Defaults
            );
            return base.VisitInputTypes(context);
        }

        public override object VisitNeighborsExp([NotNull] Combined1Parser.NeighborsExpContext context)
        {
            builder.Push(
                context.Start.Line - 1,
                context.Start.Column,
                context.Start.Text.Length,
                SemanticTokenType.Keyword,
                SemanticTokenModifier.Defaults
            );
            return base.VisitNeighborsExp(context);
        }

        public override object VisitLogStatement([NotNull] Combined1Parser.LogStatementContext context)
        {
            builder.Push(
                context.Start.Line - 1,
                context.Start.Column,
                context.Start.Text.Length,
                SemanticTokenType.Operator,
                SemanticTokenModifier.Defaults
            );
            return base.VisitLogStatement(context);
        }
    }
}
