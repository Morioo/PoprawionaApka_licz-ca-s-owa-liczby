using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace WordCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)

            {
                Console.WriteLine("C:\\Users\\Morio\\Desktop\\poprawionapaka\\wejsciowy.txt");   //path to input
                return;


            }

            string inputFile = args[0];


            string outFile = "wynikWejsciowegoPliku.txt";   // path to output

            try
            {

                string text = File.ReadAllText(inputFile).ToLower();            // conversion to lowercase letters


                text = Regex.Replace(text, @"[^a-z0-9\s]", "");                             // removal of punctuation



                string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);



                var wordCounts = new Dictionary<string, int>();

                var numberCounts = new Dictionary<string, int>();

                foreach (string word in words)

                {

                    if (int.TryParse(word, out int number))
                    {


                        if (numberCounts.ContainsKey(word)){
                        



                            numberCounts[word]++;
                        }
                        else


                        {


                            numberCounts[word] = 1;
                        }
                    }

                    else


                    {
                        if (wordCounts.ContainsKey(word))
                        {


                            wordCounts[word]++;
                        }
                        else


                        {

                            wordCounts[word] = 1;
                        }
                    }
                }


                var sortedWords = new List<KeyValuePair<string, int>>(wordCounts);              // alphabetical sorting

                     sortedWords.Sort((x, y) => x.Key.CompareTo(y.Key));


                var sortedNumbers = new List<KeyValuePair<string, int>>(numberCounts);                  // SORTING NUMBERS


                sortedNumbers.Sort((x, y) => int.Parse(x.Key).CompareTo(int.Parse(y.Key)));



                using (StreamWriter writer = new StreamWriter(outFile))  // entry the result
                {
                    writer.WriteLine("Słowa:");



                    foreach (var pair in sortedWords){

                    
                        writer.WriteLine($"{pair.Key}: {pair.Value}");
                    }

                    


                    foreach (var pair in sortedNumbers)
                    {
                        writer.WriteLine($"{pair.Key}: {pair.Value}");
                    }
                }

                Console.WriteLine($"Wynik został zapisany do pliku: {outFile}");



            }
            catch (Exception ex)
            {



                Console.WriteLine($"Wystąpił błąd: {ex.Message}");
            }
        }




        //<3
    }

}


