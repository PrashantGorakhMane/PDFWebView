using System;
using Foundation;
using System.ComponentModel;
using System.Net;
using WebKit;
using Microsoft.Maui.Controls.Platform;

namespace SampleWebViewPDFDemoApp.Controls
{
	public class CustomWebViewHandler : Microsoft.Maui.Controls.Handlers.Compatibility.ViewRenderer<CustomWebView, WKWebView>
    {
        private string _Filename;
        private string _UriType;
        private string _Uri;
        private bool _IsEmbeddedResource;
        private CustomWebView customWebView;

        static WKWebViewConfiguration webViewConfig;

        private static WKWebViewConfiguration WebViewConfiguration
        {
            get
            {
                if (webViewConfig == null)
                {
                    InitWebViewConfig();
                }

                return webViewConfig;
            }
        }

        private static void InitWebViewConfig()
        {
            webViewConfig = new WKWebViewConfiguration
            {
                WebsiteDataStore = WKWebsiteDataStore.DefaultDataStore
            };
        }

        protected override void OnElementChanged(ElementChangedEventArgs<CustomWebView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                customWebView = Element as CustomWebView;
                var x = new WKWebView(Frame, WebViewConfiguration);
                x.NavigationDelegate = new CustomWebViewNavigationDelegate(customWebView);
                SetNativeControl(x);
                LoadTrainingContent();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            customWebView = sender as CustomWebView;

            switch (e.PropertyName)
            {
                case "UriType":
                    _UriType = customWebView.UriType;
                    break;
                case "Uri":
                    _Uri = customWebView.Uri;
                    break;
                case "FileName":
                    _Filename = customWebView.FileName;
                    break;
                case "IsEmbeddedResource":
                    _IsEmbeddedResource = customWebView.IsEmbeddedResource;
                    break;
            }
            if (e.PropertyName.Equals("UriType") || e.PropertyName.Equals("Uri") || e.PropertyName.Equals("IsEmbeddedResource"))
                LoadTrainingContent();
        }

        private async void LoadTrainingContent()
        {
            try
            {
                if (_IsEmbeddedResource)
                {
                    string fileName = Path.Combine(NSBundle.MainBundle.BundlePath, string.Format("Content/{0}", WebUtility.UrlEncode(customWebView.Uri)));
                    Control.LoadRequest(new NSUrlRequest(new NSUrl(fileName, false)));
                }
                Control.SizeToFit();
            }
            catch (Exception ex)
            {
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }

    internal class CustomWebViewNavigationDelegate : WKNavigationDelegate
    {
        private CustomWebView _customWebView;
        public CustomWebViewNavigationDelegate(CustomWebView customWebView)
        {
            _customWebView = customWebView;
        }

        public override async void DecidePolicy(WKWebView webView, WKNavigationAction navigationAction, Action<WKNavigationActionPolicy> decisionHandler)
        {
            try
            {
                var url = navigationAction.Request.Url.ToString();
                    //always we need to allow other wise b2c login will fails
            }
            catch (Exception ex)
            {
            }
        }

        public override void DidReceiveServerRedirectForProvisionalNavigation(WKWebView webView, WKNavigation navigation)
        {
            string urlCode = string.Empty;
            WebNavigationEvent e = webView.Url.AbsoluteString.Contains(urlCode) ? WebNavigationEvent.Forward : WebNavigationEvent.NewPage;
            WebNavigatingEventArgs arg = new WebNavigatingEventArgs(e, null, webView.Url.AbsoluteString);
        }
    }

    public static class plateFormsSetting
    {
        public static List<NSHttpCookie> Containercookies { get; set; }
    }
}

