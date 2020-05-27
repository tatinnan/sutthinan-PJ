using _02.ShopClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        contactClass1 C1 = new contactClass1();

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            C1.FirstName = textBoxFname.Text;
            C1.LastName = textBoxLname.Text;
            C1.ContactNo = textBoxContact.Text;
            C1.Address = textBoxAddress.Text;
            C1.Brand = cmbGender.Text;
            C1.Number = int.Parse(cmbNumber.Text);
            C1.Size = cmbSize.Text;
            int sum = 0;
            if (cmbGender.Text == "A")
            {
                int p = int.Parse(cmbNumber.Text);
                sum = sum + (p * 2500);
                C1.Price = sum;
            }
            else if (cmbGender.Text == "B")
            {

            }

            bool success = C1.Insert(C1);
            if (success == true)
            {
                MessageBox.Show("New Contact Succesfully Inserted.");
                Clear();
            }
            else
            {
                MessageBox.Show("Failed To add New Contact. Try Again.");
            }
            DataTable dt = C1.Secect();
            dgvContactList.DataSource = dt;
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            DataTable dt = C1.Secect();
            dgvContactList.DataSource = dt;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void Clear()
        {
            textBoxFname.Text = "";
            textBoxLname.Text = "";
            textBoxContact.Text = "";
            textBoxAddress.Text = "";
            cmbGender.Text = "";
            textBoxContactID.Text = "";
            cmbSize.Text = "";
            cmbNumber.Text = "";
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            C1.ContactID = int.Parse(textBoxContactID.Text);
            C1.FirstName = textBoxFname.Text;
            C1.LastName = textBoxLname.Text;
            C1.ContactNo = textBoxContact.Text;
            C1.Address = textBoxAddress.Text;
            C1.Brand = cmbGender.Text;
            C1.Number = int.Parse(cmbNumber.Text);
            C1.Size = cmbSize.Text;
            bool success = C1.Update(C1);
            if (success == true)
            {
                MessageBox.Show("Contact Updated.");
                DataTable dt = C1.Secect();
                dgvContactList.DataSource = dt;
                Clear();
            }
            else
            {
                MessageBox.Show("Failed To Update Contact. Try Again.");
            }
        }
        private void DgvContactList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void ButtonDel_Click(object sender, EventArgs e)
        {
            C1.ContactID = Convert.ToInt32(textBoxContactID.Text);
            bool success = C1.Delete(C1);
            if (success == true)
            {
                MessageBox.Show("Contact Deleted.");
                DataTable dt = C1.Secect();
                dgvContactList.DataSource = dt;
                Clear();
            }
            else
            {
                MessageBox.Show("Failed To Delete Contact. Try Again.");
            }
        }
        static string myconstr = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;


        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBox1.Text;
            SqlConnection conn = new SqlConnection(myconstr);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Shop1 WHERE FirstName LIKE '%" + keyword + "%' OR LastName LIKE '%" + keyword + "%' OR Address LIKE '%" + keyword + "%' ", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvContactList.DataSource = dt;
        }

        private void CmbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void DgvContactList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DgvContactList_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowsIndex = e.RowIndex;
            textBoxContactID.Text = dgvContactList.Rows[rowsIndex].Cells[0].Value.ToString();
            textBoxFname.Text = dgvContactList.Rows[rowsIndex].Cells[1].Value.ToString();
            textBoxLname.Text = dgvContactList.Rows[rowsIndex].Cells[2].Value.ToString();
            textBoxContact.Text = dgvContactList.Rows[rowsIndex].Cells[3].Value.ToString();
            textBoxAddress.Text = dgvContactList.Rows[rowsIndex].Cells[4].Value.ToString();
            cmbGender.Text = dgvContactList.Rows[rowsIndex].Cells[5].Value.ToString();
            cmbNumber.Text = dgvContactList.Rows[rowsIndex].Cells[6].Value.ToString();
            cmbSize.Text = dgvContactList.Rows[rowsIndex].Cells[7].Value.ToString();
            lbP.Text = dgvContactList.Rows[rowsIndex].Cells[8].Value.ToString();
        }
    }
}
