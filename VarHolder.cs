using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OmsiScriptExampler {
    public class VarHolder<T> {
        public event EventHandler StateChanged;

        protected virtual void OnStateChanged() {
            EventHandler handler = StateChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        public ScriptContext Context {
            get;
            private set;
        }
        public Dictionary<String, T> VariablesValues {
            get;
            set;
        }

        public VarHolder(ScriptContext context) {
            Context = context;
            VariablesValues = new Dictionary<string, T>();
        }

        public void RegisterVarName(String name) {
            VariablesValues.Add(name, default(T));
        }

        public virtual void Set(String name) {

        }

        public T Get(String name) {
            if (!VariablesValues.ContainsKey(name)) {
                RegisterVarName(name);
            } // if end

            return VariablesValues[name];
        }
    }
}
