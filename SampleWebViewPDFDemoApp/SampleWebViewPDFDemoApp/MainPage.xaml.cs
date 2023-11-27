using SampleWebViewPDFDemoApp.Controls;

namespace SampleWebViewPDFDemoApp;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
        LoadPdfViewer();

    }
    private void LoadPdfViewer()
    {
        string pdfFilePath = "file:///android_asset/pdfjs/web/viewer.html?file=file:///android_asset/pdfjs/web/kayprotect_training.pdf";
        //PdfWebView.Source = new UrlWebViewSource { Url = pdfFilePath };
    }
}


