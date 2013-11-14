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
    public class Index
    {
        public const string DataDir = "Data";
        public const string IndexFileName = "anime-titles.dat";
        private static Entry[] _entries;

        static Index() {
            var programmRoot = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath);
            var indexFile = Path.Combine(programmRoot, DataDir, IndexFileName);   

            var entries = new List<Entry>(44000);
            using (var reader = new CsvReader(File.OpenRead(indexFile), Encoding.UTF8) { ValueSeparator = '|' }) {
                
                reader.SkipRecords(3);
                DataRecord record;
                while ((record = reader.ReadDataRecord()) != null)
                    entries.Add(new Entry(Convert.ToInt32(record[0]), (EntryType)Convert.ToInt32(record[1]), record[2], record[3]));
            }

            _entries = entries.ToArray();
        }

        public int Count {
            get { return _entries.Length; }
        }

        public Entry? Find(string title) {
            var entry = _entries.FirstOrDefault(e => e.Title == title);
            if (entry.Equals(default(Entry)))
                return null;

            return entry;
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
    }
}