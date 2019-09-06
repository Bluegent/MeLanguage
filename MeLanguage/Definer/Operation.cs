using System;

using MeLanguage.Types.Exceptions;
using MeLanguage.Types.Var;
using MeLanguage.Definer;

namespace MeLanguage.Definer
{
    using System.Collections.Generic;

    using MeLanguage.Types.Exceptions;
    using MeLanguage.Types.Var;

    public class Operation
    {
        public string Key { get; }
        public Validator Validator { private get; set; }

        private readonly int _hash;
        private Func<MeVariable[], Operation, MeVariable> _operation;

        private readonly bool _hasParamCount;

        public readonly Type[] AcceptedTypes;

        private int CalcHashCode()
        {
            int hash = 17;
            hash = hash * 23 + AcceptedTypes.GetHashCode();
            hash = hash * 23 + _hasParamCount.GetHashCode();
            return hash;
        }

        protected Operation(string key, Func<MeVariable[], Operation, MeVariable> operation, Type[] types, bool paramCount)
        {
            Key = key;
            AcceptedTypes = types;
            _hasParamCount = paramCount;
            _operation = operation;
            _hash = CalcHashCode();
        }

        public bool CanExecute(MeVariable[] parameters)
        {
            return Validator != null && Validator.Validate(parameters, this);
        }
        public MeVariable Execute(MeVariable[] parameters)
        {
            return _operation.Invoke(parameters, this);
        }

        public void CheckParamCount(int parameterCount)
        {
            if (_hasParamCount && parameterCount != AcceptedTypes.Length)
                throw new MeException($"Invalid argument count for operation {Key}, got: {parameterCount} expected:  {AcceptedTypes.Length} .");
        }

        public override int GetHashCode()
        {
            return _hash;
        }
    }
}