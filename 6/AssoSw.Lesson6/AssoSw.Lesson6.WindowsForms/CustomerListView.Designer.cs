namespace AssoSw.Lesson6.WindowsForms
{
    partial class CustomerListView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvCustomerList = new DataGridView();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCustomerList).BeginInit();
            SuspendLayout();
            // 
            // dgvCustomerList
            // 
            dgvCustomerList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomerList.Location = new Point(3, 3);
            dgvCustomerList.Name = "dgvCustomerList";
            dgvCustomerList.RowTemplate.Height = 25;
            dgvCustomerList.Size = new Size(874, 338);
            dgvCustomerList.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(773, 347);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(104, 26);
            btnClose.TabIndex = 1;
            btnClose.Text = "Chiudi";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // CustomerListView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnClose);
            Controls.Add(dgvCustomerList);
            Name = "CustomerListView";
            Size = new Size(880, 382);
            Load += CustomerListView_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCustomerList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvCustomerList;
        private Button btnClose;
    }
}
