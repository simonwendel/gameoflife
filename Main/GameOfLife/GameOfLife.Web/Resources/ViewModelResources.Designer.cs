﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GameOfLife.Web.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ViewModelResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ViewModelResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("GameOfLife.Web.Resources.ViewModelResources", typeof(ViewModelResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The life form to evolve..
        /// </summary>
        public static string GameSettingsModel_LifeForm_Description {
            get {
                return ResourceManager.GetString("GameSettingsModel_LifeForm_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You must select a life form to evolve..
        /// </summary>
        public static string GameSettingsModel_LifeForm_Missing {
            get {
                return ResourceManager.GetString("GameSettingsModel_LifeForm_Missing", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Life form.
        /// </summary>
        public static string GameSettingsModel_LifeForm_Name {
            get {
                return ResourceManager.GetString("GameSettingsModel_LifeForm_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The number of generations to progress the game once it has started..
        /// </summary>
        public static string GameSettingsModel_NumberOfGenerations_Description {
            get {
                return ResourceManager.GetString("GameSettingsModel_NumberOfGenerations_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You must enter the number of generations to progress the game..
        /// </summary>
        public static string GameSettingsModel_NumberOfGenerations_Missing {
            get {
                return ResourceManager.GetString("GameSettingsModel_NumberOfGenerations_Missing", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Number of generations.
        /// </summary>
        public static string GameSettingsModel_NumberOfGenerations_Name {
            get {
                return ResourceManager.GetString("GameSettingsModel_NumberOfGenerations_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The rules that governs the game while running..
        /// </summary>
        public static string GameSettingsModel_Rules_Description {
            get {
                return ResourceManager.GetString("GameSettingsModel_Rules_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You must select the governing rule or the game cannot progress..
        /// </summary>
        public static string GameSettingsModel_Rules_Missing {
            get {
                return ResourceManager.GetString("GameSettingsModel_Rules_Missing", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Game rules.
        /// </summary>
        public static string GameSettingsModel_Rules_Name {
            get {
                return ResourceManager.GetString("GameSettingsModel_Rules_Name", resourceCulture);
            }
        }
    }
}
