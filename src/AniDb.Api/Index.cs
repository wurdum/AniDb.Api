using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Kent.Boogaart.KBCsv;

namespace AniDb.Api
{
    public class Index : IEnumerable<IGrouping<string, Index.Entry>>
    {
        public const string DataDir = "Data";
        public const string IndexFileName = "anime-titles.dat";
        private static ILookup<string, Entry> _entries;

        static Index() {
            var programmRoot = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath);
            var indexFile = Path.Combine(programmRoot, DataDir, IndexFileName);   

            var entries = new List<Entry>(44000);
            using (var reader = new CsvReader(File.OpenRead(indexFile), Encoding.UTF8) { ValueSeparator = '|', ValueDelimiter = null }) {
                
                reader.SkipRecords(3);
                DataRecord record;
                while ((record = reader.ReadDataRecord()) != null) {
                    entries.Add(new Entry(Convert.ToInt32(record[0]), (EntryType)Convert.ToInt32(record[1]), record[2], record[3]));
                }
            }

            _entries = entries.ToLookup(e => e.Title, StringComparer.OrdinalIgnoreCase);
        }

        public int Count {
            get { return _entries.Count; }
        }

        public IEnumerable<Entry> this[string key] {
            get { return _entries[key]; }
        }

        public Entry? FindFirst(string title, EntryType preferType = EntryType.PrimaryTitle) {
            var enries = FindAll(title).ToArray();
            if (enries.Length == 0)
                return null;

            var prefered = enries.FirstOrDefault(e => e.Type == preferType);
            return !prefered.Equals(default(Entry)) ? prefered : enries[0];
        }

        public IEnumerable<Entry> FindAll(string title) {
            return this[title];
        }

        public enum EntryType { PrimaryTitle = 1, Synonyms, ShortTitles, OfficialTitle }
        
        public struct Entry
        {
            public readonly int Id;
            public readonly EntryType Type;
            public readonly string Language;
            public readonly string Title;

            public Entry(int id, EntryType type, string language, string title) {
                Id = id;
                Type = type;
                Language = language;
                Title = title;
            }
        }

        public IEnumerator<IGrouping<string, Entry>> GetEnumerator() {
            return _entries.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}