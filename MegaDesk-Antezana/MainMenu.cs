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
    public partial class MainMenu : Form
    {
        MainMenu mainMenu;
        SearchQuotes searchQuotes;
        AddQuote addQuote;
        ViewAllQuotes viewAllQuotes;

        public MainMenu()
        {
            InitializeComponent();
            addQuote = new AddQuote(this);
            searchQuotes = new SearchQuotes(this);
            viewAllQuotes = new ViewAllQuotes();
            this.mainMenu = this;
        }

        private void AddQuoteButton_Click(object sender, EventArgs e)
        {
            AddQuote form = new AddQuote(this);
            form.Show();
            this.Hide();
        }
        private void SearchQuotesButton_Click(object sender, EventArgs e)
        {
            SearchQuotes form = new SearchQuotes(this);
            form.Show();
            this.Hide();
        }        

        private void ViewQuotesButton_Click(object sender, EventArgs e)
        {
            ViewAllQuotes form = new ViewAllQuotes();
            form.Show();
            this.Hide();
        }        
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}
