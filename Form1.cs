using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OmsiScriptExampler.Parser;

namespace OmsiScriptExampler {
    public partial class Form1 : Form {
        private ScriptContext _context = new ScriptContext();
        private frmDebugger frmDebugger = new frmDebugger();

        public Form1() {
            InitializeComponent();
            frmDebugger.floatStackInspector1.AbstractStack = _context.FloatAbstractStack;
            frmDebugger.stringStackInspector1.AbstractStack = _context.StringAbstractStack;
            _context.FloatVarHolder.StateChanged += VarHolderOnStateChanged;
            _context.Runner.CurrentTokenChanged += RunnerOnCurrentTokenChanged;
        }

        private void RunnerOnCurrentTokenChanged(object sender, CurrentTokenChangedEventHandler currentTokenChangedEventHandler) {
            if (this.InvokeRequired) {
                this.Invoke(new EventHandler<CurrentTokenChangedEventHandler>(RunnerOnCurrentTokenChanged), sender, currentTokenChangedEventHandler);
                return;
            } // if end
            if (currentTokenChangedEventHandler.CurrentToken == null) {
                this.lblStatusStep.Text = "Bereit.";
                return;
            } // if end
            var lineNumber = richTextBox1.Text.Take(currentTokenChangedEventHandler.CurrentToken.Index).Count(c => c == '\n') + 1;
            this.lblStatusStep.Text = string.Format("{0} @Line {1}; Index {2}", TokenDescriptor.GetDescriptor(currentTokenChangedEventHandler.CurrentToken), lineNumber, currentTokenChangedEventHandler.CurrentToken.Index);
            frmDebugger.richTextBox2.AppendText(TokenDescriptor.GetDescriptor(currentTokenChangedEventHandler.CurrentToken));
            frmDebugger.richTextBox2.AppendText("\n== STACK ==\n");
            frmDebugger.richTextBox2.AppendText(_context.FloatAbstractStack.ToString());
            frmDebugger.richTextBox2.AppendText("\n== == == ==\n\n");
        }

        private void VarHolderOnStateChanged(object sender, EventArgs eventArgs) {
            if (this.InvokeRequired) {
                this.Invoke(new EventHandler(VarHolderOnStateChanged), sender, eventArgs);
                return;
            } // if end

            frmDebugger.listVariables.Items.Clear();
            foreach (var key in _context.FloatVarHolder.VariablesValues.Keys) {
                frmDebugger.listVariables.Items.Add(key + "=" + _context.FloatVarHolder.Get(key).ToString());
            } // foreach end

            foreach (var key in _context.StringVarHolder.VariablesValues.Keys) {
                frmDebugger.listVariables.Items.Add(key + "=\"" + _context.StringVarHolder.Get(key).ToString() + "\"");
            } // foreach end
        }

        private void bttnRun_Click(object sender, EventArgs e) {
            if (_context.Runner.Running) {
                _context.Runner.Running = false;
                return;
            } // if end
            frmDebugger.Visible = false;
            frmDebugger.Show(this);
            frmDebugger.richTextBox2.Text = "";
            _context.Parser.Clear();
            try {
                _context.Parser.ReadTokens(richTextBox1.Text);
            } // try end
            catch(Exception ex) {
                MessageBox.Show(ex.ToString());
            } // catch end
            frmDebugger.listTokens.Items.Clear();
            if (_context.Parser.Tokens != null)
                frmDebugger.listTokens.Items.AddRange(_context.Parser.Tokens.ToArray());

            Task.Factory.StartNew(() => _context.Runner.Run());
        }

        private void chkPause_CheckedChanged(object sender, EventArgs e) {
            _context.Runner.Pause = (sender as CheckBox).Checked;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {
            _context.Runner.StepForStep = (sender as CheckBox).Checked;
        }
    }
}