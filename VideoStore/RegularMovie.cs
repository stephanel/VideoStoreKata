namespace VideoStore
{
    public class RegularMovie : Movie
    {
        public RegularMovie(string title)
            : base(title)
        { }

        public override int GetFrequentRenterPoints(int daysRented)
        {
            return 1;
        }

        public override decimal GetRenterPoints(int daysRented)
        {
            return 2 + (daysRented > 2 ? (daysRented - 2) * 1.5m : 0);
        }
    }
}
