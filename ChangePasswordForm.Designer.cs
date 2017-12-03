namespace NEWPROJECT
{
    partial class ChangePasswordForm
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
            this.label5 = new System.Windows.Forms.Label();
            this.lblConfirmPasswordIsRequired = new System.Windows.Forms.Label();
            this.lblConfirmPasswordAndPasswordSame = new System.Windows.Forms.Label();
            this.ConfirmPasswordBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.NewPasswordBox = new System.Windows.Forms.TextBox();
            this.CurrentPasswordBox = new System.Windows.Forms.TextBox();
            this.Emailbox = new System.Windows.Forms.TextBox();
            this.lblPasswordIsRequired = new System.Windows.Forms.Label();
            this.lblEmailIsRequired = new System.Windows.Forms.Label();
            this.lblNameIsRequired = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(206, 33);
            this.label5.TabIndex = 45;
            this.label5.Text = "Change Password";
            // 
            // lblConfirmPasswordIsRequired
            // 
            this.lblConfirmPasswordIsRequired.AutoSize = true;
            this.lblConfirmPasswordIsRequired.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmPasswordIsRequired.ForeColor = System.Drawing.Color.Red;
            this.lblConfirmPasswordIsRequired.Location = new System.Drawing.Point(175, 289);
            this.lblConfirmPasswordIsRequired.Name = "lblConfirmPasswordIsRequired";
            this.lblConfirmPasswordIsRequired.Size = new System.Drawing.Size(202, 19);
            this.lblConfirmPasswordIsRequired.TabIndex = 44;
            this.lblConfirmPasswordIsRequired.Text = "Confirm Password is Required";
            this.lblConfirmPasswordIsRequired.Visible = false;
            this.lblConfirmPasswordIsRequired.Click += new System.EventHandler(this.lblConfirmPasswordIsRequired_Click);
            // 
            // lblConfirmPasswordAndPasswordSame
            // 
            this.lblConfirmPasswordAndPasswordSame.AutoSize = true;
            this.lblConfirmPasswordAndPasswordSame.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmPasswordAndPasswordSame.ForeColor = System.Drawing.Color.Red;
            this.lblConfirmPasswordAndPasswordSame.Location = new System.Drawing.Point(64, 312);
            this.lblConfirmPasswordAndPasswordSame.Name = "lblConfirmPasswordAndPasswordSame";
            this.lblConfirmPasswordAndPasswordSame.Size = new System.Drawing.Size(325, 19);
            this.lblConfirmPasswordAndPasswordSame.TabIndex = 43;
            this.lblConfirmPasswordAndPasswordSame.Text = "Password and Confirm Password Should be Same\r\n";
            this.lblConfirmPasswordAndPasswordSame.Visible = false;
            // 
            // ConfirmPasswordBox
            // 
            this.ConfirmPasswordBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmPasswordBox.Location = new System.Drawing.Point(179, 259);
            this.ConfirmPasswordBox.Name = "ConfirmPasswordBox";
            this.ConfirmPasswordBox.Size = new System.Drawing.Size(210, 27);
            this.ConfirmPasswordBox.TabIndex = 37;
            this.ConfirmPasswordBox.UseSystemPasswordChar = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(38, 260);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 19);
            this.label7.TabIndex = 42;
            this.label7.Text = "Confirm Password";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(288, 352);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 33);
            this.button1.TabIndex = 39;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // NewPasswordBox
            // 
            this.NewPasswordBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewPasswordBox.Location = new System.Drawing.Point(179, 201);
            this.NewPasswordBox.Name = "NewPasswordBox";
            this.NewPasswordBox.Size = new System.Drawing.Size(210, 27);
            this.NewPasswordBox.TabIndex = 35;
            this.NewPasswordBox.UseSystemPasswordChar = true;
            // 
            // CurrentPasswordBox
            // 
            this.CurrentPasswordBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentPasswordBox.Location = new System.Drawing.Point(179, 141);
            this.CurrentPasswordBox.Name = "CurrentPasswordBox";
            this.CurrentPasswordBox.Size = new System.Drawing.Size(210, 27);
            this.CurrentPasswordBox.TabIndex = 33;
            this.CurrentPasswordBox.UseSystemPasswordChar = true;
            // 
            // Emailbox
            // 
            this.Emailbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Emailbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.Emailbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Emailbox.Location = new System.Drawing.Point(179, 89);
            this.Emailbox.Name = "Emailbox";
            this.Emailbox.Size = new System.Drawing.Size(210, 27);
            this.Emailbox.TabIndex = 31;
            this.Emailbox.TextChanged += new System.EventHandler(this.Emailbox_TextChanged);
            // 
            // lblPasswordIsRequired
            // 
            this.lblPasswordIsRequired.AutoSize = true;
            this.lblPasswordIsRequired.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswordIsRequired.ForeColor = System.Drawing.Color.Red;
            this.lblPasswordIsRequired.Location = new System.Drawing.Point(175, 231);
            this.lblPasswordIsRequired.Name = "lblPasswordIsRequired";
            this.lblPasswordIsRequired.Size = new System.Drawing.Size(144, 19);
            this.lblPasswordIsRequired.TabIndex = 41;
            this.lblPasswordIsRequired.Text = "Password is required";
            this.lblPasswordIsRequired.Visible = false;
            // 
            // lblEmailIsRequired
            // 
            this.lblEmailIsRequired.AutoSize = true;
            this.lblEmailIsRequired.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmailIsRequired.ForeColor = System.Drawing.Color.Red;
            this.lblEmailIsRequired.Location = new System.Drawing.Point(175, 179);
            this.lblEmailIsRequired.Name = "lblEmailIsRequired";
            this.lblEmailIsRequired.Size = new System.Drawing.Size(118, 19);
            this.lblEmailIsRequired.TabIndex = 40;
            this.lblEmailIsRequired.Text = "Invalid Password";
            this.lblEmailIsRequired.Visible = false;
            // 
            // lblNameIsRequired
            // 
            this.lblNameIsRequired.AutoSize = true;
            this.lblNameIsRequired.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameIsRequired.ForeColor = System.Drawing.Color.Red;
            this.lblNameIsRequired.Location = new System.Drawing.Point(175, 119);
            this.lblNameIsRequired.Name = "lblNameIsRequired";
            this.lblNameIsRequired.Size = new System.Drawing.Size(107, 19);
            this.lblNameIsRequired.TabIndex = 38;
            this.lblNameIsRequired.Text = "Email Required";
            this.lblNameIsRequired.Visible = false;
            this.lblNameIsRequired.Click += new System.EventHandler(this.lblNameIsRequired_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(38, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 19);
            this.label3.TabIndex = 36;
            this.label3.Text = "New Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 19);
            this.label2.TabIndex = 34;
            this.label2.Text = "Current Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 19);
            this.label1.TabIndex = 32;
            this.label1.Text = "Email";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(389, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(29, 24);
            this.button2.TabIndex = 46;
            this.button2.Text = "X";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ChangePasswordForm
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 402);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblConfirmPasswordIsRequired);
            this.Controls.Add(this.lblConfirmPasswordAndPasswordSame);
            this.Controls.Add(this.ConfirmPasswordBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.NewPasswordBox);
            this.Controls.Add(this.CurrentPasswordBox);
            this.Controls.Add(this.Emailbox);
            this.Controls.Add(this.lblPasswordIsRequired);
            this.Controls.Add(this.lblEmailIsRequired);
            this.Controls.Add(this.lblNameIsRequired);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "ChangePasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChangePasswordForm";
            this.Load += new System.EventHandler(this.ChangePasswordForm_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblConfirmPasswordIsRequired;
        private System.Windows.Forms.Label lblConfirmPasswordAndPasswordSame;
        private System.Windows.Forms.TextBox ConfirmPasswordBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox NewPasswordBox;
        private System.Windows.Forms.TextBox CurrentPasswordBox;
        private System.Windows.Forms.TextBox Emailbox;
        private System.Windows.Forms.Label lblPasswordIsRequired;
        private System.Windows.Forms.Label lblEmailIsRequired;
        private System.Windows.Forms.Label lblNameIsRequired;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
    }
}