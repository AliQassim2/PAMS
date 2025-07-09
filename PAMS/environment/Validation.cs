using System;
using System.Collections.Generic;
using System.Text;

namespace PAMS.environment
{
    public static class Validation
    {
        private static bool IsValid(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;

            foreach (char c in value)
            {
                if (!char.IsLetterOrDigit(c) && c != ' ' && c != '_' && c != '-')
                    return false;
            }
            return true;
        }

        private static bool Required(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

        public static string Validate(
            string value,
            string fieldName,
            int minLength = 0,
            uint maxLength = uint.MaxValue,
            bool mustBeInt = false,
            bool mustBeDate = false,
            bool isRequired = true,
            bool validateCharacters = false)
        {
            var messages = new List<string>();

            if (isRequired && !Required(value))
                messages.Add($"هذا الحقل مطلوب: {fieldName}");

            if (value.Length < minLength || value.Length > maxLength)
                messages.Add($"يجب أن يكون طول النص بين {minLength} و {maxLength} حرفاً: {fieldName}");

            if (mustBeInt && !int.TryParse(value, out _))
                messages.Add($"يجب أن يكون هذا الحقل رقماً صحيحاً: {fieldName}");

            if (mustBeDate && !DateTime.TryParse(value, out _))
                messages.Add($"يجب أن يكون هذا الحقل تاريخاً صحيحاً: {fieldName}");

            if (validateCharacters && !IsValid(value))
                messages.Add($"يجب أن يحتوي هذا الحقل على أحرف وأرقام فقط (يسمح بـ - و _): {fieldName}");

            return string.Join(Environment.NewLine, messages);
        }

        public static string ValidateMultiple(
            List<string> values,
            List<string> fieldNames,
            int minLength = 0,
            uint maxLength = uint.MaxValue,
            bool mustBeInt = false,
            bool mustBeDate = false,
            bool isRequired = true,
            bool validateCharacters = false)
        {
            var result = new StringBuilder();

            for (int i = 0; i < values.Count && i < fieldNames.Count; i++)
            {
                string message = Validate(values[i], fieldNames[i], minLength, maxLength, mustBeInt, mustBeDate, isRequired, validateCharacters);
                if (!string.IsNullOrWhiteSpace(message))
                {
                    result.AppendLine(message);
                }
            }

            return result.ToString().Trim();
        }
    }
}
