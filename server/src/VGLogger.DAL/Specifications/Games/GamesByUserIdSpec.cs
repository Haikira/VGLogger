using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Unosquare.EntityFramework.Specification.Common.Primitive;
using VGLogger.DAL.Models;

namespace VGLogger.DAL.Specifications.Games
{
    public class GamesByUserIdSpec : Specification<Game>
    {
        private readonly int _userId;

        public GamesByUserIdSpec(int userId)
        {
            _userId = userId;
        }

        public override Expression<Func<Game, bool>> BuildExpression()
        {
            throw new NotImplementedException();
        }
    }
}
