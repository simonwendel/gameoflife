// <copyright file="LifeFormFactory.cs" company="N/A"> 
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright> 

namespace GameOfLife.Library.Factories
{
    using GameOfLife.Basics;
    using GameOfLife.Library.LifeForms;

    /// <summary>
    /// The static factory producing life forms for initial patterns.
    /// </summary>
    public static class LifeFormFactory
    {
        /// <summary>The constant width of new random pattern objects.</summary>
        private const int RANDOMPATTERNWIDTH = 15;

        /// <summary>The constant height of new random pattern objects.</summary>
        private const int RANDOMPATTERNHEIGHT = 15;

        /// <summary>
        /// Builds a new life form.
        /// </summary>
        /// <param name="lifeFormType">The life form type to build.</param>
        /// <returns>A newly instantiated life form object.</returns>
        public static LifeFormBase Build(LifeForm lifeFormType)
        {
            LifeFormBase lifeForm = null;
            switch (lifeFormType)
            {
                case LifeForm.Empty:
                    lifeForm = new Empty();
                    break;
                case LifeForm.Acorn:
                    lifeForm = new Acorn();
                    break;
                case LifeForm.AircraftCarrier:
                    lifeForm = new AircraftCarrier();
                    break;
                case LifeForm.FivePoint:
                    lifeForm = new FivePoint();
                    break;
                default:
                    lifeForm = new RandomPattern(
                        rows: RANDOMPATTERNHEIGHT,
                        cols: RANDOMPATTERNWIDTH);
                    break;
            }

            return lifeForm;
        }
    }
}

// eof