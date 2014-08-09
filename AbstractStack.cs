using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmsiScriptExampler {
    public class AbstractStack<T> {
        public event EventHandler StateChanged;

        protected virtual void OnStateChanged() {
            EventHandler handler = StateChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        private const int StackCapacity = 8;

        private readonly T[] _stack = new T[StackCapacity];

        /// <summary>
        /// Initializes a new AbstractStack object.
        /// </summary>
        protected AbstractStack() {
            this.Clear();
        }

        /// <summary>
        /// Pushes an item.
        /// </summary>
        /// <param name="item"></param>
        public void Push(T item) {
            for (int i = StackCapacity - 1; i > 0; i--) {
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

        /// <summary>
        /// Pops an item and returns it.
        /// </summary>
        /// <returns></returns>
        public T Pop() {
            var item = GetItemAt(0);
            for (int i = 1; i < StackCapacity - 1; i++) {
                _stack[i - 1] = _stack[i];
            } // for end

            _stack[7] = default(T);

            return item;
        }

        /// <summary>
        /// Clears the abstractStack.
        /// </summary>
        public void Clear() {
            for (int i = 0; i < StackCapacity - 1; i++) {
                _stack[i] = default(T);
            } // for end
            OnStateChanged();
        }


        public override string ToString() {
            String str = "";

            int maxChars = 0;

            maxChars = _stack.Max(a => a.ToString().Length) + 1;

            for (int i = 0; i < StackCapacity; i++) {
                str += i.ToString(CultureInfo.InvariantCulture).PadRight(maxChars) + "| ";
            } // for end

            var lineWidth = str.Length;

            str += "\n";

            str += "".PadRight(lineWidth, '─');
            str += "\n";

            for (var i = 0; i < StackCapacity; i++) {
                str += GetItemAt(i).ToString().PadRight(maxChars) + "| ";
                str += "│ ";
            } // for end

            return str;
        }
    }
}
