using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using OmsiScriptExampler.Tokens;

namespace OmsiScriptExampler {
    /// <summary>
    /// Descriptor
    /// </summary>
    class TokenDescriptor {
        /// <summary>
        /// Gets an string that describes the action of a token.
        /// </summary>
        /// <param name="abstractToken"></param>
        /// <returns></returns>
        public static String GetDescriptor(AbstractToken abstractToken) {
            if (abstractToken is FloatLiteralToken) {
                return "Pusche die Zahl " + (abstractToken as FloatLiteralToken).Value + " in den abstractStack.";
            } // if end

            if (abstractToken is OperationToken) {
                var opToken = abstractToken as OperationToken;

                if (opToken.LeftPoint == "L" && opToken.RightPoint == "L") {
                    var wert = opToken.Space;
                    return "Pusche den Wert " + wert + " in den abstractStack";
                } // if end

                if (opToken.LeftPoint == "S" && opToken.RightPoint == "L") {
                    var wert = opToken.Space;

                    return "Lese den Wert von abstractStack 0 und speichere ihn in " + wert;
                } // if end

                if (opToken.LeftPoint == "S" && opToken.RightPoint == "$") {
                    var wert = opToken.Space;

                    return "Lese den String-Wert von abstractStack 0 und speichere ihn in " + wert;
                } // if end
            } // if end

            if (abstractToken is MathOperationToken) {
                var mathOp = abstractToken as MathOperationToken;
                if (mathOp.Operator == "+")
                    return "Addiere die ersten beiden Zahlen im abstractStack und pusche das Ergebnis.";
                if (mathOp.Operator == "-")
                    return "Substrahiere die ersten beiden Zahlen im abstractStack und pusche das Ergebnis.";
                if (mathOp.Operator == "random")
                    return "Erstelle eine zufällige Zahl mit n = [größer 0 kleiner abstractStack-Wert 0].";
                if (mathOp.Operator == "/")
                    return "Dividiere die ersten beiden Zahlen im abstractStack und pusche das Ergebnis.";
            } // if end

            if (abstractToken is StringLiteralToken) {
                return "Pusche die Zeichenfolge \"" + (abstractToken as StringLiteralToken).Value + "\" in den String-abstractStack.";
            } // if end

            if (abstractToken is BlockToken) {
                var block = abstractToken as BlockToken;
                if (block.BlockName.Contains("{end}")) {
                    return "Blockende";
                } // if end
                return "Blockstart von " + block.BlockName;
            } // if end

            return abstractToken.GetType().Name;
        }
    }
}
