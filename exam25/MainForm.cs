namespace exam25
{
    public partial class MainForm : Form
    {
        private List<Contractor> _Contractors = new List<Contractor>();
        private ContractorController _ContractorController;

        public MainForm()
        {
            InitializeComponent();
            _CreateColumns();

            _ContractorController = new ContractorController();
        }

        private void _CreateColumns()
        {
            dataGridView1.Columns.Add("id", "Номер заказчика");
            dataGridView1.Columns.Add("name", "Название");
            dataGridView1.Columns.Add("address", "Адрес");
            dataGridView1.Columns.Add("inn", "ИНН");
            dataGridView1.Columns.Add("person", "Представитель");
            dataGridView1.Columns.Add("phone", "Номер тел.");
            dataGridView1.Columns.Add("email", "Почта");
            dataGridView1.Columns.Add("rating", "Рейтинг");
            dataGridView1.Columns.Add("safety", "Надежность");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            dataGridView1.Rows.Clear();

            _Contractors = _ContractorController.GetAllContractor();

            foreach (Contractor contractor in _Contractors)
            {
                _ReadSingleRow(contractor);
            }
        }

        private void _ReadSingleRow(Contractor contractor)
        {
            dataGridView1.Rows.Add(contractor.Id, contractor.Name, contractor.Address, contractor.INN, contractor.Person, contractor.Phone, contractor.Email, contractor.Rating, contractor.Safety);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new ContractorForm(null);
            form.Show();
        }
    }
}
