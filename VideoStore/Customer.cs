using System.Collections.Generic;

namespace VideoStore
{
    public class Customer
    {
        private readonly List<Rental> _rentals = new List<Rental>();

        public string Name { get; private set; }

        public Customer(string name)
        {
            Name = name;
        }

        public void Rent(Movie movie, int daysRentered)
        {
            var rental = new Rental(movie, daysRentered);

            _rentals.Add(rental);
        }

        public List<Rental> GetRentals() => _rentals;
    }
}