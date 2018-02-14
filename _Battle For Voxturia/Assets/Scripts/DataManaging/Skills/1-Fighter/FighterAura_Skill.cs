/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    13 February 2018
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterAura_Skill : Skill {

	#region DECLARATION
    // CONST

    // PRIVATE

    // PUBLIC

    #endregion
    
	#region UNITY METHODE
	void Awake() {
		// Format link for description.
        string FighterMeditation_EffecLink = FormatEffectLink(Effect.FIGHTER_MEDITATION, Effect.HEX_COLOR_DEFAULT);
        string FighterAura_EffecLink       = FormatEffectLink(Effect.FIGHTER_AURA,       Effect.HEX_COLOR_DEFAULT);

		id = 2;
        name = "Fighter Aura";
        description = "Unbuff " + FighterMeditation_EffecLink + "\n" +
                      "" + FighterAura_EffecLink + " <b>(3 turns)</b>";
        lore = "Todo";
        cost = 200;

        apCost = 3;
        mpCost = 0;
        minRange = 0;
        maxRange = 1;

        flexibleRange    = false;
        lineOfSight      = true;
        castStraightLine = false;

        cooldown             = 5;
        castPerTurn          = 0;
        castPerTurnPerTarget = 0;
    }
	
	void Start() {
		
	}
	
	void Update() {
		
	}
    #endregion

}