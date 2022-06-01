using MAUITest.ViewModels;
using MAUITest.Views;

namespace MAUITest;

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
			});

		builder.Services.AddSingleton<AccountViewModel>();
		builder.Services.AddSingleton<NewOperationViewModel>();
		builder.Services.AddSingleton<HistoryViewModel>();


        builder.Services.AddSingleton<AccountPage>();
		builder.Services.AddSingleton<NewOperationPage>();
		builder.Services.AddSingleton<HistoryPage>();

		return builder.Build();
	}
}
