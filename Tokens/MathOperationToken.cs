using System;

namespace OmsiScriptExampler.Tokens {
    public class MathOperationToken : AbstractToken {
        public String Operator { get; set; }

        public MathOperationToken(string @operator) {
            Operator = @operator;
        }
    }
}