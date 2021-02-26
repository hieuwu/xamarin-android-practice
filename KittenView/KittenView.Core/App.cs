using KittenView.Core.Services;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;

namespace KittenView.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                        .EndingWith("Service")
                        .AsInterfaces()
                        .RegisterAsLazySingleton();
            RegisterNavigationServiceAppStart<ViewModels.FirstViewModel>();
        }
    }
}
