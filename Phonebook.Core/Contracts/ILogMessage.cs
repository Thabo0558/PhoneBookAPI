using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook.Core.Contracts
{
    public interface ILogMessage
    {
        string LogMethodInfo(string className, string methodName);
        string LogMethodInputParameter(string className, string methodName, string parameter);
        string LogMethodResponse(string className, string methodName, string parameter);
        string LogMethodError(string className, string methodName, string errorMessage);
    }
}
