namespace MeLanguage.Types.Exceptions
{
    public class MeContextException : MeException
    {
        public MeContextException(string msg, string ctx)
            : base($"{msg}\n occured in {ctx}")
        {

        }
    }
}