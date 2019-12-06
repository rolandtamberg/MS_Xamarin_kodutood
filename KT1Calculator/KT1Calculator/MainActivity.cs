using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Threading.Tasks;
using System;
using System.Data;

namespace KT1Calculator
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected double answer;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var digit1 = FindViewById<EditText>(Resource.Id.ET1);
            var digit2 = FindViewById<EditText>(Resource.Id.ET2);
            var answerX = FindViewById<TextView>(Resource.Id.ET3);
            var RBGroup = FindViewById<RadioGroup>(Resource.Id.RBG);
            var RB1 = FindViewById<RadioButton>(Resource.Id.RB1_Add);
            var RB2 = FindViewById<RadioButton>(Resource.Id.RB2_Subtract);
            var RB3 = FindViewById<RadioButton>(Resource.Id.RB3_Multiply);
            var RB4 = FindViewById<RadioButton>(Resource.Id.RB4_Divide);
            var CalculateButton = FindViewById<Button>(Resource.Id.CalcButton);

            

            CalculateButton.Click += delegate
            {
                var digit1X = digit1.Text.ToString();

                var digit2X = digit2.Text.ToString();

                
                if (RB1.Checked)
                {
                    answer = Convert.ToDouble(digit1X) + Convert.ToDouble(digit2X);
                }
                
                else if (RB2.Checked)
                {
                    answer = Convert.ToDouble(digit1X) - Convert.ToDouble(digit2X);
                }
                else if (RB3.Checked)
                {
                    answer = Convert.ToDouble(digit1X) * Convert.ToDouble(digit2X);
                }
                else if (RB4.Checked)
                {
                    answer = Convert.ToDouble(digit1X) / Convert.ToDouble(digit2X);
                }

                answerX.Text = answer.ToString();

            };
        }


    }
    
}