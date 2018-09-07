using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FangZhouShuMa.ApplicationCore.Utilities;
using FangZhouShuMa.Infrastructure.Data;

namespace FangZhouShuMa.Infrastructure.Interfaces.Product
{
    public interface IReport<T, in TFilter>
        where T : class
        where TFilter : class
    {
        IQueryable<T> GenerateQuery(FangZhouShuMaContext context, TFilter filter, Sort<T> sortBy = null);
    }
}
