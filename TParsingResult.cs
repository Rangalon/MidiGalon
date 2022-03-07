using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiGalon
{
    internal sealed class TParsingResult
    {
        #region Constants

        public static readonly TParsingResult Parsed = new TParsingResult(ParsingStatus.Parsed);
        public static readonly TParsingResult EmptyInputString = new TParsingResult(ParsingStatus.EmptyInputString);
        public static readonly TParsingResult NotMatched = new TParsingResult(ParsingStatus.NotMatched);

        #endregion

        #region Fields

        private readonly string _error;

        #endregion

        #region Constructor

        private TParsingResult(string error)
            : this(ParsingStatus.FormatError, error)
        {
        }

        private TParsingResult(ParsingStatus status)
            : this(status, null)
        {
        }

        private TParsingResult(ParsingStatus status, string error)
        {
            Status = status;
            _error = error;
        }

        #endregion

        #region Properties

        public ParsingStatus Status { get; }

        public Exception Exception
        {
            get
            {
                switch (Status)
                {
                    case ParsingStatus.EmptyInputString:
                        return new ArgumentException("Input string is null or contains white-spaces only.");
                    case ParsingStatus.NotMatched:
                        return new FormatException("Input string has invalid format.");
                    case ParsingStatus.FormatError:
                        return new FormatException(_error);
                }

                return null;
            }
        }

        #endregion

        #region Methods

        public static TParsingResult Error(string error)
        {
            return new TParsingResult(error);
        }

        #endregion
    }
}
