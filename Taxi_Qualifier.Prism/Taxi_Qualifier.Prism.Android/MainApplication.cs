using System;
using Android.App;
using Android.OS;
using Android.Runtime;

using Plugin.CurrentActivity;

namespace Taxi_Qualifier.Prism.Droid
{
    [Application(
        Theme = "@style/MainTheme"
        )]
    public class MainApplication : Application
    {
        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
            Xamarin.Essentials.Platform.Init(this);
            CrossCurrentActivity.Current.Init(this);
        }
    }
}
