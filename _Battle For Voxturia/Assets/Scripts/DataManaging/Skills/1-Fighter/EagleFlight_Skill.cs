/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    16 Fabruary 2018
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleFlight_Skill : Skill {

	#region DECLARATION
    // CONST

    // PRIVATE

    // PUBLIC

    #endregion

	#region UNITY METHODE
	void Awake() {
		id = 7;
        name = "Eagle Flight";
        description = "Move at the targeted cell.";
        lore = "Todo";
        cost = 250;

        apCost = 3;
        mpCost = 1;
        minRange = 2;
        maxRange = 3;

        flexibleRange    = true;
        lineOfSight      = false;
        castStraightLine = true;

        cooldown             = 4;
        castPerTurn          = 0;
        castPerTurnPerTarget = 0;
    }
	
	void Start() {
		
	}
	
	void Update() {
		
	}
    #endregion

}