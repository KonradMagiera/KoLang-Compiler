namespace Compiler
{
    class IfIteratorData
    {
        public IfIteratorData(int i)
        {
            IfIterator = i;
            SubIfIterator = 0;
        }
        
        public int IfIterator { get; set; }
        public int SubIfIterator { get; set; }
    }
}
