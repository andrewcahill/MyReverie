using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Goals.API.Exceptions
{
    public class GoalNotFoundException : Exception
    {
        public GoalNotFoundException(string message) : base(message)
        {

        }
    }
}
