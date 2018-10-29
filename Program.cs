using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    class Program
    {
        static void Main(string[] args)
        {


            const string fileName = "users.csv";
            var propertyMapping = new Dictionary<string, int>();

            CsvGenerator.GenerateFile(fileName, 100000);

            Console.WriteLine("File is generated");
            //Console.ReadLine();

            Console.WriteLine("Starting to read file. Press something please");
            Console.ReadLine();

            var file = new StreamReader(fileName);
            string line;

            line = file.ReadLine(); // Read first line
            var titles = line.Split(';');

            for (int i = 0; i < titles.Length; i++)
            {
                propertyMapping[titles[i]] = i;
            }

            User mappedUser = new User();
            string[] linesToParse = new string[10000];
            int index = 0;

            while ((line = file.ReadLine()) != null)
            {
                linesToParse[index++] = line;
                if (index == linesToParse.Length)
                {
                    index = 0;
                    var users = ParseLines(linesToParse, propertyMapping);
                    //users.ToList().ForEach(x => Console.WriteLine(x.ToString()));
                    Console.WriteLine(users.Last());
                }

                //var user = ParseLine(line, propertyMapping);
                //MapUser(line, propertyMapping, mappedUser);

                //Console.WriteLine(line);
                //Console.WriteLine(user.ToString());
                //Console.WriteLine(mappedUser.ToString());
            }

            file.Close();

            Console.WriteLine("***  READING IS FINISHED  ***");
            Console.WriteLine("***  PRESS ANY KEY  ***");
            Console.ReadLine();
        }

        public static User[] ParseLines(string[] userData, Dictionary<string, int> propMapping)
        {
            var result = new List<User>();

            foreach (var line in userData)
            {
                result.Add(ParseLine(line, propMapping));
            }

            return result.ToArray();
        }

        public static User ParseLine(string userData, Dictionary<string, int> propMapping)
        {
            var values = userData.Split(';');
            var user = new User()
            {
                Id = int.Parse(values[propMapping[nameof(User.Id)]]),
                FirstName = values[propMapping[nameof(User.FirstName)]],
                SecondName = values[propMapping[nameof(User.SecondName)]],
                Age = int.Parse(values[propMapping[nameof(User.Age)]]),
                Address = values[propMapping[nameof(User.Address)]]
            };

            return user;
        }

        public static void MapUser(string userData, Dictionary<string, int> propMapping, User user)
        {
            var values = userData.Split(';');

            user.Id = int.Parse(values[propMapping[nameof(User.Id)]]);
            user.FirstName = values[propMapping[nameof(User.FirstName)]];
            user.SecondName = values[propMapping[nameof(User.SecondName)]];
            user.Age = int.Parse(values[propMapping[nameof(User.Age)]]);
            user.Address = values[propMapping[nameof(User.Address)]];
        }
    }
}
