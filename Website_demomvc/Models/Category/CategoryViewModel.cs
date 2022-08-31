using System.ComponentModel.DataAnnotations;

namespace Website_demomvc.Models.Category
{
    
    public class CategoryViewModel
    {
        [Key]
        public int CatId { get; set; }

        public string CatName { get; set; }

        public string CatDescribe { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
