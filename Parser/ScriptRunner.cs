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
                Context.Parser.Tokens.Find(
                    delegate(AbstractToken a) {
                        return (a is BlockToken) && (a as BlockToken).BlockName.Contains(name);
                    });

            if (blockStart == null) {
                Running = false;
                Debug.WriteLine("RunBlock( "+name + " ) was not found!");
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

            RunFromTo(startIndex, startIndex + blockEnd);
        }

        private void RunFromTo(int start, int end) {
            var block = Context.Parser.Tokens.Skip(start).Take(end - start);

            bool handled = false;
            foreach (var abstractToken in block) {
                if (StepForStep)
                    Thread.Sleep(999);

                while (Pause) {
                    Thread.Sleep(100);
                } // while end

                if (abstractToken is FloatLiteralToken) {
                    this.Context.FloatStack.Push((abstractToken as FloatLiteralToken).Value);
                    handled = true;
                } // if end

                if (abstractToken is StringLiteralToken) {
                    this.Context.StringStack.Push((abstractToken as StringLiteralToken).Value);
                    handled = true;
                } // if end

                if (abstractToken is OperationToken) {
                    var opToken = abstractToken as OperationToken;

                    if (opToken.LeftPoint == "L" && opToken.RightPoint == "L") {
                        Context.FloatStack.Push(Context.FloatVarHolder.Get(opToken.Space));
                    } // if end

                    if (opToken.LeftPoint == "S" && opToken.RightPoint == "L") {
                        Context.FloatVarHolder.Set(opToken.Space);
                    } // if end

                    if (opToken.LeftPoint == "S" && opToken.RightPoint == "$") {
                        Context.StringVarHolder.Set(opToken.Space);
                    } // if end
                    handled = true;
                } // if end

                if (abstractToken is MathOperationToken) {
                    var mathOp = abstractToken as MathOperationToken;
                    if (mathOp.Operator == "+") {
                        var addition = Context.FloatStack.GetItemAt(0) + Context.FloatStack.GetItemAt(1);
                        Context.FloatStack.Clear();
                        Context.FloatStack.Push(addition);
                        handled = true;
                    } // if end

                    if (mathOp.Operator == "-") {
                        var substract = Context.FloatStack.GetItemAt(1) - Context.FloatStack.GetItemAt(0);
                        Context.FloatStack.Clear();
                        Context.FloatStack.Push(substract);
                        handled = true;
                    } // if end

                    if (mathOp.Operator == "/") {
                        var divide = Context.FloatStack.GetItemAt(1) / Context.FloatStack.GetItemAt(0);
                        Context.FloatStack.Clear();
                        Context.FloatStack.Push(divide);
                        handled = true;
                    } // if end

                    if (mathOp.Operator == "random") {
                        var rand = _random.Next(0, (int)this.Context.FloatStack.GetItemAt(0));
                        Context.FloatStack.Push(rand);
                        handled = true;
                    } // if end

                } // if end

                if (!handled) {
                    throw new Exception("Unhandled token: " + TokenDescriptor.GetDescriptor(abstractToken));
                } // if end

                OnCurrentTokenChanged(new CurrentTokenChangedEventHandler(abstractToken));
            } // foreach end
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
