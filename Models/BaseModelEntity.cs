using System.ComponentModel.DataAnnotations;

namespace DotNetCore8Api.Models
{
    public class BaseModelEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedId { get; set; }
        public int? UpdatedId { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
