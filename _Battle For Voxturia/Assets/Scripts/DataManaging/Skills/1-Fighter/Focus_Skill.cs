/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    15 Fabruary 2018
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Focus_Skill : Skill {

    #region DECLARATION
    // CONST
    private const int VULNERABILITY_LEVEL = 20;
    private const int VULNERABILITY_NB_TURN = 2;

    private const int INCURABLE_NB_TURN = 2;

    // PRIVATE

    // PUBLIC

    #endregion

	#region UNITY METHODE
	void Awake() {
		// Format link for description.
        string Vulnerability_EffecLink = FormatEffectLink(Effect.VULNERABILITY, Effect.HEX_COLOR_PROTECTION);
        string Incurable_EffecLink     = FormatEffectLink(Effect.INCURABLE,     Effect.HEX_COLOR_LIFE);

		id = 3;
        name = "Focus";
        description = Vulnerability_EffecLink + " +" + VULNERABILITY_LEVEL + " levels <b>(" + VULNERABILITY_NB_TURN + " turns)</b>"  + "\n" +
                      Incurable_EffecLink + " <b>(" + INCURABLE_NB_TURN + " turns)</b>";
        lore = "Todo";
        cost = 250;

        apCost = 2;
        mpCost = 0;
        minRange = 1;
        maxRange = 4;

        flexibleRange    = false;
        lineOfSight      = true;
        castStraightLine = false;

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