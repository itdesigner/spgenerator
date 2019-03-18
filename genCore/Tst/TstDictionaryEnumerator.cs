namespace DS.Tst
{
    using System;
    using System.Collections;

    public sealed class TstDictionaryEnumerator : IDictionaryEnumerator, IEnumerator
    {
        public TstDictionaryEnumerator(TstDictionary tst)
        {
            if (tst == null)
            {
                throw new ArgumentNullException("tst");
            }
            this.version = tst.Version;
            this.dictionary = tst;
            this.currentNode = null;
            this.stack = null;
        }

        public bool MoveNext()
        {
            this.ThrowIfChanged();
            if (this.stack == null)
            {
                this.stack = new Stack();
                this.currentNode = null;
                if (this.dictionary.Root != null)
                {
                    this.stack.Push(this.dictionary.Root);
                }
            }
            else if (this.currentNode == null)
            {
                throw new InvalidOperationException("out of range");
            }
            if (this.stack.Count == 0)
            {
                this.currentNode = null;
            }
            while (this.stack.Count > 0)
            {
                this.currentNode = (TstDictionaryEntry) this.stack.Pop();
                if (this.currentNode.HighChild != null)
                {
                    this.stack.Push(this.currentNode.HighChild);
                }
                if (this.currentNode.EqChild != null)
                {
                    this.stack.Push(this.currentNode.EqChild);
                }
                if (this.currentNode.LowChild != null)
                {
                    this.stack.Push(this.currentNode.LowChild);
                }
                if (this.currentNode.IsKey)
                {
                    break;
                }
            }
            return (this.currentNode != null);
        }

        public void Reset()
        {
            this.ThrowIfChanged();
            this.stack.Clear();
            this.stack = null;
        }

        internal void ThrowIfChanged()
        {
            if (this.version != this.dictionary.Version)
            {
                throw new InvalidOperationException("Collection changed");
            }
        }


        public DictionaryEntry Current
        {
            get
            {
                this.ThrowIfChanged();
                return this.Entry;
            }
        }

        public DictionaryEntry Entry
        {
            get
            {
                this.ThrowIfChanged();
                if (this.currentNode == null)
                {
                    throw new InvalidOperationException();
                }
                return new DictionaryEntry(this.currentNode.Key, this.currentNode.Value);
            }
        }

        public string Key
        {
            get
            {
                this.ThrowIfChanged();
                if (this.currentNode == null)
                {
                    throw new InvalidOperationException();
                }
                return this.currentNode.Key;
            }
        }

        object IDictionaryEnumerator.Key
        {
            get
            {
                return this.Key;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return this.Current;
            }
        }

        public object Value
        {
            get
            {
                this.ThrowIfChanged();
                if (this.currentNode == null)
                {
                    throw new InvalidOperationException();
                }
                return this.currentNode.Value;
            }
        }


        private TstDictionaryEntry currentNode;
        private TstDictionary dictionary;
        private Stack stack;
        private long version;
    }
}

