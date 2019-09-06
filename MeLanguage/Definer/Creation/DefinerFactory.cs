using System.Collections.Generic;
using MeLanguage.Definer.Functions.Mathematical;
using MeLanguage.Definer.Operators.Mathematical;

namespace MeLanguage.Definer.Creation
{
    public interface IDefinerFactory
    {
        LanguageDefiner BuildDefiner();
        void AddToDefiner(LanguageDefiner definer);
    }

    public abstract class DefinerFactoryHelper : IDefinerFactory
    {
        public LanguageDefiner BuildDefiner()
        {
            LanguageDefiner definer = new LanguageDefiner();
            AddToDefiner(definer);
            return definer;
        }

        public abstract void AddToDefiner(LanguageDefiner definer);
    }

    public class BaseDefinerFactory : DefinerFactoryHelper
    {

        public override void AddToDefiner(LanguageDefiner definer)
        {
            IOperatorDefiner[] operators =
            {
                //math   
                new MinusOperator(),
                new PlusOperator(),
                new DivideOperator(),
                new MultiplyOperator(),
                new PowerOperator(), 
                //comparison
                new EqualsOperator(), 
                new GreaterOperator(), 
                new LesserOperator(),
                //bolean
                new NotOperator()

                //???
                //new AssignOperator(), 
            };

            foreach (IOperatorDefiner def in operators)
            {
                def.AddOperator(definer);
            }


            IFunctionDefiner[] functions =
            {
                //math
                new MaxFunction(),
                new NonNegFunction(),
                new MinFunction(), 
                new Absfunction()
            };

            foreach (IFunctionDefiner func in functions)
            {
                func.AddFunction(definer);
            }
        }
    }
}