using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ExamenDeStat
{
    public partial class Clienti : Form
    {
        public Clienti()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Informatie lipsa!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string telefon = @"^(0+[6|7]+\d{7})?$";
                Regex r1 = new Regex(telefon);
                string email = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                Regex r2 = new Regex(email);
                if (!r1.IsMatch(textBox4.Text)) MessageBox.Show("Telefonul e gresit!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (!r2.IsMatch(textBox3.Text)) MessageBox.Show("Emailul e gresit!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (r1.IsMatch(textBox4.Text) && r2.IsMatch(textBox3.Text))
                {
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        Client cli = new Client { Nume = textBox5.Text, Prenume = textBox1.Text, Adresa = textBox2.Text, Email = textBox3.Text, Telefon = textBox4.Text };

                        db.Clients.Add(cli);
                        db.SaveChanges();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox4.Text = "";
                        textBox3.Text = "";
                        textBox5.Text = "";
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = db.Clients.ToList();
                        dataGridView1.Columns[0].Visible = false;
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Comenzi f = new Comenzi();
            this.Hide();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Informatie lipsa!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string telefon = @"^(0+[6|7]+\d{7})?$";
                Regex r1 = new Regex(telefon);
                string email = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                Regex r2 = new Regex(email);
                if (!r1.IsMatch(textBox4.Text)) MessageBox.Show("Telefonul e gresit!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (!r2.IsMatch(textBox3.Text)) MessageBox.Show("Emailul e gresit!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (r1.IsMatch(textBox4.Text) && r2.IsMatch(textBox3.Text))
                {
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        Client updCli = (from u in db.Clients where u.CodClient == Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].Value.ToString()) select u).FirstOrDefault();
                        updCli.Nume = textBox5.Text;
                        updCli.Prenume = textBox1.Text;
                        updCli.Adresa = textBox2.Text;
                        updCli.Email = textBox3.Text;
                        updCli.Telefon = textBox4.Text;
                        db.SaveChanges();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox4.Text = "";
                        textBox3.Text = "";
                        textBox5.Text = "";
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = db.Clients.ToList();
                        dataGridView1.Columns[0].Visible = false;
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].Value == null) MessageBox.Show(this, "Nu ați selectat clientul", "Atention!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
              if (MessageBox.Show(this, "Doriti sa stergeti " + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString(), "Sterge", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    Client delCli = (from u in db.Clients where u.Nume == textBox5.Text select u).FirstOrDefault();
                    db.Clients.Remove(delCli);
                    db.SaveChanges();

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = db.Clients.ToList();
                    dataGridView1.Columns[0].Visible = false;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox5.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value.ToString();
        }

        private void Clienti_Load(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {

                dataGridView1.DataSource = db.Clients.ToList();
                dataGridView1.Columns[0].Visible = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Query f = new Query();
            f.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
