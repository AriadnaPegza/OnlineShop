using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamenDeStat
{
    public partial class Comenzi : Form
    {
        public Comenzi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Informatie lipsa!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                using (ApplicationContext db = new ApplicationContext())
                {
                    Comanda com = new Comanda { DataComanda = dateTimePicker1.Value.Date, SumaTotala = double.Parse(textBox1.Text), NumeClient = comboBox1.Text, CodClient = (int)comboBox1.SelectedValue };

                    db.Comands.Add(com);
                    db.SaveChanges();
                    textBox1.Text = "";
                    comboBox1.Text = "";
                    dateTimePicker1.Value = DateTime.Now.Date;
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = db.Comands.ToList();
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[3].Visible = false;
                    dataGridView1.Columns[5].Visible = false;
                }
            }
        }

        private void Comenzi_Load(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var cli = db.Clients.ToList();

                var displayItems = cli.Select(p => new
                {
                    FullName = $"{p.Nume} {p.Prenume}",
                    Id = p.CodClient
                }).ToList();
                comboBox1.DataSource = displayItems;
                comboBox1.DisplayMember = "FullName";
                comboBox1.ValueMember = "Id";
                dataGridView1.DataSource = db.Comands.ToList();
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[5].Visible = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Clienti f = new Clienti();
            this.Hide();
            f.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value);
            comboBox1.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Informatie lipsa!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                using (ApplicationContext db = new ApplicationContext())
                {
                    Comanda updCom = (from u in db.Comands where u.CodComanda == Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].Value.ToString()) select u).FirstOrDefault();
                    updCom.DataComanda = dateTimePicker1.Value.Date;
                    updCom.SumaTotala = double.Parse(textBox1.Text);
                    updCom.NumeClient = comboBox1.Text;
                    db.SaveChanges();
                    textBox1.Text = "";
                    comboBox1.Text = "";
                    dateTimePicker1.Value = DateTime.Now.Date;
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = db.Comands.ToList();
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[3].Visible = false;
                    dataGridView1.Columns[5].Visible = false;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox1.Text = "";
            dateTimePicker1.Value = DateTime.Now.Date;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].Value == null) MessageBox.Show(this, "Nu ați selectat comanda", "Atention!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
             if (MessageBox.Show(this, "Doriti sa stergeti comanda clientului " + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString(), "Sterge", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    Comanda delCom = (from u in db.Comands where u.NumeClient == comboBox1.Text select u).FirstOrDefault();
                    db.Comands.Remove(delCom);
                    db.SaveChanges();

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = db.Clients.ToList();
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[3].Visible = false;
                    dataGridView1.Columns[5].Visible = false;
                }
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

