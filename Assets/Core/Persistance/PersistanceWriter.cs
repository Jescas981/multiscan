namespace Multiscan.Persistance
{
    public class PersistanceWriter<TProcedure, TModel>
        where TProcedure : Procedures.IProcedureWriter, new()
        where TModel : class
    {
        private TProcedure _procedure;
        private string _filepath;

        public PersistanceWriter(string filepath)
        {
            _procedure = new TProcedure();
            _filepath = filepath;
        }

        public void write(TModel model)
        {
            _procedure.decode<TModel>(model);
        }
    }
}
