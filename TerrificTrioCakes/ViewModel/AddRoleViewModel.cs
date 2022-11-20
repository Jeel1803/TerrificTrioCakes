using System.ComponentModel.DataAnnotations;

namespace TerrificTrioCakes.ViewModel
{

    //Hosam: AddRoleViewModel class
    public class AddRoleViewModel
    {

        [Required]
        [Display(Name = "Role")]
        public string RoleName { get; set; }
    }
}
