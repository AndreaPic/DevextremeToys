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
}
