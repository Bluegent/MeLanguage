namespace MeLanguage.Definer
{
    using System;

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
        public Function(string key, Type[] types, bool[] executeInPlace = null) : base(key, types)
        {
            _executeInPlace = executeInPlace;
        }
    }
}
