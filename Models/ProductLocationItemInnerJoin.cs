namespace InsureManage.Models
{
    /// <summary>
    /// Model นี้สร้างคือมาเพื่อรองรับ InnerJoin ไปแสดงผลยัง Table ได้หลากหลาย
    /// property นี้เป็นส่วนที่สร้างโดยอิงจากข้อมูลที่ต้องการทราบ
    /// </summary>
    public class ProductLocationItemInnerJoin
    {
        public int IdProduct { get; set; }
        public string NameProduct { get; set; } = string.Empty;
        public DateOnly DateBuyProduct { get; set; }
        public DateOnly DateEndProduct { get; set; }
        public string NoteProduct { get; set; } = string.Empty;
        public string NameLocationItem { get; set; } = string.Empty;
    }
}
