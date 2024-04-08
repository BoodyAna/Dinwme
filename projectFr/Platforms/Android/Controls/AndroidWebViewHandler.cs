using Android.Webkit;
using Microsoft.Maui.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectFr.Platforms.Android.Controls
{
    public class AndroidWebViewHandler : WebViewHandler
    {
        protected override void ConnectHandler(global::Android.Webkit.WebView platformView)
        {
            platformView.Settings.SetSupportMultipleWindows(false);
            platformView.Settings.JavaScriptCanOpenWindowsAutomatically = true;

            platformView.Settings.JavaScriptEnabled = true;
            base.ConnectHandler(platformView);
        }
    }
}
