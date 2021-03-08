using Marten;

namespace ProductService
{
    public class CustomSessionFactory : ISessionFactory
    {
        private readonly IDocumentStore _store;

        public CustomSessionFactory(IDocumentStore store)
        {
            _store = store;
        }

        public IDocumentSession OpenSession()
        => _store.LightweightSession(System.Data.IsolationLevel.Serializable);

        public IQuerySession QuerySession()
        => _store.QuerySession();
    }
}
