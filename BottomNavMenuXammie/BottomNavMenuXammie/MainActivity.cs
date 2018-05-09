using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.Design.Widget;
using System;
using BottomNavMenuXammie.SampleFragments;

namespace BottomNavMenuXammie
{
    [Activity(Label = "BottomNavMenuXammie", MainLauncher = true, Icon = "@drawable/Alerts", Theme = "@style/AppTheme")]
    public class MainActivity : Activity
    {
        BottomNavigationView bottomNavigation;
       // string alertId = "";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            bottomNavigation = FindViewById<BottomNavigationView>(Resource.Id.btmNavBar);
            bottomNavigation.NavigationItemSelected += BottomNavigation_NavigationItemSelected;

          // bottomNavigation.NavigationItemSelected = (int)(Resource.Id.menu_Utility);
            LoadFragment(Resource.Id.menu_Alerts);
        }

        private void BottomNavigation_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            LoadFragment(e.Item.ItemId);
        }

        private void LoadFragment(int id)
        {
            

            Fragment fragment = null;
            switch (id)
            {
                case Resource.Id.menu_Alerts:
                    fragment = new FirstFragment1();
                    break;
                case Resource.Id.menu_Application:
                    fragment = new SecondFragment();
                    break;
                case Resource.Id.menu_Utility:
                    fragment = new ThirdFragment();
                    break;
            }

            if (fragment == null)
                return;

            FragmentManager.BeginTransaction()
                .Replace(Resource.Id.content_frame, fragment)
                .Commit();
        }
    }
}

