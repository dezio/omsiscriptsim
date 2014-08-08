namespace OmsiScriptExampler.Tokens {
    public class FloatLiteralToken : AbstractToken {
        public float Value { get; set; }

        public FloatLiteralToken(float value) {
            Value = value;
        }
    }
}