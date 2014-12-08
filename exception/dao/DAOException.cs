using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CentreLocationOutils.exception.dao
{
    public class DAOException : Exception
    {
        /**
      * Constructs a new exception with null as its detail message. The cause is not initialized, and may subsequently be initialized by a call
      * to {@link java.lang.Throwable#initCause(java.lang.Throwable) Throwable.initCause(Throwable)}.
      */
        public DAOException() : base() { }
        /**
       * Constructs a new exception with the specified detail message. The cause is not initialized, and may subsequently be initialized by a call
       * to {@link java.lang.Throwable#initCause(java.lang.Throwable) Throwable.initCause(Throwable)}.
       * 
       * @param message The detail message. The detail message is saved for later retrieval by the
       *        {@link java.lang.Throwable#getMessage() Throwable.getMessage()} method
       */
        public DAOException(string message) : base(message) { }


        /**
     * Constructs a new exception with the specified cause and a detail message of (<code>cause == null ? null : cause.toString()</code>) (which
     * typically contains the class and detail message of cause). This  ructor is useful for exceptions that are little more than wrappers
     * for other throwables (for example, {@link java.security.PrivilegedActionException PrivilegedActionException}).
     * 
     * @param cause The cause (which is saved for later retrieval by the {@link java.lang.Throwable#getCause() Throwable.getCause()} method).
     *        A null value is permitted, and indicates that the cause is nonexistent or unknown
     */
        public DAOException(Exception cause) : base(cause.Source) {}

        /**
         * Constructs a new exception with the specified detail message and cause. Note that the detail message associated with cause is not
         * automatically incorporated in this exception's detail message.
         * 
         * @param message The detail message. The detail message is saved for later retrieval by the Throwable.getMessage() method
         * @param cause The cause (which is saved for later retrieval by the {@link java.lang.Throwable#getCause() Throwable.getCause()} method).
         *        A null value is permitted, and indicates that the cause is nonexistent or unknown
         */
        public DAOException(string message,
            Exception cause) : base(message, cause) {}

    }
}

