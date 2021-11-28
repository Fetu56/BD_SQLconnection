
namespace FormsNotes
{
    partial class FormNotes
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
            this.comboBoxNotes = new System.Windows.Forms.ComboBox();
            this.textBoxNotes = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.labelDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxNotes
            // 
            this.comboBoxNotes.FormattingEnabled = true;
            this.comboBoxNotes.Location = new System.Drawing.Point(12, 12);
            this.comboBoxNotes.Name = "comboBoxNotes";
            this.comboBoxNotes.Size = new System.Drawing.Size(202, 23);
            this.comboBoxNotes.TabIndex = 0;
            this.comboBoxNotes.SelectedIndexChanged += new System.EventHandler(this.comboBoxNotes_SelectedIndexChanged);
            // 
            // textBoxNotes
            // 
            this.textBoxNotes.Location = new System.Drawing.Point(12, 71);
            this.textBoxNotes.Multiline = true;
            this.textBoxNotes.Name = "textBoxNotes";
            this.textBoxNotes.ReadOnly = true;
            this.textBoxNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxNotes.Size = new System.Drawing.Size(202, 292);
            this.textBoxNotes.TabIndex = 1;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(12, 380);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDel
            // 
            this.buttonDel.Location = new System.Drawing.Point(139, 380);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(75, 23);
            this.buttonDel.TabIndex = 3;
            this.buttonDel.Text = "Delete";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(98, 379);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(29, 26);
            this.button1.TabIndex = 4;
            this.button1.Text = "RE";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(12, 46);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(10, 15);
            this.labelDate.TabIndex = 5;
            this.labelDate.Text = " ";
            // 
            // FormNotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 411);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonDel);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textBoxNotes);
            this.Controls.Add(this.comboBoxNotes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormNotes";
            this.Text = "Notes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxNotes;
        private System.Windows.Forms.TextBox textBoxNotes;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelDate;
    }
}

