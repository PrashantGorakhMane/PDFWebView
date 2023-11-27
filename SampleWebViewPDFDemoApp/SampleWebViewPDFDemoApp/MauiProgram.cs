using Microsoft.Extensions.Logging;
using SampleWebViewPDFDemoApp.Controls;

namespace SampleWebViewPDFDemoApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
            .ConfigureMauiHandlers(handlers =>
			{
                handlers.AddHandler(typeof(CustomWebView), typeof(SampleWebViewPDFDemoApp.Controls.CustomWebViewHandler));
                //handlers.AddHandler(typeof(PDFWebView), typeof(SampleWebViewPDFDemoApp.Controls.PDFWebViewHandler));
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

