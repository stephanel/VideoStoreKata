using System.Globalization;

namespace VideoStore.Original
{
    public class Statement
    {
        private readonly Customer _customer;

        public Statement(Customer customer)
        {
            _customer = customer;
        }

        public string Print()
        {
            var rentals = _customer.GetRentals();

            var frequentRenterPoints = 0;
            var totalAmount          = 0m;
            var result               = "Rental Record for " + _customer.Name + "\n";

            foreach (var each in rentals)
            {
                var thisAmount = each.GetRenterPoints();

                result      += "\t" + each.Movie.Title + "\t" + thisAmount.ToString("0.0", CultureInfo.InvariantCulture) + "\n";
                totalAmount += thisAmount;

                frequentRenterPoints += each.GetFrequentRenterPoints();
            }

            result += "You owed " + totalAmount.ToString("0.0", CultureInfo.InvariantCulture) + "\n";
            result += "You earned " + frequentRenterPoints.ToString() + " frequent renter points \n";

            return result;
        }
    }
}
