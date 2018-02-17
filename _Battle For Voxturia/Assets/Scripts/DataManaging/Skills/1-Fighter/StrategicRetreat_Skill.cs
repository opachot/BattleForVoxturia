/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    16 Fabruary 2018
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrategicRetreat_Skill : Skill {

	#region DECLARATION
    // CONST
    private const int    DAMAGE         = 30;
    private const string DAMAGE_ELEMENT = "ground";

    private const int SELF_MOVEMENT_LENGHT = 2;

    // PRIVATE

    // PUBLIC

    #endregion

	#region UNITY METHODE
	void Awake() {
		id = 6;
        name = "Strategic Retreat";
        description = "<b>" + "Damage: " + DAMAGE + " " + DAMAGE_ELEMENT + "</b>" + "\n" +
                      "Move in the opposite direction from the target by " + SELF_MOVEMENT_LENGHT + " cells.";
        lore = "Todo";
        cost = 250;

        apCost = 3;
        mpCost = 0;
        minRange = 1;
        maxRange = 1;

        flexibleRange    = false;
        lineOfSight      = true;
        castStraightLine = false;

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