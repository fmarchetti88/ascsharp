namespace AssoSw.Lesson6.WindowsForms
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            txtName = new TextBox();
            lblName = new Label();
            groupBox1 = new GroupBox();
            label3 = new Label();
            dtpBirthDate = new DateTimePicker();
            txtEmail = new TextBox();
            label5 = new Label();
            txtTelephone = new TextBox();
            label4 = new Label();
            txtAddress = new TextBox();
            label2 = new Label();
            txtSurname = new TextBox();
            label1 = new Label();
            button1 = new Button();
            progressBar1 = new ProgressBar();
            button2 = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(138, 22);
            txtName.Name = "txtName";
            txtName.Size = new Size(151, 23);
            txtName.TabIndex = 0;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(6, 25);
            lblName.Name = "lblName";
            lblName.Size = new Size(40, 15);
            lblName.TabIndex = 1;
            lblName.Text = "Nome";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(dtpBirthDate);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtTelephone);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtAddress);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtSurname);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtName);
            groupBox1.Controls.Add(lblName);
            groupBox1.Location = new Point(12, 17);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(306, 276);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Dati anagrafici";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 158);
            label3.Name = "label3";
            label3.Size = new Size(73, 15);
            label3.TabIndex = 14;
            label3.Text = "Data Nascita";
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.Location = new Point(138, 158);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(151, 23);
            dtpBirthDate.TabIndex = 13;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(138, 216);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(151, 23);
            txtEmail.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 219);
            label5.Name = "label5";
            label5.Size = new Size(36, 15);
            label5.TabIndex = 12;
            label5.Text = "Email";
            // 
            // txtTelephone
            // 
            txtTelephone.Location = new Point(138, 187);
            txtTelephone.Name = "txtTelephone";
            txtTelephone.Size = new Size(151, 23);
            txtTelephone.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(5, 190);
            label4.Name = "label4";
            label4.Size = new Size(52, 15);
            label4.TabIndex = 10;
            label4.Text = "Telefono";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(138, 80);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(151, 72);
            txtAddress.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 83);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 5;
            label2.Text = "Indirizzo";
            // 
            // txtSurname
            // 
            txtSurname.Location = new Point(138, 51);
            txtSurname.Name = "txtSurname";
            txtSurname.Size = new Size(151, 23);
            txtSurname.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 54);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 3;
            label1.Text = "Cognome";
            // 
            // button1
            // 
            button1.Location = new Point(227, 328);
            button1.Name = "button1";
            button1.Size = new Size(91, 31);
            button1.TabIndex = 3;
            button1.Text = "Salva";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 299);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(306, 23);
            progressBar1.TabIndex = 4;
            // 
            // button2
            // 
            button2.Location = new Point(12, 328);
            button2.Name = "button2";
            button2.Size = new Size(91, 31);
            button2.TabIndex = 5;
            button2.Text = "Visualizza lista";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(334, 371);
            Controls.Add(button2);
            Controls.Add(progressBar1);
            Controls.Add(button1);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Anagrafica Cliente";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtName;
        private Label lblName;
        private GroupBox groupBox1;
        private TextBox txtAddress;
        private Label label2;
        private TextBox txtSurname;
        private Label label1;
        private TextBox txtEmail;
        private Label label5;
        private TextBox txtTelephone;
        private Label label4;
        private Button button1;
        private ProgressBar progressBar1;
        private Button button2;
        private Label label3;
        private DateTimePicker dtpBirthDate;
    }
}