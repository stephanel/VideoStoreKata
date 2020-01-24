namespace VideoStore
{
    public abstract class Movie
    {
        public string Title { get; private set; }

        public Movie(string title)
        {
            Title     = title;
        }

        public abstract int GetFrequentRenterPoints(int daysRented);

        public abstract decimal GetRenterPoints(int daysRented);
    }
}
