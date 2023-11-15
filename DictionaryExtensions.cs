namespace DLLInject
{
    public static class DictionaryExtensions
    {
        public static string GetParameterValue(this Dictionary<string, string> parameters, string parameterName)
        {
            return parameters.ContainsKey(parameterName) ? parameters[parameterName] : null;
        }
    }
}
