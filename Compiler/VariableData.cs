namespace Compiler
{
    public class VariableData
    {
        public int Id { get; set; }
        public string VarType { get; set; }
        
        public VariableData(int id, string varType)
        {
            Id = id;
            VarType = varType;
        }
    }
}
