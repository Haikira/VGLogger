using System.Linq.Expressions;
using Unosquare.EntityFramework.Specification.Common.Primitive;
using VGLogger.DAL.Models;

namespace VGLogger.DAL.Specifications.Reviews
{
    public class ReviewByIdSpec : Specification<Review>
    {
        private readonly int _id;

        public ReviewByIdSpec(int id)
        {
            _id = id;
        }

        public override Expression<Func<Review, bool>> BuildExpression()
        {
            return x => x.Id == _id;
        }
    }
}
