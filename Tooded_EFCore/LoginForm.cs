using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tooded_EFCore
{
    public partial class LoginForm : Form
    {

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using var db = new ToodedContext();

            string email = txtEmail.Text;
            string parool = txtParool.Text;

            var kasutaja = db.Kasutajad.FirstOrDefault(k => k.Email == email);

            if (kasutaja == null)
            {
                lblVeateade.Text = "Vale email!";
                return;
            }

            if (!PasswordHelper.Verify(parool, kasutaja.ParoolHash))
            {
                lblVeateade.Text = "Vale parool!";
                return;
            }

            // roll salvestatakse globaalselt
            AktiivneKasutaja.Roll = kasutaja.Roll;

            // peale login
            FormMain main = new FormMain();
            main.Show();
            this.Hide();
        }


    }
}

