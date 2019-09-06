namespace MeLanguage.Definer
{
    using System;

    using MeLanguage.Types.Var;

    public class Function : Operation
    {
        private readonly bool[] _executeInPlace;

        public bool ExecuteSubNode(int index)
        {
            if (_executeInPlace == null)
            {
                return true;
            }
            return _executeInPlace[index];

        }
        public Function(string key, Func<MeVariable[], Operation, MeVariable> operation, Type[] types, bool hasParamCount = true,  bool[] executeInPlace = null) : base(key, operation, types,hasParamCount)
        {
            _executeInPlace = executeInPlace;
        }
    }
}
