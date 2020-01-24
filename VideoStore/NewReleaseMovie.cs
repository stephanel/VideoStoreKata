using VideoStore.Original;

namespace VideoStore
{
    public class NewReleaseMovie : Movie
    {
        public NewReleaseMovie(string title) 
            : base(title)
        { }

        public override int GetFrequentRenterPoints(int daysRented)
        {
            return 1 + (daysRented > 1 ? 1 : 0);
        }

        public override decimal GetRenterPoints(int daysRented)
        {
            return daysRented * 3;
        }
    }
}
