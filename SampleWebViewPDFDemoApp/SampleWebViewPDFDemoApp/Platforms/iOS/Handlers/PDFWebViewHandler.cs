using System;
using Microsoft.Maui.Controls.Compatibility.Platform.iOS;
using Microsoft.Maui.Controls.Platform;
using System.Net;
using UIKit;
using Foundation;

namespace SampleWebViewPDFDemoApp.Controls
{
    public class PDFWebViewHandler //: ViewRenderer<PDFWebView, UIWebView>
    {
        //protected override void OnElementChanged(ElementChangedEventArgs<PDFWebViewHandler> e)
        //{
        //    base.OnElementChanged(e);

        //    if (Control == null)
        //    {
        //        SetNativeControl(new UIWebView());
        //    }
        //    if (e.OldElement != null)
        //    {
        //        // Cleanup
        //    }
        //    if (e.NewElement != null)
        //    {
        //        PDFWebView customWebView = Element as PDFWebView;
        //        string fileName = Path.Combine(NSBundle.MainBundle.BundlePath, string.Format("Content/{0}", WebUtility.UrlEncode(customWebView.Uri)));
        //        Control.LoadRequest(new NSUrlRequest(new NSUrl(fileName, false)));
        //        Control.ScalesPageToFit = true;
        //    }
        //}
    }
}

