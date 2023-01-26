using System.Linq.Expressions;
using Unosquare.EntityFramework.Specification.Common.Primitive;
using VGLogger.DAL.Models;

namespace VGLogger.DAL.Specifications.Games
{
    public class GameByIdSpec : Specification<Game>
    {
        private readonly int _id;

        public GameByIdSpec(int id)
        {
            _id = id;
        }

        public override Expression<Func<Game, bool>> BuildExpression()
        {
            return x => x.Id == _id;
        }
    }
}
