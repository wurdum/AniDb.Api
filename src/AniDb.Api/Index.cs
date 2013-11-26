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
    public class Index : IEnumerable<Index.Entry>
    {
        public const string DataDir = "Data";
        public const string IndexFileName = "anime-titles.dat";
        private static Entry[] _entries;

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

            _entries = entries.ToArray();
        }

        public int Count {
            get { return _entries.Length; }
        }

        public Entry this[int key] {
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
            return _entries.Where(e => e.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
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

        public IEnumerator<Entry> GetEnumerator() {
            return _entries.Cast<Entry>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }

    public class IndexByTitle
    {
        private readonly ILookup<string, Index.Entry> _entries;

        public IndexByTitle() {
            var index = new Index();
            _entries = index.ToLookup(i => i.Title);
        }

        public Index.Entry? FindFirst(string title, Index.EntryType preferType = Index.EntryType.PrimaryTitle) {
            var enries = FindAll(title).ToArray();
            if (enries.Length == 0)
                return null;

            var prefered = enries.FirstOrDefault(e => e.Type == preferType);
            return !prefered.Equals(default(Index.Entry)) ? prefered : enries[0];
        }

        public IEnumerable<Index.Entry> FindAll(string title) {
            return _entries.Contains(title) ? _entries[title] : Enumerable.Empty<Index.Entry>();
        }
    }

    public class IndexById
    {
        private readonly ILookup<int, Index.Entry> _entries;

        public IndexById() {
            var index = new Index();
            _entries = index.ToLookup(i => i.Id);
        }

        public Index.Entry? FindFirst(int id, Index.EntryType preferType = Index.EntryType.PrimaryTitle) {
            var enries = FindAll(id).ToArray();
            if (enries.Length == 0)
                return null;

            var prefered = enries.FirstOrDefault(e => e.Type == preferType);
            return !prefered.Equals(default(Index.Entry)) ? prefered : enries[0];
        }

        public IEnumerable<Index.Entry> FindAll(int id) {
            return _entries.Contains(id) ? _entries[id] : Enumerable.Empty<Index.Entry>();
        }
    }
}