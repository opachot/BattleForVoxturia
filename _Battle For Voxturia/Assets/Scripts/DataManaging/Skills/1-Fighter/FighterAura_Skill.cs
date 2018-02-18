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
    private const int FIGHTER_AURA_NB_TURN = 3;

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
        description = FighterAura_EffecLink + "<b>" + " (" + FIGHTER_AURA_NB_TURN + " turns)" + "</b>" + "\n" +
                      "Unbuff " + FighterMeditation_EffecLink;
        lore = "Todo";
        cost = 250;

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