using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        //public object CIDtxtBox { get; private set; }

        public Form2()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConnectDB a = new ConnectDB();
            a.connectionSql(string.Format("select * from CustomerInvoice where CID={0}", int.Parse(comboBox1.Text)));
            SqlDataReader rdr = a.command.ExecuteReader();
            while (rdr.Read())
            {
                txtBoxCID.Text = rdr["CID"].ToString();
                textBoxName.Text = rdr["CName"].ToString();
                textBoxEmail.Text = rdr["Email"].ToString();
                textBoxPaid.Text = rdr["Paid"].ToString();
   
            }
        }

        public void comboboxRefresh()
        {
            comboBox1.Items.Clear();
            ConnectDB a = new ConnectDB();
            a.connectionSql(string.Format("select CID from CustomerInvoice"));
            SqlDataReader rdr = a.command.ExecuteReader();
            while (rdr.Read())
            {
                comboBox1.Items.Add(rdr[0].ToString());
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConnectDB a = new ConnectDB();
            a.connectionSql(string.Format("insert into CustomerInvoice values({0},'{1}','{2}',{3})", int.Parse(txtBoxCID.Text), textBoxName.Text, textBoxEmail.Text, double.Parse(textBoxPaid.Text)));
            if (a.command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show($"CID: {txtBoxCID.Text} Successfully added");
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            comboboxRefresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConnectDB a = new ConnectDB();
            a.connectionSql(string.Format("update CustomerInvoice set CName='{1}',Email='{2}',Paid={3} where CID={0}", int.Parse(txtBoxCID.Text), textBoxName.Text, textBoxEmail.Text, double.Parse(textBoxPaid.Text)));
            if (a.command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show($"ID: {txtBoxCID.Text} Successfully updated");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ConnectDB a = new ConnectDB();
            a.connectionSql(string.Format("delete CustomerInvoice where CID={0}", int.Parse(txtBoxCID.Text)));
            if (a.command.ExecuteNonQuery() == 1)
            {
                comboboxRefresh();
                MessageBox.Show($"ID: {txtBoxCID.Text} Successfully deleted");
            }
        }
    }
}
