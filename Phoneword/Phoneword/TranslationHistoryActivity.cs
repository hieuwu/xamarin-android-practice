using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phoneword
{
    [Activity(Label = "TranslationHistoryActivity")]
    public class TranslationHistoryActivity : ListActivity
    {
        private IList<string> phoneNumbers;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            phoneNumbers = Intent.Extras.GetStringArrayList("phone_numbers") ?? new string[0];
            this.ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, phoneNumbers);
        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            base.OnListItemClick(l, v, position, id);
            var clickedNumberItem = phoneNumbers[position];
            Android.Widget.Toast.MakeText(this, clickedNumberItem, Android.Widget.ToastLength.Short).Show();
        }
    }
}