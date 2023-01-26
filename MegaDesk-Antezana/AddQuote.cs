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
        MainMenu mainMenu;
        // constraints on desk width and depth
        public const int MINWIDTH = 24;
        public const int MAXWIDTH = 96;
        public const int MINDEPTH = 12;
        public const int MAXDEPTH = 48;
        public AddQuote(MainMenu mainMenuForm)
        {
            InitializeComponent();
            mainMenu = mainMenuForm;
            // Set the current date on the form
            timer1.Start();
            this.SaveQuote.Enabled = false;
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
            form.rushDays = rushDaysOptions.Text;
            DeskQuote quote = new DeskQuote(DateTime.Parse(currentDate.Text), form.customerName, int.Parse(form.width), int.Parse(form.depth), int.Parse(form.drawers), form.material, int.Parse(form.rushDays));
            form.QuoteTotalPrice = $"{quote.QuoteTotalPrice}";
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainMenu mainMenuForm = new MainMenu();
            mainMenuForm.Show();
            this.Close();
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



        //public void setSurfaceArea(int size)
        //{
        //    this.s.Text = string.Format("{0:n0}", size.ToString());
        //}

        //public void setPrice(int price)
        //{
        //    DeskQuote.quote.QuoteTotalPrice.Text = "$" + string.Format("{0:n0}", price.ToString());
        //}


        //private void SaveQuote_Click(object sender, EventArgs e)
        //{
        //    DeskQuote quote = new DeskQuote);
        //    deskQuote.saveQuote(this);
        //    this.SaveQuote.Enabled = false;
        //    System.Windows.Forms.MessageBox.Show("The quote has been saved successfully");
        //}


        public void checkFields()
        {
            if (this.customerName.Text != "" && this.depth.Text != "" && this.width.Text != ""
                && this.drawers.Text != "" && this.rushDays.Text != "")
            {
                this.SaveQuote.Enabled = true;
            }
        }

        private void ClientName_TextChanged(object sender, EventArgs e)
        {
            checkFields();
        }

        private void DeskWidth_TextChanged(object sender, EventArgs e)
        {
            checkFields();
        }

        private void DeskDepth_TextChanged(object sender, EventArgs e)
        {
            checkFields();
        }

        private void rushDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkFields();
        }

        private void Material_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkFields();
        }

        private void DeskDrawers_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkFields();
        }

        private void DeskSurface_TextChanged(object sender, EventArgs e)
        {
            checkFields();
        }


        public bool CheckWidth()
        {

            int width = Convert.ToInt32(this.width.Text);

            if (width < MINWIDTH || width > MAXWIDTH)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        private void Width_Validating(object sender, CancelEventArgs e)
        {
            bool result = CheckWidth();
            string errorMessage = "Width not correct";

            if (!result)
            {
                e.Cancel = true;
                width.Select(0, width.Text.Length);
                System.Windows.Forms.MessageBox.Show(errorMessage);
            }
        }

        public bool CheckDepth()
        {
            int depth = Convert.ToInt32(this.depth.Text);

            if (depth < MINDEPTH || depth > MAXDEPTH)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void DeskDepth_Validating(object sender, CancelEventArgs e)
        {
            bool result = CheckDepth();
            string errorMessage = "Depth not correct";

            if (!result)
            {
                depth.Select(0, depth.Text.Length);
                System.Windows.Forms.MessageBox.Show(errorMessage);
            }
        }

        public string getMaterial()
        {
            return this.material.Text;
        }

        private int calcMaterialPrice()
        {
            string material = getMaterial();
            int MaterialPrice = 0;

            switch (material) 
            {
                case "Oak": 
                    MaterialPrice = 200;
                break;
                case "Laminate":
                    MaterialPrice = 100;
                break;
                case "Pine":
                    MaterialPrice = 50;
                break;
                case "Rosewood":
                    MaterialPrice = 300;
                break;
                case "Veneer":
                    MaterialPrice = 125;
                break;
            }
            return MaterialPrice;
        }

        public int getDeskWidth()
        {
            return Convert.ToInt32(this.width.Text);
        }

        public int getDeskDepth()
        {
            return Convert.ToInt32(this.depth.Text);
        }

        public int getDeskDrawers()
        {
            return Convert.ToInt32(this.drawers.Text);
        }

        public String getCustomerName()
        {
            return this.customerName.Text;
        }

        public int getRushDays()
        {
            return Convert.ToInt32(this.rushDays.Text);
        }
    }
}
