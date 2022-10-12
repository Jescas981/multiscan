namespace Multiscan.Persistance
{
    public class PersistanceReader<TProcedureReader, TModel>
        where TProcedureReader : Procedures.IProcedureReader, new()
        where TModel : class
    {
        private TProcedureReader _procedure;

        public PersistanceReader(string filepath)
        {
            _procedure = new TProcedureReader();
        }

        public TModel read()
        {
            return _procedure.encode<TModel>();
        }

    }
}
