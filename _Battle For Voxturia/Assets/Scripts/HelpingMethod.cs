/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    09 October 2017
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

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

    // Used to resize correctly a TMP_Text to fit perfectly in a ScrollView.
    public static void AdjustTMPBlockHeight(this TMP_Text origine) {
        // Update the textInfo.lineCount
        origine.ForceMeshUpdate();

        // Find the margin (used to fix the GetPreferredValues that dosn't take them in consideration...)
        float marginsLeft   = origine.margin.w;
        float marginsRight  = origine.margin.y;
        float totalWidthLostByMargins = marginsLeft + marginsRight;

        float width  = origine.rectTransform.sizeDelta.x;
        float height = origine.GetPreferredValues(origine.text, width - totalWidthLostByMargins, 0).y;

        origine.rectTransform.sizeDelta = new Vector2(width, height);
    }

    public static void ScrollToTop(this ScrollRect origine) {
        const int TOP_VALUE = 1;

        origine.verticalNormalizedPosition = TOP_VALUE;
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

    public static string ConvertBoolToIndicator1(bool tf) {
        string indicator = "";

        if(tf) {
            indicator = "O";
        }
        else {
            indicator = "X";
        }

        return indicator;
    }

    public static string ConvertBoolToIndicator2(bool tf) {
        string indicator = "";

        if(tf) {
            indicator = "✔";
        }
        else {
            indicator = "✘";
        }

        return indicator;
    }

    public static void ClearEventSystemButtonHighlighted() {
        // Fix the button glitch that make it staying highlighted.
        EventSystem.current.SetSelectedGameObject(null);
    }

}