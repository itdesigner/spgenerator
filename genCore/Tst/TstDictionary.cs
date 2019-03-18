namespace DS.Tst
{
    using System;
    using System.Collections;
    using System.Collections.Specialized;
    using System.Reflection;

    public class TstDictionary : ICollection, IEnumerable, ICloneable
    {
        public TstDictionary()
        {
            this.root = null;
            this.version = 0;
        }

        protected TstDictionary(TstDictionaryEntry root)
        {
            if (root == null)
            {
                throw new ArgumentNullException("root is null");
            }
            this.root = root;
            this.version = 0;
        }

        public virtual void Add(string key, object value)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key is null");
            }
            if (key.Length == 0)
            {
                throw new ArgumentException("trying to add empty key");
            }
            if (this.IsReadOnly)
            {
                throw new NotSupportedException("dictionary is read-only");
            }
            if (this.IsFixedSize)
            {
                throw new NotSupportedException("dictionary has fixed size");
            }
            this.version++;
            if (this.Root == null)
            {
                this.root = new TstDictionaryEntry(null, key[0]);
            }
            TstDictionaryEntry entry1 = this.Root;
            int num1 = 0;
            while (num1 < key.Length)
            {
                char ch1 = key[num1];
                if (ch1 < entry1.SplitChar)
                {
                    if (entry1.LowChild == null)
                    {
                        entry1.LowChild = new TstDictionaryEntry(entry1, ch1);
                    }
                    entry1 = entry1.LowChild;
                    continue;
                }
                if (ch1 > entry1.SplitChar)
                {
                    if (entry1.HighChild == null)
                    {
                        entry1.HighChild = new TstDictionaryEntry(entry1, ch1);
                    }
                    entry1 = entry1.HighChild;
                    continue;
                }
                num1++;
                if (num1 == key.Length)
                {
                    if (entry1.IsKey)
                    {
                        throw new ArgumentException("key already in dictionary");
                    }
                    break;
                }
                if (entry1.EqChild == null)
                {
                    entry1.EqChild = new TstDictionaryEntry(entry1, key[num1]);
                }
                entry1 = entry1.EqChild;
            }
            entry1.IsKey = true;
            entry1.Key = key;
            entry1.Value = value;
        }

        public virtual void Clear()
        {
            if (this.IsReadOnly)
            {
                throw new NotSupportedException("dictionary is read-only");
            }
            this.version++;
            this.root = null;
        }

        public virtual object Clone()
        {
            return new TstDictionary(this.Root.Clone() as TstDictionaryEntry);
        }

        public bool Contains(string key)
        {
            return this.ContainsKey(key);
        }

        public virtual bool ContainsKey(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            TstDictionaryEntry entry1 = this.Find(key);
            return ((entry1 != null) && entry1.IsKey);
        }

        public bool ContainsValue(object value)
        {
            TstDictionaryEnumerator enumerator1 = this.GetEnumerator();
            while (enumerator1.MoveNext())
            {
                if (enumerator1.Current.Value != value)
                {
                    continue;
                }
                return true;
            }
            return false;
        }

        public virtual void CopyTo(Array array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }
            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException("index is negative");
            }
            if (array.Rank > 1)
            {
                throw new ArgumentException("array is multi-dimensional");
            }
            if (arrayIndex >= array.Length)
            {
                throw new ArgumentException("index >= array.Length");
            }
            int num1 = arrayIndex;
            TstDictionaryEnumerator enumerator1 = this.GetEnumerator();
            while (enumerator1.MoveNext())
            {
                object obj1 = enumerator1.Current;
                if (num1 > array.Length)
                {
                    throw new ArgumentException("The number of elements in the source ICollection is greater than the available space from index to the end of the destination array.");
                }
                array.SetValue(obj1, num1++);
            }
        }

        public virtual TstDictionaryEntry Find(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            int num1 = key.Length;
            if (num1 == 0)
            {
                return null;
            }
            TstDictionaryEntry entry1 = this.Root;
            int num2 = 0;
            while ((num2 < num1) && (entry1 != null))
            {
                char ch1 = key[num2];
                if (ch1 < entry1.SplitChar)
                {
                    entry1 = entry1.LowChild;
                    continue;
                }
                if (ch1 > entry1.SplitChar)
                {
                    entry1 = entry1.HighChild;
                    continue;
                }
                if (num2 == (num1 - 1))
                {
                    return entry1;
                }
                num2++;
                entry1 = entry1.EqChild;
            }
            return entry1;
        }

        public virtual TstDictionaryEnumerator GetEnumerator()
        {
            return new TstDictionaryEnumerator(this);
        }

        public virtual ICollection NearNeighbors(string key, int distance)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            if (distance < 0)
            {
                throw new ArgumentException("dist is negative");
            }
            ArrayList list1 = new ArrayList();
            this.NearNeighborsSearch(this.Root, key, 0, distance, list1);
            return list1;
        }

        internal void NearNeighborsSearch(TstDictionaryEntry p, string key, int index, int dist, IList matches)
        {
            if ((p != null) && (dist >= 0))
            {
                char ch1 = key[index];
                if ((dist > 0) || (ch1 < p.SplitChar))
                {
                    this.NearNeighborsSearch(p.LowChild, key, index, dist, matches);
                }
                if (p.IsKey)
                {
                    if ((key.Length - index) <= dist)
                    {
                        matches.Add(new DictionaryEntry(p.Key, p.Value));
                    }
                }
                else
                {
                    int num1 = index;
                    if (num1 != (key.Length - 1))
                    {
                        num1++;
                    }
                    int num2 = dist;
                    if (ch1 != p.SplitChar)
                    {
                        num2--;
                    }
                    this.NearNeighborsSearch(p.EqChild, key, num1, num2, matches);
                }
                if ((dist > 0) || (ch1 > p.SplitChar))
                {
                    this.NearNeighborsSearch(p.HighChild, key, index, dist, matches);
                }
            }
        }

        public virtual ICollection PartialMatch(string key)
        {
            return this.PartialMatch(key, '*');
        }

        public virtual ICollection PartialMatch(string key, char wildChar)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            if (key.Length == 0)
            {
                throw new ArgumentException("key is empty");
            }
            ArrayList list1 = new ArrayList();
            this.PartialMatchSearch(this.Root, key, 0, wildChar, list1);
            return list1;
        }

        internal void PartialMatchSearch(TstDictionaryEntry p, string key, int index, char wildChar, IList matches)
        {
            if (p != null)
            {
                char ch1 = key[index];
                if ((ch1 == wildChar) || (ch1 < p.SplitChar))
                {
                    this.PartialMatchSearch(p.LowChild, key, index, wildChar, matches);
                }
                if ((ch1 == wildChar) || (ch1 == p.SplitChar))
                {
                    if (index < (key.Length - 1))
                    {
                        this.PartialMatchSearch(p.EqChild, key, index + 1, wildChar, matches);
                    }
                    else if (p.IsKey)
                    {
                        matches.Add(new DictionaryEntry(p.Key, p.Value));
                    }
                }
                if ((ch1 == wildChar) || (ch1 > p.SplitChar))
                {
                    this.PartialMatchSearch(p.HighChild, key, index, wildChar, matches);
                }
            }
        }

        public virtual void Remove(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key is null");
            }
            if (key.Length == 0)
            {
                throw new ArgumentException("key length cannot be 0");
            }
            if (this.IsReadOnly)
            {
                throw new NotSupportedException("dictionary is read-only");
            }
            if (this.IsFixedSize)
            {
                throw new NotSupportedException("dictionary has fixed size");
            }
            this.version++;
            TstDictionaryEntry entry1 = this.Find(key);
            if (entry1 != null)
            {
                entry1.IsKey = false;
                entry1.Key = null;
                while ((!entry1.IsKey && !entry1.HasChildren) && (entry1.Parent != null))
                {
                    if (entry1.IsLowChild)
                    {
                        entry1.Parent.LowChild = null;
                    }
                    else if (entry1.IsHighChild)
                    {
                        entry1.Parent.HighChild = null;
                    }
                    else
                    {
                        entry1.Parent.EqChild = null;
                    }
                    entry1 = entry1.Parent;
                }
                if ((!entry1.IsKey && !entry1.HasChildren) && (entry1 == this.root))
                {
                    this.root = null;
                }
            }
        }

        public static TstDictionary Synchronized(TstDictionary table)
        {
            if (table == null)
            {
                throw new ArgumentNullException("table");
            }
            return new TstSynchronizedDictionary(table);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }


        public virtual int Count
        {
            get
            {
                IEnumerator enumerator1 = this.GetEnumerator();
                int num1 = 0;
                while (enumerator1.MoveNext())
                {
                    num1++;
                }
                return num1;
            }
        }

        public virtual bool IsFixedSize
        {
            get
            {
                return false;
            }
        }

        public virtual bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public virtual bool IsSynchronized
        {
            get
            {
                return false;
            }
        }

        public virtual object this[string key]
        {
            get
            {
                if (key == null)
                {
                    throw new ArgumentNullException("key");
                }
                TstDictionaryEntry entry1 = this.Find(key);
                if (entry1 == null)
                {
                    return null;
                }
                return entry1.Value;
            }
            set
            {
                if (key == null)
                {
                    throw new ArgumentNullException("key");
                }
                if (key.Length == 0)
                {
                    throw new ArgumentException("key is an empty string");
                }
                if (this.IsReadOnly)
                {
                    throw new NotSupportedException("read-only dictionary");
                }
                this.version++;
                TstDictionaryEntry entry1 = this.Find(key);
                if (entry1 == null)
                {
                    this.Add(key, value);
                }
                else
                {
                    if (this.IsFixedSize)
                    {
                        throw new NotSupportedException("fixed-size dictionary");
                    }
                    entry1.Value = value;
                }
            }
        }

        public virtual ICollection Keys
        {
            get
            {
                StringCollection collection1 = new StringCollection();
                TstDictionaryEnumerator enumerator1 = this.GetEnumerator();
                while (enumerator1.MoveNext())
                {
                    collection1.Add(enumerator1.Key);
                }
                return collection1;
            }
        }

        public TstDictionaryEntry Root
        {
            get
            {
                return this.root;
            }
        }

        public virtual object SyncRoot
        {
            get
            {
                return this;
            }
        }

        public virtual ICollection Values
        {
            get
            {
                ArrayList list1 = new ArrayList();
                TstDictionaryEnumerator enumerator1 = this.GetEnumerator();
                while (enumerator1.MoveNext())
                {
                    DictionaryEntry entry1 = enumerator1.Current;
                    list1.Add(entry1.Value);
                }
                return list1;
            }
        }

        public long Version
        {
            get
            {
                return this.version;
            }
        }


        private TstDictionaryEntry root;
        private long version;
    }
}

