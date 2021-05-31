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

namespace Grocery_Store
{
    public partial class SellerForm : Form
    {
        public SellerForm()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\Grocery Store\Grocery Store\Database1.mdf; Integrated Security=True");

        private void populate()
        {
            con.Open();
            string query = "select * from SellerTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            SellerDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void SellerForm_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void SellerDGV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            SId.Text = SellerDGV.SelectedRows[0].Cells[0].Value.ToString();
            SName.Text = SellerDGV.SelectedRows[0].Cells[1].Value.ToString();
            SAge.Text = SellerDGV.SelectedRows[0].Cells[2].Value.ToString();
            SPhone.Text = SellerDGV.SelectedRows[0].Cells[3].Value.ToString();
            SPass.Text = SellerDGV.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "insert into SellerTbl values(" + SId.Text + ",'" + SName.Text + "','" + SAge.Text + "','" + SPhone.Text + "','" + SPass.Text + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Seller Detail Added Successfully");
                con.Close();
                populate();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (SId.Text == "" || SName.Text == "" || SAge.Text == "" || SPhone.Text == ""|| SPass.Text == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    con.Open();
                    string query = "update SellerTbl set SellerName= '" + SName.Text + "',SellerAge='" + SAge.Text + "', SellerPhone=" + SPhone.Text + ", SellerPass='"+SPass.Text+"'where SellerId=" + SId.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Seller Detail Updated");
                    con.Close();
                   // fillcombo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (SId.Text == "")
                {
                    MessageBox.Show("Select Seller to Delete");
                }
                else
                {
                    con.Open();
                    string query = "delete from SellerTbl where SellerId=" + SId.Text + "";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Seller Deleted Successfully");
                    con.Close();
                    populate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CategoryForm cat = new CategoryForm();
            cat.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Product prod = new Product();
            prod.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SellingForm sell = new SellingForm();
            sell.Show();
            this.Hide();
        }

        private void SName_TextChanged(object sender, EventArgs e)
        {

        }

        private void SId_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
