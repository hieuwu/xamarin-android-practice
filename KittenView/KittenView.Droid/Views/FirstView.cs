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

namespace KittenView.Droid.Views
{
    [Activity(Label = "First")]
    public class FirstView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);
        }
        //    protected override void OnViewModelSet()
        //    {
        //        base.OnViewModelSet();
        //        SetContentView(Resource.Layout.FirstView);
        //    }
        //}
    }
}