using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    public class User
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return $"'Id': '{Id}', 'FirstName': '{FirstName}', 'SecondName': '{SecondName}', 'Age': '{Age}', 'Address': '{Address}'";
        }
    }
}
