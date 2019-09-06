
namespace MeLanguage.Definer
{
    using System;

    public class Operator : Operation
    {
        public int Precedence { get; }

        public bool LeftAsoc { get; }


        public bool Precedes(Operator other)
        {
            return Precedence > other.Precedence;
        }

        public bool IsUnary()
        {
            return AcceptedTypes.Length == 1;
        }
        public Operator(string key, int precedence, bool leftAsoc, Type[] types) : base(key,types)
        {
            Precedence = precedence;
            LeftAsoc = leftAsoc;
        }
    }
}
