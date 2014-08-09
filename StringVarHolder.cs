namespace OmsiScriptExampler {
    public class StringVarHolder : VarHolder<string> {

        public StringVarHolder(ScriptContext context)
            : base(context) {
        }

        public override void Set(string name) {
            if (!VariablesValues.ContainsKey(name)) {
                RegisterVarName(name);
            } // if end
            VariablesValues[name] = Context.StringAbstractStack.GetItemAt(0);
            OnStateChanged();
        }
    }
}