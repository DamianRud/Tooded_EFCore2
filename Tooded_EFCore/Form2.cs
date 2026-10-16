
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Tooded_EFCore
{
    public partial class Form2 : Form
    {
        private readonly ToodedContext _db;
        private string valitudPilt;

        public Form2()
        {
            InitializeComponent();
            _db = new ToodedContext();
            LaeKategooriad();
            LaeTooted();
        }

        private void LaeKategooriad()
        {
            comboKategooria.DataSource = _db.Kategooriatabel.ToList();
            comboKategooria.DisplayMember = "Kategooria_nimetus";
            comboKategooria.ValueMember = "Id";
        }

        private void LaeTooted()
        {
            dataGridViewTooted.DataSource = _db.Toodetabel
                .Include(t => t.Kategooria)
                .Select(t => new
                {
                    t.Id,
                    t.Toodenimetus,
                    t.Kogus,
                    t.Hind,
                    Kategooria = t.Kategooria.Kategooria_nimetus,
                    t.Pilt
                })
                .ToList();
        }

        private void btnValiPilt_Click(object sender, EventArgs e)
        {
            try
            {
                using var ofd = new OpenFileDialog();
                ofd.Filter = "Pildid|*.jpg;*.png;*.jpeg";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    valitudPilt = ofd.FileName;
                    picturePilt.Image = Image.FromFile(valitudPilt);
                }
            }
            catch
            {
                MessageBox.Show("Pildi valimine ebaõnnestus!");
            }
        }

        private void btnLisa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNimetus.Text) ||
                string.IsNullOrWhiteSpace(txtKogus.Text) ||
                string.IsNullOrWhiteSpace(txtHind.Text) ||
                comboKategooria.SelectedItem == null)
            {
                MessageBox.Show("Palun täida kõik väljad!");
                return;
            }

            try
            {
                var uus = new Toode
                {
                    Toodenimetus = txtNimetus.Text,
                    Kogus = int.Parse(txtKogus.Text),
                    Hind = float.Parse(txtHind.Text),
                    KategooriaId = (int)comboKategooria.SelectedValue,
                    Pilt = Path.GetFileName(valitudPilt)
                };

                if (!string.IsNullOrEmpty(valitudPilt))
                {
                    Directory.CreateDirectory("Images");
                    File.Copy(valitudPilt, Path.Combine("Images", uus.Pilt), true);
                }

                _db.Toodetabel.Add(uus);
                _db.SaveChanges();
                LaeTooted();

                MessageBox.Show("Toode on lisatud!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Viga: " + ex.Message);
            }
        }

        private void dataGridViewTooted_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            txtNimetus.Text = dataGridViewTooted.Rows[e.RowIndex].Cells["Toodenimetus"].Value.ToString();
            txtKogus.Text = dataGridViewTooted.Rows[e.RowIndex].Cells["Kogus"].Value.ToString();
            txtHind.Text = dataGridViewTooted.Rows[e.RowIndex].Cells["Hind"].Value.ToString();

            string pilt = dataGridViewTooted.Rows[e.RowIndex].Cells["Pilt"].Value?.ToString();

            if (!string.IsNullOrEmpty(pilt) && File.Exists(Path.Combine("Images", pilt)))
                picturePilt.Image = Image.FromFile(Path.Combine("Images", pilt));
        }

        private void btnUuenda_Click(object sender, EventArgs e)
        {
            if (dataGridViewTooted.SelectedRows.Count == 0)
            {
                MessageBox.Show("Palun vali toode!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNimetus.Text) ||
                string.IsNullOrWhiteSpace(txtKogus.Text) ||
                string.IsNullOrWhiteSpace(txtHind.Text))
            {
                MessageBox.Show("Palun täida kõik väljad!");
                return;
            }

            try
            {
                int id = (int)dataGridViewTooted.SelectedRows[0].Cells["Id"].Value;

                var toode = _db.Toodetabel.Find(id);

                toode.Toodenimetus = txtNimetus.Text;
                toode.Kogus = int.Parse(txtKogus.Text);
                toode.Hind = float.Parse(txtHind.Text);
                toode.KategooriaId = (int)comboKategooria.SelectedValue;

                if (valitudPilt != null)
                {
                    toode.Pilt = Path.GetFileName(valitudPilt);
                    Directory.CreateDirectory("Images");
                    File.Copy(valitudPilt, Path.Combine("Images", toode.Pilt), true);
                }

                _db.SaveChanges();
                LaeTooted();

                MessageBox.Show("Toode on uuendatud!");
            }
            catch
            {
                MessageBox.Show("Toote uuendamine ebaõnnestus!");
            }
        }

        private void btnKustuta_Click(object sender, EventArgs e)
        {
            if (dataGridViewTooted.SelectedRows.Count == 0)
            {
                MessageBox.Show("Palun vali toode!");
                return;
            }

            try
            {
                int id = (int)dataGridViewTooted.SelectedRows[0].Cells["Id"].Value;

                var toode = _db.Toodetabel.Find(id);

                _db.Toodetabel.Remove(toode);
                _db.SaveChanges();
                LaeTooted();

                MessageBox.Show("Toode on kustutatud!");
            }
            catch
            {
                MessageBox.Show("Toote kustutamine ebaõnnestus!");
            }
        }


        private void btnArve_Click(object sender, EventArgs e)
        {
            if (dataGridViewTooted.SelectedRows.Count == 0) return;

            int id = (int)dataGridViewTooted.SelectedRows[0].Cells["Id"].Value;
            var toode = _db.Toodetabel.Find(id);

            ArveForm arve = new ArveForm();
            arve.SelectedToode = toode;
            arve.ShowDialog();
        }
       
        private void Form2_Load(object sender, EventArgs e)
        {
            if (AktiivneKasutaja.Roll != "admin")
            {
                btnLisa.Enabled = false;
                btnUuenda.Enabled = false;
                btnKustuta.Enabled = false;
            }
        }

    }
}

