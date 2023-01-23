using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk_Antezana.Properties
{
    class DeskQuote
    {
        // Attributes
        public DateTime QuoteDate;
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

        public DeskQuote(DateTime quoteDate, string customerName, int width, int depth, int drawers, Desk.Material material, int rushDays)
        {
            QuoteDate = quoteDate;
            CustomerName = customerName;
            Desk.width = width;
            Desk.depth = depth;
            Desk.drawers= drawers;
            Desk.deskMaterial = material;
            RushDays = rushDays;

            Desk.surfaceArea = Desk.width * Desk.depth;            
        }

        public double CalcQuoteTotalPrice() 
        {
            QuoteTotalPrice = BASE_PRICE + SurfaceAreaPrice() + DrawersPrice() + MaterialPrice + RushDays;
            return QuoteTotalPrice; 
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
    }
}
