﻿using System;

namespace Calabonga.Microservices.Core.Exceptions
{
    /// <summary>
    /// Represent Price Point Exception
    /// </summary>
    public class MicroserviceException : Exception
    {
        public MicroserviceException() : base(AppContracts.Exceptions.ThrownException)
        {

        }

        public MicroserviceException(string message) : base(message)
        {

        }

        public MicroserviceException(string message, Exception exception) : base(message, exception)
        {

        }
    }
}
