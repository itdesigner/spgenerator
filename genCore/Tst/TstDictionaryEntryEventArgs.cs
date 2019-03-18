namespace DS.Tst
{
    using System;

    public class TstDictionaryEntryEventArgs : EventArgs
    {
        public TstDictionaryEntryEventArgs(TstDictionaryEntry entry)
        {
            this.entry = entry;
        }


        public TstDictionaryEntry Entry
        {
            get
            {
                return this.entry;
            }
        }


        private TstDictionaryEntry entry;
    }
}

