using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OmsiScriptExampler {
    public class StackInspector<T> : Control {
        private StackEight<T> _stack;

        public StackInspector(StackEight<T> stack) {
            Stack = stack;
            Stack.StateChanged += StackOnStateChanged;
        }

        public StackInspector() {

        }

        private void StackOnStateChanged(object sender, EventArgs eventArgs) {
            this.Invalidate();
        }

        public StackEight<T> Stack {
            get {
                return _stack;
            }
            set {
                _stack = value;
                if (_stack == null) return;
                _stack.StateChanged += StackOnStateChanged;
            }
        }

        protected override void OnPaint(PaintEventArgs e) {
            if (Stack == null) {
                return;
            }
            e.Graphics.Clear(Color.White);
            var colWidth = this.Width / 8;
            var rowHeight = this.Height / 2;
            for (int i = 0; i < 8; i++) {
                e.Graphics.DrawString(i.ToString(), this.Font, Brushes.Black, new PointF(colWidth * i, 0));
                var value = Stack.GetItemAt(i);
                if (value == null)
                    continue;
                e.Graphics.DrawString(value.ToString(), this.Font, Brushes.Black, new PointF(colWidth * i, rowHeight));
            } // for end
        }
    }
}
