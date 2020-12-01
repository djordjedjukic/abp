using Volo.Abp.Modularity;

namespace Volo.Abp.RavenDB.Tests.Volo.RavenDB
{
    public class AbpRavenDbTestModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            /*using (var store = GetDocumentStore())
            {
                store.ExecuteIndex(new TestDocumentByName());
                using (var session = store.OpenSession())
                {
                    session.Store(new TestDocument { Name = "Hello world!" });
                    session.Store(new TestDocument { Name = "Goodbye..." });
                    session.SaveChanges();
                }
            }*/
            
            
            /*var connectionString = MongoDbFixture.ConnectionString.EnsureEndsWith('/')  +
                                   "Db_" +
                                   Guid.NewGuid().ToString("N");

            Configure<AbpDbConnectionOptions>(options =>
            {
                options.ConnectionStrings.Default = connectionString;
            });

            context.Services.AddMongoDbContext<TestAppMongoDbContext>(options =>
            {
                options.AddDefaultRepositories<ITestAppMongoDbContext>();
                options.AddRepository<City, CityRepository>();
            });

            Configure<AbpUnitOfWorkDefaultOptions>(options =>
            {
                options.TransactionBehavior = UnitOfWorkTransactionBehavior.Disabled;
            });*/
        }
    }
}