using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Storage.Criterias.Interfacies
{
    public interface ICriteria<T>
    {
        bool MeetCriteria(T entity);
    }
}