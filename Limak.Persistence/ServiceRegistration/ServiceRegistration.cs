﻿using Limak.Application.Abstractions.Repositories;
using Limak.Application.Abstractions.Services;
using Limak.Domain.Entities;
using Limak.Persistence.ContextInitializers;
using Limak.Persistence.DAL;
using Limak.Persistence.Implementations.Hubs;
using Limak.Persistence.Implementations.Repositories;
using Limak.Persistence.Implementations.Services;
using Limak.Persistence.Interceptors;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Limak.Persistence.ServiceRegistration;

public static class ServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSignalR();
        AddDbContext(services, configuration);
        AddIdentity(services);
        AddServices(services);
        AddRepositories(services);
        AddInterceptors(services);


        return services;
    }




    public static ModelBuilder AddBaseAuditableEntityQueryFilter(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<Chat>().HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<Delivery>().HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<DeliveryArea>().HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<Kargomat>().HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<Message>().HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<Order>().HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<Request>().HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<RequestMessage>().HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<Shop>().HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<Tariff>().HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<Transaction>().HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<Warehouse>().HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<News>().HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<Notification>().HasQueryFilter(x => !x.IsDeleted);



        return modelBuilder;
    }

    public static WebApplication AddSignalREndpoints(this WebApplication app)
    {
        app.MapHub<NotificationHub>("/notificationHub");
        app.MapHub<ChatHub>("/chatHub");
        app.MapHub<RequestHub>("/requestHub");

        return app;
    }


    #region PrivateMethods

    private static void AddInterceptors(IServiceCollection services)
    {
        services.AddScoped<BaseEntityInterceptor>();
    }
    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));
    }

    private static void AddIdentity(IServiceCollection services)
    {
        services.AddIdentity<AppUser, IdentityRole<int>>(opt =>
        {
            opt.Password.RequiredLength = 6;
            opt.Password.RequireNonAlphanumeric = false;
            opt.Password.RequireLowercase = false;
            opt.Password.RequireUppercase = false;
            opt.User.RequireUniqueEmail = true;
            opt.SignIn.RequireConfirmedEmail = true;
            opt.Lockout.AllowedForNewUsers = false;
            opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            opt.Lockout.MaxFailedAccessAttempts = 3;
            opt.SignIn.RequireConfirmedEmail = true;


        }).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();
    }

    private static void AddServices(IServiceCollection services)
    {
        services.AddScoped<IShopService, ShopService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IShopCategoryService, ShopCategoryService>();
        services.AddScoped<ICountryService, CountryService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ICitizenshipService, CitizenshipService>();
        services.AddScoped<IGenderService, GenderService>();
        services.AddScoped<IUserPositionService, UserPositionService>();
        services.AddScoped<IStatusService, StatusService>();
        services.AddScoped<IWarehouseService, WarehouseService>();
        services.AddScoped<IKargomatService, KargomatService>();
        services.AddScoped<IDeliveryAreaService, DeliveryAreaService>();
        services.AddScoped<IDeliveryService, DeliveryService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<ICompanyService, CompanyService>();
        services.AddScoped<ITransactionService, TransactionService>();
        services.AddScoped<INotificationService, NotificationService>();
        services.AddScoped<INewsService, NewsService>();
        services.AddScoped<ITariffService, TariffService>();
        services.AddScoped<IChatService, ChatService>();
        services.AddScoped<IMessageService, MessageService>();
        services.AddScoped<IRequestSubjectService, RequestSubjectService>();
        services.AddScoped<IRequestService, RequestService>();
        services.AddScoped<IRequestMessageService, RequestMessageService>();
        services.AddScoped<ISettingService, SettingService>();
        services.AddScoped<IBrandService, BrandService>();

        services.AddScoped<AppDbContextInitializer>();
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IShopRepository, ShopRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IShopCategoryRepository, ShopCategoryRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<ICitizenshipRepository, CitizenshipRepository>();
        services.AddScoped<IGenderRepository, GenderRepository>();
        services.AddScoped<IUserPositionRepository, UserPositionRepository>();
        services.AddScoped<IStatusRepository, StatusRepository>();
        services.AddScoped<IWarehouseRepository, WarehouseRepository>();
        services.AddScoped<IKargomatRepository, KargomatRepository>();
        services.AddScoped<IDeliveryAreaRepository, DeliveryAreaRepository>();
        services.AddScoped<IDeliveryRepository, DeliveryRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<ICompanyRepository, CompanyRepository>();
        services.AddScoped<INotificationRepository, NotificationRepository>();
        services.AddScoped<INewsRepository, NewsRepository>();
        services.AddScoped<ITariffRepository, TariffRepository>();
        services.AddScoped<IChatRepository, ChatRepository>();
        services.AddScoped<IMessageRepository, MessageRepository>();
        services.AddScoped<IRequestSubjectRepository, RequestSubjectRepository>();
        services.AddScoped<IRequestRepository, RequestRepository>();
        services.AddScoped<IRequestMessageRepository, RequestMessageRepository>();
        services.AddScoped<ITransactionRepository, TransactionRepository>();
        services.AddScoped<ISettingRepository, SettingRepository>();
        services.AddScoped<IBrandRepository, BrandRepository>();


    }
    #endregion
}
