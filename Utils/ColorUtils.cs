using System.Drawing;

namespace SpiroGraph.Utils
{
    public static class ColorUtils
    {
        public static Color ActualColor(string value)
        {
            return Color.FromName(value);
            //if (string.IsNullOrWhiteSpace(value))
            //    return Color.Empty;

            //if (value.StartsWith("#"))
            //{
            //    try
            //    {
            //        return ColorTranslator.FromHtml(value);
            //    }
            //    catch
            //    {
            //        return Color.Empty;
            //    }
            //}

            //Color named = Color.FromName(value);

            //if (named.IsKnownColor || named.IsNamedColor)
            //    return named;

            //return Color.Empty;
        }
        //public static string ColorName(Color c)
        //{
        //    // If it's a named color, return the name
        //    if (c.IsNamedColor)
        //        return c.Name;

        //    // Otherwise return a hex string like #RRGGBB
        //    return ColorTranslator.ToHtml(c);
        //}
    }
}