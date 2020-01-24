using NFluent;
using System.Collections.Generic;
using VideoStore;
using Xunit;

namespace VideoStore.Tests
{
    public enum MovieKind
    {
        Children = 1,
        NewRelease = 2,
        Regular = 3
    }

    public class ChildrenMovieShould
    {
        Dictionary<MovieKind, Movie> moviesDic = new Dictionary<MovieKind, Movie>()
        {
            { MovieKind.Children, new ChildrenMovie("children1") },
            { MovieKind.NewRelease, new NewReleaseMovie("newrelease1") },
            { MovieKind.Regular, new RegularMovie("regular1") },
        };

        [Theory]
        [InlineData(MovieKind.Children, 1, 1.5)]
        [InlineData(MovieKind.Children, 4, 3)]
        [InlineData(MovieKind.NewRelease, 2, 6)]
        [InlineData(MovieKind.Regular, 2, 2)]
        [InlineData(MovieKind.Regular, 3, 3.5)]
        public void Calculate_Renter_Points_For_Kind_Of_Movie_And_Rented_Days(
            MovieKind kindOfMovie, int daysRented, decimal expected)
        {
            // Arrange
            var movie = moviesDic[kindOfMovie];

            // Act
            var renterPoints = movie.GetRenterPoints(daysRented);

            // Assert
            Check.That(renterPoints).IsEqualTo(expected);
        }

        [Theory]
        [InlineData(MovieKind.Children, 1, 1)]
        [InlineData(MovieKind.NewRelease, 1, 1)]
        [InlineData(MovieKind.NewRelease, 2, 2)]
        [InlineData(MovieKind.Regular, 1, 1)]
        public void Calculate_Frequent_Renter_Points_For_Kind_Of_Movie_And_Rented_Days(
            MovieKind kindOfMovie, int daysRented, decimal expected)
        {
            // Arrange
            var movie = moviesDic[kindOfMovie];

            // Act
            var frequentRenterPoints = movie.GetFrequentRenterPoints(daysRented);

            // Assert
            Check.That(frequentRenterPoints).IsEqualTo(expected);
        }
    }
}
