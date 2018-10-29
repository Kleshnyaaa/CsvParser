using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    public class CsvGenerator
    {
        public static void GenerateFile(string path, int numberOfRows = 1)
        {
            var fileStream = File.Open(path, FileMode.Create);
            var streamWriter = new StreamWriter(fileStream);
            var random = new Random(DateTime.Now.Millisecond);

            streamWriter.WriteLine(
                $"{nameof(User.Id)};{nameof(User.FirstName)};{nameof(User.SecondName)};{nameof(User.Age)};{nameof(User.Address)}");

            for (var i = 1; i < numberOfRows; i++)
            {
                var user = new User()
                {
                    Id = i,
                    FirstName = $"First Name {i}",
                    SecondName = $"Second Name {i}",
                    Address = $"Minsk - {i}",
                    Age = random.Next(10, 99)
                };

                streamWriter.WriteLine($"{user.Id};{user.FirstName};{user.SecondName};{user.Age};{user.Address}");
            }

            streamWriter.Close();
            fileStream.Close();
        }
    }
}
