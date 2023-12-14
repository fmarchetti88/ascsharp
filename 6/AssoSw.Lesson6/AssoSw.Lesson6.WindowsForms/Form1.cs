using AssoSw.Lesson6.WindowsForms.Models;

namespace AssoSw.Lesson6.WindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lblName.Text = Resources.NameLabel;
        }

        private void UpdateProgress(int i)
        {
            progressBar1.Value = i;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string surname = txtSurname.Text;

            if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(surname))
            {
                MessageBox.Show("Nome o Cognome sono obbligatori!", "Errore");
                return;
            }

            string address = txtAddress.Text;
            string email = txtEmail.Text;
            string telephone = txtTelephone.Text;
            string birthDateString = dtpBirthDate.Text;
            if (!DateTime.TryParse(birthDateString, out DateTime birthDate))
            {
                MessageBox.Show("La Data di Nascita non è stata specificata!", "Errore");
                return;
            }

            Customer customer = new Customer()
            {
                Name = name,
                Surname = surname,
                Address = address,
                Email = email,
                Telephone = telephone,
                BirthDate = birthDate
            };

            int progress = 10;
            Task task = new Task(() =>
            {
                while (progress <= 100)
                {
                    Thread.Sleep(500);
                    progressBar1.Invoke(UpdateProgress, progress);
                    progressBar1.Value = progress;
                    progress += 10;
                }
                MyDbRepository.AddCustomer(customer);
                MessageBox.Show("Cliente salvato con successo!");
            });
            task.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form = new Form();
            form.Text = "Lista clienti";
            form.Width = 900;
            form.Height = 420;
            CustomerListView customListView = new();
            customListView.Dock = DockStyle.Fill;
            form.Controls.Add(new CustomerListView());
            form.Show();
        }
    }
}