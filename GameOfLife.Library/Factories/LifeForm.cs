// <copyright file="LifeForm.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2016.
// </copyright>

namespace GameOfLife.Library.Factories
{
    /// <summary>
    /// Enumeration of all life forms.
    /// </summary>
    public enum LifeForm
    {
        /// <summary>Empty universe.</summary>
        Empty,

        /// <summary>The acorn standard pattern.</summary>
        Acorn,

        /// <summary>The aircraft carrier standard pattern.</summary>
        AircraftCarrier,

        /// <summary>The five point pattern.</summary>
        FivePoint,

        /// <summary>A random pattern.</summary>
        RandomPattern
    }
}
