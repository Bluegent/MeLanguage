using System;
using System.Collections.Generic;

using MeLanguage.Types.Exceptions;
namespace MeLanguage.Types.Var
{
    using System.Text;

    using MeLanguage.Types.Exceptions;

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
            if (tType == typeof(MeStruct))
                return (T)Convert.ChangeType(this,typeof(T));

            throw CastExcept(typeof(T));
        }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder(MeMarkers.STRUCT_MARKER);
            b.Append((string)_value);
            b.Append("{");
            if (Members.Values.Count != 0)
            {
                
                foreach (var pair in Members)
                {
                    b.Append($"{pair.Key} = {pair.Value}, ");
                }

                b.Remove(b.Length - 2, 2);
               
            }
            b.Append("}");
            return b.ToString();
        }
    }
}