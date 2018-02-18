/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    20 january 2018
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterMeditation_Skill : Skill {

	#region DECLARATION
    // CONST
    private const int FIGHTER_MEDITATION_NB_TURN = 3;

    // PRIVATE

    // PUBLIC

    #endregion

	#region UNITY METHODE
	void Awake() {
        // Format link for description.
        string FighterAura_EffecLink       = FormatEffectLink(Effect.FIGHTER_AURA,       Effect.HEX_COLOR_DEFAULT);
        string FighterMeditation_EffecLink = FormatEffectLink(Effect.FIGHTER_MEDITATION, Effect.HEX_COLOR_DEFAULT);

		id = 1;
        name = "Fighter Meditation";
        description = FighterMeditation_EffecLink + "<b>" + " (" + FIGHTER_MEDITATION_NB_TURN + " turns)" + "</b>" + "\n" +
                      "Unbuff " + FighterAura_EffecLink;
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