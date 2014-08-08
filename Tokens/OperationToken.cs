using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmsiScriptExampler.Tokens {
    public class OperationToken : AbstractToken {
        public String LeftPoint { get; set; }
        public String RightPoint { get; set; }
        public String Space { get; set; }

        public OperationToken(string leftPoint, string rightPoint, string space) {
            LeftPoint = leftPoint;
            RightPoint = rightPoint;
            Space = space;
        }
    }
}
