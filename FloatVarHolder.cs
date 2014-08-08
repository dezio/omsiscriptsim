namespace OmsiScriptExampler {
    public class FloatVarHolder : VarHolder<float> {

        public FloatVarHolder(ScriptContext context)
            : base(context) {

        }

        public override void Set(string name) {
            if (!VariablesValues.ContainsKey(name)) {
                RegisterVarName(name);
            } // if end
            VariablesValues[name] = Context.FloatStack.GetItemAt(0);
            OnStateChanged();
        }
    }
}