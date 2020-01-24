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
    }
}
