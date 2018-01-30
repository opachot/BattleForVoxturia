/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    09 October 2017
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HelpingMethod {

    #region DECLARATION
    // CONST
    public const string HEX_BLUE   = "0000FFFF";
    public const string HEX_GREEN  = "007300FF";
    public const string HEX_AQUA   = "00FFFFFF";
    public const string HEX_PINK   = "AF00FFFF";
    public const string HEX_YELLOW = "FFFF00FF";
    public const string HEX_RED    = "FF0000FF";
    public const string HEX_WHITE  = "FFFFFFFF";

    // PRIVATE

    // PUBLIC

    #endregion


    #region ExtensionsMethode
    //Breadth-first search
    public static Transform FindDeepChild(this Transform origine, string target)
    {
        Transform result = origine.Find(target);

        // search deeper...
        if(result == null) {
            foreach(Transform child in origine)
            {
                result = child.FindDeepChild(target);

                if(result != null) {
                    break;
                }
            }
        }

        return result;
    }
    #endregion


    #region ConvertToDecimalColor
    public static Vector4 ConvertToDecimalColor(Color colorToConvert) {
        Vector4 convertedColor = new Vector4(colorToConvert.r/255.0f, 
                                             colorToConvert.g/255.0f, 
                                             colorToConvert.b/255.0f, 
                                             colorToConvert.a/255.0f);

        return convertedColor;
    }

    public static Vector4 ConvertToDecimalColor(float r, float g, float b, float a) {
        Vector4 color = new Vector4(r/255.0f, g/255.0f, b/255.0f, a/255.0f);
        return  color;
    }

    public static float   ConvertToDecimalColor(float rgba) {
        float  color = rgba / 255.0f;
        return color;
    }
    #endregion

    public static string ConvertBoolToIndicator(bool tf) {
        string indicator = "";

        if(tf) {
            indicator = "✔";
        }
        else {
            indicator = "✘";
        }

        return indicator;
    }

}