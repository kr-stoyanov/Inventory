using CommunityToolkit.Maui;
using Inventory.DataStore.InMemory;
using Inventory.Pages;
using Inventory.Usecases.Interfaces;
using Inventory.Usecases.ItemUsecases;
using Inventory.ViewModels;
using Microsoft.Extensions.Logging;

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
            builder.Services.AddTransient<IItemsUsecase, ItemsUsecase>();
            builder.Services.AddTransient<IGetItemByIdUsecase, GetItemByIdUsecase>();
            builder.Services.AddTransient<IAddItemUsecase, AddItemUsecase>();
            builder.Services.AddTransient<IRemoveItemUsecase, RemoveItemUsecase>();

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainPageViewModel>();

            builder.Services.AddTransient<ItemsPage>();
            builder.Services.AddTransient<ItemsViewModel>();

            builder.Services.AddTransient<ItemDetailsPage>();
            builder.Services.AddTransient<ItemDetailsViewModel>();

            builder.Services.AddTransient<AddItemPage>();
            builder.Services.AddTransient<AddItemViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}