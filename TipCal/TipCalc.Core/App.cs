using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using TipCalc.Core.Services;
using TipCalc.Core.ViewModels;

namespace TipCalc.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            //Register CalculationService class to implement ICalculationService service
            Mvx.RegisterType<ICalculationService, CalculationService>();

            //Tell the MvvmCross that TipViewModel should be the first
            //ViewModel/View pair appears when the app starts
            RegisterNavigationServiceAppStart<TipViewModel>();
        }
    }
}
