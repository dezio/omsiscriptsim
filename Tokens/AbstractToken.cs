using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmsiScriptExampler.Tokens {
    public class AbstractToken {
        public override string ToString() {
            return TokenDescriptor.GetDescriptor(this);
        }

        public int Index { get; set; }
    }
}
