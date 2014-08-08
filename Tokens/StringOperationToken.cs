using System;

namespace OmsiScriptExampler.Tokens {
    public class StringOperationToken : AbstractToken {
        public String Operator {
            get;
            set;
        }

        public StringOperationToken(string @operator) {
            Operator = @operator;
        }
    }
}