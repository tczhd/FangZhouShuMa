using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FangZhouShuMa.ApplicationCore.Interfaces.Sort;
using FangZhouShuMa.ApplicationCore.Models;
using FangZhouShuMa.ApplicationCore.Extensions;

namespace FangZhouShuMa.ApplicationCore.Utilities
{
    public class Sort<T> : ISortable<T> where T : class
    {
        public List<SortModel<T>> SortModels { get; }

        public Sort(params Expression<Func<T, object>>[] sortModels)
        {
            SortModels = new List<SortModel<T>>();

            foreach (var sortModel in sortModels)
            {
                Add(sortModel);
            }
        }

        public Sort<T> Add(Expression<Func<T, object>> expression, bool ascending = true)
        {
            SortModels.Add(new SortModel<T>(expression, ascending));
            return this;
        }

        public IQueryable<T> AsQueryable(IQueryable<T> query)
        {
            foreach (var sortModel in SortModels)
            {
                query = query.OrderBy(sortModel.SortExpression, sortModel.Ascending);
            }

            return query;
        }
    }
}
