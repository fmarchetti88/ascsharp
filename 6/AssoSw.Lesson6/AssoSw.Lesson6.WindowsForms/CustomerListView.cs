using AssoSw.Lesson6.WindowsForms.Models;
using System.ComponentModel;

namespace AssoSw.Lesson6.WindowsForms
{
    public partial class CustomerListView : UserControl
    {
        BindingList<Customer> bindingCustomerList = new BindingList<Customer>();

        public CustomerListView()
        {
            InitializeComponent();
        }

        private void CustomerListView_Load(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.DataPropertyName = "Name";
            nameColumn.HeaderText = "Nome";
            nameColumn.Name = "Name";
            nameColumn.ValueType = typeof(string);
            nameColumn.Width = 100;
            nameColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            nameColumn.ReadOnly = true;
            nameColumn.MinimumWidth = 50;
            dgvCustomerList.Columns.Add(nameColumn);

            DataGridViewTextBoxColumn surnameColumn = new DataGridViewTextBoxColumn();
            surnameColumn.DataPropertyName = "Surname";
            surnameColumn.HeaderText = "Cognome";
            surnameColumn.Name = "Surname";
            surnameColumn.ValueType = typeof(string);
            surnameColumn.Width = 100;
            surnameColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            surnameColumn.ReadOnly = true;
            surnameColumn.MinimumWidth = 50;
            dgvCustomerList.Columns.Add(surnameColumn);

            DataGridViewTextBoxColumn birthDateColumn = new DataGridViewTextBoxColumn();
            birthDateColumn.DataPropertyName = "BirthDate";
            birthDateColumn.HeaderText = "Data di nascita";
            birthDateColumn.Name = "BirthDate";
            birthDateColumn.ValueType = typeof(DateTime);
            birthDateColumn.Width = 100;
            birthDateColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            birthDateColumn.ReadOnly = true;
            birthDateColumn.MinimumWidth = 50;
            dgvCustomerList.Columns.Add(birthDateColumn);

            // Carica i dati nella lista
            bindingCustomerList.Clear();
            List<Customer> customers = MyDbRepository.GetCustomers();

            customers.ForEach(customer => bindingCustomerList.Add(customer));

            // La dgv si aggiorna da sola perché la lista è BindingList
            dgvCustomerList.DataSource = bindingCustomerList;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ((Form)this.TopLevelControl).Close();
        }
    }
}
