using System;
using OmsiScriptExampler.Tokens;

namespace OmsiScriptExampler.Parser {
    public class CurrentTokenChangedEventHandler : EventArgs {
        public AbstractToken CurrentToken {
            get;
            set;
        }

        public CurrentTokenChangedEventHandler(AbstractToken currentToken) {
            CurrentToken = currentToken;
        }
    }
}