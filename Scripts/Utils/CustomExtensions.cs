using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace Utils
{
    public static class CustomExtensions
    {
        public static string ConcatArray(this string[] entities, string separator)
        {
            if (entities == null || entities.Length == 0)
                return string.Empty;

            var builder = new StringBuilder();
            var validEntitiesCount = 0;
            for (int i = 0; i < entities.Length; i++)
            {
                var entity = entities[i];
                if (!string.IsNullOrEmpty(entity))
                {
                    builder.Append(entities[i]);
                    if (i < entities.Length - 1)
                    {
                        builder.Append(separator);
                    }
                    validEntitiesCount++;
                }
            }
            return validEntitiesCount > 0 ? builder.ToString() : string.Empty;
        }

        public static bool TryConcatArray(this string[] entities, string separator, out string output)
        {
            output = string.Empty;

            if (entities == null || entities.Length == 0)
                return false;

            var builder = new StringBuilder();
            var validEntitiesCount = 0;
            for (int i = 0; i < entities.Length; i++)
            {
                var entity = entities[i];
                if (!string.IsNullOrEmpty(entity))
                {
                    builder.Append(entities[i]);
                    if (i < entities.Length - 1)
                    {
                        builder.Append(separator);
                    }
                    validEntitiesCount++;
                }
            }
            if(validEntitiesCount > 0)
            {
                output = builder.ToString();
                return true;
            }
            return false;
        }
    }
}