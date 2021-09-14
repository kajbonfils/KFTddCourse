using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout
{
    public class Original
    {
        private List<Entry> Data;

        public Original()
        {
            Data = new List<Entry>();
        }
        public void AddEntries(List<Entry> entries)
        {
            foreach (var entry in entries)
            {
                entry.DoStuff();
                Data.Add(entry);
            }
        }
    }

    public class NewRequirementHacked
    {
        private List<Entry> Data;

        public NewRequirementHacked()
        {
            Data = new List<Entry>();
        }
        public void AddEntries(List<Entry> entries)
        {
            foreach (var entry in entries)
            {
                if (!Data.Contains(entry)) // Only non existing fields
                {
                    entry.DoStuff();
                    Data.Add(entry);
                }
            }
        }
    }


    public class NewRequirementSprout
    {
        private List<Entry> Data;

        public NewRequirementSprout()
        {
            Data = new List<Entry>();
        }
        public void AddEntries(List<Entry> entries)
        {
            var uniqueEntries = GetUniqueEntries(entries, Data);
            foreach (var entry in uniqueEntries)
            {
                    entry.DoStuff();
                    Data.Add(entry);
            }
        }

        public static IEnumerable<Entry> GetUniqueEntries(List<Entry> newEntries, List<Entry> existingList)
        {
            return newEntries.Where(p => !existingList.Contains(p));
        }
    }




    public class Entry
    {
        public void DoStuff() { }
    }
}
