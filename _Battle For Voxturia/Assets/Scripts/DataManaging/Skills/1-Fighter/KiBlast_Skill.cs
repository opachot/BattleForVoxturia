/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    17 Fabruary 2018
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiBlast_Skill : Skill {

	#region DECLARATION
    // CONST
    private const int    MIN_DAMAGE     = 1;
    private const int    MAX_DAMAGE     = 100;
    private const string DAMAGE_ELEMENT = "light";

    private const int MELEE_PUSH = 2;
    private const int RANGE_PUSH = 1;

    // PRIVATE

    // PUBLIC

    #endregion

	#region UNITY METHODE
	void Awake() {
		id = 9;
        name = "Ki Blast";
        description = "<b>" + "Damage: " + MIN_DAMAGE + "-" + MAX_DAMAGE + " " + DAMAGE_ELEMENT + "</b>" + " (On enemy)" + "\n" +
                      "On melee target: Push back of " + MELEE_PUSH + " cells" + "\n" +
                      "On range target: Push back of " + RANGE_PUSH + " cell";
        lore = "Todo";
        cost = 250;

        apCost = 4;
        mpCost = 0;
        minRange = 1;
        maxRange = 3;

        flexibleRange    = true;
        lineOfSight      = true;
        castStraightLine = true;

        cooldown             = 2;
        castPerTurn          = 0;
        castPerTurnPerTarget = 0;
    }
	
	void Start() {
		
	}
	
	void Update() {
		
	}
    #endregion

}