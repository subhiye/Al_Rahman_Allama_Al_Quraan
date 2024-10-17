using Alrahman_Allama_Allquran.People.Controls;
using System;
using System.Data;
using System.Windows.Forms;

namespace Alrahman_Allama_Allquran.People
{
    public partial class frmShowPersonInfo : Form
    {
        public frmShowPersonInfo()
        {
            InitializeComponent();
        }
        public frmShowPersonInfo(int StudentID)
        {
            InitializeComponent();
            ctrlPersonCardInfo1.LoadPersonInfo(StudentID);
        }
    }
}