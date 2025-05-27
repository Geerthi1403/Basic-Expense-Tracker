using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Basic_Expense_Tracker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddExpense_Click(object sender, EventArgs e)
        {
            //Updated Code with Validation

            string description = txtDescription.Text.Trim();
            string amountText = txtAmount.Text.Trim();
            DateTime date = dtpDate.Value;

            if (string.IsNullOrEmpty(description))
            {
                MessageBox.Show("Description cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(amountText, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Amount must be a positive number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string expenseEntry = $"{date.ToShortDateString()} - {description} - {amount:C}";
            lstExpenses.Items.Add(expenseEntry);

            txtDescription.Clear();
            txtAmount.Clear();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            txtDescription.Clear();
            txtAmount.Clear();
            dtpDate.Value = DateTime.Today;

        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (lstExpenses.SelectedIndex != -1)
            {
                lstExpenses.Items.RemoveAt(lstExpenses.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Please select an expense to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
