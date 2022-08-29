using System.ComponentModel.DataAnnotations;

namespace Website_demomvc.DTO
{
    public class Category
    {
        [Key]
        public int CatId { get; set; }
        [Required]
        public string CatName { get; set; }
        [Required]
        public string CatDescribe { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
