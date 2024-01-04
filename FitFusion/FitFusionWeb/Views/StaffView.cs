using System.ComponentModel.DataAnnotations;

namespace FitFusionWeb.Views
{
    public class StaffView : UserView
    {
        [Required(ErrorMessage = "Phone is required")]
        public string Phone {  get; set; } = string.Empty;

        public override string GetUserRole()
        {
            return "Staff";
        }
    }
}
