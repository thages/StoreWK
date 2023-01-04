namespace Catalog.API.Infrastructure.AutofacModules;

public class ApplicationModule
    : Autofac.Module
{
    public string QueriesConnectionString { get; }

    public ApplicationModule(string qconnstr)
    {
        QueriesConnectionString = qconnstr;

    }

    protected override void Load(ContainerBuilder builder)
    {

        builder.Register(c => new ProductQueries(QueriesConnectionString))
            .As<IProductQueries>()
            .InstancePerLifetimeScope();

        builder.RegisterType<ProductRepository>()
            .As<IProductRepository>()
            .InstancePerLifetimeScope();

        builder.Register(c => new CategoryQueries(QueriesConnectionString))
            .As<ICategoryQueries>()
            .InstancePerLifetimeScope();

        builder.RegisterType<CategoryRepository>()
            .As<ICategoryRepository>()
            .InstancePerLifetimeScope();

        builder.RegisterAssemblyTypes(typeof(CreateProductCommandHandler).GetTypeInfo().Assembly)
            .AsClosedTypesOf(typeof(IIntegrationEventHandler<>));

        builder.RegisterAssemblyTypes(typeof(CreateCategoryCommandHandler).GetTypeInfo().Assembly)
           .AsClosedTypesOf(typeof(IIntegrationEventHandler<>));

        builder.RegisterAssemblyTypes(typeof(PageableListProductQueryHandler).GetTypeInfo().Assembly)
           .AsClosedTypesOf(typeof(IIntegrationEventHandler<>));


        builder.RegisterAssemblyTypes(typeof(UpdateProductCommandHandler).GetTypeInfo().Assembly)
           .AsClosedTypesOf(typeof(IIntegrationEventHandler<>));

    }
}
