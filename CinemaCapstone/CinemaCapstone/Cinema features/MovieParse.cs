using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Menus
{
    public static class MovieParse
    {
        public struct MovieData
        {
            public string Movie;
            public int Length;
            public string Genre;
            public string Rating;
        }
        private static string path = $@"{Environment.CurrentDirectory}\Resources\Movies.txt";
        public static List<MovieData> GetMovies()
        {
            List<MovieData> MovieDataList = new List<MovieData>();
            foreach (string line in File.ReadAllLines(path))
            {
                string[] parts = line.Trim('[', ']').Split('%');
                MovieData MovieData = new MovieData();
                foreach (string part in parts)
                {
                    string[] keyValue = part.Split(':');
                    if (keyValue.Length == 2)
                    {
                        switch (keyValue[0])
                        {
                            case "Movie":
                                MovieData.Movie = keyValue[1];
                                break;
                            case "Length":
                                MovieData.Length = int.Parse(keyValue[1]);
                                break;
                            case "Genre":
                                MovieData.Genre = keyValue[1];
                                break;
                            case "Rating":
                                MovieData.Rating = keyValue[1];
                                break;
                        }
                    }
                }
                MovieDataList.Add(MovieData);
            }
            return MovieDataList;
        }
    }
}


