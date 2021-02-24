using KittenView.Core.Services;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;


namespace KittenView.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            Mvx.RegisterType<IKittenGenesisService, KittenGenesisService>();
            RegisterNavigationServiceAppStart<ViewModels.FirstViewModel>();
        }
    }
}
