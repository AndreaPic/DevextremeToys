using Microsoft.Extensions.Configuration;
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

        public Func<Settings>? GetDefaultSetting;

        /// <summary>
        /// File with configuration
        /// </summary>
        private const string appSettingsFileName = "appsettings.json";
        /// <summary>
        /// Current configuration
        /// </summary>
        private IConfiguration configuration;

        /// <summary>
        /// Singleton constructor
        /// </summary>
        private CompareSettings() {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(appSettingsFileName, optional: true, reloadOnChange: true);

                configuration = builder.Build();
        }

        /// <summary>
        /// Lazy singleton
        /// </summary>
        private static readonly Lazy<CompareSettings>
                lazy = new Lazy<CompareSettings>(() =>                
                new CompareSettings()
                );
        /// <summary>
        /// True only if the settings file was already readed
        /// </summary>
        private bool accentReaded = false;
        /// <summary>
        /// Current Accent compare option
        /// </summary>
        private AccentOptions accentOption;
        /// <summary>
        /// Current Accent compare option
        /// </summary>
        internal AccentOptions AccentOption
        {
            get
            {
                if (GetDefaultSetting != null)
                {
                    var settings = GetDefaultSetting();
                    accentOption = settings.AccentOption;
                }
                else
                {
                    if (!accentReaded)
                    {
                        accentOption = configuration.GetValue<AccentOptions>(nameof(AccentOption), AccentOptions.Sensitive);
                        accentReaded = true;
                    }
                }
                return accentOption;
            }
            set
            {
                if (GetDefaultSetting == null)
                {
                    accentReaded = true;
                }
                accentOption = value;
                compareOption = null;
            }
        }

        /// <summary>
        /// True only if the settings file was already readed
        /// </summary>
        private bool caseOptionReaded = false;
        /// <summary>
        /// Current case sense option
        /// </summary>
        private CaseOptions caseOption;
        /// <summary>
        /// Current case sense option
        /// </summary>
        internal CaseOptions CaseOption
        {
            get
            {
                if (GetDefaultSetting != null)
                {
                    var settings = GetDefaultSetting();
                    caseOption = settings.CaseOption;
                }
                else
                {
                    if (!caseOptionReaded)
                    {
                        caseOption = configuration.GetValue<CaseOptions>(nameof(CaseOption), CaseOptions.Insensitive);
                        caseOptionReaded = true;
                    }
                }
                return caseOption;
            }
            set
            {
                if (GetDefaultSetting==null)
                {
                    caseOptionReaded = true;
                }
                caseOption = value;
                compareOption = null;
            }
        }

        /// <summary>
        /// Singleton instance
        /// </summary>
        public static CompareSettings Instance { get { return lazy.Value; } }

        /// <summary>
        /// Current Globalizion options
        /// </summary>
        private Nullable<CompareOptions> compareOption;

        /// <summary>
        /// Get the Current Globalization options
        /// </summary>
        /// <returns></returns>
        public CompareOptions GetCompareOptions()
        {
            if (!compareOption.HasValue)
            {
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
            }
            return compareOption.Value;
        }

    }

    /// <summary>
    /// Configure how accents works during comparison
    /// </summary>
    public enum AccentOptions
    {
        /// <summary>
        /// Accented letter and unaccented are the same
        /// </summary>
        Sensitive = 0,
        /// <summary>
        /// Accented letter and unaccented are NOT the same
        /// </summary>
        Insensitive = 1 
    }

    /// <summary>
    /// Configure how upper and lower case works during comparison
    /// </summary>
    public enum CaseOptions
    {
        /// <summary>
        /// Upper letter and lower lettere are the same
        /// </summary>
        Insensitive = 0,
        /// <summary>
        /// Upper letter and lower lettere are NOT the same
        /// </summary>
        Sensitive = 1
    }

}
