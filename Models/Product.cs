namespace InsureManage.Models
{
    public partial class Product
    {
        public int IdProduct { get; set; }
        public string NameProduct { get; set; } = null!;
        public int PositionProduct { get; set; }
        public DateTime? DateBuyProduct { get; set; }
        public DateTime? DateEndInsureProduct { get; set; }
        public string? NoteProduct { get; set; }
    }
}
