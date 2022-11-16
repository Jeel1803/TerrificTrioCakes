using System.ComponentModel.DataAnnotations;

namespace TerrificTrioCakes.ViewModel
{
    public class AddRoleViewModel
    {

        [Required]
        [Display(Name = "Role")]
        public string RoleName { get; set; }
    }
}
