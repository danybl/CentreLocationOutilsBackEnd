using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CentreLocationOutils.exception.db
{
    public class ConnectionException : Exception
    {
        /// <summary>
        /// Construit une nouvelle exception.
        /// </summary>
        public ConnectionException() : base() { }

        /// <summary>
        /// Construit une nouvelle exception avec le messagage détaillé spécifique.
        /// </summary>
        /// <param name="message">Message détaillé</param>
        public ConnectionException(string message) : base(message) { }

    }
}