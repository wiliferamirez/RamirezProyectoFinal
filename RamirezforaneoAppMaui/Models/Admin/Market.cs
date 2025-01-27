using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamirezforaneoAppMaui.Models.Admin
{
    public class Market
    {
        public int MarketItemId { get; set; }

        public string ItemSellerId { get; set; }

        public string ItemName { get; set; }

        public string ItemDescription { get; set; }

        public string ItemImageUrl { get; set; }

        public decimal ItemPrice { get; set; }

        public int CategoryId { get; set; }

        public DateTime ItemCreationDate { get; set; } = DateTime.Now;
    }
}
