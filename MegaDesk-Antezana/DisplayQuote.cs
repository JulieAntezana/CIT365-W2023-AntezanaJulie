using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        public DisplayQuote()
        {
            InitializeComponent();
        }

        private void DisplayQuote_Load(object sender, EventArgs e)
        {
            label15.Text = currentDate;
            label7.Text = customerName;
            label8.Text = width;
            label9.Text = depth;
            label10.Text = drawers;
            label11.Text = material;
            label12.Text = rushDays;
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

    }
}
