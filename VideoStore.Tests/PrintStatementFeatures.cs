using NFluent;
using Xunit;

namespace VideoStore.Original.Tests
{
    public class PrintStatementFeatures
    {
        private readonly Customer _customer;

        private readonly Movie _newRelease1 = new Movie("New Release 1", Movie.NEW_RELEASE);
        private readonly Movie _newRelease2 = new Movie("New Release 2", Movie.NEW_RELEASE);

        private readonly Movie _children1 = new Movie("Children 1", Movie.CHILDREN);

        private readonly Movie _regular1 = new Movie("Regular 1", Movie.REGULAR);

        public PrintStatementFeatures()
        {
            _customer = new Customer("Any customer name");
        }

        //[Fact]
        //public void TestSingleNewReleaseStatement()
        //{
        //    _customer.AddRental(new Rental(_newRelease1, 3));

        //    Assert.Equal(_customer.Statement(),
        //                 "Rental Record for Any customer name\n" +
        //                 "\tNew release 1\t9.0\n" +
        //                 "You owed 9.0\n" +
        //                 "You earned 2 frequent renter points \n");
        //}

        //[Fact]
        //public void TestDualNewReleaseStatement()
        //{
        //    _customer.AddRental(new Rental(_newRelease1, 3));
        //    _customer.AddRental(new Rental(_newRelease2, 3));

        //    Assert.Equal(_customer.Statement(),
        //                 "Rental Record for Any customer name\n" +
        //                 "\tNew release 1\t9.0\n" +
        //                 "\tNew release 2\t9.0\n" +
        //                 "You owed 18.0\n" +
        //                 "You earned 4 frequent renter points \n");
        //}

        //[Fact]
        //public void TestSingleChildrensStatement()
        //{
        //    _customer.AddRental(new Rental(_children1, 3));

        //    Assert.Equal(_customer.Statement(),
        //                 "Rental Record for Any customer name\n" +
        //                 "\tChildren 1\t1.5\n" +
        //                 "You owed 1.5\n" +
        //                 "You earned 1 frequent renter points \n");
        //}

        //[Fact]
        //public void TestMultipleRegularStatement()
        //{
        //    _customer.AddRental(new Rental(_regular1, 1));
        //    _customer.AddRental(new Rental(new Movie("8 1/2",                   Movie.REGULAR), 2));
        //    _customer.AddRental(new Rental(new Movie("Eraserhead",              Movie.REGULAR), 3));

        //    Assert.Equal(_customer.Statement(),
        //                 "Rental Record for Any customer name\n" +
        //                 "\tPlan 9 from Outer Space\t2.0\n" +
        //                 "\t8 1/2\t2.0\n" +
        //                 "\tEraserhead\t3.5\n" +
        //                 "You owed 7.5\nYou earned 3 frequent renter points \n");
        //}

        [Fact]
        public void PrintStatementForDifferentKindOfMovies()
        {
            _customer.AddRental(new Rental(_regular1, 1));
            _customer.AddRental(new Rental(_newRelease1, 2));
            _customer.AddRental(new Rental(_newRelease2, 3));
            _customer.AddRental(new Rental(_children1, 4));

            Check.That(_customer.Statement())
                .IsEqualTo("Rental Record for Any customer name\n" +
                         "\tRegular 1\t2.0\n" +
                         "\tNew Release 1\t6.0\n" +
                         "\tNew Release 2\t9.0\n" +
                         "\tChildren 1\t3.0\n" +
                         "You owed 20.0\n" +
                         "You earned 6 frequent renter points \n");
        }
    }
}
