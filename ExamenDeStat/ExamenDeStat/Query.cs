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
    public partial class Query : Form
    {
        public Query()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                double v = double.Parse(textBox1.Text);

                var sumCli = from c in db.Clients
                             join o in db.Comands on c.CodClient equals o.CodClient
                             where o.SumaTotala > v
                             select new { 
                             c.Nume,
                             c.Prenume,
                             o.SumaTotala
                             };
                dataGridView1.DataSource = sumCli.ToList();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
