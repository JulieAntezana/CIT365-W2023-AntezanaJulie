using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaDesk_Antezana
{
    public partial class AddQuote : Form
    {
        public const int MINWIDTH = 24;
        public const int MAXWIDTH = 96;
        public const int MINDEPTH = 12;
        public const int MAXDEPTH = 48;
        public AddQuote()
        {
            InitializeComponent();
            // Set the current date on the form
            timer1.Start();
            // this.SaveQuote.Enabled = false;
            // 
        }


        private void ShowQuoteButton_Click(object sender, EventArgs e)
        {
            DisplayQuote form = new DisplayQuote();
            form.currentDate = currentDate.Text;
            form.customerName = customerName.Text;
            form.width = width.Text;
            form.depth = depth.Text;
            form.drawers = drawers.Text;
            form.material = material.Text;
            form.rushDays = rushDays.Text;
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainMenu form = new MainMenu();
            form.Show();
            this.Hide();
        }

        public string getDate()
        {
            return this.TodayDate.Text;
        }

        public void setDate(string date)
        {
            this.TodayDate.Text = date;
        }

        private void AddQuote_Load(object sender, EventArgs e)
        {
            currentDate.Text = DateTime.Now.ToString("dd MMMM yyyy");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            currentDate.Text = DateTime.Now.ToString("dd MMMM yyyy");
        }
    }
}
