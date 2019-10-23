using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter12_HashTables
{
    public static class HashTables_00_FindAnagrams
    {
        public static List<List<string>> FindAnagrams(List<string> dictionary)
        {
            var sortedStringToAnagram = new Dictionary<string, List<string>>();
            for(var i = 0; i < dictionary.Count; i++)
            {
                var s = dictionary[i].ToCharArray();
                Array.Sort(s);
                var sSorted = new string(s);
                if (sortedStringToAnagram.ContainsKey(sSorted))
                {
                    sortedStringToAnagram[sSorted].Add(dictionary[i]);
                }
                else
                {
                    sortedStringToAnagram[sSorted] = new List<string> { dictionary[i] };
                }
            }
            var res = new List<List<string>>();
            foreach(KeyValuePair<string, List<string>> kv in sortedStringToAnagram)
            {
                if(kv.Value.Count > 1)
                {
                    res.Add(kv.Value);
                }                
            }
            return res;
        }
        public static void Test()
        {
            var dictionary = new List<string>
            {
                "debitcard", "elvis", "silent", "badcredit", "lives", "freedom", "listen", "levis", "money"
            };
            var res = FindAnagrams(dictionary);
            foreach(var v in res)
            {
                Utilities.PrintList(v);
                Console.WriteLine();
            }
        }
    }
}
