using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FangZhouShuMa.ApplicationCore.Models
{
    public class SortModel<T> where T : class
    {
        public Expression<Func<T, object>> SortExpression { get; set; }
        public bool Ascending { get; set; }

        public SortModel(Expression<Func<T, object>> sortExpression, bool ascending = true)
        {
            SortExpression = sortExpression;
            Ascending = ascending;
        }
    }
}
