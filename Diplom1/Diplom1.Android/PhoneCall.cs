using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Content;
using Diplom1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using AndroidX.Core.App;
using Diplom1.Toast;

[assembly: Dependency(typeof(Diplom1.Droid.PhoneCall))]

namespace Diplom1.Droid
{
    internal class PhoneCall : Calls
    {
        readonly string[] Permissions =
         {
            Manifest.Permission.CallPhone

        };
        public Task Call(string phoneNumber)
        {
            try
            {
                var packageManager = Android.App.Application.Context.PackageManager;
                Android.Net.Uri telUri = Android.Net.Uri.Parse($"tel:{phoneNumber}");
                var callIntent = new Intent(Intent.ActionDial, telUri);

                callIntent.AddFlags(ActivityFlags.NewTask);
                // проверяем доступность
                var result = null != callIntent.ResolveActivity(packageManager);

                if (!string.IsNullOrWhiteSpace(phoneNumber) && result == true)
                {
                    Android.App.Application.Context.StartActivity(callIntent);
                }

                return Task.FromResult(true);
            }
            catch(Exception ex)
            {
                Activity Activity = Platform.CurrentActivity;
                Xamarin.Forms.Application.Current.MainPage.Toast("Отсутствует разрешение", status.error);
                Activity.RequestPermissions(Permissions, 0);
                return null;
            }
        }
    }
}