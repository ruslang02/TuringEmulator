namespace TuringEmulator
{
    partial class InputEditorForm
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
            this.InputFieldLabel = new System.Windows.Forms.Label();
            this.InputField = new System.Windows.Forms.TextBox();
            this.FileLoadButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelDialogButton = new System.Windows.Forms.Button();
            this.LoadDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // InputFieldLabel
            // 
            this.InputFieldLabel.AutoSize = true;
            this.InputFieldLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputFieldLabel.Location = new System.Drawing.Point(12, 9);
            this.InputFieldLabel.Name = "InputFieldLabel";
            this.InputFieldLabel.Size = new System.Drawing.Size(110, 20);
            this.InputFieldLabel.TabIndex = 0;
            this.InputFieldLabel.Text = "Лента входа:";
            // 
            // textBox1
            // 
            this.InputField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputField.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputField.Location = new System.Drawing.Point(12, 37);
            this.InputField.Name = "InputField";
            this.InputField.Size = new System.Drawing.Size(329, 30);
            this.InputField.TabIndex = 1;
            // 
            // FileLoadButton
            // 
            this.FileLoadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.FileLoadButton.Location = new System.Drawing.Point(12, 79);
            this.FileLoadButton.Name = "FileLoadButton";
            this.FileLoadButton.Size = new System.Drawing.Size(87, 23);
            this.FileLoadButton.TabIndex = 2;
            this.FileLoadButton.Text = "Из файла...";
            this.FileLoadButton.UseVisualStyleBackColor = true;
            this.FileLoadButton.Click += new System.EventHandler(this.FileLoadButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Location = new System.Drawing.Point(261, 79);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(80, 23);
            this.OKButton.TabIndex = 3;
            this.OKButton.Text = "Применить";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton
            // 
            this.CancelDialogButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelDialogButton.Location = new System.Drawing.Point(180, 79);
            this.CancelDialogButton.Name = "button3";
            this.CancelDialogButton.Size = new System.Drawing.Size(75, 23);
            this.CancelDialogButton.TabIndex = 4;
            this.CancelDialogButton.Text = "Отмена";
            this.CancelDialogButton.UseVisualStyleBackColor = true;
            this.CancelDialogButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // LoadDialog
            // 
            this.LoadDialog.Filter = "Текстовые файлы | *.txt";
            this.LoadDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.LoadDialog_Select);
            // 
            // InputEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 114);
            this.Controls.Add(this.CancelDialogButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.FileLoadButton);
            this.Controls.Add(this.InputField);
            this.Controls.Add(this.InputFieldLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InputEditor";
            this.Text = "Изменение входных данных";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InputFieldLabel;
        private System.Windows.Forms.TextBox InputField;
        private System.Windows.Forms.Button FileLoadButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelDialogButton;
        private System.Windows.Forms.OpenFileDialog LoadDialog;
    }
}