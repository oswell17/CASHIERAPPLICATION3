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
    public partial class PurchaseDiscountedItem : Form
    {
        private string loggedInUser;
        DiscountedItem item = new DiscountedItem();
        public class Item
        {
            public string ItemName { get; set; }
            public double Price { get; set; }
            public int Quantity { get; set; }
        }
        public class DiscountedItem : Item
        {
            public double Discount { get; set; }
            public double GetTotalAmount()
            {
                double discountedPrice = Price * (1 - (Discount * 0.01));
                return discountedPrice * Quantity;
            }
        }
        public PurchaseDiscountedItem(string username)
        {
            InitializeComponent();
            loggedInUser = username;
            MessageBox.Show("Welcome, " + loggedInUser);


        }

        private void PurchaseDiscountedItem_Load(object sender, EventArgs e)
        {
            
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exitApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public class UserAccount
        {
            protected string Username { get; set; }
            protected string Password { get; set; }

            public UserAccount(string username, string password)
            {
                Username = username;
                Password = password;
            }

            public virtual bool Login(string inputUsername, string inputPassword)
            {
                return Username == inputUsername && Password == inputPassword;
            }
        }

        public class Cashier : UserAccount
        {
            public string Department { get; set; }

            public Cashier(string username, string password, string department)
                : base(username, password)
            {
                Department = department;
            }

            public override bool Login(string inputUsername, string inputPassword)
            {
               
                return base.Login(inputUsername, inputPassword);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                item.Price = Convert.ToDouble(Pricetxtbox.Text);
                item.Discount = Convert.ToDouble(Discounttxtbox.Text);
                item.Quantity = Convert.ToInt32(Quantitytxtbox.Text);

                double totalAmount = item.GetTotalAmount();
                label6TotalAm.Text =" "+ totalAmount.ToString("F2");
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR!! Enter Valid Numbers for Price, Discount, and Quantity.");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                double totalAmount = Convert.ToDouble(label6TotalAm.Text.Split(':')[1]);
                double paymentReceived = Convert.ToDouble(Paymenttxtbox.Text);

                if (paymentReceived >= totalAmount)
                {
                    double change = paymentReceived - totalAmount;
                    label9Change.Text = " "+change.ToString("F2");
                }
                else
                {
                    MessageBox.Show("Payment received is less than the total amount.");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("ERROR!! calculate the total amount first and enter a valid payment.");
            }
        }
    }
}
