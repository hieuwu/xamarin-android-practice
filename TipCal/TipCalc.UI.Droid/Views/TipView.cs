using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TipCalc.UI.Droid.Views
{
    [Activity(Label = "Tip", MainLauncher = true)]
    class TipView : MvxActivity
    {
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.TipView);
        }
    }
}