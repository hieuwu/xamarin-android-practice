using Android.App;
using Android.Content;

using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using KittenView.Core;
namespace KittenView.Droid
{
    class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }
        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

    }
}