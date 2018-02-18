/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    17 Fabruary 2018
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronPunch_Skill : Skill {

	#region DECLARATION
    // CONST
    private const int    MIN_DAMAGE     = 75;
    private const int    MAX_DAMAGE     = 80;
    private const string DAMAGE_ELEMENT = "ground";

    private const int POWERLESS_LEVEL   = 100;
    private const int POWERLESS_NB_TURN = 2;

    // PRIVATE

    // PUBLIC

    #endregion

	#region UNITY METHODE
	void Awake() {
		// Format link for description.
        string Powerless_EffecLink = FormatEffectLink(Effect.POWERLESS, Effect.HEX_COLOR_DAMAGE);

		id = 8;
        name = "Iron Punch";
        description = "<b>" + "Damage: " + MIN_DAMAGE + "-" + MAX_DAMAGE + " " + DAMAGE_ELEMENT + "</b>" + "\n" +
                      Powerless_EffecLink + " +" + POWERLESS_LEVEL + " levels " + "<b>" + "(" + POWERLESS_NB_TURN + " turns)" + "</b>";
        lore = "Todo";
        cost = 250;

        apCost = 4;
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