using System;

namespace AccessManagerApp.Helpers
{
    public static class Utilities
    {
        public static T ConvertType<T>(object v)
        {
            try
            {
                return (T) Convert.ChangeType(v, typeof(T));
            }
            catch (InvalidCastException ex)
            {
                return (T) Activator.CreateInstance(typeof(T));
            }
        }
    }
}
