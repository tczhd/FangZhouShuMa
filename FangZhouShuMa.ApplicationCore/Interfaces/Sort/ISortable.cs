using System;
using System.Collections.Generic;
using System.Text;
using FangZhouShuMa.ApplicationCore.Models;

namespace FangZhouShuMa.ApplicationCore.Interfaces.Sort
{
    public interface ISortable<T> where T : class
    {
        List<SortModel<T>> SortModels { get; }
    }
}
