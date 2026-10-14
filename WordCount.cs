using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace async_prograaming
{
    internal class WordCount
    {


        //Anton Chepelev

        public async Task<Dictionary<string, int>> CountWordsAsync(string filePath)
        {
            return await Task.Run(() =>
            {
                return File.ReadLines(filePath)
                    .SelectMany(line => line.Split(new char[] { ' ', '.', ',', '?', '!', '"' }, StringSplitOptions.RemoveEmptyEntries))
                    .Select(word => word.ToLower())
                    .Where(word => word.Any(char.IsLetter))
                    .GroupBy(word => word)
                    .OrderByDescending(group => group.Count())
                    .Take(10)
                    .ToDictionary(group => group.Key, group => group.Count());
            });
        }
    }
}









