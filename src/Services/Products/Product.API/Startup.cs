namespace Catalog.API;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public virtual IServiceProvider ConfigureServices(IServiceCollection services)
    {
        services
            .AddCustomMvc()
            //.AddHealthChecks(Configuration)
            .AddCustomDbContext(Configuration)
            .AddCustomSwagger(Configuration)
            .AddCustomIntegrations(Configuration)
            .AddCustomConfiguration(Configuration)
            .AddEventBus(Configuration);
            
       
        var container = new ContainerBuilder();
        container.Populate(services);

        container.RegisterModule(new MediatorModule());
        container.RegisterModule(new ApplicationModule(Configuration["ConnectionString"]));

        return new AutofacServiceProvider(container.Build());
    }


    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
    {
       
        var pathBase = Configuration["PATH_BASE"];
        if (!string.IsNullOrEmpty(pathBase))
        {
            loggerFactory.CreateLogger<Startup>().LogDebug("Using PATH BASE '{pathBase}'", pathBase);
            app.UsePathBase(pathBase);
        }

        app.UseSwagger()
            .UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"{ (!string.IsNullOrEmpty(pathBase) ? pathBase : string.Empty) }/swagger/v1/swagger.json", "Catalog.API V1");
            });

        app.UseRouting();
        app.UseCors("CorsPolicy");
       
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapDefaultControllerRoute();
            endpoints.MapControllers();
            //endpoints.MapHealthChecks("/hc", new HealthCheckOptions()
            //{
            //    Predicate = _ => true,
            //    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            //});
            //endpoints.MapHealthChecks("/liveness", new HealthCheckOptions
            //{
            //    Predicate = r => r.Name.Contains("self")
            //});
        });

        ConfigureEventBus(app);
    }


    private void ConfigureEventBus(IApplicationBuilder app)
    {
        var eventBus = app.ApplicationServices.GetRequiredService<BuildingBlocks.EventBus.Abstractions.IEventBus>();

    }

    
}

static class CustomExtensionsMethods
{
    public static IServiceCollection AddCustomMvc(this IServiceCollection services)
    {
        
        services.AddControllers(options =>
        {
            options.Filters.Add(typeof(HttpGlobalExceptionFilter));
        })
            .AddApplicationPart(typeof(ProductsController).Assembly)
            .AddApplicationPart(typeof(CategoriesController).Assembly)
            .AddJsonOptions(options => options.JsonSerializerOptions.WriteIndented = true);

        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                builder => builder
                .SetIsOriginAllowed((host) => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
        });

        return services;
    }

    public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CatalogContext>(options =>
        {
            options.UseMySql(configuration["ConnectionString"], new MySqlServerVersion(new Version(10, 4, 17)),
                mySqlOptionsAction: sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                });
        },
                    ServiceLifetime.Scoped
                );

        services.AddDbContext<IntegrationEventLogContext>(options =>
        {
            options.UseMySql(configuration["ConnectionString"], new MySqlServerVersion(new Version(10, 4, 17)),
                                    mySqlOptionsAction: sqlOptions =>
                                    {
                                        sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                                    });
        });

        return services;
    }

    public static IServiceCollection AddCustomSwagger(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Store - Catalogo HTTP API",
                Version = "v1",
                Description = "Serviço HTTP API do catalogo"
            });


        });

        return services;
    }

    public static IServiceCollection AddCustomIntegrations(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddTransient<Func<DbConnection, IIntegrationEventLogService>>(
            sp => (DbConnection c) => new IntegrationEventLogService(c));

        services.AddSingleton<IRabbitMQPersistentConnection>(sp =>
        {
            var logger = sp.GetRequiredService<ILogger<DefaultRabbitMQPersistentConnection>>();


            var factory = new ConnectionFactory()
            {
                HostName = configuration["EventBusConnection"],
                DispatchConsumersAsync = true
            };

            if (!string.IsNullOrEmpty(configuration["EventBusUserName"]))
            {
                factory.UserName = configuration["EventBusUserName"];
            }

            if (!string.IsNullOrEmpty(configuration["EventBusPassword"]))
            {
                factory.Password = configuration["EventBusPassword"];
            }

            var retryCount = 5;
            if (!string.IsNullOrEmpty(configuration["EventBusRetryCount"]))
            {
                retryCount = int.Parse(configuration["EventBusRetryCount"]);
            }

            return new DefaultRabbitMQPersistentConnection(factory, logger, retryCount);
        });
        
        return services;
    }

    public static IServiceCollection AddCustomConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions();
        services.Configure<CatalogSettings>(configuration);
        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.InvalidModelStateResponseFactory = context =>
            {
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Instance = context.HttpContext.Request.Path,
                    Status = StatusCodes.Status400BadRequest,
                    Detail = "Please refer to the errors property for additional details."
                };

                return new BadRequestObjectResult(problemDetails)
                {
                    ContentTypes = { "application/problem+json", "application/problem+xml" }
                };
            };
        });

        return services;
    }

    public static IServiceCollection AddEventBus(this IServiceCollection services, IConfiguration configuration)
    {
       
        services.AddSingleton<IEventBus, EventBusRabbitMQ>(sp =>
        {
            var subscriptionClientName = configuration["SubscriptionClientName"];
            var rabbitMQPersistentConnection = sp.GetRequiredService<IRabbitMQPersistentConnection>();
            var iLifetimeScope = sp.GetRequiredService<ILifetimeScope>();
            var logger = sp.GetRequiredService<ILogger<EventBusRabbitMQ>>();
            var eventBusSubcriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();

            var retryCount = 5;
            if (!string.IsNullOrEmpty(configuration["EventBusRetryCount"]))
            {
                retryCount = int.Parse(configuration["EventBusRetryCount"]);
            }

            return new EventBusRabbitMQ(rabbitMQPersistentConnection, logger, iLifetimeScope, eventBusSubcriptionsManager, subscriptionClientName, retryCount);
        });
       

        services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();

        return services;
    }

}