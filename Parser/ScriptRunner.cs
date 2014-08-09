using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OmsiScriptExampler.Tokens;

namespace OmsiScriptExampler.Parser {
    public sealed class ScriptRunner {
        public event EventHandler<CurrentTokenChangedEventHandler> CurrentTokenChanged;
        private static readonly Random _random = new Random();

        public bool StepForStep {
            get;
            set;
        }

        private void OnCurrentTokenChanged(CurrentTokenChangedEventHandler e) {
            EventHandler<CurrentTokenChangedEventHandler> handler = CurrentTokenChanged;
            if (handler != null)
                handler(this, e);
        }

        public bool Running {
            get;
            set;
        }

        public ScriptRunner(ScriptContext context) {
            Context = context;
        }

        public ScriptContext Context {
            get;
            set;
        }

        public void Run() {
            RunBlock("init");
            Running = true;
            Task.Factory.StartNew(() => {
                while (Running)
                    RunBlock("frame");
            });
        }

        public void RunBlock(String name) {

            var blockStart =
                Context.Parser.Tokens.Find(a => (a is BlockToken) && (a as BlockToken).BlockName.Contains(name));

            if (blockStart == null) {
                Running = false;
                Debug.WriteLine("RunBlock( " + name + " ) was not found!");
            } // if end

            var startIndex = Context.Parser.Tokens.IndexOf(blockStart) + 1;

            var blockEnd = 0;

            for (int i = startIndex; i < Context.Parser.Tokens.Count; i++) {
                var tok = Context.Parser.Tokens[i];
                if (tok is BlockToken && (tok as BlockToken).BlockName == "{end}") {
                    break;
                } // if end
                blockEnd++;
            } // for end

            try {
                RunFromTo(startIndex, startIndex + blockEnd);
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
        }

        private void RunFromTo(int start, int end) {
            var block = Context.Parser.Tokens.Skip(start).Take(end - start).ToList();

            Console.WriteLine("Doing block from {0} to {1}| {2}, {3}", start, end, block.First(), block.Last());

            bool handled = false;

            for (int index = 0; index < block.Count; index++) {
                var abstractToken = block[index];
                if (StepForStep)
                    Thread.Sleep(999);

                while (Pause)
                    Thread.Sleep(100);

                if (abstractToken is FloatLiteralToken) {
                    this.Context.FloatAbstractStack.Push((abstractToken as FloatLiteralToken).Value);
                    handled = true;
                } // if end

                if (abstractToken is StringLiteralToken) {
                    this.Context.StringAbstractStack.Push((abstractToken as StringLiteralToken).Value);
                    handled = true;
                } // if end

                if (abstractToken is OperationToken) {
                    var opToken = abstractToken as OperationToken;

                    if (opToken.LeftPoint == "L" && opToken.RightPoint == "L")
                        Context.FloatAbstractStack.Push(Context.FloatVarHolder.Get(opToken.Space));

                    if (opToken.LeftPoint == "S" && opToken.RightPoint == "L")
                        Context.FloatVarHolder.Set(opToken.Space);

                    if (opToken.LeftPoint == "S" && opToken.RightPoint == "$")
                        Context.StringVarHolder.Set(opToken.Space);
                    handled = true;
                } // if end

                if (abstractToken is MathOperationToken) {
                    var mathOp = abstractToken as MathOperationToken;
                    if (mathOp.Operator == "+") {
                        var a = Context.FloatAbstractStack.Pop();
                        var b = Context.FloatAbstractStack.Pop();

                        var addition = a + b;
                        Context.FloatAbstractStack.Push(addition);
                        handled = true;
                    } // if end

                    if (mathOp.Operator == "-") {
                        var a = Context.FloatAbstractStack.Pop();
                        var b = Context.FloatAbstractStack.Pop();

                        var substract = b - a;
                        Context.FloatAbstractStack.Push(substract);
                        handled = true;
                    } // if end

                    if (mathOp.Operator == "/") {
                        var divide = Context.FloatAbstractStack.GetItemAt(1) / Context.FloatAbstractStack.GetItemAt(0);
                        Context.FloatAbstractStack.Push(divide);
                        handled = true;
                    } // if end

                    if (mathOp.Operator == ">") {
                        var result = Context.FloatAbstractStack.GetItemAt(1) > Context.FloatAbstractStack.GetItemAt(0);
                        Context.FloatAbstractStack.Push(result ? 1 : 0);
                        handled = true;
                    } // if end

                    if (mathOp.Operator == "<") {
                        var result = Context.FloatAbstractStack.GetItemAt(1) < Context.FloatAbstractStack.GetItemAt(0);
                        Context.FloatAbstractStack.Push(result ? 1 : 0);
                        handled = true;
                    } // if end

                    if (mathOp.Operator == "random") {
                        var rand = _random.Next(0, (int)this.Context.FloatAbstractStack.GetItemAt(0));
                        Context.FloatAbstractStack.Push(rand);
                        handled = true;
                    } // if end
                } // if end

                if (abstractToken is BlockToken) {
                    var blockToken = abstractToken as BlockToken;
                    if (blockToken.BlockName == "{if}") {
                        if (blockToken.BlockName == "{if}" || blockToken.BlockName == "{else}" ||
                        blockToken.BlockName == "{endif}") {
                            handled = true;
                        } // if end

                        var expression = Math.Abs(Context.FloatAbstractStack.GetItemAt(0) - 1) < float.Epsilon;
                        var len = 0;
                        var ifBlock = new int[2] { index, index };
                        var elseBlock = new int[2] { 0, 0 };

                        bool inElseBlock = false;
                        ifBlock[0] = index;
                        var internalIf = 0;
                        for (var i = index + 1; i < block.Count; i++) {
                            if (block[i] is BlockToken) {
                                var blockTok = block[i] as BlockToken;
                                if (blockTok.BlockName == "{if}")
                                    internalIf++;
                                else if (blockTok.BlockName == "{else}") {
                                    internalIf--;
                                    if (internalIf <= 0) {
                                        inElseBlock = true;
                                        elseBlock[0] = i;
                                        elseBlock[1] = i;
                                    } // if end
                                } // else end
                                else if (internalIf == 0 && blockTok.BlockName == "{endif}") {
                                    break;
                                } // if end
                            } // if end

                            if (!inElseBlock)
                                ifBlock[1]++;
                            else
                                elseBlock[1]++;
                        } // for end

                        if (expression) {
                            Console.WriteLine("Running if.");
                            RunFromTo(start + ifBlock[0] + 1, start + ifBlock[1] + 1);
                        } // if end
                        else {
                            if (elseBlock[0] > 0) {
                                Console.WriteLine("Running else.");
                                RunFromTo(start + elseBlock[0], start + elseBlock[1]);
                            } // if end
                        } // else end

                        index = Math.Max(ifBlock[1], elseBlock[1]);
                    } // if end

                } // if end 


                OnCurrentTokenChanged(new CurrentTokenChangedEventHandler(abstractToken));
            }
            OnCurrentTokenChanged(new CurrentTokenChangedEventHandler(null));
        }

        private void RunIf(int iIfPos) {

        }

        public bool Pause {
            get;
            set;
        }
    }
}
