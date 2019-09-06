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
        public Func<MeVariable[], Operation, MeVariable> OpFunc { private get; set; }

        public bool HasParamCount;

        public readonly Type[] AcceptedTypes;

        protected Operation(string key, Type[] types, bool paramCount = false)
        {
            Key = key;
            AcceptedTypes = types;
            HasParamCount = paramCount;
        }

        public bool CanExecute(MeVariable[] parameters)
        {
            return Validator != null && Validator.Validate(parameters, this);
        }
        public MeVariable Execute(MeVariable[] parameters)
        {
            return OpFunc.Invoke(parameters, this);
        }

        public void CheckParamCount(int parameterCount)
        {
            if (HasParamCount && parameterCount != AcceptedTypes.Length)
                throw new MeException($"Invalid argument count for operation {Key}, got: {parameterCount} expected:  {AcceptedTypes.Length} .");
        }

        public override int GetHashCode()
        {
            return AcceptedTypes.GetHashCode();
        }
    }
}