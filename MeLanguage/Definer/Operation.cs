using System;

using MeLanguage.Types.Exceptions;
using MeLanguage.Types.Var;
using MeLanguage.Definer;

namespace MeLanguage.Definer
{
    using MeLanguage.Types.Exceptions;
    using MeLanguage.Types.Var;

    public class Operation
    {
        public string Key { get; }
        public Validator Validator { private get; set; }
        public Func<MeVariable[], Operation, MeVariable> OpFunc { private get; set; }
        public int ParameterCount { get; protected set; }

        protected Operation(string key, int parameterCount = -1)
        {
            Key = key;
            ParameterCount = parameterCount;
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
            if (ParameterCount != -1 && parameterCount != ParameterCount)
                throw new MeException($"Invalid argument count for operation {Key}, got: {parameterCount} expected:  {ParameterCount} .");
        }
    }
}