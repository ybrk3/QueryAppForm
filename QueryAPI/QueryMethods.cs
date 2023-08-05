using System.Collections.Concurrent;

namespace QueryAPI
{
     internal class QueryMethods
    {
        protected internal ConcurrentDictionary<Guid, IResult> _queryStates;
        public QueryMethods()
        {
            _queryStates = new ConcurrentDictionary<Guid, IResult>();
        }

        protected internal IResult GetProcessState(Guid id)
        {
            bool processStateExists = _queryStates.TryGetValue(id, out IResult processState);
            if (processStateExists)
                return processState;
            else
                return IResult;
        }
        protected internal Guid StartProcess()
        {
            Guid id = Guid.NewGuid();
            Task.Run(() => Query(id));
            _queryStates.TryAdd(id, IResult.Active);
            return id;
        }
        protected internal async Task Query(Guid id)
        {
            try
            {
                Task query = Task.Delay(5000);
                await query;
                _queryStates.TryUpdate(id, ProcessState.Success, ProcessState.Active);
            }
            catch (Exception)
            {
                _queryStates.TryUpdate(id, ProcessState.Failed, ProcessState.Active);
            }
        }





    }
}
