﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace tyr.Core.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("tyr.Core.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to dateTime parameter {0} should be before {1}, but was {2}.
        /// </summary>
        public static string DateTimeParameterShouldBeSmallerThen {
            get {
                return ResourceManager.GetString("DateTimeParameterShouldBeSmallerThen", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Duration parameter {0} should be a positive duration. Duration: {1}.
        /// </summary>
        public static string DurationParameterShouldBePositive {
            get {
                return ResourceManager.GetString("DurationParameterShouldBePositive", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to parameter {0} should be between {1} and {2}, but was {3}.
        /// </summary>
        public static string ParameterShouldBeBetween {
            get {
                return ResourceManager.GetString("ParameterShouldBeBetween", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to parameter {0} should be greater or equal then {1}, but was {2}.
        /// </summary>
        public static string ParameterShouldBeGreaterOrEqualThen {
            get {
                return ResourceManager.GetString("ParameterShouldBeGreaterOrEqualThen", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to parameter {0} should be greater then {1}, but was {2}.
        /// </summary>
        public static string ParameterShouldBeGreaterThen {
            get {
                return ResourceManager.GetString("ParameterShouldBeGreaterThen", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to parameter {0} should be smaller or equal then {1}, but was {2}.
        /// </summary>
        public static string ParameterShouldBeSmallerOrEqualThen {
            get {
                return ResourceManager.GetString("ParameterShouldBeSmallerOrEqualThen", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to parameter {0} should be smaller then {1}, but was {2}.
        /// </summary>
        public static string ParameterShouldBeSmallerThen {
            get {
                return ResourceManager.GetString("ParameterShouldBeSmallerThen", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to value type parameter {0} should have a value other then default.
        /// </summary>
        public static string ParameterShouldNotBeDefault {
            get {
                return ResourceManager.GetString("ParameterShouldNotBeDefault", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to parameter {0} should not be null or empty.
        /// </summary>
        public static string ParameterShouldNotBeNullOrEmpty {
            get {
                return ResourceManager.GetString("ParameterShouldNotBeNullOrEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Sequence parameter {0} should not contain null elements.
        /// </summary>
        public static string ParameterShouldNotContainNullElements {
            get {
                return ResourceManager.GetString("ParameterShouldNotContainNullElements", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ticks should not contain Milliseconds. Ticks: {0}.
        /// </summary>
        public static string TicksShouldNotContainMilliseconds {
            get {
                return ResourceManager.GetString("TicksShouldNotContainMilliseconds", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ticks should not contain Time component. Ticks: {0}.
        /// </summary>
        public static string TicksShouldNotContainTime {
            get {
                return ResourceManager.GetString("TicksShouldNotContainTime", resourceCulture);
            }
        }
    }
}
