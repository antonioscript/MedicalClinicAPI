using Marko.Api.Mercury.Application.Exceptions;
using MedicalClinic.Infrastructure.Shared.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MedicalClinic.Application.Extensions
{
    public static class QueryableExtensions
    {
        public static async Task<PaginatedResult<T>> ToPaginatedListAsync<T>(this IQueryable<T> source, int pageNumber, int pageSize) where T : class
        {
            Throw.Exception.IfNull(source, nameof(source));
            pageNumber = pageNumber == 0 ? 1 : pageNumber;
            //pageSize = pageSize == 0 ? 10 : pageSize;
            long count = await source.LongCountAsync();
            pageSize = pageSize < 0 ? ((int)count + 1) : (pageSize == 0 ? 10 : pageSize);
            pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            List<T> items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return PaginatedResult<T>.Success(items, count, pageNumber, pageSize);
        }

        public static IQueryable<T> OrderByDynamic<T>(this IQueryable<T> query, string orderByMember, string direction = "ASC")
        {
            string[] memberTree = orderByMember.Split('.');
            Expression ex = null;
            Type currentType = typeof(T);
            ParameterExpression parameterExpression = Expression.Parameter(currentType);
            for (int i = 0; i < memberTree.Length; i++)
            {
                ex = Expression.Property(ex != null ? ex : parameterExpression, memberTree[i]);
            }
            LambdaExpression lambda = Expression.Lambda(ex, parameterExpression);

            var orderBy = Expression.Call(
                typeof(Queryable),
                direction == "ASC" ? "OrderBy" : "OrderByDescending",
                new Type[] { typeof(T), ex.Type },
                query.Expression,
                Expression.Quote(lambda));

            return query.Provider.CreateQuery<T>(orderBy);
        }

        //[Obsolete]
        //public static IQueryable<T> OrderByDynamic<T>(this IQueryable<T> query, string orderByMember, string direction = "ASC")
        //{
        //    var queryElementTypeParam = Expression.Parameter(typeof(T));
        //    var memberAccess = Expression.PropertyOrField(queryElementTypeParam, orderByMember);
        //    var keySelector = Expression.Lambda(memberAccess, queryElementTypeParam);

        //    var orderBy = Expression.Call(
        //        typeof(Queryable),
        //        direction == "ASC" ? "OrderBy" : "OrderByDescending",
        //        new Type[] { typeof(T), memberAccess.Type },
        //        query.Expression,
        //        Expression.Quote(keySelector));

        //    return query.Provider.CreateQuery<T>(orderBy);
        //}

    }
}