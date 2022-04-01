using System;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.UI.Views.Options;
using Xamarin.Forms;


namespace Diplom1.Toast
{
    public static class CustomToast
    {
        public static void Toast(this Page page, string message, status status)
        {
            double procent = 4.5;
            int TextSize = (int)Math.Floor((page.Width / 100) * procent);
            ToastOptions toast = new ToastOptions();
            if (status == status.warning)
            {
                toast.BackgroundColor = Color.Orange;
                toast.Duration = TimeSpan.FromSeconds(3);
                toast.MessageOptions = new MessageOptions
                {
                    Message = message,
                    Font = Font.SystemFontOfSize(TextSize)
                };
                toast.CornerRadius = 0;
            }
            else if (status == status.error)
            {
                toast.BackgroundColor = Color.Red;
                toast.Duration = TimeSpan.FromSeconds(3);
                toast.MessageOptions = new MessageOptions
                {
                    Message = message,
                    Font = Font.SystemFontOfSize(TextSize),
                };
                toast.CornerRadius = 0;
            }
            else if (status == status.message)
            {
                toast.BackgroundColor = Color.Green;
                toast.Duration = TimeSpan.FromSeconds(3);
                toast.MessageOptions = new MessageOptions
                {
                    Message = message,
                    Font = Font.SystemFontOfSize(TextSize)
                };
                toast.CornerRadius = 0;
            }
            if (toast != null) page.DisplayToastAsync(toast);
        }
    }

    public enum status
    {
        warning,
        error,
        message
    }
}
