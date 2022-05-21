using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExtremeToys.StringComparer
{
    /// <summary>
    /// Setting options to compare strings 
    /// </summary>
#if NETCOREAPP3_1
    public class Settings
    {
        /// <summary>
        /// Accent options
        /// </summary>
        public AccentOptions AccentOption { get; set; }
        /// <summary>
        /// Case sense options
        /// </summary>
        public CaseOptions CaseOption { get; set; }
    }
#else
    public record Settings
    {
        /// <summary>
        /// Accent options
        /// </summary>
        public AccentOptions AccentOption { get; init; }
        /// <summary>
        /// Case sense options
        /// </summary>
        public CaseOptions CaseOption { get; init; }
    }
#endif
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
