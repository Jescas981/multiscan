namespace Multiscan.Persistance.Procedures
{
    public interface IProcedure : IProcedureReader, IProcedureWriter { }

    public interface IProcedureReader
    {
        public string filepath { get; set; }
        TModel encode<TModel>();
    }

    public interface IProcedureWriter
    {
        public string filepath { get; set; }
        void decode<TModel>(TModel model);
    }
}
