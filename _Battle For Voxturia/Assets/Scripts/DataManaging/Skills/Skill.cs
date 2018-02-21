/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    20 january 2018
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour {

    #region DECLARATION
    // CONST

    // PRIVATE

    // PROTECTED
    protected int        id;
    protected new string name;
    protected string     description;
    protected string     lore;
    protected int        cost;

    protected int apCost;
    protected int mpCost;
    protected int minRange;
    protected int maxRange;

    protected bool flexibleRange;
    protected bool lineOfSight;
    protected bool castStraightLine;

    protected int cooldown;
    protected int castPerTurn;
    protected int castPerTurnPerTarget;

    // PUBLIC
    public Sprite icon;
    public Sprite areaOfEffect;

    #endregion

	#region UNITY METHODE
	void Awake() {
		
    }
	
	void Start() {
		
	}
	
	void Update() {
		
	}
    #endregion

    public int GetId() {
        return id;
    }

    public Sprite GetIcon() {
        return icon;
    }

    public string GetName() {
        return name;
    }

    public string GetDescription() {
        return description;
    }

    public string GetLore() {
        return lore;
    }

    public int GetCost() {
        return cost;
    }


    public int GetApCost() {
        return apCost;
    }

    public int GetMpCost() {
        return mpCost;
    }

    public int GetMinRange() {
        return minRange;
    }

    public int GetMaxRange() {
        return maxRange;
    }

    public string GetRangeDisplay() {
        string rangeDisplay = "";

        int minRange = GetMinRange();
        int maxRange = GetMaxRange();

        if(minRange == maxRange) {
            rangeDisplay = minRange.ToString();
        }
        else {
            rangeDisplay = minRange + "-" + maxRange;
        }

        return rangeDisplay;
    }

    public bool GetFlexibleRange() {
        return flexibleRange;
    }

    public bool GetLineOfSight() {
        return lineOfSight;
    }

    public bool GetCastStraightLine() {
        return castStraightLine;
    }

    public int GetCooldown() {
        return cooldown;
    }

    public int GetCastPerTurn() {
        return castPerTurn;
    }

    public int GetCastPerTurnPerTarget() {
        return castPerTurnPerTarget;
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