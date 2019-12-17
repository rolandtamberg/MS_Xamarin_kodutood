using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Refit;
using EDMTDialog;
using System.Collections.Generic;
using System;

namespace KT3ListView
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button button_data;
        ListView list_users;

        ApiIF myAPI;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            button_data = FindViewById<Button>(Resource.Id.BTN_Users);
            list_users = FindViewById<ListView>(Resource.Id.LV_Users);

            myAPI = RestService.For<ApiIF>("http://jsonplaceholder.typicode.com");

            button_data.Click += async delegate {
                try
                {
                    Android.Support.V7.App.AlertDialog dialog = new EDMTDialogBuilder()
                    .SetContext(this)
                    .SetMessage("Patience please!!!")
                    .Build();

                    if (!dialog.IsShowing)
                        dialog.Show();

                    List<User> users = await myAPI.GetUsers();
                    List<string> user_name = new List<string>();

                    foreach (var user in users)
                        user_name.Add(user.name);
                    var adapter = new ArrayAdapter<string>(this,
                        Android.Resource.Layout.SimpleListItem1, user_name);
                    list_users.Adapter = adapter;

                    if (dialog.IsShowing)
                        dialog.Dismiss();
                }
                catch (Exception ex)
                {
                    Toast.MakeText(this, "" + ex.Message, ToastLength.Long).Show();
                }
                };
        
        }
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}