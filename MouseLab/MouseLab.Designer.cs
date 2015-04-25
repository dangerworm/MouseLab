namespace MouseLab
{
    partial class frmMouseLab
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
            this.components = new System.ComponentModel.Container();
            this.stsStrip = new System.Windows.Forms.StatusStrip();
            this.tslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmrTimer = new System.Windows.Forms.Timer(this.components);
            this.lstData = new System.Windows.Forms.ListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.imgGraph = new System.Windows.Forms.PictureBox();
            this.rdoButtons = new System.Windows.Forms.RadioButton();
            this.rdoYAxis = new System.Windows.Forms.RadioButton();
            this.btnGo = new System.Windows.Forms.Button();
            this.stsStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // stsStrip
            // 
            this.stsStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslStatus});
            this.stsStrip.Location = new System.Drawing.Point(0, 354);
            this.stsStrip.Name = "stsStrip";
            this.stsStrip.Size = new System.Drawing.Size(784, 22);
            this.stsStrip.TabIndex = 4;
            this.stsStrip.Text = "statusStrip1";
            // 
            // tslStatus
            // 
            this.tslStatus.Name = "tslStatus";
            this.tslStatus.Size = new System.Drawing.Size(39, 17);
            this.tslStatus.Text = "Ready";
            // 
            // tmrTimer
            // 
            this.tmrTimer.Tick += new System.EventHandler(this.tmrTimer_Tick);
            // 
            // lstData
            // 
            this.lstData.FormattingEnabled = true;
            this.lstData.Location = new System.Drawing.Point(618, 12);
            this.lstData.Name = "lstData";
            this.lstData.Size = new System.Drawing.Size(154, 303);
            this.lstData.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(618, 323);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(154, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save Data";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // imgGraph
            // 
            this.imgGraph.BackColor = System.Drawing.Color.Black;
            this.imgGraph.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgGraph.Location = new System.Drawing.Point(12, 12);
            this.imgGraph.Name = "imgGraph";
            this.imgGraph.Size = new System.Drawing.Size(600, 280);
            this.imgGraph.TabIndex = 1;
            this.imgGraph.TabStop = false;
            this.imgGraph.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imgGraph_MouseDown);
            this.imgGraph.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imgGraph_MouseMove);
            this.imgGraph.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imgGraph_MouseUp);
            // 
            // rdoButtons
            // 
            this.rdoButtons.AutoSize = true;
            this.rdoButtons.Checked = true;
            this.rdoButtons.Location = new System.Drawing.Point(12, 298);
            this.rdoButtons.Name = "rdoButtons";
            this.rdoButtons.Size = new System.Drawing.Size(61, 17);
            this.rdoButtons.TabIndex = 0;
            this.rdoButtons.TabStop = true;
            this.rdoButtons.Text = "Buttons";
            this.rdoButtons.UseVisualStyleBackColor = true;
            this.rdoButtons.CheckedChanged += new System.EventHandler(this.rdoButtons_CheckedChanged);
            // 
            // rdoYAxis
            // 
            this.rdoYAxis.AutoSize = true;
            this.rdoYAxis.Location = new System.Drawing.Point(12, 321);
            this.rdoYAxis.Name = "rdoYAxis";
            this.rdoYAxis.Size = new System.Drawing.Size(53, 17);
            this.rdoYAxis.TabIndex = 1;
            this.rdoYAxis.Text = "Y-axis";
            this.rdoYAxis.UseVisualStyleBackColor = true;
            this.rdoYAxis.CheckedChanged += new System.EventHandler(this.rdoYAxis_CheckedChanged);
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(279, 298);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(65, 48);
            this.btnGo.TabIndex = 5;
            this.btnGo.Text = "Start Recording";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // frmMouseLab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 376);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.rdoYAxis);
            this.Controls.Add(this.rdoButtons);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lstData);
            this.Controls.Add(this.stsStrip);
            this.Controls.Add(this.imgGraph);
            this.MaximizeBox = false;
            this.Name = "frmMouseLab";
            this.Text = "MouseLab";
            this.Load += new System.EventHandler(this.frmMouseLab_Load);
            this.Move += new System.EventHandler(this.frmMouseLab_Move);
            this.Resize += new System.EventHandler(this.frmMouseLab_Resize);
            this.stsStrip.ResumeLayout(false);
            this.stsStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip stsStrip;
        private System.Windows.Forms.ToolStripStatusLabel tslStatus;
        private System.Windows.Forms.Timer tmrTimer;
        private System.Windows.Forms.ListBox lstData;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SaveFileDialog dlgSave;
        private System.Windows.Forms.PictureBox imgGraph;
        private System.Windows.Forms.RadioButton rdoButtons;
        private System.Windows.Forms.RadioButton rdoYAxis;
        private System.Windows.Forms.Button btnGo;

    }
}

