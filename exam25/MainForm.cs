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
            dataGridView1.Columns.Add("id", "����� ���������");
            dataGridView1.Columns.Add("name", "��������");
            dataGridView1.Columns.Add("address", "�����");
            dataGridView1.Columns.Add("inn", "���");
            dataGridView1.Columns.Add("person", "�������������");
            dataGridView1.Columns.Add("phone", "����� ���.");
            dataGridView1.Columns.Add("email", "�����");
            dataGridView1.Columns.Add("rating", "�������");
            dataGridView1.Columns.Add("safety", "����������");
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
