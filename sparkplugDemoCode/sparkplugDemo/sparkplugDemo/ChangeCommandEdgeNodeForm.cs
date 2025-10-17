using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sparkplugDemo
{
    public partial class ChangeCommandEdgeNodeForm : Form
    {
        private string OldCommandEdgeNode { get; set; }
        private string Instructions { get; set; }
        public string NewCommandEdgeNode { get; set; }
        private const string CURRENTNODESTRING = "Current Edge Node: {0}";
        private const string INSTRUCTIONSSTRING = "Instructions: {0}";

        public ChangeCommandEdgeNodeForm(string oldEdgeNode, string instructions = "")
        {
            InitializeComponent();
            OldCommandEdgeNode = oldEdgeNode;
            Instructions = instructions;
            InitializeUI();
            HookEvents(true);
        }

        private void InitializeUI()
        {
            lblCurrentEdgeNode.Text = string.Format(CURRENTNODESTRING, OldCommandEdgeNode);
            lblInstructions.Text = string.Format(INSTRUCTIONSSTRING, Instructions);
        }

        private void HookEvents(bool hook)
        {
            if (hook)
            {
                HookEvents(false);
                btnOk.Click += OnBtnOkClicked;
                btnCancel.Click += OnBtnCancelClicked;
            }
            else
            {
                btnOk.Click -= OnBtnOkClicked;
                btnCancel.Click -= OnBtnCancelClicked;
            }
        }

        private void OnBtnCancelClicked(object sender, EventArgs e)
        {
            Button btnSender = sender as Button;
            if (btnSender == null)
            {
                return;
            }
            DialogResult = DialogResult.Cancel;
        }

        private void OnBtnOkClicked(object sender, EventArgs e)
        {
            Button btnSender = sender as Button;
            if (btnSender == null)
            {
                return;
            }
            NewCommandEdgeNode = tbNewEdgeNodeName.Text;
            DialogResult = DialogResult.OK;
        }
    }
}
