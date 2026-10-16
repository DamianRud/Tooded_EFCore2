
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tooded_EFCore
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            btnTooted.Enabled = AktiivneKasutaja.Roll == "admin";
        }

        private void btnTooted_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();
        }

        private void btnPood_Click(object sender, EventArgs e)
        {
            Form3 poodForm = new Form3();
            poodForm.ShowDialog();
        }

        private void btnArve_Click(object sender, EventArgs e)
        {
            ArveForm arve = new ArveForm();
            arve.ShowDialog();
        }
       
    }
}
