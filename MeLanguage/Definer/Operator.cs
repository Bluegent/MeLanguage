
namespace MeLanguage.Definer
{
    using System;

    using MeLanguage.Types.Var;

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
        public Operator(string key, int precedence,  bool leftAsoc, Func<MeVariable[], Operation, MeVariable> operation, Type[] types) : base(key,operation, types,true)
        {
            Precedence = precedence;
            LeftAsoc = leftAsoc;
        }
    }
}
