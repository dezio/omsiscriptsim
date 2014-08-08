using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OmsiScriptExampler.Parser;

namespace OmsiScriptExampler {
    public class ScriptContext {


        /// <summary>
        /// Gets or sets the script parser
        /// </summary>
        public ScriptParser Parser {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the script executor
        /// </summary>
        public ScriptRunner Runner {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the holder for floating variables
        /// </summary>
        public FloatVarHolder FloatVarHolder {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the holder for string variables
        /// </summary>
        public StringVarHolder StringVarHolder {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the stack of strings.
        /// </summary>
        public StringStack StringStack {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the stack of floats.
        /// </summary>
        public FloatStack FloatStack {
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
