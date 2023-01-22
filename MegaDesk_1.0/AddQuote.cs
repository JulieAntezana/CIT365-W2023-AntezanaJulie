using System;
using System.Windows.Forms;

namespace MegaDesk_1._0
{
    public partial class AddQuote : Form
    {
        public AddQuote() => InitializeComponent();

        private void Button_Transfer_Click(object sender, EventArgs e)
        {
            DisplayQuote form = new DisplayQuote();
            form.fullName = textBox1.Text;
            form.width = textBox2.Text;
            form.depth = textBox3.Text;
            form.drawers = textBox4.Text;
            form.material = textBox5.Text;
            form.rush = textBox6.Text;
            form.ShowDialog();


        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }
    }
}
