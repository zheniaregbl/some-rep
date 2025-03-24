using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exam25
{
    public partial class ContractorForm : Form
    {
        private Contractor? _Contractor;
        private TypeController _TypeController;
        private List<ContractorType> _Types = new List<ContractorType>();

        public ContractorForm(Contractor? contractor)
        {
            InitializeComponent();
            _Contractor = contractor;
            _TypeController = new TypeController();
        }

        private void ContractorForm_Load(object sender, EventArgs e)
        {
            _Types = _TypeController.GetTypes();

            foreach (ContractorType type in _Types)
            {
                comboBox1.Items.Add(type.Name);
            }

            if (_Contractor != null)
            {

            }
        }
    }
}
