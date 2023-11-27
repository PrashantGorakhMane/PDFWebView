using System;
namespace SampleWebViewPDFDemoApp.Controls
{
    public class PDFWebView : WebView
    {
        public static readonly Microsoft.Maui.Controls.BindableProperty UriProperty = Microsoft.Maui.Controls.BindableProperty.Create(nameof(Uri), typeof(string), typeof(WebView), default(string));

        public string Uri
        {
            get
            {
                return (string)GetValue(UriProperty);
            }
            set
            {
                SetValue(UriProperty, value);
            }
        }
    }
}

