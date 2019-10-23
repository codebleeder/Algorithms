using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter12_HashTables
{
    public static class HashTables_00_MergeContactLists
    {
        public static List<ContactList> MergeContactLists(List<ContactList> contacts)
        {            
            var hs = new HashSet<ContactList>(contacts);
            return new List<ContactList>(hs);
        }
        public static void Test()
        {
            var contacts = new List<ContactList>
            {
                new ContactList(new List<string> {"a", "b", "c"}),
                new ContactList(new List<string> {"c", "b", "a"}),
                new ContactList(new List<string> {"a", "d", "c"}),
            };
            var res = MergeContactLists(contacts);
            var resDisplay = res.Count == 2 ? "pass" : "fail";
            Console.WriteLine(resDisplay);

            var res2 = contacts[0].Equals(contacts[1]);
        }
    }
    public class ContactList
    {
        public List<string> Names { get; set; }
        public ContactList(List<string> names)
        {
            Names = names;
        }
        public override bool Equals(Object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }
            
            return this == obj ? 
                true : 
                new HashSet<string>(Names).SetEquals(new HashSet<string>(((ContactList)obj).Names)); 
            
        }
        public override int GetHashCode()
        {
            return new HashSet<string>(Names).GetHashCode();
        }
    }
}
