using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Convert
{

    public static int ToInt(string s)
    {
        try
        {
            int i = Int32.Parse(s);
            return i;
        }
        catch
        {
            return 0;
        }
    }

}
