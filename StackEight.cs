using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmsiScriptExampler {
    public class StackEight<T> {
        public event EventHandler StateChanged;

        protected virtual void OnStateChanged() {
            EventHandler handler = StateChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        private readonly T[] _stack = new T[8];

        protected StackEight() {
            for (int i = 0; i < 8; i++) {
                _stack[i] = default(T);
            } // for end
        }

        public void Push(T item) {
            for (int i = 7; i > 0; i--) {
                _stack[i] = _stack[i - 1];
            } // for end
            _stack[0] = item;
            OnStateChanged();
        }

        public T GetItemAt(int index) {
            return _stack[index];
        }
        
        public void Clear() {
            for (int i = 0; i < 8; i++) {
                _stack[i] = default(T);
            } // for end
            OnStateChanged();
        }

        public override string ToString() {
            String str = "";

            int maxChars = 0;

            for (int i = 0; i < 8; i++) {
                maxChars = Math.Max(maxChars, GetItemAt(i).ToString().Length);
            } // for end

            maxChars++;
            for (int i = 0; i < 8; i++) {
                str += i.ToString().PadRight(maxChars);
                str += "| ";
            } // for end

            int lineWidth = str.Length;

            str += "\n";

            str += "".PadRight(lineWidth, '─');
            str += "\n";

            for (int i = 0; i < 8; i++) {
                str += GetItemAt(i).ToString().PadRight(maxChars);
                str += "│ ";
            } // for end

            return str;
        }
    }
}
