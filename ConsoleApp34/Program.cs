using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CsvHelper.Configuration.Attributes;

namespace ConsoleApp34
{
    public class Person
    {
        [Index(0)]
        public int Id { get; set; }

        [Index(1)]
        public string Name { get; set; }

        [Index(2)]
        public int Age { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }
    }
}
