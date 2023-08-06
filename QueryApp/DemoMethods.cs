using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryApp
{
    internal static class DemoMethods
    {
        public static ConcurrentDictionary<Guid, ProcessState> _queryStates = new();


        internal static ProcessState GetProcessState(Guid id)
        {
            bool processStateExists = _queryStates.TryGetValue(id, out ProcessState processState);
            if (processStateExists)
                return processState;
            else
                return ProcessState.None;
        }
        internal static Guid StartProcess()
        {
            Guid id = Guid.NewGuid();
            Task.Run(() => Query(id));
            _queryStates.TryAdd(id, ProcessState.Active);
            return id;
        }
        private static async Task Query(Guid id)
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
