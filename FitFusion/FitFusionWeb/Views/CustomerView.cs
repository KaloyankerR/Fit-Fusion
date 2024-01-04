using System.ComponentModel.DataAnnotations;

namespace FitFusionWeb.Views
{
    public class CustomerView : UserView
    {
        // TODO: data annotation change
        [Range(0, int.MaxValue, ErrorMessage = "NutriPoints must be a non-negative value.")]
        public int NutriPoints { get; set; }

        public override string GetUserRole()
        {
            return "Customer";
        }
    }
}
