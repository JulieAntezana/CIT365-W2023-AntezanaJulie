using System;
using System.Collections.Generic;
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
            Desk.drawers = drawers;
            Desk.deskMaterial = material;
            RushDays = rushDays;
            


            Desk.surfaceArea = Desk.width * Desk.depth;
        }

        public int CalcQuoteTotalPrice()
        {
            QuoteTotalPrice = (BASE_PRICE + SurfaceAreaPrice() + DrawersPrice());
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

        //private int MaterialPrice(Desk desk, DisplayQuote displayQuote)
        //{
        //    //if (displayQuote.label18.Text == "Oak" || "Laminate" || "Pine" || "Rosewood" || "Veneer")

        //    switch(displayQuote.label18.Text) {
        //        case "Oak": MaterialPrice = Desk.Material.Oak; break;
        //        case "Laminate": MaterialPrice = Desk.Material.Laminate; break;
        //        case "Pine": MaterialPrice = Desk.Material.Pine; break;
        //        case "Rosewood": MaterialPrice = Desk.Material.Rosewood; break;
        //        case "Veneer": MaterialPrice = Desk.Material.Veneer; break;
        //        default: MaterialPrice = 0; break;

        //    return MaterialPrice();


        //}

        //private int calcMaterialPrice(Desk.Material material)
        //{

        //    switch (material)
        //    {
        //        case Desk.Material.Oak:
        //            (int) MaterialPrice = 200;
        //            break;
        //        case Desk.Material.Laminate:
        //            MaterialPrice = 100;
        //            break;
        //        case Desk.Material.Pine:
        //            MaterialPrice = 50;
        //            break;
        //        case Desk.Material.Rosewood:
        //            MaterialPrice = 300;
        //            break;
        //        case Desk.Material.Veneer:
        //            MaterialPrice = 125;
        //            break;
        //    }
        //    return MaterialPrice;
        //}
    }
}
