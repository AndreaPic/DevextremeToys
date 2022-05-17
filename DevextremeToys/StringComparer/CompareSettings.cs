using System;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DevExtremeToysTests", AllInternalsVisible =true)]

namespace DevExtremeToys.StringComparer
{
    /// <summary>
    /// Configure how the comparison works
    /// </summary>
    internal sealed class CompareSettings
    {
        /// <summary>
        /// Default compare settings
        /// </summary>
        private readonly Settings DefaultSettings = new Settings() {  AccentOption = AccentOptions.Sensitive, CaseOption = CaseOptions.Sensitive };

        /// <summary>
        /// Implement this function to configure settings used comparing strings
        /// </summary>
        public Func<Settings>? GetSetting;

        /// <summary>
        /// Singleton constructor
        /// </summary>
        private CompareSettings() {}

        /// <summary>
        /// Lazy singleton
        /// </summary>
        private static readonly Lazy<CompareSettings>
                lazy = new Lazy<CompareSettings>(() =>                
                new CompareSettings()
                );

        /// <summary>
        /// Current accent options
        /// </summary>
        internal AccentOptions AccentOption
        {
            get
            {
                if (GetSetting != null)
                {
                    return GetSetting().AccentOption;
                }
                else
                {
                    return DefaultSettings.AccentOption;
                }
            }
        }

        /// <summary>
        /// Current case sense option
        /// </summary>
        internal CaseOptions CaseOption
        {
            get
            {
                if (GetSetting != null)
                {                    
                    return GetSetting().CaseOption;
                }
                else
                {
                    return DefaultSettings.CaseOption;
                }
            }
        }

        /// <summary>
        /// Singleton instance
        /// </summary>
        public static CompareSettings Instance { get { return lazy.Value; } }

        /// <summary>
        /// Get the current compare options
        /// </summary>
        /// <returns>current compare options</returns>
        public CompareOptions GetCompareOptions()
        {
            CompareOptions compareOption;
            if ((CaseOption == CaseOptions.Sensitive)
                && (AccentOption == AccentOptions.Sensitive)
                )
            {
                compareOption = CompareOptions.None;
            }
            else if ((CaseOption == CaseOptions.Sensitive)
                && (AccentOption == AccentOptions.Insensitive)
                )
            {
                compareOption = CompareOptions.IgnoreNonSpace;
            }
            else if ((CaseOption == CaseOptions.Insensitive)
                && (AccentOption == AccentOptions.Sensitive)
                )
            {
                compareOption = CompareOptions.IgnoreCase;
            }
            else if ((CaseOption == CaseOptions.Insensitive)
                && (AccentOption == AccentOptions.Insensitive)
                )
            {
                compareOption = CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace;
            }
            else
            {
                compareOption = CompareOptions.None;
            }
            return compareOption;
        }

    }


}
