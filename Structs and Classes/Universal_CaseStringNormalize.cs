// Coded by Bl@ke. http://www.blatke.cc/
// Version 0.1.0 on March 18, 2024. 
// To convert a string to a form of lowercase letters, deletion of spaces or substitute designated characters with other particular characters.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

namespace Universal.CaseStringNormalize
{
public struct Universal_CaseStringNormalize
{
    public string d(string str, bool toLower, bool trim, bool noSpace, string replace1, string replace2)
    {
        if (str != null && str !="")
        {
            if (toLower)
            {
                str = str.ToLower();
            }
            if (trim)
            {
                str = str.Trim();
            }
            if (noSpace)
            {
                str = Regex.Replace(str, "\\s+", "");
            }
            if (replace1 != "" && replace2 !="" && replace1 != replace2)
            {
                str = str.Replace(replace1, replace2);
            }

        }
        return str;
    }
}
}