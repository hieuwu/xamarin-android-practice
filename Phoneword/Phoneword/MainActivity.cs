using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Util;
using Android.Content.Res;
using System.IO;
using System.Collections.Generic;
using Android.Content;

namespace Phoneword
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        static readonly List<string> phoneNumbers = new List<string>();
        const string ACTIVITY_STATE = "ACTIVITY STATE";

        const string ON_CREATE = "OnCreate is called";
        const string ON_START = "OnStart is called";
        const string ON_RESUME = "OnResume is called";

        const string ON_PAUSE = "OnPause is called";
        const string ON_STOP = "OnStop is called";
        const string ON_DESTROY = "OnDestroy is called";

        const string ON_RESTART = "OnRestart is called";

        const string ASSET_FILENAME = "read_assets.txt";


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Log.Debug(ACTIVITY_STATE, ON_CREATE);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            // Get our UI controls from the loaded layout
            EditText phoneNumberText = FindViewById<EditText>(Resource.Id.PhoneNumberText);
            TextView translatedPhoneWord = FindViewById<TextView>(Resource.Id.TranslatedPhoneword);
            Button translateButton = FindViewById<Button>(Resource.Id.TranslateButton);
            Button translateHistoryButton = FindViewById<Button>(Resource.Id.TranslationHistoryButton);
            translateHistoryButton.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(TranslationHistoryActivity));
                intent.PutStringArrayListExtra("phone_numbers", phoneNumbers);
                StartActivity(intent);
            };
            // Add code to translate number
            translateButton.Click += (sender, e) =>
            {
                // Translate user's alphanumeric phone number to numeric
                string translatedNumber = Core.PhonewordTranslator.ToNumber(phoneNumberText.Text);
                if (string.IsNullOrWhiteSpace(translatedNumber))
                {
                    translatedPhoneWord.Text = string.Empty;
                }
                else
                {
                    translatedPhoneWord.Text = translatedNumber;
                    phoneNumbers.Add(translatedNumber);
                    translateHistoryButton.Enabled = true;
                }

                //Read the content of assets
                string content;
                AssetManager assets = this.Assets;
                try
                {
                    using (StreamReader sr = new StreamReader(assets.Open(ASSET_FILENAME)))
                    {
                        content = sr.ReadToEnd();
                    }

                }
                catch (FileNotFoundException exception)
                {
                    throw exception;
                }

                Log.Debug("ASSET_CONTENT", content);

            };

            phoneNumberText.TextChanged += (sender, e) =>
            {
                string translatedNumber = Core.PhonewordTranslator.ToNumber(phoneNumberText.Text);
                if (string.IsNullOrWhiteSpace(translatedNumber))
                {
                    translatedPhoneWord.Text = string.Empty;
                }
                else
                {
                    translatedPhoneWord.Text = translatedNumber;
                }

            };
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnStart()
        {
            base.OnStart();
            Log.Debug(ACTIVITY_STATE, ON_START);
        }

        protected override void OnResume()
        {
            base.OnResume();
            Log.Debug(ACTIVITY_STATE, ON_RESUME);
        }

        protected override void OnPause()
        {
            Log.Debug(ACTIVITY_STATE, ON_PAUSE);
            base.OnPause();
        }

        protected override void OnStop()
        {
            Log.Debug(ACTIVITY_STATE, ON_STOP);
            base.OnStop();
        }

        protected override void OnDestroy()
        {
            Log.Debug(ACTIVITY_STATE, ON_DESTROY);
            base.OnDestroy();
        }

        protected override void OnRestart()
        {
            base.OnRestart();
            Log.Debug(ACTIVITY_STATE, ON_RESTART);

        }
    }
}