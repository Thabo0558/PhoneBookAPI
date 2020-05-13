using Phonebook.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook.Core.Services
{
    public class LogMessage : ILogMessage
    {
        public string LogMethodInfo(string className, string methodName)
        {
            return string.Format("Executing : Class :{0} Method:{1}", className, methodName);
        }

        public string LogMethodError(string className, string methodName, string errorMessage)
        {
            return string.Format("Something went wrong: Class :{0} Method:{1} error: {2}", className, methodName, errorMessage);
        }


        public string LogMethodInputParameter(string className, string methodName, string parameter)
        {
            return string.Format("Parameters for: Class :{0} Method:{1} parameter: [{2}]", className, methodName, parameter);
        }

        public string LogMethodResponse(string className, string methodName, string parameter)
        {
            return string.Format("Response for: Class :{0} Method:{1} parameter: [{2}]", className, methodName, parameter);
        }
    }
}
