using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using File = System.IO.File;

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

        public void CalcQuoteTotalPrice()
        {
            // Calculate the quote total price for the desk
            QuoteTotalPrice = (BASE_PRICE + SurfaceAreaPrice() + CalcDrawersPrice() + MaterialPrice() + RushDaysPrice());
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

        public int CalcDrawersPrice()
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
                    case 0: RushDaysPrice = 0; break;
                    case 3: RushDaysPrice = 60; break;
                    case 5: RushDaysPrice = 40; break;
                    case 7: RushDaysPrice = 30; break;
                    default: RushDaysPrice = 0; break;
                }
            }
            else if (Desk.surfaceArea >= 1000 && Desk.surfaceArea <= 2000)
            {
                switch (rushDays)
                {
                    case 0: RushDaysPrice = 0; break;
                    case 3: RushDaysPrice = 70; break;
                    case 5: RushDaysPrice = 50; break;
                    default: RushDaysPrice = 0; break;
                }
            }
            else
            {
                switch (rushDays)
                {
                    case 0: RushDaysPrice = 0; break;
                    case 3: RushDaysPrice = 80; break;
                    case 5: RushDaysPrice = 60; break;
                    case 7: RushDaysPrice = 40; break;
                    default: RushDaysPrice = 0; break;
                }
            }
            return RushDaysPrice;
        }
    }
}

