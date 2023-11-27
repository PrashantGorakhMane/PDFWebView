using System;
using Android.Content;
using Android.Net.Http;
using Android.Views;
using Android.Views.InputMethods;
using Android.Webkit;
using Microsoft.Maui.Controls.Platform;
using System.ComponentModel;
using System.Net;
using SampleWebViewPDFDemoApp.Controls;

namespace SampleWebViewPDFDemoApp.Controls
{
    public class CustomWebViewHandler : Microsoft.Maui.Controls.Handlers.Compatibility.ViewRenderer<CustomWebView, Android.Webkit.WebView>
    {
        private string _Filename;
        private string _UriType;
        private string _Uri;
        private bool _IsEmbeddedResource;

        public CustomWebViewHandler(Context context) : base(context)
        {
            var cookieManager = CookieManager.Instance;
            cookieManager.SetAcceptCookie(true);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<CustomWebView> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null && Control != null)
            {
                Control.ResumeTimers();
                Control.Settings.AllowUniversalAccessFromFileURLs = true;
                Control.Settings.AllowFileAccess = true;
                Control.ClearCache(true);
                Control.Settings.SetAppCacheEnabled(false);
                Control.Settings.CacheMode = CacheModes.NoCache;
                Control.ClearHistory();
                
                    Control.SetWebViewClient(
                      new SSLTolerentWebViewClient());
               
                var customWebView = Element as CustomWebView;



                if (!string.IsNullOrEmpty(customWebView.Uri))
                    _Uri = customWebView.Uri;

                LoadContent(customWebView);
            }
        }




        public override bool DispatchTouchEvent(MotionEvent e)
        {
            Parent.RequestDisallowInterceptTouchEvent(true);
            return base.DispatchTouchEvent(e);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            var element = sender as CustomWebView;

            switch (e.PropertyName)
            {
                case "UriType":
                    _UriType = element.UriType;
                    break;
                case "Uri":
                    _Uri = element.Uri;
                    break;
                case "FileName":
                    _Filename = element.FileName;
                    break;
                case "IsEmbeddedResource":
                    _IsEmbeddedResource = element.IsEmbeddedResource;
                    break;
            }

            if (!string.IsNullOrWhiteSpace(_Uri) &&
                (e.PropertyName.Equals("Uri") ||
                e.PropertyName.Equals("FileName") ||
                e.PropertyName.Equals("IsEmbeddedResource")))
                LoadContent(element);
        }

        private async void LoadContent(CustomWebView customWebView)
        {
            try
            {
                if (_IsEmbeddedResource)
                {
                    string url = string.Format("file:///android_asset/pdfjs/web/viewer.html?file={0}", string.Format("file:///android_asset/Content/{0}", WebUtility.UrlEncode("https://www.africau.edu/images/default/sample.pdf")));
                    //string url = string.Format("file:///android_asset/pdfjs/web/viewer.html?file={0}", string.Format("file:///android_asset/{0}", WebUtility.UrlEncode("kayprotect_training_n.pdf")));
                    Control.Settings.AllowUniversalAccessFromFileURLs = true;
                    Control.Settings.JavaScriptEnabled = true;
                    Control.Settings.AllowFileAccess = true;
                    Control.Settings.AllowFileAccessFromFileURLs = true;
                    Control.LoadUrl(url);
                    customWebView.IsLoading = false;
                }
               
            }
            catch (Exception ex)
            {
                customWebView.IsLoading = false;
            }
        }

        protected override void Dispose(bool disposing = true)
        {
            if (disposing && this.Element != null && this.Control != null)
            {
                var customWebView = Element as CustomWebView;

                //if (customWebView.UriType != null && customWebView.UriType.Equals("PDF") && !customWebView.IsEmbeddedResource)
                //{
                //    var fileManager = new WebViewFileManagerDroid();
                //    if (!String.IsNullOrEmpty(_Filename))
                //    {
                //        fileManager.DeleteFile(_Filename);
                //    }
                //}
                Control.RemoveAllViews();

                Control.ClearHistory();
                Control.ClearFormData();
                Control.ClearCache(true);
                Control.OnPause();
                Control.DestroyDrawingCache();
                Control.Destroy();
            }

            base.Dispose(disposing);

        }

        protected override void OnVisibilityChanged(Android.Views.View changedView, [Android.Runtime.GeneratedEnum] ViewStates visibility)
        {
            if (visibility == ViewStates.Gone || visibility == ViewStates.Invisible)
                HideKeyboard();
            base.OnVisibilityChanged(changedView, visibility);
        }
        private void HideKeyboard()
        {
            if (Control != null)
            {
                Control.RequestFocus();
                InputMethodManager inputMethodManager = Control.Context.GetSystemService(Context.InputMethodService) as InputMethodManager;
                inputMethodManager.HideSoftInputFromWindow(this.Control.WindowToken, HideSoftInputFlags.None); // this probably needs to be set to ToogleSoftInput, forced.
            }
        }

        public void ClearCookies(Context context)
        {
            var cookieManager = CookieManager.Instance;
            if (cookieManager != null)
            {
                cookieManager.RemoveAllCookie();
                cookieManager.RemoveSessionCookie();
                cookieManager.Flush();
            }
        }
    }


    public class SSLTolerentWebViewClient : WebViewClient
    {


        public override void OnReceivedSslError(Android.Webkit.WebView view, SslErrorHandler handler, SslError error)
        {
            handler.Proceed();

        }
    }
}

