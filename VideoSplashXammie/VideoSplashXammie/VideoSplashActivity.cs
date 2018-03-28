using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;
using Android.Util;
using Android.Content.PM;

namespace VideoSplashXammie
{
    //Here we are adding the theme which is specified in values/style.xml page , blocking the screen orientation to Potrait mode for that 
    //use namespace Android.Content.PM , splash activity must be your main launcher, to not to run the splash activity after pressing
    //the back button NoHistory should be TRUE. 

    //Here i am using AppCompatActivity for that you have to add Android.Support.V7.App; nuget package 

    [Activity(Theme = "@style/MyTheme.Splash", ScreenOrientation = ScreenOrientation.Portrait, MainLauncher = true, NoHistory = true)]
    public class VideoSplashActivity : AppCompatActivity
    {
        VideoView videoView;
            //To create the logs creating the TAG string . it will help us to understand the logs 
            static readonly string TAG = "X:" + typeof(VideoSplashActivity).Name;

            //Overridhen onCreate method 
            protected override void OnCreate(Bundle savedInstanceState)
            {
                base.OnCreate(savedInstanceState);
                Log.Debug(TAG, "VideoSplashActivity.OnCreate");

            //setting the Layout view
            SetContentView(Resource.Layout.SplashLayout);

            //accessing the video view id that is specified in Splash Layout video view
            videoView = FindViewById<VideoView>(Resource.Id.splashVideo);
         
            //accessing the path of the video 
            string path = string.Format("android.resource://{0}/{1}",Application.PackageName,Resource.Raw.earth);

            videoView.SetVideoPath(path);
            videoView.Start();

            videoView.Completion += (o, e) =>
            {
                SimulateStartup();
            };

            }

            protected override void OnResume()
            {
                base.OnResume();
               
            }

            // Simulates background work that happens behind the splash screen
             void SimulateStartup()
            {
                
                Log.Debug(TAG, "Startup work is finished - starting MainActivity.");

                StartActivity(new Intent(Application.Context, typeof(MainActivity)));


            }
        }


    }

