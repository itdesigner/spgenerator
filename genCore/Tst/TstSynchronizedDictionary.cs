namespace DS.Tst
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class TstSynchronizedDictionary : TstDictionary
    {
        public TstSynchronizedDictionary(TstDictionary dic)
        {
            this.wrapped = dic;
        }

        public override void Add(string key, object value)
        {
            lock (this.Wrapped.SyncRoot)
            {
                this.Wrapped.Add(key, value);
            }
        }

        public override void Clear()
        {
            lock (this.Wrapped.SyncRoot)
            {
                this.Wrapped.Clear();
            }
        }

        public override object Clone()
        {
            return this.Wrapped.Clone();
        }

        public override bool ContainsKey(string key)
        {
            return this.Wrapped.ContainsKey(key);
        }

        public override void CopyTo(Array array, int arrayIndex)
        {
            this.Wrapped.CopyTo(array, arrayIndex);
        }

        public override TstDictionaryEntry Find(string key)
        {
            return this.Wrapped.Find(key);
        }

        public override TstDictionaryEnumerator GetEnumerator()
        {
            return this.Wrapped.GetEnumerator();
        }

        public override ICollection NearNeighbors(string key, int distance)
        {
            return this.Wrapped.NearNeighbors(key, distance);
        }

        public override ICollection PartialMatch(string key)
        {
            return this.Wrapped.PartialMatch(key);
        }

        public override ICollection PartialMatch(string key, char wildChar)
        {
            return this.Wrapped.PartialMatch(key, wildChar);
        }

        public override void Remove(string key)
        {
            lock (this.Wrapped.SyncRoot)
            {
                this.Wrapped.Remove(key);
            }
        }


        public override int Count
        {
            get
            {
                return this.Wrapped.Count;
            }
        }

        public override bool IsFixedSize
        {
            get
            {
                return this.Wrapped.IsFixedSize;
            }
        }

        public override bool IsReadOnly
        {
            get
            {
                return this.Wrapped.IsReadOnly;
            }
        }

        public override bool IsSynchronized
        {
            get
            {
                return true;
            }
        }

        public override object this[string key]
        {
            get
            {
                return this.Wrapped[key];
            }
            set
            {
                lock (this.Wrapped.SyncRoot)
                {
                    this.Wrapped[key] = value;
                }
            }
        }

        public override ICollection Keys
        {
            get
            {
                return this.Wrapped.Keys;
            }
        }

        public override object SyncRoot
        {
            get
            {
                return this.Wrapped.SyncRoot;
            }
        }

        public override ICollection Values
        {
            get
            {
                return this.Wrapped.Values;
            }
        }

        private TstDictionary Wrapped
        {
            get
            {
                return this.Wrapped;
            }
        }


        private TstDictionary wrapped;
    }
}

