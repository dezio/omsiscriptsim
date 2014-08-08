using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OmsiScriptExampler.Parser;

namespace OmsiScriptExampler {
    public class ScriptContext {

        /// <summary>
        /// The float stack.
        /// </summary>
        public FloatStack FloatStack {
            get;
            set;
        }

        /// <summary>
        /// The script parser
        /// </summary>
        public ScriptParser Parser {
            get;
            private set;
        }

        /// <summary>
        /// The script executor
        /// </summary>
        public ScriptRunner Runner {
            get;
            set;
        }

        public FloatVarHolder FloatVarHolder {
            get;
            set;
        }

        public StringVarHolder StringVarHolder {
            get;
            set;
        }

        public StringStack StringStack {
            get;
            set;
        }

        public ScriptContext() {
            Runner = new ScriptRunner(this);
            FloatStack = new FloatStack();
            StringStack = new StringStack();
            Parser = new ScriptParser();
            FloatVarHolder = new FloatVarHolder(this);
            StringVarHolder = new StringVarHolder(this);
        }
    }
}
