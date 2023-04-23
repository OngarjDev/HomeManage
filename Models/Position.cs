using System.ComponentModel.DataAnnotations;

namespace InsureManage.Models
{
    public partial class Position
    {
        [Key]
        public int IdPosition { get; set; }
        public string NamePosition { get; set; } = null!;
    }
}
