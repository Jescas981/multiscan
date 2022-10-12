namespace Multiscan.Persistance
{
    public class PersistanceManager<TProcedure, TModel>
        where TProcedure : Procedures.IProcedure, new()
        where TModel : class
    {
        private TProcedure _procedure;

        public PersistanceManager(string filepath)
        {
            _procedure = new TProcedure();
        }

        public TModel read()
        {
            return _procedure.encode<TModel>();
        }

        public void write(TModel model)
        {
            _procedure.decode<TModel>(model);
        }
    }
}
