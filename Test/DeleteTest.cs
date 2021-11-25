using EFCoreDeletingNullableReference;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Test
{
    public class DeleteTest
    {

        [Test]
        public async Task DeleteReferenceTest()
        {
            EFCoreDeletingNullableReferenceContext dbContext = new EFCoreDeletingNullableReferenceContext();

            Person person = await dbContext.Set<Person>()
                .Include(prop => prop.Car)
                .FirstAsync();

            Assert.IsNotNull(person.Car, "Car should be set when person is loaded.");

            person.Car = null;

            Assert.IsNull(person.Car, "Car should be null.");

            dbContext.ChangeTracker.DetectChanges();

            Assert.IsNull(person.Car, "Car should not be present after calling DetectChanges.");
        }
    }
}
