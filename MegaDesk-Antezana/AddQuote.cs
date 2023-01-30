using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
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
            //this.SaveQuote.Enabled = false;
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
            form.rushDays = RushDaysComboBox.Text;
            DeskQuote quote = new DeskQuote(DateTime.Parse(currentDate.Text), form.customerName, int.Parse(form.width), int.Parse(form.depth), int.Parse(form.drawers), form.material, int.Parse(form.rushDays));
            form.DrawersPrice = $"{quote.DrawersPrice}";
            form.QuoteTotalPrice = $"{quote.QuoteTotalPrice}";
            form.ShowDialog();
        }

        private void MainMenuButton_Click(object sender, EventArgs e)
        {
            MainMenu mainMenuForm = new MainMenu();
            mainMenuForm.Show();
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
        //    DeskQuote deskQuote.saveQuote(this);
        //    this.SaveQuote.Enabled = false;
        //    System.Windows.Forms.MessageBox.Show("The quote has been saved successfully");
        //}


        public void checkFields()
        {
            if (this.customerName.Text != "" && this.depth.Text != "" && this.width.Text != ""
                && this.drawers.Text != "" && this.rushDays.Text != "")
            {
                //this.SaveQuote.Enabled = true;
            }
        }

        private void CustomerName_TextChanged(object sender, EventArgs e)
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

        //private void width_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) || (e.KeyChar) == (char)Keys.Back)
        //    {
        //        e.Handled = false;
        //    }
        //    else
        //    {
        //        e.Handled = true;
        //        MessageBox.Show("Please enter a number between 24 and 96");
        //    }
        //}



        private void width_Validating_1(object sender, CancelEventArgs e)
        {
            if (width.Text == string.Empty)
            {
                errorProvider1.SetError(width, "Please enter a number between 24 and 96");
                errorProvider2.SetError(width, "");
                errorProvider3.SetError(width, "");
            }
            else
            {
                Regex numberchk = new Regex(@"^([0-9]*|\d*)$");
                if (numberchk.IsMatch(width.Text) && int.Parse(width.Text) >= MINWIDTH && int.Parse(width.Text) <= MAXWIDTH)
                {
                    errorProvider1.SetError(width, "");
                    errorProvider2.SetError(width, "");
                    errorProvider3.SetError(width, "You entered a number between 24 and 96");
                }
                else
                {
                    errorProvider1.SetError(width, "");
                    errorProvider2.SetError(width, "Please enter a number between 24 and 96");
                    errorProvider3.SetError(width, "");
                }
            }
        }

        private void depth_Validating(object sender, CancelEventArgs e)
        {
            if (depth.Text == string.Empty)
            {
                errorProvider1.SetError(depth, "Please enter a number between 12 and 48");
                errorProvider2.SetError(depth, "");
                errorProvider3.SetError(depth, "");
            }
            else
            {
                Regex numberchk = new Regex(@"^([0-9]*|\d*)$");
                if (numberchk.IsMatch(depth.Text) && int.Parse(depth.Text) >= MINDEPTH && int.Parse(depth.Text) <= MAXDEPTH)
                {
                    errorProvider1.SetError(depth, "");
                    errorProvider2.SetError(depth, "");
                    errorProvider3.SetError(depth, "You entered a number between 12 and 48");
                }
                else
                {
                    errorProvider1.SetError(depth, "");
                    errorProvider2.SetError(depth, "Please enter a number between 12 and 48");
                    errorProvider3.SetError(depth, "");
                }
            }
        }

        private void customerName_Validating(object sender, CancelEventArgs e)
        {
            if (customerName.Text == string.Empty)
            {
                errorProvider1.SetError(customerName, "Please enter name");
                errorProvider2.SetError(customerName, "");
                errorProvider3.SetError(customerName, "");
            }
            else
                if (!Regex.IsMatch(customerName.Text, @"[\p{L} ]+$"))
                {
                errorProvider1.SetError(customerName, "Please enter name with letters");
                errorProvider2.SetError(customerName, "");
                errorProvider3.SetError(customerName, "");
            }

            else
            {
                errorProvider1.SetError(customerName, "");
                errorProvider2.SetError(customerName, "");
                errorProvider3.SetError(customerName, "You entered a name");
            }
        }
    }
}
