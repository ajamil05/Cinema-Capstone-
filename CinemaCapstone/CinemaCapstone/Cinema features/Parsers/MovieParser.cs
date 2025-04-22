using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Menus
{
    /// <summary>
    /// This class is responsible for parsing movie data from a text file.
    /// Static class MovieParser is used to read and parse movie information from a file.
    /// </summary>
    public static class MovieParser
    {
        /// <summary>
        /// Stuct MovieData is used to store movie information.
        /// </summary>
        public struct MovieData
        {
            public string Movie;
            public int Length;
            public string Genre;
            public string Rating;
        }

        /// Path to the file containing movie information
        private static string path = $@"{Environment.CurrentDirectory}\Resources\Movies.txt";

        /// <summary>
        /// This method reads the movie data from a file and parses it into a list of MovieData objects.
        /// </summary>
        /// <returns></returns>
        public static List<MovieData> GetMovies()
        {
            // List to store parsed movie data
            List<MovieData> MovieDataList = new List<MovieData>();

            // Read all lines from the file and parse each line
            foreach (string line in File.ReadAllLines(path))
            {
                // Trim the line and split it into parts
                string[] parts = line.Trim('[', ']').Split('%');

                // Create a new MovieData object for each line
                MovieData MovieData = new MovieData();

                // Loop through each part and assign values to the MovieData object
                foreach (string part in parts)
                {
                    // Split the part into key-value pairs
                    string[] keyValue = part.Split(':');

                    // Check if the key-value pair has exactly two elements
                    if (keyValue.Length == 2)
                    {
                        // Gets the Data from the file and assigns it to the MovieData object
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
                // Add the parsed MovieData object to the list
                MovieDataList.Add(MovieData);
            }
            // Return the list of parsed movie data
            return MovieDataList;
        }
    }
}


