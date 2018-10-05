using System;

namespace AzureApplicationInsightsKit.Exceptions
{
    /// <summary>
    /// Client error exception
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class ClientErrorException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientErrorException"/> class.
        /// </summary>
        public ClientErrorException() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientErrorException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ClientErrorException(string message)
            : base(message) { }
    }
}
