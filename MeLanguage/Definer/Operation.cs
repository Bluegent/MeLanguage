using System;

using MeLanguage.Types.Exceptions;
using MeLanguage.Types.Var;
using MeLanguage.Definer;

namespace MeLanguage.Definer
{
    using System.Security.Policy;

    using MeLanguage.Types.Exceptions;
    using MeLanguage.Types.Var;
    using MeLanguage.Utility;

    public class Operation
    {
        public string Key { get; }
        public Validator Validator { private get; set; }

        private readonly int _hash;
        private Func<MeVariable[], Operation, MeVariable> _operation;

        private readonly bool _hasParamCount;

        public readonly Type[] AcceptedTypes;


        public static int GetDynamicParameterAmountHashCode(Type varType)
        {
            int arrayHash = varType.GetHashCode();
            int hash = GlobalConstants.HASH_BASE;
            hash = GlobalConstants.HASH_MULTIPLIER * hash + arrayHash;
            hash = GlobalConstants.HASH_MULTIPLIER * hash + false.GetHashCode();
            return hash;
        }

        private int CalcHashCode()
        {
            return _hasParamCount ? MeArray.GetHashCode(AcceptedTypes) : GetDynamicParameterAmountHashCode(AcceptedTypes[0]);
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