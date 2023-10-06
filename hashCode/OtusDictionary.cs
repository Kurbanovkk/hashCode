using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hashCode
{
    internal class OtusDictionary
    {
        private const int InitialCapacity = 32;

        private Entry[] entries;
        private int count;

        public OtusDictionary()
        {
            entries = new Entry[InitialCapacity];
        }

        public string this[int key]
        {
            get => Get(key);
            set => Add(key, value);
        }

        public void Add(int key, string value)
        {
            if (count >= entries.Length)
            {
                ResizeEntries();
            }

            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), "Значение не может быть Null.");
            }

            int index = GetIndex(key);
            while (entries[index] != null)
            {
                if (entries[index].Key == key)
                {
                    throw new ArgumentException($"Элемент с ключём {key} уже существует.");
                }
                index = (index + 1) % entries.Length;
            }

            entries[index] = new Entry(key, value);
            count++;
        }

        public string Get(int key)
        {
            int index = GetIndex(key);
            while (entries[index] != null)
            {
                if (entries[index].Key == key)
                {
                    return entries[index].Value;
                }
                index = (index + 1) % entries.Length;
            }

            return null;
        }

        private int GetIndex(int key)
        {
            return Math.Abs(key % entries.Length);
        }

        private void ResizeEntries()
        {
            var newEntries = new Entry[entries.Length * 2];
            foreach (var entry in entries)
            {
                if (entry != null)
                {
                    int newIndex = GetIndex(entry.Key);
                    while (newEntries[newIndex] != null)
                    {
                        newIndex = (newIndex + 1) % newEntries.Length;
                    }
                    newEntries[newIndex] = entry;
                }
            }
            entries = newEntries;
        }

        private class Entry
        {
            public int Key { get; }
            public string Value { get; }

            public Entry(int key, string value)
            {
                Key = key;
                Value = value;
            }
        }
    }
}
