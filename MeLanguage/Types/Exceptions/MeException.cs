using System;
namespace MeLanguage.Types.Exceptions
{
 

    public class MeException : Exception
    {
        public MeException(string msg)
            : base(msg)
        {
        }
    }

}