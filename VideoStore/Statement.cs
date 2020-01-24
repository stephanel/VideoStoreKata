using System.Globalization;
using System.Linq;
using System.Text;

namespace VideoStore
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
            var customerName = _customer.Name;
            var rentals = _customer.GetRentals();

            var totalRenterPoints = rentals.Sum(x => x.GetRenterPoints());
            var totalFrequentRenterPoints = rentals.Sum(x => x.GetFrequentRenterPoints());

            var rentalStatements = rentals
                .Select(x => x.GetStatementLine())
                .ToList();

            return new StringBuilder()
                .Append($"Rental Record for {customerName}\n")
                .Append($"{string.Join("\n", rentalStatements)}\n")
                .Append($"You owed {totalRenterPoints.ToString("0.0", CultureInfo.InvariantCulture)}\n")
                .Append($"You earned {totalFrequentRenterPoints.ToString()} frequent renter points \n")
                .ToString();
        }

    }
}
