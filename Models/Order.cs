using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogiTrack.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public string CustomerName { get; set; } = string.Empty;

        [Required]
        public DateTime OrderDate { get; set; }

        // ✅ Add this navigation property
        public ICollection<InventoryItem> Items { get; set; } = new List<InventoryItem>();
    }
}
