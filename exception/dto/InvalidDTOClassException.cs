﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CentreLocationOutils.exception.dto
{
    public class InvalidDTOClassException : Exception
    {

        ///<summary>
        /// Constructs a new exception with null as its detail message. The cause is
        /// not initialized, and may subsequently be initialized by a call to
        /// {@link java.lang.Throwable#initCause(java.lang.Throwable)
        /// Throwable.initCause(Throwable)}.
        ///</summary>
        public InvalidDTOClassException() : base() { }

        ///<summary>
        /// Constructs a new exception with the specified detail message. The cause
        /// is not initialized, and may subsequently be initialized by a call to
        /// {@link java.lang.Throwable#initCause(java.lang.Throwable)
        /// Throwable.initCause(Throwable)}. 
        /// @param message
        ///           The detail message. The detail message is saved for later
        ///            retrieval by the {@link java.lang.Throwable#getMessage()
        ///            Throwable.getMessage()} method
        ///</summary>
        public InvalidDTOClassException(string message) : base(message) { }

    }
    
}
