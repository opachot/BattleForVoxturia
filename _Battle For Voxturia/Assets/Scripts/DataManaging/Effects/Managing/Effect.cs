/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    DAY MONTH YEARS
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour {

	#region DECLARATION
    // CONST
    // General Effect
    public const string INCURABLE     = "Incurable";
    public const string VULNERABILITY = "Vulnerability";
    public const string VITALITY      = "Vitality";
    
    // Specific Effect
    public const string FIGHTER_MEDITATION = "Fighter Meditation";
    public const string FIGHTER_AURA       = "Fighter Aura";
    
    // Color
    public const string HEX_COLOR_ACTION     = "#0000FFFF"; // Blue
    public const string HEX_COLOR_MOVEMENT   = "#007300FF"; // Green
    public const string HEX_COLOR_SIGHT      = "#00FFFFFF"; // Aqua
    public const string HEX_COLOR_LIFE       = "#AF00FFFF"; // Pink
    public const string HEX_COLOR_PROTECTION = "#FFFF00FF"; // Yellow
    public const string HEX_COLOR_DAMAGE     = "#FF0000FF"; // Red
    public const string HEX_COLOR_DEFAULT    = "#FFFFFFFF"; // White

    // PRIVATE

    // PROTECTED
    protected new string name;
    protected string     description;
    protected int        maxLvl;
    protected bool       isUnbuffable;
    protected string     specificClassName;

    // PUBLIC
    public Sprite icon;

    #endregion


    public string GetName() {
        return name;
    }

    public string GetDescription() {
        return description;
    }

    public int GetMaxLvl() {
        return maxLvl;
    }

    public bool GetIsUnbuffable() {
        return isUnbuffable;
    }

    public string GetSpecificClassName() {
        return specificClassName;
    }

    public Sprite GetIcon() {
        return icon;
    }


    protected string FormatEffectLink(string effectName, string hexColor) {
        string effectLink = "";

        effectLink = "<color=" + hexColor + ">" +
                         "<style=Link>" +
                             "<link=" + effectName + ">" +
                                 "[[" + effectName + "]]" +
                             "</link>" +
                         "</style>" +
                     "</color>";

        return effectLink;
    }
}