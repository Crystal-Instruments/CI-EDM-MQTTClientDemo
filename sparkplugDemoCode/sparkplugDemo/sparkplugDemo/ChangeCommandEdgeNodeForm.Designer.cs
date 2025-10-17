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
            this.lblInstructions = new System.Windows.Forms.Label();
            this.lblCurrentEdgeNode = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNewEdgeNodeName = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblInstructions
            // 
            this.lblInstructions.AutoSize = true;
            this.lblInstructions.Location = new System.Drawing.Point(16, 41);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(67, 13);
            this.lblInstructions.TabIndex = 6;
            this.lblInstructions.Text = "Instructions: ";
            // 
            // lblCurrentEdgeNode
            // 
            this.lblCurrentEdgeNode.AutoSize = true;
            this.lblCurrentEdgeNode.Location = new System.Drawing.Point(16, 85);
            this.lblCurrentEdgeNode.Name = "lblCurrentEdgeNode";
            this.lblCurrentEdgeNode.Size = new System.Drawing.Size(104, 13);
            this.lblCurrentEdgeNode.TabIndex = 7;
            this.lblCurrentEdgeNode.Text = "Current Edge Node: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Edge Node To Send Commands: ";
            // 
            // tbNewEdgeNodeName
            // 
            this.tbNewEdgeNodeName.Location = new System.Drawing.Point(188, 125);
            this.tbNewEdgeNodeName.Name = "tbNewEdgeNodeName";
            this.tbNewEdgeNodeName.Size = new System.Drawing.Size(193, 20);
            this.tbNewEdgeNodeName.TabIndex = 9;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(225, 185);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(306, 185);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // ChangeCommandEdgeNodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 211);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tbNewEdgeNodeName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblCurrentEdgeNode);
            this.Controls.Add(this.lblInstructions);
            this.Name = "ChangeCommandEdgeNodeForm";
            this.ShowIcon = false;
            this.Text = "Change Edge Node";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Label lblCurrentEdgeNode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbNewEdgeNodeName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
    }
}