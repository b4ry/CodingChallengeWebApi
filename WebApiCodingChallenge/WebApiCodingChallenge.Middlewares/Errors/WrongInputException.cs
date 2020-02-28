using System;

namespace WebApiCodingChallenge.Middlewares.Errors
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
