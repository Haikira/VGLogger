using System.Linq.Expressions;
using Unosquare.EntityFramework.Specification.Common.Primitive;
using VGLogger.DAL.Models;

namespace VGLogger.DAL.Specifications.Developers
{
    public class DeveloperByIdSpec : Specification<Developer>
    {
        private readonly int _id;

        public DeveloperByIdSpec(int id)
        {
            _id = id;
        }

        public override Expression<Func<Developer, bool>> BuildExpression()
        {
            return x => x.Id == _id;
        }
    }
}
