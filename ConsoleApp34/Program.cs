using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

using CsvHelper.Configuration.Attributes;
using CsvHelper;
using System.Globalization;

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

    public class Department
    {
        [Index(0)]
        public int Id { get; set; }

        [Index(1)]
        public string Name { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var filename = Path.Combine(Path.GetTempPath(), "test.csv");

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            using (var writer = new StreamWriter(filename, false, Encoding.GetEncoding("Shift_JIS"))) //Shift-JISの文字化け対策にエンコード
            {
                var config = new CsvHelper.Configuration.CsvConfiguration(new CultureInfo("ja-JP", false))
                {
                    HasHeaderRecord = true,
                    Delimiter = "\t",
                };

                writer.WriteLine("sep=\t");

                writer.WriteLine("peoples");

                {
                    var csv = new CsvWriter(writer, config);
                    var people = new List<Person>()
                    {
                        new Person(){Id=4,Name="川口春奈",Age=26 },
                        new Person(){Id=5,Name="新垣結衣",Age=33 },
                        new Person(){Id=6,Name="吉岡里帆",Age=28 },
                    };
                    csv.WriteRecords(people);
                }

                writer.WriteLine("department");

                {
                    var csv = new CsvWriter(writer, config);
                    var people = new List<Department>()
                    {
                        new Department(){Id=10,Name="総務部" },
                        new Department(){Id=20,Name="人事部" },
                        new Department(){Id=30,Name="経理部" },
                        new Department(){Id=40,Name="広報部" },
                        new Department(){Id=50,Name="開発部" },
                    };
                    csv.WriteRecords(people);
                }
            }
        }
    }
}
