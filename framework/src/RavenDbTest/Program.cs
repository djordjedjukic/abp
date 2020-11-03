using System;
using Autofac.Core.Lifetime;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Raven.Client.Documents.Session;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.RavenDB.Volo.Abp.Domain.Repositories.RavenDB;
using Volo.Abp.RavenDB.Volo.Abp.RavenDB;
using Volo.Abp.RavenDB.Volo.Abp.Uow;
using Volo.Abp.Uow;

namespace RavenDbTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var serviceProvider = new ServiceCollection()
                    //.AddSingleton<IRavenDbContextProvider<TestAppRavenDbContext>, UnitOfWorkRavenDbContextProvider<TestAppRavenDbContext>>()
                    .AddSingleton<IConnectionStringResolver, DefaultConnectionStringResolver>()
                    .AddSingleton<IHybridServiceScopeFactory, DefaultServiceScopeFactory>()
                    .AddSingleton<IAmbientUnitOfWork, AmbientUnitOfWork>()
                    .AddSingleton<IAmbientUnitOfWork, AmbientUnitOfWork>()
                    .AddSingleton<IUnitOfWorkManager, UnitOfWorkManager>()
                    .AddSingleton<ITestAppRavenDbContext, TestAppRavenDbContext>()
                    .AddSingleton<IRavenDbContextProvider<ITestAppRavenDbContext>, UnitOfWorkRavenDbContextProvider<ITestAppRavenDbContext>>()
                    .AddSingleton<IRepository<City>, CityRepository>()
                    .BuildServiceProvider();
                
                //DefaultServiceScopeFactory serviceFactory = new DefaultServiceScopeFactory(new AutofacServiceProvider(null));
                //DefaultServiceScopeFactory serviceFactory = new DefaultServiceScopeFactory(null);
                //var uow = new AmbientUnitOfWork();
                //var conn = new DefaultConnectionStringResolver(new OptionsManager<AbpDbConnectionOptions>());

                //var contextProvider = new UnitOfWorkRavenDbContextProvider<ITestAppRavenDbContext>(new UnitOfWorkManager(uow, serviceFactory), null);
            
                //var userRepository = new RavenDbRepository<ITestAppRavenDbContext, User>(contextProvider);

                try
                {
                    var cityRepository = serviceProvider.GetService<IRepository<City>>();
                    cityRepository.InsertAsync(new City()
                    {
                        FirstName = "John",
                        LastName = "Doe"
                    });
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }

    public class City :  AggregateRoot<string>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
    
    /*public interface ITestAppRavenDbContext : IAbpRavenDbContext
    {
        IAsyncDocumentSession AsyncSession { get; }
    }
    
    public class TestAppRavenDbContext : ITestAppRavenDbContext
    {
        public IAsyncDocumentSession AsyncSession { get; }
    }*/
}