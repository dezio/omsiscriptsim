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

        /// <summary>
        /// Initializes a new StackEight object.
        /// </summary>
        protected StackEight() {
            this.Clear();
        }

        /// <summary>
        /// Pushes an item.
        /// </summary>
        /// <param name="item"></param>
        public void Push(T item) {
            for (int i = 7; i > 0; i--) {
                _stack[i] = _stack[i - 1];
            } // for end
            _stack[0] = item;
            OnStateChanged();
        }


        /// <summary>
        /// Gets an item from its index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T GetItemAt(int index) {
            return _stack[index];
        }

        public T Pop() {
            var item = GetItemAt(0);
            for (int i = 1; i < 7; i++) {
                _stack[i - 1] = _stack[i];
            } // for end

            _stack[7] = default(T);

            return item;
        }

        /// <summary>
        /// Clears the stack.
        /// </summary>
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
