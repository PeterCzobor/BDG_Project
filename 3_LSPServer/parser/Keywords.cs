using Language;
using OmniSharp.Extensions.LanguageServer.Protocol.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parser
{
    public class Keywords
    {
        public static List<string> keywords = new List<string>
        {
            "Player",
            "Piece",
            "Tile",
            "Dice",
            "List",
            "if",
            "else",
            "repeat",
            "until",
            "true",
            "false",
            "NULL",
            "AND",
            "OR",
            "stop",
            "cancel",
            "all",
            "none",
            "any",
            "count",
            "Phase",
            "Rule",
            "Turn",
            "EndTurn",
            "WinCondition",
            "MoveTo",
            "Remove",
            "TryTurn",
            "DrawCondition",
            "Move",
            "Find",
            "pieces",
            "tiles",
            "posX",
            "posY",
            "player",
            "color",
            "Color",
            "route",
            "empty",
            "routePosition",
            "texture",
            "type",
            "name",
            "value",
            "size",
            "active",
            "text",
            "SelectPiece",
            "SelectTile",
            "CheckRule",
            "Roll",
            "INPUT",
            "Click",
            "Press",
            "Step",
            "Slide",
            "Jump"
        };

        public CompletionList<Data> variableKeywords = new CompletionList<Data>();
        public CompletionList<Data> otherKeywords = new CompletionList<Data>(
             new CompletionItem<Data>()
             {
                 Label = "Player",
                 Kind = CompletionItemKind.Class
             },
             new CompletionItem<Data>()
             {
                 Label = "Piece",
                 Kind = CompletionItemKind.Class
             },
             new CompletionItem<Data>()
             {
                 Label = "Tile",
                 Kind = CompletionItemKind.Class
             },
             new CompletionItem<Data>()
             {
                 Label = "Dice",
                 Kind = CompletionItemKind.Class
             },
             new CompletionItem<Data>()
             {
                 Label = "List",
                 Kind = CompletionItemKind.Class
             },
             new CompletionItem<Data>()
             {
                 Label = "Remove",
                 Kind = CompletionItemKind.Function
             },
             new CompletionItem<Data>()
             {
                 Label = "Phase",
                 Kind = CompletionItemKind.Keyword
             },
             new CompletionItem<Data>()
             {
                 Label = "if",
                 Kind = CompletionItemKind.Keyword
             },
             new CompletionItem<Data>()
             {
                 Label = "else",
                 Kind = CompletionItemKind.Keyword
             },
             new CompletionItem<Data>()
             {
                 Label = "repeat",
                 Kind = CompletionItemKind.Keyword
             },
             new CompletionItem<Data>()
             {
                 Label = "until",
                 Kind = CompletionItemKind.Keyword
             },
             new CompletionItem<Data>()
             {
                 Label = "stop",
                 Kind = CompletionItemKind.Keyword
             },
             new CompletionItem<Data>()
             {
                 Label = "cancel",
                 Kind = CompletionItemKind.Keyword
             },
             new CompletionItem<Data>()
             {
                 Label = "SelectPiece",
                 Kind = CompletionItemKind.EnumMember
             },
             new CompletionItem<Data>()
             {
                 Label = "SelectTile",
                 Kind = CompletionItemKind.EnumMember
             },
             new CompletionItem<Data>()
             {
                 Label = "CheckRule",
                 Kind = CompletionItemKind.EnumMember
             },
             new CompletionItem<Data>()
             {
                 Label = "INPUT",
                 Kind = CompletionItemKind.Event
             },
             new CompletionItem<Data>()
             {
                 Label = "Click",
                 Kind = CompletionItemKind.Event
             },
             new CompletionItem<Data>()
             {
                 Label = "Press",
                 Kind = CompletionItemKind.Event
             },
             new CompletionItem<Data>()
             {
                 Label = "AND",
                 Kind = CompletionItemKind.Operator
             },
             new CompletionItem<Data>()
             {
                 Label = "OR",
                 Kind = CompletionItemKind.Operator
             },
             new CompletionItem<Data>()
             {
                 Label = "true",
                 Kind = CompletionItemKind.Keyword
             },
             new CompletionItem<Data>()
             {
                 Label = "false",
                 Kind = CompletionItemKind.Keyword
             },
             new CompletionItem<Data>()
             {
                 Label = "NULL",
                 Kind = CompletionItemKind.Keyword
             }
             );
        public CompletionList<Data> KeywordsByValue(object value)
        {
            switch (value)
            {
                case Player:
                    return new CompletionList<Data>(
                        new CompletionItem<Data>()
                        {
                            Label = "name",
                            Kind = CompletionItemKind.Property,
                            Documentation = new StringOrMarkupContent(new MarkupContent()
                            {
                                Kind = MarkupKind.Markdown,
                                Value = $"{VisitorHelper.GetValueDetails(VisitorHelper.classColor("Player") + ".name")}"
                            })
                        },
                        new CompletionItem<Data>()
                        {
                            Label = "pieces",
                            Kind = CompletionItemKind.Property,
                            Documentation = new StringOrMarkupContent(new MarkupContent()
                            {
                                Kind = MarkupKind.Markdown,
                                Value = $"{VisitorHelper.GetValueDetails(VisitorHelper.classColor("Player") + ".pieces")}"
                            })
                        },
                        new CompletionItem<Data>()
                        {
                            Label = "Turn",
                            Kind = CompletionItemKind.Function,
                            Documentation = new StringOrMarkupContent(new MarkupContent()
                            {
                                Kind = MarkupKind.Markdown,
                                Value = $"{VisitorHelper.GetFuncString("Turn")}"
                            })
                        },
                        new CompletionItem<Data>()
                        {
                            Label = "TryTurn",
                            Kind = CompletionItemKind.Function,
                            Documentation = new StringOrMarkupContent(new MarkupContent()
                            {
                                Kind = MarkupKind.Markdown,
                                Value = $"{VisitorHelper.GetFuncString("TryTurn")}"
                            })

                        },
                        new CompletionItem<Data>()
                        {
                            Label = "Rule",
                            Kind = CompletionItemKind.Function
                        },
                        new CompletionItem<Data>()
                        {
                            Label = "EndTurn",
                            Kind = CompletionItemKind.Function,
                            Documentation = new StringOrMarkupContent(new MarkupContent()
                            {
                                Kind = MarkupKind.Markdown,
                                Value = $"{VisitorHelper.GetFuncString("EndTurn")}"
                            })
                        },
                        new CompletionItem<Data>()
                        {
                            Label = "WinCondition",
                            Kind = CompletionItemKind.Function
                        }
                    );
                case Piece:
                    return new CompletionList<Data>(
                        new CompletionItem<Data>()
                        {
                            Label = "posX",
                            Kind = CompletionItemKind.Property,
                            Documentation = new StringOrMarkupContent(new MarkupContent()
                            {
                                Kind = MarkupKind.Markdown,
                                Value = $"{VisitorHelper.GetValueDetails(VisitorHelper.classColor("Piece")+".posX")}"
                            })
                        },
                        new CompletionItem<Data>()
                        {
                            Label = "posY",
                            Kind = CompletionItemKind.Property,
                            Documentation = new StringOrMarkupContent(new MarkupContent()
                            {
                                Kind = MarkupKind.Markdown,
                                Value = $"{VisitorHelper.GetValueDetails(VisitorHelper.classColor("Piece") + ".posY")}"
                            })
                        },
                        new CompletionItem<Data>()
                        {
                            Label = "color",
                            Kind = CompletionItemKind.Property,
                            Documentation = new StringOrMarkupContent(new MarkupContent()
                            {
                                Kind = MarkupKind.Markdown,
                                Value = $"{VisitorHelper.GetValueDetails(VisitorHelper.classColor("Piece") + ".color")}"
                            })
                        },
                        new CompletionItem<Data>()
                        {
                            Label = "player",
                            Kind = CompletionItemKind.Property,
                            Documentation = new StringOrMarkupContent(new MarkupContent()
                            {
                                Kind = MarkupKind.Markdown,
                                Value = $"{VisitorHelper.GetValueDetails(VisitorHelper.classColor("Piece") + ".player")}"
                            })
                        },
                        new CompletionItem<Data>()
                        {
                            Label = "route",
                            Kind = CompletionItemKind.Property,
                            Documentation = new StringOrMarkupContent(new MarkupContent()
                            {
                                Kind = MarkupKind.Markdown,
                                Value = $"{VisitorHelper.GetValueDetails(VisitorHelper.classColor("Piece") + ".route")}"
                            })
                        },
                        new CompletionItem<Data>()
                        {
                            Label = "routePosition",
                            Kind = CompletionItemKind.Property,
                            Documentation = new StringOrMarkupContent(new MarkupContent()
                            {
                                Kind = MarkupKind.Markdown,
                                Value = $"{VisitorHelper.GetValueDetails(VisitorHelper.classColor("Piece") + ".routePosition")}"
                            })
                        },
                        new CompletionItem<Data>()
                        {
                            Label = "texture",
                            Kind = CompletionItemKind.Property,
                            Documentation = new StringOrMarkupContent(new MarkupContent()
                            {
                                Kind = MarkupKind.Markdown,
                                Value = $"{VisitorHelper.GetValueDetails(VisitorHelper.classColor("Piece") + ".texture")}"
                            })
                        },
                        new CompletionItem<Data>()
                        {
                            Label = "type",
                            Kind = CompletionItemKind.Property,
                            Documentation = new StringOrMarkupContent(new MarkupContent()
                            {
                                Kind = MarkupKind.Markdown,
                                Value = $"{VisitorHelper.GetValueDetails(VisitorHelper.classColor("Piece") + ".type")}"
                            })
                        },
                        new CompletionItem<Data>()
                        {
                            Label = "Step",
                            Kind = CompletionItemKind.Function,
                            Documentation = new StringOrMarkupContent(new MarkupContent()
                            {
                                Kind = MarkupKind.Markdown,
                                Value = $"{VisitorHelper.GetFuncString("Step")}"
                            })
                        },
                        new CompletionItem<Data>()
                        {
                            Label = "Rule",
                            Kind = CompletionItemKind.Function
                        }
                    );
                case Tile:
                    return new CompletionList<Data>(
                        new CompletionItem<Data>()
                        {
                            Label = "posX",
                            Kind = CompletionItemKind.Property,
                            Documentation = new StringOrMarkupContent(new MarkupContent()
                            {
                                Kind = MarkupKind.Markdown,
                                Value = $"{VisitorHelper.GetValueDetails(VisitorHelper.classColor("Tile") + ".posX")}"
                            })
                        },
                        new CompletionItem<Data>()
                        {
                            Label = "posY",
                            Kind = CompletionItemKind.Property,
                            Documentation = new StringOrMarkupContent(new MarkupContent()
                            {
                                Kind = MarkupKind.Markdown,
                                Value = $"{VisitorHelper.GetValueDetails(VisitorHelper.classColor("Tile") + ".posY")}"
                            })
                        },
                        new CompletionItem<Data>()
                        {
                            Label = "pieces",
                            Kind = CompletionItemKind.Property,
                            Documentation = new StringOrMarkupContent(new MarkupContent()
                            {
                                Kind = MarkupKind.Markdown,
                                Value = $"{VisitorHelper.GetValueDetails(VisitorHelper.classColor("Tile") + ".pieces")}"
                            })
                        },
                        new CompletionItem<Data>()
                        {
                            Label = "empty",
                            Kind = CompletionItemKind.Property,
                            Documentation = new StringOrMarkupContent(new MarkupContent()
                            {
                                Kind = MarkupKind.Markdown,
                                Value = $"{VisitorHelper.GetValueDetails(VisitorHelper.classColor("Tile") + ".empty")}"
                            })
                        }
                    );
                case Dice:
                    return new CompletionList<Data>(
                        new CompletionItem<Data>()
                        {
                            Label = "value",
                            Kind = CompletionItemKind.Property,
                            Documentation = new StringOrMarkupContent(new MarkupContent()
                            {
                                Kind = MarkupKind.Markdown,
                                Value = $"{VisitorHelper.GetValueDetails(VisitorHelper.classColor("Dice") + ".value")}"
                            })
                        }
                    );
                case IList:
                    return new CompletionList<Data>(
                        new CompletionItem<Data>()
                        {
                            Label = "all",
                            Kind = CompletionItemKind.Keyword
                        },
                        new CompletionItem<Data>()
                        {
                            Label = "any",
                            Kind = CompletionItemKind.Keyword
                        },
                        new CompletionItem<Data>()
                        {
                            Label = "none",
                            Kind = CompletionItemKind.Keyword
                        },
                        new CompletionItem<Data>()
                        {
                            Label = "count",
                            Kind = CompletionItemKind.Keyword
                        },
                        new CompletionItem<Data>()
                        {
                            Label = "Add",
                            Kind = CompletionItemKind.Function
                        },
                        new CompletionItem<Data>()
                        {
                            Label = "Move",
                            Kind = CompletionItemKind.Function
                        },
                        new CompletionItem<Data>()
                        {
                            Label = "Find",
                            Kind = CompletionItemKind.Function
                        }
                    );
            }
            return null;
        }

        public CompletionList<Data> KeywordsByString(string value)
        {
            switch (value)
            {
                case "pieces":
                    return KeywordsByValue(new List<Piece>() { new Piece() });
                case "tiles":
                    return KeywordsByValue(new List<Tile>() { new Tile() });
                case "player":
                    return KeywordsByValue(new Player());
                case "route":
                    return KeywordsByValue(new List<Tile>() { new Tile() });
            }
            if (value.Contains("pieces"))
                return KeywordsByValue(new Piece());
            if (value.Contains("tiles"))
                return KeywordsByValue(new Tile());

            return otherKeywords.Concat(variableKeywords).ToList();
        }
    }
}
