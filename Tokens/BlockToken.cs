using System;

namespace OmsiScriptExampler.Tokens {
    public class BlockToken : AbstractToken {
        public String BlockName { get; set; }

        public BlockToken(string blockName) {
            BlockName = blockName;
        }
    }
}