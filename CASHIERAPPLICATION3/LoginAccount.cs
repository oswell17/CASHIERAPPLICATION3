using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CASHIERAPPLICATION3
{
    public partial class LoginAccount : Form
    {
        public LoginAccount()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            
            if (username == username && password == "1234")
            {
                
                PurchaseDiscountedItem cashierForm = new PurchaseDiscountedItem(username);
                //this.Hide();
                cashierForm.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar ='•';
        }
    }
}
