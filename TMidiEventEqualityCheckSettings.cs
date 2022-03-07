using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiGalon
{
    public sealed class MidiEventEqualityCheckSettings
    {
        #region Fields

        private StringComparison _textComparison = StringComparison.CurrentCulture;

        #endregion

        #region Properties
 
        public bool CompareDeltaTimes { get; set; } = true;
         
        public StringComparison TextComparison
        {
            get { return _textComparison; }
            set
            {
                //ThrowIfArgument.IsInvalidEnumValue(nameof(value), value);

                _textComparison = value;
            }
        }

        #endregion
    }
}
