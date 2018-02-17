/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    16 Fabruary 2018
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrecisionStrike_Skill : Skill {

    #region DECLARATION
    // CONST
    private const int    DAMAGE         = 20;
    private const string DAMAGE_ELEMENT = "wind";

    private const int POWER_LEVEL   = 15;
    private const int POWER_NB_TURN = 10;

    private const int PREPARATION_LEVEL   = 25;
    private const int PREPARATION_NB_TURN = 1;

    // PRIVATE

    // PUBLIC

    #endregion

	#region UNITY METHODE
	void Awake() {
		// Format link for description.
        string Power_EffecLink       = FormatEffectLink(Effect.POWER,       Effect.HEX_COLOR_DAMAGE);
        string Preparation_EffecLink = FormatEffectLink(Effect.PREPARATION, Effect.HEX_COLOR_DAMAGE);

		id = 4;
        name = "Precision Strike";
        description = "<b>" + "Damage: " + DAMAGE + " " + DAMAGE_ELEMENT + "</b>" + "\n" +
                      Power_EffecLink       + " +" + POWER_LEVEL       + " levels " + "<b>" + "(" + POWER_NB_TURN       + " turns)" + "</b>" + "\n" +
                      Preparation_EffecLink + " +" + PREPARATION_LEVEL + " levels " + "<b>" + "(" + PREPARATION_NB_TURN + " turn)"  + "</b>";
        lore = "Todo";
        cost = 250;

        apCost = 2;
        mpCost = 0;
        minRange = 1;
        maxRange = 1;

        flexibleRange    = false;
        lineOfSight      = true;
        castStraightLine = false;

        cooldown             = 0;
        castPerTurn          = 0;
        castPerTurnPerTarget = 1;
    }
	
	void Start() {
		
	}
	
	void Update() {
		
	}
    #endregion

}