using System;
namespace Language.Types.Exceptions
{
 

    public class MeException : Exception
    {
        public MeException(string msg)
            : base(msg)
        {
        }
    }

}