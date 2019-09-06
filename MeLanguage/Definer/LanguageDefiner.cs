namespace MeLanguage.Definer
{
    using System;
    using System.Collections.Generic;

    using MeLanguage.Types.Exceptions;
    using MeLanguage.Types.Var;

    public class LanguageDefiner
    {
        private readonly Dictionary<string, Dictionary<int, Function>> _functions ;
        private readonly Dictionary<string, Dictionary<int, Operator>> _operators;

        public LanguageDefiner()
        {
            _functions = new Dictionary<string, Dictionary<int, Function>>();
            _operators = new Dictionary<string, Dictionary<int, Operator>>();
        }


        public static int GetParamHashCode(MeVariable[] parameters)
        {
            Type[] paramTypes = new Type[parameters.Length];
            for (int index = 0; index < parameters.Length; ++index)
            {
                paramTypes[index] = parameters[index].GetType();
            }
            return paramTypes.GetHashCode();
        }
        public void AddFunction(Function func)
        {
            int hash = func.GetHashCode();
            string key = func.Key;
            Dictionary<int, Function> subFunctions = _functions.ContainsKey(key) ? _functions[key] : new Dictionary<int, Function>();
            if (subFunctions.ContainsKey(hash))
            {
                throw new Exception($"Duplicate function {key} with params {func.AcceptedTypes}");
            }

            subFunctions.Add(hash, func);
            if (!_functions.ContainsKey(key))
                _functions.Add(key, subFunctions);
        }

        public Function GetFunction(string key, MeVariable[] parameters)
        {
            Dictionary<int, Function> subFunctions = _functions.ContainsKey(key) ? _functions[key] : null;
            if (subFunctions == null)
            {
                return null;
            }

            int hash = GetParamHashCode(parameters);

            return subFunctions.ContainsKey(hash) ? subFunctions[hash] : null;

        }


        public void AddOperator(Operator op)
        {
            int hash = op.GetHashCode();
            string key = op.Key;
            Dictionary<int, Operator> subOperators = _operators.ContainsKey(key) ? _operators[key] : new Dictionary<int, Operator>();
            if (subOperators.ContainsKey(hash))
            {
                throw new Exception($"Duplicate operator {key} with params {op.AcceptedTypes}");
            }

            subOperators.Add(hash, op);
            if(!_operators.ContainsKey(key))
                _operators.Add(key,subOperators);
        }

        public Operator GetOperator(string key, MeVariable[] parameters)
        {
            Dictionary<int, Operator> subOperators = _operators.ContainsKey(key) ? _operators[key] : null;
            if (subOperators == null)
            {
                return null;
            }
            int hash = GetParamHashCode(parameters);
            return subOperators.ContainsKey(hash) ? subOperators[hash] : null;
        }
    }
}