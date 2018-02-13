using System;

namespace KnockKnockReadifyChallenge.Middlewares.Errors
{
    public class WrongInputException : Exception
    {
        public WrongInputException()
        {

        }

        public WrongInputException(string message) : base(message)
        {

        }
    }
}
