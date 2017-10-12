using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FrameworkCommon
{
    public class ClassFactory
    {
        private static readonly ReaderWriterLockSlim _Lock = new ReaderWriterLockSlim();

        private static readonly Dictionary<Type, object> _InstantiatedClasses = new Dictionary<Type, object>();

        public static T GetOrCreate<T>()
            where T : class
        {
            T result;

            Type key = typeof(T);
            object instantiatedClass;
            bool isClassNew;

            _Lock.EnterReadLock();
            try
            {
                isClassNew = !_InstantiatedClasses.TryGetValue(key, out instantiatedClass);
            }
            finally
            {
                _Lock.ExitReadLock();
            }

            if (isClassNew)
            {
                _Lock.EnterWriteLock();
                try
                {
                    if (!_InstantiatedClasses.TryGetValue(key, out instantiatedClass))
                    {
                        result = Activator.CreateInstance<T>();
                        _InstantiatedClasses.Add(key, result);
                    }
                    else
                    {
                        result = (T)instantiatedClass;
                    }
                }
                finally
                {
                    _Lock.ExitWriteLock();
                }
            }
            else
            {
                result = (T)instantiatedClass;
            }

            return result;
        }
    }
}
