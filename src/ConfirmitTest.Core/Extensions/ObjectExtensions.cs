using System;

namespace ConfirmitTest.Core.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsNull(this object obj)
        {
            return ReferenceEquals(obj, null);
        }
    }
}