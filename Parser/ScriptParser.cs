using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using OmsiScriptExampler.Tokens;

namespace OmsiScriptExampler.Parser {
    public class ScriptParser {
        public List<AbstractToken> Tokens {
            get;
            private set;
        }

        public void Clear() {
            Tokens.Clear();
        }

        public ScriptParser() {
            Tokens = new List<AbstractToken>();
        }

        private void AddToken(AbstractToken token, int startIndex) {
            token.Index = startIndex;
            Tokens.Add(token);
        }

        public void ReadTokens(String code) {
            for (int i = 0; i < code.Length; i++) {
                #region Parse blocks
                if (code[i] == '{') {
                    var assumedBlockStringBuilder = new StringBuilder();
                    while (code[i] != '}') {
                        assumedBlockStringBuilder.Append(code[i]);
                        i++;
                    } // while end
                    assumedBlockStringBuilder.Append('}');
                    AddToken(new BlockToken(assumedBlockStringBuilder.ToString()), i);
                    continue;
                } // if end
                #endregion

                #region Parse (A.B.X)-Commands
                if (code[i] == '(') {
                    int startIndex = i;
                    var assumedBlockStringBuilder = new StringBuilder();
                    while (code[i] != ')') {
                        assumedBlockStringBuilder.Append(code[i]);
                        i++;
                    } // while end
                    assumedBlockStringBuilder.Append(')');
                    var match = assumedBlockStringBuilder.ToString().Substring(1, assumedBlockStringBuilder.Length - 2).Split('.');
                    AddToken(new OperationToken(match[0], match[1], match[2]), startIndex);
                    continue;
                } // if end

                #endregion

                #region Parse float numbers
                if ((code[i] == '-' && char.IsDigit(code[i + 1])) || char.IsDigit(code[i])) {
                    int startIndex = i;
                    var assumedBlockStringBuilder = new StringBuilder();
                    while (code[i] != ' ') {
                        assumedBlockStringBuilder.Append(code[i]);
                        i++;
                    } // while end

                    var num = assumedBlockStringBuilder.ToString().Trim();
                    num = num.Replace(".", ",");
                    AddToken(new FloatLiteralToken(float.Parse(num)), startIndex);
                    continue;
                } // if end
                #endregion 

                #region Mathematicals
                if (code[i] == '+') {
                    AddToken(new MathOperationToken("+"), i);
                    continue;
                } // if end

                if (code[i] == '-') {
                    AddToken(new MathOperationToken("-"), i);
                    continue;
                } // if end

                if (code[i] == '*') {
                    AddToken(new MathOperationToken("*"), i);
                    continue;
                } // if end

                if (code[i] == '/') {
                    AddToken(new MathOperationToken("/"), i);
                    continue;
                } // if end

                #endregion

                #region Special Mathematicals
                if (code[i] == 'r' && code.Substring(i, "random".Length) == "random") {
                    AddToken(new MathOperationToken("random"), i);
                    continue;
                }
                #endregion

                #region String parsing
                if (code[i] == '"') {
                    int startIndex = i;
                    var assumedBlockStringBuilder = new StringBuilder();
                    i++;
                    while (code[i] != '"') {
                        assumedBlockStringBuilder.Append(code[i]);
                        i++;
                    } // while end

                    var value = assumedBlockStringBuilder.ToString();
                    AddToken(new StringLiteralToken(value), startIndex);
                    continue;
                }
                #endregion
            } // for end
        }
    }
}
