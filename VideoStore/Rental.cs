using System.Globalization;

namespace VideoStore.Original
{
    public class Rental
    {
        public int DaysRented { get; }
        public virtual Movie Movie { get; }

        public Rental(Movie movie, int daysRented)
        {
            Movie      = movie;
            DaysRented = daysRented;
        }

        public int GetFrequentRenterPoints() => Movie.GetFrequentRenterPoints(DaysRented);

        public decimal GetRenterPoints() => Movie.GetRenterPoints(DaysRented);

        public string GetStatementLine()
            => $"\t{Movie.Title}\t{GetRenterPoints().ToString("0.0", CultureInfo.InvariantCulture)}";
    }
}
