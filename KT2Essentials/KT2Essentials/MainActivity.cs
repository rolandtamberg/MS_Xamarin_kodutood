using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Xamarin.Essentials;
using System;
using System.Threading.Tasks;



namespace KT2Essentials
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);


            Button BatteryInfo = FindViewById<Button>(Resource.Id.battery_info);
            ToggleButton FlashOnOff = FindViewById<ToggleButton>(Resource.Id.flash_on_off);
            Button AccMeterOn = FindViewById<Button>(Resource.Id.acc_button_on);
            Button AccMeterOff = FindViewById<Button>(Resource.Id.acc_button_off);

            
            BatteryInfo.Click += (sender, e) =>
            {
                var level = Battery.ChargeLevel * 100;
                var LevelValue = level.ToString();

                var state = Battery.State;
                var StateValue = state.ToString();

                var source = Battery.PowerSource;
                var SourceValue = source.ToString();

                var BattText = FindViewById<TextView>(Resource.Id.batt_info_text);
                BattText.Text = LevelValue + " protsenti" + "\n" + StateValue + "\n" + SourceValue;
            };

            FlashOnOff.Click += (sender, e) =>
            {
                if (FlashOnOff.Checked)
                    Flashlight.TurnOnAsync();
                else
                    Flashlight.TurnOffAsync();
            };

            void Accelerometer_ReadingChanged(object sender, 
                AccelerometerChangedEventArgs e)
            {
                var AccText = FindViewById<TextView>(Resource.Id.acc_meter_text);
                AccText.Text = e.Reading.Acceleration.ToString();
            }

            AccMeterOn.Click += (sender, e) =>
            {
                if (Accelerometer.IsMonitoring)
                    return;

                Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
                Accelerometer.Start(SensorSpeed.UI);
            };

            AccMeterOff.Click += (sender, e) =>
            {
                if (!Accelerometer.IsMonitoring)
                    return;

                Accelerometer.ReadingChanged -= Accelerometer_ReadingChanged;
                Accelerometer.Stop();

            };

        }

        private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}