namespace DS.Tst
{
    using System;
    using System.Runtime.CompilerServices;

    public class TstTraverser
    {
        public event TstDictionaryEntryEventHandler EqChild;
        public event TstDictionaryEntryEventHandler HighChild;
        public event TstDictionaryEntryEventHandler LowChild;
        public event TstDictionaryEntryEventHandler TreeEntry;

        protected virtual void OnEqChild(TstDictionaryEntry p)
        {
            if (this.EqChild != null)
            {
                this.EqChild(this, new TstDictionaryEntryEventArgs(p));
            }
        }

        protected virtual void OnHighChild(TstDictionaryEntry p)
        {
            if (this.HighChild != null)
            {
                this.HighChild(this, new TstDictionaryEntryEventArgs(p));
            }
        }

        protected virtual void OnLowChild(TstDictionaryEntry p)
        {
            if (this.LowChild != null)
            {
                this.LowChild(this, new TstDictionaryEntryEventArgs(p));
            }
        }

        protected virtual void OnTreeEntry(TstDictionaryEntry p)
        {
            if (this.TreeEntry != null)
            {
                this.TreeEntry(this, new TstDictionaryEntryEventArgs(p));
            }
        }

        public void Traverse(TstDictionary dic)
        {
            if (dic == null)
            {
                throw new ArgumentNullException("dic");
            }
            this.Traverse(dic.Root);
        }

        protected void Traverse(TstDictionaryEntry p)
        {
            if (p != null)
            {
                this.OnTreeEntry(p);
                this.OnLowChild(p.LowChild);
                this.Traverse(p.LowChild);
                this.OnEqChild(p.EqChild);
                this.Traverse(p.EqChild);
                this.OnHighChild(p.HighChild);
                this.Traverse(p.HighChild);
            }
        }

    }
}

