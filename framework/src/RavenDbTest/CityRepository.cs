using System.Collections.Generic;
using System.Threading.Tasks;
using Raven.Client.Documents.Session;
using Volo.Abp.RavenDB.Volo.Abp.Domain.Repositories.RavenDB;
using Volo.Abp.RavenDB.Volo.Abp.RavenDB;

namespace RavenDbTest
{
    public class CityRepository : RavenDbRepository<ITestAppRavenDbContext, City>
    {
        public CityRepository(IRavenDbContextProvider<ITestAppRavenDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        /*public async Task<City> FindByNameAsync(string name)
        {
            return await (await Collection.FindAsync(c => c.Name == name)).FirstOrDefaultAsync();
        }

        public async Task<List<Person>> GetPeopleInTheCityAsync(string cityName)
        {
            var city = await FindByNameAsync(cityName);
            return await DbContext.People.AsQueryable().Where(p => p.CityId == city.Id).ToListAsync();
        }*/
    } 
    
    public interface ITestAppRavenDbContext : IAbpRavenDbContext
    {
        IAsyncDocumentSession AsyncSession { get; }
    }
    
    public class TestAppRavenDbContext : ITestAppRavenDbContext
    {
        public IAsyncDocumentSession AsyncSession { get; }
    }
}