using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeduShop.Model.Models
{
    [Table("Tags")]
    public class Tag
    {
        [Key]
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string ID { set; get; }

        [Required]
        [MaxLength(50)]
        public string Name { set; get; }

        [MaxLength(50)]
        [Required]
        public string Type { set; get; }

        //public virtual IEnumerable<ProductTag> ProductTags { set; get; }
        //public virtual IEnumerable<PostTag> PostTags { set; get; }
    }
}