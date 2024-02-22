using CsvHelper;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWormSpecFlow.TestData
{
    public class TestData
    {
        private static readonly string directoryPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

        public static string GetWishListTitle()
        {
            string filePath = Path.Combine(directoryPath, "WishListTitles.txt");

            string[] lines = File.ReadAllLines(filePath);

            Random random = new Random();
            int randomIndex = random.Next(0, lines.Length);

            string randomWishListTitle = lines[randomIndex];

            return randomWishListTitle;
        }

        public static List<YourTestDataClass> GetTestDataFromCsv(string fileName, int numberOfRecords)
        {
            string filePath = Path.Combine(directoryPath, fileName);

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<YourTestDataClass>().ToList();


                var random = new Random();
                records = records.OrderBy(item => random.Next()).ToList();


                return records.Take(numberOfRecords).ToList();
            }
        }


    }


    public class YourTestDataClass
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string TownCity { get; set; }
        public string PostCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
