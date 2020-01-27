using System;
using McMaster.Extensions.CommandLineUtils;

namespace _2
{
    class Program
    {
        public static string random (int length = 32, bool letters = true, bool number = true)
        {
            var p = "";
            if (letters == false)
            {
                p = "0123456789";
            }
            else if (number == false)
            {
                p = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            }
            var chars = p;
            var stringchar = new char[length];
            var random = new Random();
            for (int i =0; i< stringchar.Length; i++)
            {
                stringchar[i] =chars[random.Next(chars.Length)];
            }
            var data = new string(stringchar);
            return data;
        }
        static int Main(string[] args)
        {
            
            var rootApp = new CommandLineApplication()
            {
                Name = "Aplikasi Pertama",
                Description = "Ini digunakan untuk mencetak text",
                ShortVersionGetter = () => "1.0.0"
            };

             rootApp.Command("random", app => 
            {
                app.Description = "random generator";
                // var text = app.Argument("text","Masukkan text");
                var lengths = app.Option("--lengths", "generator random", CommandOptionType.SingleOrNoValue);
                var letters = app.Option("--letters", "generator random", CommandOptionType.SingleOrNoValue);
                var numbers = app.Option("--numbers", "generator random", CommandOptionType.SingleOrNoValue);
                var uppercase = app.Option("--uppercase", "generator random", CommandOptionType.SingleOrNoValue);
                var lowercase = app.Option("--lowercase", "generator random", CommandOptionType.MultipleValue);

                app.OnExecute(() =>
                {
                    if (lengths.HasValue())
                    {
                        Console.WriteLine(random(Convert.ToInt32(lengths.Value()), true, true));
                    }
                    else if (letters.HasValue())
                    {
                        Console.WriteLine(random(32, Convert.ToBoolean(letters.Value()), false));
                    }
                     else if (numbers.HasValue())
                    {
                        Console.WriteLine(random(32, true, Convert.ToBoolean(numbers.Value())));
                    }
                    else if (uppercase.HasValue())
                    {
                        Console.WriteLine(random(32, true, false).ToUpper());
                    }
                    else if (lowercase.HasValue())
                    {
                        Console.WriteLine(random(20, true, false).ToLower());
                        // Console.WriteLine(random(Convert.ToInt32(lengths.Value()), true, Convert.ToBoolean(numbers.Value())).ToLower());
                    }
                });
            });
            return rootApp.Execute(args);
        }

    }
}
