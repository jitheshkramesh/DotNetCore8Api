﻿namespace DotNetCore8Api.Exceptions
{
    public abstract class DomainException:System.Exception
    {
        public DomainException(string message):base(message)
        {
            
        }
    }

    public class DomainNotFoundException : DomainException
    {
        public DomainNotFoundException(string message) : base(message)
        {
            
        }
    }
    public class DomainValidationException : DomainException
    {
        public DomainValidationException(string message) : base(message)
        {

        }
    }
}
