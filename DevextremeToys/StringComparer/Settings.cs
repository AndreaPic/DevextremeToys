using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExtremeToys.StringComparer
{
    public record Settings
    {
        public AccentOptions AccentOption { get; init; }
        public CaseOptions CaseOption { get; init; }
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
