namespace sparkplugDemo
{
    partial class ChangeCommandEdgeNodeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCurrentEdgeNode = new DevComponents.DotNetBar.LabelX();
            this.lblChangeEdgeNode = new DevComponents.DotNetBar.LabelX();
            this.tbNewEdgeNodeName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.lblInstructions = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // lblCurrentEdgeNode
            // 
            // 
            // 
            // 
            this.lblCurrentEdgeNode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCurrentEdgeNode.Location = new System.Drawing.Point(12, 65);
            this.lblCurrentEdgeNode.Name = "lblCurrentEdgeNode";
            this.lblCurrentEdgeNode.Size = new System.Drawing.Size(112, 23);
            this.lblCurrentEdgeNode.TabIndex = 0;
            this.lblCurrentEdgeNode.Text = "Current Edge Node: ";
            // 
            // lblChangeEdgeNode
            // 
            // 
            // 
            // 
            this.lblChangeEdgeNode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblChangeEdgeNode.Location = new System.Drawing.Point(12, 114);
            this.lblChangeEdgeNode.Name = "lblChangeEdgeNode";
            this.lblChangeEdgeNode.Size = new System.Drawing.Size(166, 23);
            this.lblChangeEdgeNode.TabIndex = 1;
            this.lblChangeEdgeNode.Text = "Edge Node To Send Commands: ";
            // 
            // tbNewEdgeNodeName
            // 
            // 
            // 
            // 
            this.tbNewEdgeNodeName.Border.Class = "TextBoxBorder";
            this.tbNewEdgeNodeName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbNewEdgeNodeName.Location = new System.Drawing.Point(187, 114);
            this.tbNewEdgeNodeName.Name = "tbNewEdgeNodeName";
            this.tbNewEdgeNodeName.PreventEnterBeep = true;
            this.tbNewEdgeNodeName.Size = new System.Drawing.Size(185, 20);
            this.tbNewEdgeNodeName.TabIndex = 2;
            // 
            // btnOk
            // 
            this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOk.Location = new System.Drawing.Point(306, 185);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "Ok";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(225, 185);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cnacel";
            // 
            // lblInstructions
            // 
            // 
            // 
            // 
            this.lblInstructions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblInstructions.Location = new System.Drawing.Point(12, 25);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(360, 23);
            this.lblInstructions.TabIndex = 5;
            this.lblInstructions.Text = "Instructions: ";
            // 
            // ChangeCommandEdgeNodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 211);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.tbNewEdgeNodeName);
            this.Controls.Add(this.lblChangeEdgeNode);
            this.Controls.Add(this.lblCurrentEdgeNode);
            this.Name = "ChangeCommandEdgeNodeForm";
            this.Text = "Change Edge Node";
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX lblCurrentEdgeNode;
        private DevComponents.DotNetBar.LabelX lblChangeEdgeNode;
        private DevComponents.DotNetBar.Controls.TextBoxX tbNewEdgeNodeName;
        private DevComponents.DotNetBar.ButtonX btnOk;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.LabelX lblInstructions;
    }
}