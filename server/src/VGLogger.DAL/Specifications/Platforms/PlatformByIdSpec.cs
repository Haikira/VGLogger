using System.Linq.Expressions;
using Unosquare.EntityFramework.Specification.Common.Primitive;
using VGLogger.DAL.Models;

namespace VGLogger.DAL.Specifications.Platforms
{
    public class PlatformByIdSpec : Specification<Platform>
    {
        private readonly int _id;

        public PlatformByIdSpec(int id)
        {
            _id = id;
        }

        public override Expression<Func<Platform, bool>> BuildExpression()
        {
            return x => x.Id == _id;
        }
    }
}
