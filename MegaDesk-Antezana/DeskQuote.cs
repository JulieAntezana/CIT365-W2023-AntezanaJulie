using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk_Antezana
{
    class DeskQuote
    {
        // Attributes
        public DateTime TodayDate;
        public string CustomerName;
        public Desk Desk = new Desk();
        public int RushDays;
        public int QuoteTotalPrice;
        public int[,] extraCharges = new int[3, 3];

        // Constraints
        private const int BASE_PRICE = 200;
        private const int SIZE_THRESHOLD = 1000;
        private const int PRICE_PER_DRAWER = 50;
        private const int AREA_PRICE_PER_IN = 1;
        private const int RUSH_THRESHOLD = 2000;

        public DeskQuote(DateTime quoteDate, string customerName, int width, int depth, int drawers, string material, int rushDays)
        {
            TodayDate = quoteDate;
            CustomerName = customerName;
            Desk.width = width;
            Desk.depth = depth;
            Desk.drawers = drawers;
            Desk.deskMaterial = material;
            RushDays = rushDays;
            Desk.surfaceArea = Desk.width * Desk.depth;
            CalcQuoteTotalPrice();
        }

        public DeskQuote()
        {
        }

        public void CalcQuoteTotalPrice()
        {
            // Calculate the quote total price for the desk
            QuoteTotalPrice = (BASE_PRICE + SurfaceAreaPrice() + DrawersPrice() + MaterialPrice() + RushDaysPrice());
        }

        private int SurfaceAreaPrice()
        {
            // check the size threshold
            if (Desk.surfaceArea > SIZE_THRESHOLD)
            {
                return (Desk.surfaceArea - SIZE_THRESHOLD) * AREA_PRICE_PER_IN;
            }
            else
            {
                return 0;
            }
        }

        private int DrawersPrice()
        {
            int DrawersPrice = Desk.drawers * PRICE_PER_DRAWER;
            return DrawersPrice;
        }

        private int MaterialPrice()
        {
            string material = Desk.deskMaterial;
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

        private int RushDaysPrice()
        {
            int rushDays = this.RushDays;
            int RushDaysPrice = 0;
            if (Desk.surfaceArea > 0 && Desk.surfaceArea < 1000)
            {
                switch (rushDays)
                {
                    case 3: RushDaysPrice = extraCharges[0, 0]; break;
                    case 5: RushDaysPrice = extraCharges[0, 1]; break;
                    case 7: RushDaysPrice = extraCharges[0, 2]; break;
                    default: RushDaysPrice = 0; break;
                }
            }
            else if (Desk.surfaceArea >= 1000 && Desk.surfaceArea <= 2000)
            {
                switch (rushDays)
                {
                    case 3: RushDaysPrice = extraCharges[1, 0]; break;
                    case 5: RushDaysPrice = extraCharges[1, 1]; break;
                    case 7: RushDaysPrice = extraCharges[1, 2]; break;
                    default: RushDaysPrice = 0; break;
                }
            }
            else
            {
                switch (rushDays)
                {
                    case 3: RushDaysPrice = extraCharges[2, 0]; break;
                    case 5: RushDaysPrice = extraCharges[2, 1]; break;
                    case 7: RushDaysPrice = extraCharges[2, 2]; break;
                    default: RushDaysPrice = 0; break;
                }
            }
            return RushDaysPrice;
        }

        public int[,] GetRushOrder(string fileName)
        {

            int[,] extraCharges = new int[3, 3];

            try
            {
                string[] lines = File.ReadAllLines(fileName);

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        extraCharges[i, j] = int.Parse(lines[j + (3 * i)]);
                    }
                }
            }
            catch (IOException e)
            {
                System.Windows.Forms.MessageBox.Show("There was a problem while trying to read the file" + e);
            }
            catch (NullReferenceException ne)
            {
                System.Windows.Forms.MessageBox.Show("Null point exception " + ne);
            }

            return extraCharges;
        }

        public List<DeskQuote> ReadJSONFile(string file)
        {
            StreamReader sr = new StreamReader(file);
            List<DeskQuote> deskQuotes = new List<DeskQuote>();
            string JSONString;

            try
            {
                while (!sr.EndOfStream)
                {
                    JSONString = sr.ReadLine();
                    DeskQuote deskQuote = new DeskQuote();
                    deskQuote = JsonConvert.DeserializeObject<DeskQuote>(JSONString);
                    deskQuotes.Add(deskQuote);
                }
            }
            catch (IOException e)
            {
                System.Windows.Forms.MessageBox.Show("There was a problem trying to read the file" + e);
            }

            sr.Close();
            return deskQuotes;
        }

        public void writeJSONFile(string file, AddQuote addQuote)
        {
            Desk = new Desk();

            Desk.width = addQuote.getDeskDepth();
            Desk.depth = addQuote.getDeskWidth();
            Desk.surfaceArea = addQuote.getDeskDepth() * addQuote.getDeskWidth();
            Desk.drawers = addQuote.getDeskDrawers();
            Desk.deskMaterial = addQuote.getMaterial();

            this.CustomerName = addQuote.getCustomerName();
            this.RushDays = addQuote.getRushDays();

            //this.CalcQuoteTotalPrice(Desk, addQuote);
            //this.date = addQuote.getDate();
            //addQuote.setSurfaceArea(Desk.surfaceArea);
            //addQuote.setPrice(this.price);

            try
            {
                StreamWriter sw = new StreamWriter(file, append: true);
                string jsonString = JsonConvert.SerializeObject(this);
                sw.WriteLine(jsonString);
                sw.Close();
            }
            catch (IOException e)
            {

            }
        }

        public void SaveQuote(AddQuote addQuote)
        {
            writeJSONFile("Quotes.json", addQuote);
        }

        public List<DeskQuote> SearchQuotes(string file, string searchBy, SearchQuotes searchQuotes)
        {
            StreamReader sr = new StreamReader(file);
            List<DeskQuote> deskQuotes = new List<DeskQuote>();
            string JSONString;

            try
            {
                while (!sr.EndOfStream)
                {
                    JSONString = sr.ReadLine();
                    DeskQuote deskQuote = new DeskQuote();
                    deskQuote = JsonConvert.DeserializeObject<DeskQuote>(JSONString);

                    if (searchQuotes.getSearchBy().Equals("Customer"))
                    {
                        if (searchQuotes.getCriteria() == deskQuote.CustomerName)
                        {
                            deskQuotes.Add(deskQuote);
                        }
                    }
                    else if (searchQuotes.getSearchBy().Equals("Material"))
                    {
                        if (searchQuotes.getCriteria() == deskQuote.Desk.deskMaterial)
                        {
                            deskQuotes.Add(deskQuote);
                        }
                    }
                }
            }
            catch (IOException e)
            {
                System.Windows.Forms.MessageBox.Show("There was a problem trying to read the file" + e);
            }
            sr.Close();
            return deskQuotes;
        }

    }
}

