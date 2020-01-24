using VideoStore.Original;

namespace VideoStore
{
    public class ChildrenMovie : Movie
    {
        public ChildrenMovie(string title)
            : base(title)
        { }

        public override int GetFrequentRenterPoints(int daysRented)
        {
            return 1;
        }

        public override decimal GetRenterPoints(int daysRented)
        {
            return 1.5m + (daysRented > 3 ? (daysRented - 3) * 1.5m : 0);
        }
    }
}
