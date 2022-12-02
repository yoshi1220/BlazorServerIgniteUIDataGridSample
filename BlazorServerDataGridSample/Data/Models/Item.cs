using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorServerDataGridSample.Data.Models
{
    [Table("Items")]
    public class Item
    {

        [Key]
        public int Id { get; set; }

        public string? ItemCode { get; set; }

        public string? ItemName { get; set; }

        public decimal UnitPrice { get; set; }

        [Timestamp]
        public byte[]? TimeStamp { get; set; }
    }
}
