// <copyright file="RuleFactory.cs" company="N/A"> 
//      Copyright (C) Simon Wendel 2013.
// </copyright> 

namespace GameOfLife.Library.Factories
{
    using GameOfLife.Basics;
    using GameOfLife.Library.Rules;

    /// <summary>
    /// Static factory producing rules for playing the game.
    /// </summary>
    public static class RuleFactory
    {
        /// <summary>
        /// Builds a new rule object.
        /// </summary>
        /// <param name="ruleType">The type of rules to build.</param>
        /// <returns>A newly instantiated rule.</returns>
        public static RulesBase Build(Rule ruleType)
        {
            RulesBase rules = null;
            switch (ruleType)
            {
                case Rule.Sierpinskish:
                    rules = new SierpinskishRules();
                    break;
                default:
                    rules = new StandardRules();
                    break;
            }

            return rules;
        }
    }
}

// eof