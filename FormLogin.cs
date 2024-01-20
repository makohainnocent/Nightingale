using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Configuration;
using Nightingale;
using static Nightingale.Common.Functions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace Nightingale
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        

        private void btLogin_Click(object sender, EventArgs e)
        {
            // Retrieve hashed username and password from configuration
            string storedUsernameHash = ConfigurationManager.AppSettings["Username"];
            string storedPasswordHash = ConfigurationManager.AppSettings["Password"];

            // Retrieve user-entered username and password
            string enteredUsername = tbUsername.Text;
            string enteredPassword = textBox2.Text;

            // Hash the user-entered username and password
            string enteredUsernameHash = ComputeSHA256Hash(enteredUsername);
            string enteredPasswordHash = ComputeSHA256Hash(enteredPassword);

            // Check if the entered username and password match the stored values
            if  (enteredUsernameHash == storedUsernameHash && enteredPasswordHash == storedPasswordHash)
            {
                MessageBox.Show("Login Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.Yes; 
               
            }
            else
            {
                MessageBox.Show("Wrong Credentials!", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DialogResult = DialogResult.No;
            }
        }


        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult = DialogResult.Cancel;
            }
        }


    }
}
