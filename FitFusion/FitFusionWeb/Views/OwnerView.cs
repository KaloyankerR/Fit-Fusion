using System.ComponentModel.DataAnnotations;

namespace FitFusionWeb.Views
{
    public class OwnerView : UserView
    {
        [Required(ErrorMessage = "Phone is required")]
        public string Phone { get; set; } = string.Empty;

        public override string GetUserRole()
        {
            return "Owner";
        }
    }
}
