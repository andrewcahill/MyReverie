using System;

namespace Goals.API.Exceptions
{
    public class GoalNotFoundException : Exception
    {
        public GoalNotFoundException(string message) : base(message)
        {

        }
    }
}
