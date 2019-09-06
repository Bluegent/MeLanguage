using System;
using System.Collections.Generic;

using Language.Types.Exceptions;
namespace Language.Types.Var
{
    using System.Text;

    public class MeStruct : MeVariable
    {
        private Dictionary<string,MeVariable> Members { get; }

        public MeStruct(string obj)
            : base(obj)
        {
            Members = new Dictionary<string, MeVariable>();
        }

        public string GetName()
        {
            return (string)_value;
        }
        public void Add(string key, MeVariable variable)
        {
            if (Members.ContainsKey(key))
            {
                throw new MeException($"Struct {(string)_value} already contains a variable named {key}.");
            }
            Members.Add(key,variable);
        }

        public MeVariable GetVariable(string key)
        {
            return Members.ContainsKey(key) ? Members[key] : null;
        }

        public override T Get<T>()
        {
            Type tType = typeof(T);
            if (tType == typeof(string))
                return (T)_value;
            if (tType == typeof(MeStruct))
                return (T)Convert.ChangeType(this,typeof(T));

            throw Except(typeof(T));
        }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder("$OBJ:");
            b.Append((string)_value);
            if (Members.Values.Count != 0)
            {
                b.Append("{");
                foreach (var pair in Members)
                {
                    b.Append($"{pair.Key} = {pair.Value}, ");
                }

                b.Remove(b.Length - 2, 2);
                b.Append("}");
            }
            return b.ToString();
        }
    }
}