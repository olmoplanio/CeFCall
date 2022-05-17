using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CeFDllDemo
{
	internal partial class MainForm
	{
	#region Windows Form Designer generated code 
		[System.Diagnostics.DebuggerNonUserCode()]
        public MainForm()
            : base()
		{
			//This call is required by the Windows Form Designer.
			InitializeComponent();
		}
		//Form overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]
		protected override void Dispose(bool Disposing)
		{
			if (Disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(Disposing);
		}
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
        public System.Windows.Forms.ToolTip ToolTip1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ComboPort = new System.Windows.Forms.ComboBox();
            this.Text3 = new System.Windows.Forms.TextBox();
            this.buttonReadVersion = new System.Windows.Forms.Button();
            this.checkBuffer = new System.Windows.Forms.CheckBox();
            this.checkReadStatus = new System.Windows.Forms.CheckBox();
            this.checkDGFEAlmostFull = new System.Windows.Forms.CheckBox();
            this.checkDGFEFull = new System.Windows.Forms.CheckBox();
            this.checkNearPaperEnd = new System.Windows.Forms.CheckBox();
            this.checkPaperEnd = new System.Windows.Forms.CheckBox();
            this.checkCoverOpen = new System.Windows.Forms.CheckBox();
            this.buttonReadStatus = new System.Windows.Forms.Button();
            this.Text2 = new System.Windows.Forms.TextBox();
            this.buttonReadLine = new System.Windows.Forms.Button();
            this.buttonReadDate = new System.Windows.Forms.Button();
            this.Text1 = new System.Windows.Forms.TextBox();
            this.Combo1 = new System.Windows.Forms.ComboBox();
            this.buttonPrintTicket = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ComboPort
            // 
            this.ComboPort.BackColor = System.Drawing.SystemColors.Window;
            this.ComboPort.Cursor = System.Windows.Forms.Cursors.Default;
            this.ComboPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboPort.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboPort.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ComboPort.Location = new System.Drawing.Point(76, 239);
            this.ComboPort.Name = "ComboPort";
            this.ComboPort.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ComboPort.Size = new System.Drawing.Size(73, 22);
            this.ComboPort.TabIndex = 8;
            this.ComboPort.SelectedIndexChanged += new System.EventHandler(this.ComboPort_SelectedIndexChanged);
            // 
            // Text3
            // 
            this.Text3.AcceptsReturn = true;
            this.Text3.BackColor = System.Drawing.SystemColors.Window;
            this.Text3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Text3.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Text3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Text3.Location = new System.Drawing.Point(192, 120);
            this.Text3.MaxLength = 0;
            this.Text3.Name = "Text3";
            this.Text3.ReadOnly = true;
            this.Text3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text3.Size = new System.Drawing.Size(273, 20);
            this.Text3.TabIndex = 13;
            // 
            // buttonReadVersion
            // 
            this.buttonReadVersion.BackColor = System.Drawing.SystemColors.Control;
            this.buttonReadVersion.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonReadVersion.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReadVersion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonReadVersion.Location = new System.Drawing.Point(8, 120);
            this.buttonReadVersion.Name = "buttonReadVersion";
            this.buttonReadVersion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonReadVersion.Size = new System.Drawing.Size(177, 25);
            this.buttonReadVersion.TabIndex = 3;
            this.buttonReadVersion.Text = "Read DLL Version";
            this.buttonReadVersion.UseVisualStyleBackColor = false;
            this.buttonReadVersion.Click += new System.EventHandler(this.buttonReadVersion_Click);
            // 
            // checkBuffer
            // 
            this.checkBuffer.BackColor = System.Drawing.SystemColors.Control;
            this.checkBuffer.Cursor = System.Windows.Forms.Cursors.Default;
            this.checkBuffer.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBuffer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBuffer.Location = new System.Drawing.Point(8, 208);
            this.checkBuffer.Name = "checkBuffer";
            this.checkBuffer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBuffer.Size = new System.Drawing.Size(169, 25);
            this.checkBuffer.TabIndex = 6;
            this.checkBuffer.Text = "Buffer Ticket";
            this.checkBuffer.UseVisualStyleBackColor = false;
            // 
            // checkReadStatus
            // 
            this.checkReadStatus.BackColor = System.Drawing.SystemColors.Control;
            this.checkReadStatus.Cursor = System.Windows.Forms.Cursors.Default;
            this.checkReadStatus.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkReadStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkReadStatus.Location = new System.Drawing.Point(8, 184);
            this.checkReadStatus.Name = "checkReadStatus";
            this.checkReadStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkReadStatus.Size = new System.Drawing.Size(177, 25);
            this.checkReadStatus.TabIndex = 5;
            this.checkReadStatus.Text = "Read Status every Ticket Line";
            this.checkReadStatus.UseVisualStyleBackColor = false;
            // 
            // checkDGFEAlmostFull
            // 
            this.checkDGFEAlmostFull.BackColor = System.Drawing.SystemColors.Control;
            this.checkDGFEAlmostFull.Cursor = System.Windows.Forms.Cursors.Default;
            this.checkDGFEAlmostFull.Enabled = false;
            this.checkDGFEAlmostFull.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkDGFEAlmostFull.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkDGFEAlmostFull.Location = new System.Drawing.Point(317, 245);
            this.checkDGFEAlmostFull.Name = "checkDGFEAlmostFull";
            this.checkDGFEAlmostFull.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkDGFEAlmostFull.Size = new System.Drawing.Size(148, 25);
            this.checkDGFEAlmostFull.TabIndex = 18;
            this.checkDGFEAlmostFull.Text = "DGFE Almost Full";
            this.checkDGFEAlmostFull.UseVisualStyleBackColor = false;
            // 
            // checkDGFEFull
            // 
            this.checkDGFEFull.BackColor = System.Drawing.SystemColors.Control;
            this.checkDGFEFull.Cursor = System.Windows.Forms.Cursors.Default;
            this.checkDGFEFull.Enabled = false;
            this.checkDGFEFull.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkDGFEFull.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkDGFEFull.Location = new System.Drawing.Point(317, 221);
            this.checkDGFEFull.Name = "checkDGFEFull";
            this.checkDGFEFull.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkDGFEFull.Size = new System.Drawing.Size(148, 25);
            this.checkDGFEFull.TabIndex = 17;
            this.checkDGFEFull.Text = "DGFE Full";
            this.checkDGFEFull.UseVisualStyleBackColor = false;
            // 
            // checkNearPaperEnd
            // 
            this.checkNearPaperEnd.BackColor = System.Drawing.SystemColors.Control;
            this.checkNearPaperEnd.Cursor = System.Windows.Forms.Cursors.Default;
            this.checkNearPaperEnd.Enabled = false;
            this.checkNearPaperEnd.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkNearPaperEnd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkNearPaperEnd.Location = new System.Drawing.Point(317, 197);
            this.checkNearPaperEnd.Name = "checkNearPaperEnd";
            this.checkNearPaperEnd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkNearPaperEnd.Size = new System.Drawing.Size(148, 25);
            this.checkNearPaperEnd.TabIndex = 16;
            this.checkNearPaperEnd.Text = "Near Paper End";
            this.checkNearPaperEnd.UseVisualStyleBackColor = false;
            // 
            // checkPaperEnd
            // 
            this.checkPaperEnd.BackColor = System.Drawing.SystemColors.Control;
            this.checkPaperEnd.Cursor = System.Windows.Forms.Cursors.Default;
            this.checkPaperEnd.Enabled = false;
            this.checkPaperEnd.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkPaperEnd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkPaperEnd.Location = new System.Drawing.Point(317, 173);
            this.checkPaperEnd.Name = "checkPaperEnd";
            this.checkPaperEnd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkPaperEnd.Size = new System.Drawing.Size(148, 25);
            this.checkPaperEnd.TabIndex = 15;
            this.checkPaperEnd.Text = "Paper End";
            this.checkPaperEnd.UseVisualStyleBackColor = false;
            // 
            // checkCoverOpen
            // 
            this.checkCoverOpen.BackColor = System.Drawing.SystemColors.Control;
            this.checkCoverOpen.Cursor = System.Windows.Forms.Cursors.Default;
            this.checkCoverOpen.Enabled = false;
            this.checkCoverOpen.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkCoverOpen.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkCoverOpen.Location = new System.Drawing.Point(317, 149);
            this.checkCoverOpen.Name = "checkCoverOpen";
            this.checkCoverOpen.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkCoverOpen.Size = new System.Drawing.Size(148, 25);
            this.checkCoverOpen.TabIndex = 14;
            this.checkCoverOpen.Text = "Cover Open";
            this.checkCoverOpen.UseVisualStyleBackColor = false;
            // 
            // buttonReadStatus
            // 
            this.buttonReadStatus.BackColor = System.Drawing.SystemColors.Control;
            this.buttonReadStatus.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonReadStatus.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReadStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonReadStatus.Location = new System.Drawing.Point(8, 152);
            this.buttonReadStatus.Name = "buttonReadStatus";
            this.buttonReadStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonReadStatus.Size = new System.Drawing.Size(177, 25);
            this.buttonReadStatus.TabIndex = 4;
            this.buttonReadStatus.Text = "Printer Status";
            this.buttonReadStatus.UseVisualStyleBackColor = false;
            this.buttonReadStatus.Click += new System.EventHandler(this.buttonReadStatus_Click);
            // 
            // Text2
            // 
            this.Text2.AcceptsReturn = true;
            this.Text2.BackColor = System.Drawing.SystemColors.Window;
            this.Text2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Text2.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Text2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Text2.Location = new System.Drawing.Point(192, 88);
            this.Text2.MaxLength = 0;
            this.Text2.Name = "Text2";
            this.Text2.ReadOnly = true;
            this.Text2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text2.Size = new System.Drawing.Size(273, 20);
            this.Text2.TabIndex = 12;
            // 
            // buttonReadLine
            // 
            this.buttonReadLine.BackColor = System.Drawing.SystemColors.Control;
            this.buttonReadLine.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonReadLine.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReadLine.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonReadLine.Location = new System.Drawing.Point(8, 88);
            this.buttonReadLine.Name = "buttonReadLine";
            this.buttonReadLine.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonReadLine.Size = new System.Drawing.Size(177, 25);
            this.buttonReadLine.TabIndex = 2;
            this.buttonReadLine.Text = "Read 1st Line of Header";
            this.buttonReadLine.UseVisualStyleBackColor = false;
            this.buttonReadLine.Click += new System.EventHandler(this.buttonReadLine_Click);
            // 
            // buttonReadDate
            // 
            this.buttonReadDate.BackColor = System.Drawing.SystemColors.Control;
            this.buttonReadDate.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonReadDate.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReadDate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonReadDate.Location = new System.Drawing.Point(8, 56);
            this.buttonReadDate.Name = "buttonReadDate";
            this.buttonReadDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonReadDate.Size = new System.Drawing.Size(177, 25);
            this.buttonReadDate.TabIndex = 1;
            this.buttonReadDate.Text = "Read Date and Time";
            this.buttonReadDate.UseVisualStyleBackColor = false;
            this.buttonReadDate.Click += new System.EventHandler(this.buttonReadDate_Click);
            // 
            // Text1
            // 
            this.Text1.AcceptsReturn = true;
            this.Text1.BackColor = System.Drawing.SystemColors.Window;
            this.Text1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Text1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Text1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Text1.Location = new System.Drawing.Point(192, 56);
            this.Text1.MaxLength = 0;
            this.Text1.Name = "Text1";
            this.Text1.ReadOnly = true;
            this.Text1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text1.Size = new System.Drawing.Size(273, 20);
            this.Text1.TabIndex = 11;
            // 
            // Combo1
            // 
            this.Combo1.BackColor = System.Drawing.SystemColors.Window;
            this.Combo1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Combo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combo1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Combo1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Combo1.Location = new System.Drawing.Point(352, 24);
            this.Combo1.Name = "Combo1";
            this.Combo1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Combo1.Size = new System.Drawing.Size(65, 22);
            this.Combo1.TabIndex = 10;
            // 
            // buttonPrintTicket
            // 
            this.buttonPrintTicket.BackColor = System.Drawing.SystemColors.Control;
            this.buttonPrintTicket.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonPrintTicket.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPrintTicket.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonPrintTicket.Location = new System.Drawing.Point(8, 24);
            this.buttonPrintTicket.Name = "buttonPrintTicket";
            this.buttonPrintTicket.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonPrintTicket.Size = new System.Drawing.Size(177, 25);
            this.buttonPrintTicket.TabIndex = 0;
            this.buttonPrintTicket.Text = "Print Ticket";
            this.buttonPrintTicket.UseVisualStyleBackColor = false;
            this.buttonPrintTicket.Click += new System.EventHandler(this.buttonPrintTicket_Click);
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.SystemColors.Control;
            this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label2.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label2.Location = new System.Drawing.Point(8, 236);
            this.Label2.Name = "Label2";
            this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label2.Size = new System.Drawing.Size(62, 30);
            this.Label2.TabIndex = 7;
            this.Label2.Text = "Com Port";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.SystemColors.Control;
            this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label1.Location = new System.Drawing.Point(192, 24);
            this.Label1.Name = "Label1";
            this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label1.Size = new System.Drawing.Size(153, 17);
            this.Label1.TabIndex = 9;
            this.Label1.Text = "Number of Lines on Ticket";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(481, 282);
            this.Controls.Add(this.ComboPort);
            this.Controls.Add(this.Text3);
            this.Controls.Add(this.buttonReadVersion);
            this.Controls.Add(this.checkBuffer);
            this.Controls.Add(this.checkReadStatus);
            this.Controls.Add(this.checkDGFEAlmostFull);
            this.Controls.Add(this.checkDGFEFull);
            this.Controls.Add(this.checkNearPaperEnd);
            this.Controls.Add(this.checkPaperEnd);
            this.Controls.Add(this.checkCoverOpen);
            this.Controls.Add(this.buttonReadStatus);
            this.Controls.Add(this.Text2);
            this.Controls.Add(this.buttonReadLine);
            this.Controls.Add(this.buttonReadDate);
            this.Controls.Add(this.Text1);
            this.Controls.Add(this.Combo1);
            this.Controls.Add(this.buttonPrintTicket);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(4, 23);
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "C# 2005 CeFDllDemo";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
	#endregion

		[STAThread]
		static void Main()
		{
			Application.Run(new MainForm());
		}

        private ComboBox ComboPort;
        private TextBox Text3;
        private Button buttonReadVersion;
        private CheckBox checkBuffer;
        private CheckBox checkReadStatus;
        private CheckBox checkDGFEAlmostFull;
        private CheckBox checkDGFEFull;
        private CheckBox checkNearPaperEnd;
        private CheckBox checkPaperEnd;
        private CheckBox checkCoverOpen;
        private Button buttonReadStatus;
        private TextBox Text2;
        private Button buttonReadLine;
        private Button buttonReadDate;
        private TextBox Text1;
        private ComboBox Combo1;
        private Button buttonPrintTicket;
        private Label Label2;
        private Label Label1;

	}
} //end of root namespace