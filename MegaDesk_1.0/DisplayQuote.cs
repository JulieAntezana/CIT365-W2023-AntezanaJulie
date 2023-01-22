using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaDesk_1._0
{
    public partial class DisplayQuote : Form
    {
        public string fullName { get; set; }
        public string width { get; set; }
        public string depth { get; set; }
        public string drawers { get; set; }
        public string material { get; set; }
        public string rush { get; set; }

        public DisplayQuote()
        {
            InitializeComponent();
        }

        private void DisplayQuote_Load(object sender, EventArgs e)
        {
            label1.Text = fullName;
            label2.Text = width;
            label3.Text = depth;
            label4.Text = drawers;
            label5.Text = material;
            label6.Text = rush;
        }
    }
}
 

