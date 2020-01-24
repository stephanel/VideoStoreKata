using NFluent;
using Xunit;

namespace VideoStore.Original.Tests
{
    public class PrintStatementFeatures
    {
        private readonly Movie _newRelease1 = new NewReleaseMovie("New Release 1");
        private readonly Movie _newRelease2 = new NewReleaseMovie("New Release 2");

        private readonly Movie _children1 = new ChildrenMovie("Children 1");

        private readonly Movie _regular1 = new RegularMovie("Regular 1");
        private readonly Movie _regular2 = new RegularMovie("Regular 2");

        [Fact]
        public void PrintStatementForDifferentKindOfMovies()
        {
            // Given
            var customer = new Customer("Any customer name");
            customer.Rent(_regular1, 1);
            customer.Rent(_regular2, 3);
            customer.Rent(_newRelease1, 2);
            customer.Rent(_newRelease2, 3);
            customer.Rent(_children1, 4);

            var statement = new Statement(customer);

            // When
            var output = statement.Print();

            // Then
            Check.That(output)
                .IsEqualTo("Rental Record for Any customer name\n" +
                    "\tRegular 1\t2.0\n" +
                    "\tRegular 2\t3.5\n" +
                    "\tNew Release 1\t6.0\n" +
                    "\tNew Release 2\t9.0\n" +
                    "\tChildren 1\t3.0\n" +
                    "You owed 23.5\n" +
                    "You earned 7 frequent renter points \n");
        }
    }
}
