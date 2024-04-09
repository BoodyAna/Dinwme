using Android.Content;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Controls.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectFr.Platforms.Android.Renderers
{
    public class UserAgentWebViewRenderer : WebViewRenderer
    {
        public UserAgentWebViewRenderer(Context context) : base(context)
        { }

        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                Control.SetWebViewClient(GetWebViewClient());
                Control.Settings.UserAgentString = "Mozilla/5.0 (Linux; Android 12; sdk_gphone64_x86_64 Build/SE1A.211212.001.B1;wv) AppleWebKit/537.36 (KHTML, like Gecko) Versione/4.0 Chrome/91.0.4472.114 Mobile Safari/537.36";
                
            }
        }
    }
}
