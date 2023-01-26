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
    public partial class SearchQuotes : Form
    {
        readonly MainMenu mainMenu;
        public string criteria { get; set; }
        public string searchBy { get; set; }
        public SearchQuotes(MainMenu mainMenu)
        {
            InitializeComponent();
            //mainMenu = mainMenuForm
        }
        public string getSearchBy()
        {
            return this.searchBy = this.SearchComboBox.Text;
        }

        public string getCriteria()
        {
            return this.criteria = this.Criteria.Text;
        }
        private void MainMenuButton_Click(object sender, EventArgs e)
        {
            mainMenu.Show();
            this.Hide();
        }

        private void SearchComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
                DeskQuote deskQuote = new DeskQuote();
                List<DeskQuote> DeskQuotes = new List<DeskQuote>();

                DeskQuotes = deskQuote.SearchQuotes("Quotes.json", this.searchBy, this);

                this.Results.AppendText("Date" + "\t\t");
                this.Results.AppendText("Client" + "\t");
                this.Results.AppendText("Depth" + "\t");
                this.Results.AppendText("Width" + "\t");
                this.Results.AppendText("Sice" + "\t");
                this.Results.AppendText("Material" + "\t\t");
                this.Results.AppendText("Price" + "\n");

                for (int i = 0; i < DeskQuotes.Count; i++)
                {

                    this.Results.AppendText(DeskQuotes.ElementAt(i).TodayDate + "\t");
                    this.Results.AppendText(DeskQuotes.ElementAt(i).CustomerName + "\t");
                    this.Results.AppendText(DeskQuotes.ElementAt(i).Desk.width + "\t");
                    this.Results.AppendText(DeskQuotes.ElementAt(i).Desk.depth + "\t");
                    this.Results.AppendText(DeskQuotes.ElementAt(i).Desk.surfaceArea + "\t");
                    if (DeskQuotes.ElementAt(i).Desk.deskMaterial.Equals("Rosewood"))
                    {
                        this.Results.AppendText(DeskQuotes.ElementAt(i).Desk.deskMaterial + "\t");
                    }
                    else
                    {
                        this.Results.AppendText(DeskQuotes.ElementAt(i).Desk.deskMaterial + "\t\t");
                    }
                    this.Results.AppendText("$" + string.Format("{0:n0}", DeskQuotes.ElementAt(i).QuoteTotalPrice) + "\n");
                }

                this.Search.Enabled = false;
            
        }
    }
}
