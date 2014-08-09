using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OmsiScriptExampler {
    public class StackInspector<T> : Control {
        private AbstractStack<T> _abstractStack;

        public StackInspector(AbstractStack<T> abstractStack) {
            AbstractStack = abstractStack;
            AbstractStack.StateChanged += AbstractStackOnStateChanged;
        }

        public StackInspector() {

        }

        private void AbstractStackOnStateChanged(object sender, EventArgs eventArgs) {
            this.Invalidate();
        }

        public AbstractStack<T> AbstractStack {
            get {
                return _abstractStack;
            }
            set {
                _abstractStack = value;
                if (_abstractStack == null) return;
                _abstractStack.StateChanged += AbstractStackOnStateChanged;
            }
        }

        protected override void OnPaint(PaintEventArgs e) {
            if (AbstractStack == null) {
                return;
            }
            e.Graphics.Clear(Color.White);
            var colWidth = this.Width / 8;
            var rowHeight = this.Height / 2;
            for (int i = 0; i < 8; i++) {
                e.Graphics.DrawString(i.ToString(), this.Font, Brushes.Black, new PointF(colWidth * i, 0));
                var value = AbstractStack.GetItemAt(i);
                if (value == null)
                    continue;
                e.Graphics.DrawString(value.ToString(), this.Font, Brushes.Black, new PointF(colWidth * i, rowHeight));
            } // for end
        }
    }
}
