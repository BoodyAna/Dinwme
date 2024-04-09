using Android.Webkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectFr.Platforms.Android
{
    internal class MyWebChromeClient : WebChromeClient
    {
        public override void OnPermissionRequest(PermissionRequest request)
        {
            foreach (var resource in request.GetResources())
            {
                if (resource.Equals(PermissionRequest.ResourceVideoCapture, StringComparison.OrdinalIgnoreCase))
                {
                    request.Grant(request.GetResources());
                    return;
                }
            }

            base.OnPermissionRequest(request);
        }
    }
}
