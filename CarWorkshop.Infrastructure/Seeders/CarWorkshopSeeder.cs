using CarWorkshop.Infrastructure.Persistence;

namespace CarWorkshop.Infrastructure.Seeders
{
    public class CarWorkshopSeeder
    {
        private readonly CarWorkshopDbContext _dbContext;

        public CarWorkshopSeeder(CarWorkshopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                if (!_dbContext.CarWorkshops.Any())
                {
                    var volkswagenBielany = new Domain.Entities.CarWorkshop()
                    {
                        Name = "Volskwagen Bielany",
                        Description = "Autoryzowany serwis Volkswagena",
                        ContactDetails = new()
                        {
                            City = "Kraków",
                            Street = "Przemysłowa 13",
                            PostalCode = "30-001",
                            PhoneNumber = "+48699222534"
                        }
                    };
                    volkswagenBielany.EncodeName();

                    _dbContext.CarWorkshops.Add(volkswagenBielany);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}