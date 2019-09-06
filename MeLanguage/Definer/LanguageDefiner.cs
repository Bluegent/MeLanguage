using System.Linq;

namespace MeLanguage.Definer
{
    using System;
    using System.Collections.Generic;

    using MeLanguage.Types.Exceptions;
    using MeLanguage.Types.Var;

    public class LanguageDefiner
    {
        private readonly Dictionary<string, Dictionary<int, Function>> _functions;
        private readonly Dictionary<string, Dictionary<int, Operator>> _operators;
        private readonly List<char> _operatorChars;



        public bool IsFunction(string tokenString)
        {
            return _functions.ContainsKey(tokenString);
        }

        public bool IsOperator(string tokenString)
        {
            return _operators.ContainsKey(tokenString);
        }

        public bool IsOperatorCharacter(char c)
        {
            return _operatorChars.Contains(c);
        }

        public bool IsRightParen(string tokenString)
        {
            if (tokenString.Length != 1)
                return false;
            if (tokenString[0] == LConstants.RIGHT_PAREN)
                return true;
            return false;
        }

        public bool IsLeftParen(string tokenString)
        {
            if (tokenString.Length != 1)
                return false;
            if (tokenString[0] == LConstants.LEFT_PAREN)
                return true;
            return false;
        }

        public bool IsIgnored(char c)
        {
            return LConstants.IgnoreChars.Contains(c);
        }

        public bool IsSpecialChar(char c)
        {
            return c == LConstants.PARAM_SEPARATOR 
                || c == LConstants.LEFT_PAREN 
                || c == LConstants.RIGHT_PAREN 
                || IsOperatorCharacter(c);
        }

        public bool IsSeparator(string tokenString)
        {
            if (tokenString.Length != 1)
                return false;
            if (tokenString[0] == LConstants.PARAM_SEPARATOR)
                return true;
            return false;
        }

        public LanguageDefiner()
        {
            _functions = new Dictionary<string, Dictionary<int, Function>>();
            _operators = new Dictionary<string, Dictionary<int, Operator>>();
            _operatorChars = new List<char>();
        }


        public static int GetParamHashCode(MeVariable[] parameters, bool paramCount = true)
        {
            if (paramCount)
                return MeArray.GetTypeHashCode(parameters);

            return Operation.GetDynamicParameterAmountHashCode(parameters[0].GetType());

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

            //first try with dynamic parameter count
            int hash = GetParamHashCode(parameters, false);

            Function func = subFunctions.ContainsKey(hash) ? subFunctions[hash] : null;

            if (func != null)
            {
                return func;
            }
            //then try with static param number
            hash = GetParamHashCode(parameters);
            func = subFunctions.ContainsKey(hash) ? subFunctions[hash] : null;

            return func;

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
            if (!_operators.ContainsKey(key))
                _operators.Add(key, subOperators);

            foreach (char c in op.Key)
            {
                if (!_operatorChars.Contains(c))
                    _operatorChars.Add(c);
            }
        }

        public Operator GetOperator(string key, MeVariable[] parameters)
        {
            Dictionary<int, Operator> subOperators = _operators.ContainsKey(key) ? _operators[key] : null;
            if (subOperators == null)
            {
                return null;
            }

            //first try with dynamic parameter count
            int hash = GetParamHashCode(parameters, false);

            Operator op = subOperators.ContainsKey(hash) ? subOperators[hash] : null;

            if (op != null)
            {
                return op;
            }
            //then try with static param number
            hash = GetParamHashCode(parameters);
            op = subOperators.ContainsKey(hash) ? subOperators[hash] : null;

            return op;
        }
    }
}