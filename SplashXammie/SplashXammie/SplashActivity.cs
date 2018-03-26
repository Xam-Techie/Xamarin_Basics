using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using Android.Content.PM;
using System.Threading.Tasks;
using Android.Util;

namespace SplashXammie
{
    //Here we are adding the theme which is specified in values/style.xml page , blocking the screen orientation to Potrait mode for that 
    //use namespace Android.Content.PM , splash activity must be your main launcher, to not to run the splash activity after pressing
    //the back button NoHistory should be TRUE. 

    //Here i am using AppCompatActivity for that you have to add Android.Support.V7.App; nuget package 

    [Activity(Theme = "@style/MyTheme.Splash", ScreenOrientation = ScreenOrientation.Portrait, MainLauncher = true, NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {
        //To create the logs creating the TAG string . it will help us to understand the logs 
        static readonly string TAG = "X:" + typeof(SplashActivity).Name;

        //Overridhen onCreate method 
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Log.Debug(TAG, "SplashActivity.OnCreate");
            // Create your application here
        }

        protected override void OnResume()
        {
            base.OnResume();
            //Here we are using Task class to delay the screen for required minute / TIME 
            Task startupWork = new Task(() => { SimulateStartup(); });
            startupWork.Start();
        }

        // Simulates background work that happens behind the splash screen
        async void SimulateStartup()
        {
            Log.Debug(TAG, "Performing some startup work that takes a bit of time.");

            await Task.Delay(8000); // Simulate a bit of startup work.

            Log.Debug(TAG, "Startup work is finished - starting MainActivity.");

            StartActivity(new Intent(Application.Context, typeof(MainActivity)));

  
        }
    }
}