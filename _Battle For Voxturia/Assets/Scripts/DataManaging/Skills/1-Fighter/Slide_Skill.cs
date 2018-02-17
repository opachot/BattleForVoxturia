/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    16 Fabruary 2018
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide_Skill : Skill {

	#region DECLARATION
    // CONST
    private const int    DAMAGE         = 30;
    private const string DAMAGE_ELEMENT = "ground";

    // PRIVATE

    // PUBLIC

    #endregion

	#region UNITY METHODE
	void Awake() {
		id = 5;
        name = "Slide";
        description = "<b>" + "Damage: " + DAMAGE + " " + DAMAGE_ELEMENT + "</b>" + "\n" +
                      "Move in front of the target.";
        lore = "Todo";
        cost = 250;

        apCost = 3;
        mpCost = 0;
        minRange = 2;
        maxRange = 3;

        flexibleRange    = false;
        lineOfSight      = true;
        castStraightLine = true;

        cooldown             = 0;
        castPerTurn          = 2;
        castPerTurnPerTarget = 1;
    }
	
	void Start() {
		
	}
	
	void Update() {
		
	}
    #endregion

}