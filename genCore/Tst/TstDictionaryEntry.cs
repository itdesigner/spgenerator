namespace DS.Tst
{
    using System;

    public class TstDictionaryEntry : ICloneable
    {
        public TstDictionaryEntry(TstDictionaryEntry parent, char splitChar)
        {
            this.isKey = false;
            this.key = null;
            this.value = null;
            this.parent = parent;
            this.splitChar = splitChar;
            this.lowChild = null;
            this.eqChild = null;
            this.highChild = null;
        }

        public object Clone()
        {
            TstDictionaryEntry entry1 = new TstDictionaryEntry(this.Parent, this.SplitChar);
            if (this.LowChild != null)
            {
                entry1.LowChild = this.LowChild.Clone() as TstDictionaryEntry;
            }
            if (this.EqChild != null)
            {
                entry1.EqChild = this.EqChild.Clone() as TstDictionaryEntry;
            }
            if (this.HighChild != null)
            {
                entry1.HighChild = this.HighChild.Clone() as TstDictionaryEntry;
            }
            return entry1;
        }

        public override string ToString()
        {
            char ch1;
            if (this.IsEqChild)
            {
                ch1 = 'E';
            }
            else if (this.IsLowChild)
            {
                ch1 = 'L';
            }
            else if (this.IsHighChild)
            {
                ch1 = 'H';
            }
            else
            {
                ch1 = 'R';
            }
            if (this.IsKey)
            {
                return string.Format("{0} {1} {2}", ch1, this.SplitChar, this.Key);
            }
            return string.Format("{0} {1}", ch1, this.SplitChar);
        }


        public TstDictionaryEntry EqChild
        {
            get
            {
                return this.eqChild;
            }
            set
            {
                this.eqChild = value;
            }
        }

        public bool HasChildren
        {
            get
            {
                return (((this.LowChild != null) || (this.EqChild != null)) || (this.HighChild != null));
            }
        }

        public TstDictionaryEntry HighChild
        {
            get
            {
                return this.highChild;
            }
            set
            {
                this.highChild = value;
            }
        }

        public bool IsEqChild
        {
            get
            {
                return ((this.Parent != null) && (this.Parent.EqChild == this));
            }
        }

        public bool IsHighChild
        {
            get
            {
                return ((this.Parent != null) && (this.Parent.HighChild == this));
            }
        }

        public bool IsKey
        {
            get
            {
                return this.isKey;
            }
            set
            {
                this.isKey = value;
            }
        }

        public bool IsLowChild
        {
            get
            {
                return ((this.Parent != null) && (this.Parent.LowChild == this));
            }
        }

        public string Key
        {
            get
            {
                if (!this.IsKey)
                {
                    throw new InvalidOperationException("node is not a key");
                }
                return this.key;
            }
            set
            {
                this.key = value;
            }
        }

        public TstDictionaryEntry LowChild
        {
            get
            {
                return this.lowChild;
            }
            set
            {
                this.lowChild = value;
            }
        }

        public TstDictionaryEntry Parent
        {
            get
            {
                return this.parent;
            }
        }

        public char SplitChar
        {
            get
            {
                return this.splitChar;
            }
        }

        public object Value
        {
            get
            {
                if (!this.IsKey)
                {
                    throw new InvalidOperationException("node is not a key");
                }
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }


        private TstDictionaryEntry eqChild;
        private TstDictionaryEntry highChild;
        private bool isKey;
        private string key;
        private TstDictionaryEntry lowChild;
        private TstDictionaryEntry parent;
        private char splitChar;
        private object value;
    }
}

