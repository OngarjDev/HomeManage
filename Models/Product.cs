using System;
using System.Collections.Generic;

namespace InsureManage.Models
{
    public partial class Product
    {
        public int IdProduct { get; set; }
        public string NameProduct { get; set; } = null!;
        public int PositionProduct { get; set; }
        public string? DateBuyProduct { get; set; }
        public string? DateEndInsureProduct { get; set; }
        public string? NoteProduct { get; set; }
    }
}
