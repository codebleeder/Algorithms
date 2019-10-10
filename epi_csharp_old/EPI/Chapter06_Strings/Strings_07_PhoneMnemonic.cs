using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter6_Strings
{
    public static class Strings_07_PhoneMnemonic
    {
        public static List<string> PhoneMnemonic(string phoneNumber)
        {
            var partialMnemonic = new char[phoneNumber.Length];
            var mnemonics = new List<string>();
            PhoneMnemonicHelper(phoneNumber, 0, partialMnemonic, mnemonics);
            return mnemonics;
        }
        private static string[] MAPPING = { "0", "1", "ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ" };
        private static void PhoneMnemonicHelper(string phoneNumber, int digit, char[] partialMnemonic, List<string> mnemonics)
        {
            if (digit == phoneNumber.Length)
            {
                mnemonics.Add(new string(partialMnemonic));
            }
            else
            {
                var mappingString = MAPPING[phoneNumber[digit] - '0'];
                for (var i = 0; i < mappingString.Length; i++)
                {
                    partialMnemonic[digit] = mappingString[i];
                    PhoneMnemonicHelper(phoneNumber, digit + 1, partialMnemonic, mnemonics);
                }
            }
        }                
        public static void Test()
        {
            var res = PhoneMnemonic("23");
            Utilities.PrintList(res);
        }
    }
}
