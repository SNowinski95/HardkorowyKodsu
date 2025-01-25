namespace HardkorowyKodsu
{
    partial class MainView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            ReloadButton = new Button();
            label2 = new Label();
            label1 = new Label();
            panel1 = new Panel();
            ViewList = new ListBox();
            TableList = new ListBox();
            panel2 = new Panel();
            ColumnList = new ListBox();
            label3 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // ReloadButton
            // 
            ReloadButton.Location = new Point(624, 12);
            ReloadButton.Name = "ReloadButton";
            ReloadButton.Size = new Size(164, 75);
            ReloadButton.TabIndex = 2;
            ReloadButton.Text = "Reload Data";
            ReloadButton.UseVisualStyleBackColor = true;
            ReloadButton.Click += RealodClick;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(225, 0);
            label2.Name = "label2";
            label2.Size = new Size(75, 32);
            label2.TabIndex = 4;
            label2.Text = "Views";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(45, 0);
            label1.Name = "label1";
            label1.Size = new Size(79, 32);
            label1.TabIndex = 3;
            label1.Text = "Tables";
            // 
            // panel1
            // 
            panel1.Controls.Add(ViewList);
            panel1.Controls.Add(TableList);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(351, 426);
            panel1.TabIndex = 5;
            // 
            // ViewList
            // 
            ViewList.FormattingEnabled = true;
            ViewList.Location = new Point(188, 35);
            ViewList.Name = "ViewList";
            ViewList.Size = new Size(160, 379);
            ViewList.TabIndex = 7;
            ViewList.Click += List_Click;
            // 
            // TableList
            // 
            TableList.FormattingEnabled = true;
            TableList.Location = new Point(3, 35);
            TableList.Name = "TableList";
            TableList.Size = new Size(160, 379);
            TableList.TabIndex = 6;
            TableList.Click += List_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(ColumnList);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(369, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(249, 426);
            panel2.TabIndex = 6;
            // 
            // ColumnList
            // 
            ColumnList.Enabled = false;
            ColumnList.FormattingEnabled = true;
            ColumnList.Location = new Point(3, 35);
            ColumnList.Name = "ColumnList";
            ColumnList.Size = new Size(243, 379);
            ColumnList.TabIndex = 8;
            ColumnList.UseTabStops = false;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(72, 0);
            label3.Name = "label3";
            label3.Size = new Size(108, 32);
            label3.TabIndex = 5;
            label3.Text = "Columns";
            // 
            // MainView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(ReloadButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainView";
            Text = "HardkorowyKodsu";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button ReloadButton;
        private Label label2;
        private Label label1;
        private Panel panel1;
        private ListBox ViewList;
        private ListBox TableList;
        private Panel panel2;
        private Label label3;
        private ListBox ColumnList;
    }
}
