using System.Reflection;
using System.Text;

namespace DataGridComponent
{
    public static class ValidateExt
    {
        public static string Validation<T>(this T obj) where T : class
        {
            var msg = new StringBuilder();
            var props = typeof(T).GetProperties();
            foreach (var prop in props)
            {
                foreach (var attr in prop.GetCustomAttributes())
                {
                    switch (attr)
                    {
                        case Required at:
                            if (prop.GetValue(obj) == null || prop.GetValue(obj) == "")
                                msg.AppendLine($"{prop.Name}:error");
                            break;

                        case StringMaximum at:
                            if (prop.GetValue(obj).ToString().Length > at.Maximum)
                                msg.AppendLine($"{prop.Name}:error");
                            break;
                    }
                }
            }

            return msg.ToString();
        }
    }
}