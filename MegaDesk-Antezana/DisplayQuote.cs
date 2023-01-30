using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MegaDesk_Antezana
{
    public partial class DisplayQuote : Form
    {
        public string currentDate { get; set; }
        public string customerName { get; set; }
        public string width { get; set; }
        public string depth { get; set; }
        public string drawers { get; set; }
        public string material { get; set; }
        public string rushDays { get; set; }

        public string QuoteTotalPrice { get; set; }
        public string DrawersPrice { get; set; }
        public string MaterialPrice { get; set; }
        public string RushDaysPrice { get; set; }

        public DisplayQuote()
        {
            InitializeComponent();
        }

        private void DisplayQuote_Load(object sender, EventArgs e)
        {
            label15.Text = currentDate;
            label17.Text = customerName;
            label8.Text = width;
            label9.Text = depth;
            label10.Text = drawers;
            label2.Text = "$ " + DrawersPrice;
            label11.Text = material;
            label4.Text = "$ " + MaterialPrice;
            label12.Text = rushDays;
            label6.Text = "$ " + RushDaysPrice;
            label18.Text = "$ " + QuoteTotalPrice;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainMenu form = new MainMenu();
            form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void SaveQuoteButton_Click(object sender, EventArgs e)
        {
            //SaveQuote = saveQuote;
            //DeskQuote deskQuote.saveQuote(this);
            //this.SaveQuote.Enabled = false;
            System.Windows.Forms.MessageBox.Show("The quote has been saved successfully");
        }
    }
}
