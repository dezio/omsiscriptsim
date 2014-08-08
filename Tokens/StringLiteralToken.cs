using System;

namespace OmsiScriptExampler.Tokens {
    public class StringLiteralToken : AbstractToken {
        public String Value {
            get;
            set;
        }

        public StringLiteralToken(string value) {
            Value = value;
        }
    }
}