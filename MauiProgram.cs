using Inventory.DataStore.InMemory;
using Inventory.Usecases.Interfaces;
using Inventory.Usecases.ItemUsecases;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;

namespace Inventory
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>().ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            }).UseMauiCommunityToolkit();
            builder.Services.AddSingleton<IItemRepositoryInMemory, ItemRepositoryInMemory>();
            builder.Services.AddTransient<IItemUsecase, ItemUsecase>();
            builder.Services.AddTransient<IGetItemByIdUsecase, GetItemByIdUsecase>();
            builder.Services.AddTransient<IAddItemUsecase, AddItemUsecase>();
#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}