using System;
using System.Net;

namespace SampleWebViewPDFDemoApp.Controls
{
    public class CustomWebView : WebView
    {
        public string Uri
        {
            get { return (string)GetValue(UriProperty); }
            set { SetValue(UriProperty, value); }
        }
        public static readonly BindableProperty UriProperty =
            BindableProperty.Create(nameof(Uri), typeof(string), typeof(CustomWebView), string.Empty, BindingMode.Default, null, null);

        public string UriType
        {
            get { return (string)GetValue(UriTypeProperty); }
            set { SetValue(UriTypeProperty, value); }
        }
        public static readonly BindableProperty UriTypeProperty =
            BindableProperty.Create(nameof(UriType), typeof(string), typeof(CustomWebView), string.Empty, BindingMode.Default, null, null);

        public bool IsEmbeddedResource
        {
            get { return (bool)GetValue(IsEmbeddedResourceProperty); }
            set { SetValue(IsEmbeddedResourceProperty, value); }
        }
        public static readonly BindableProperty IsEmbeddedResourceProperty =
            BindableProperty.Create(nameof(IsEmbeddedResource), typeof(bool), typeof(CustomWebView), false, BindingMode.Default, null, null);

        public string FileName
        {
            get { return (string)GetValue(FileNameProperty); }
            set { SetValue(FileNameProperty, value); }
        }
        public static readonly BindableProperty FileNameProperty =
            BindableProperty.Create(nameof(FileName), typeof(string), typeof(CustomWebView), string.Empty, BindingMode.Default, null, null);

        public bool IsLoading
        {
            get { return (bool)GetValue(IsLoadingProperty); }
            set { SetValue(IsLoadingProperty, value); }
        }
        public static readonly BindableProperty IsLoadingProperty =
            BindableProperty.Create(nameof(IsLoading), typeof(bool), typeof(CustomWebView), true, BindingMode.Default, null, null);

        public bool UseAuthorization { get; set; }

        public bool UsePowerBIJavaScript
        {
            get { return (bool)GetValue(UsePowerBIJavaScriptProperty); }
            set { SetValue(UsePowerBIJavaScriptProperty, value); }
        }

        public static readonly BindableProperty UsePowerBIJavaScriptProperty =
          BindableProperty.Create(nameof(UsePowerBIJavaScript), typeof(bool), typeof(CustomWebView), false, BindingMode.Default, null, null);


        public string PowerBIData
        {
            get { return (string)GetValue(PowerBIDataProperty); }
            set { SetValue(PowerBIDataProperty, value); }
        }

        public static readonly BindableProperty PowerBIDataProperty =
          BindableProperty.Create(nameof(PowerBIData), typeof(string), typeof(CustomWebView), string.Empty, BindingMode.Default, null, null);



        public static readonly BindableProperty CookiesProperty = BindableProperty.Create(
      propertyName: "Cookies",
          returnType: typeof(CookieContainer),
          declaringType: typeof(CustomWebView),
        defaultValue: default(string));

        public CookieContainer Cookies
        {
            get { return (CookieContainer)GetValue(CookiesProperty); }
            set { SetValue(CookiesProperty, value); }
        }


        public bool SSOUseCookies
        {
            get { return (bool)GetValue(SSOUseCookiesProperty); }
            set { SetValue(SSOUseCookiesProperty, value); }
        }

        public static readonly BindableProperty SSOUseCookiesProperty =
          BindableProperty.Create(nameof(SSOUseCookies), typeof(bool), typeof(CustomWebView), false, BindingMode.Default, null, null);



        public CustomWebView()
        {


            Cookies = new CookieContainer();
        }
    }
}

