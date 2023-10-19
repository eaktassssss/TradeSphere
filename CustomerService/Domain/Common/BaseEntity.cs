using System.ComponentModel.DataAnnotations;

namespace CustomerService.Domain.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        [StringLength(50)]
        public string CreatedBy { get; set; } = "System User";
        public bool IsDeleted { get; set; } = false;
    }
}
