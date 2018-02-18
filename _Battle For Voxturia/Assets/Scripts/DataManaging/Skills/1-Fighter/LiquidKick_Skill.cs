/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    20 january 2018
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidKick_Skill : Skill {
     
	#region DECLARATION
    // CONST
    private const int    MIN_DAMAGE1     = 45;
    private const int    MAX_DAMAGE1     = 50;
    private const string DAMAGE_ELEMENT1 = "water";

    private const int    PERCENT_CHANCE  = 50;

    private const int    MIN_DAMAGE2     = 20;
    private const int    MAX_DAMAGE2     = 25;
    private const string DAMAGE_ELEMENT2 = "water";

    private const int UNDERPOWER_LEVEL   = 25;
    private const int UNDERPOWER_NB_TURN = 1;

    // PRIVATE

    // PUBLIC

    #endregion

	#region UNITY METHODE
	void Awake() {
		// Format link for description.
        string UnderPower_EffecLink = FormatEffectLink(Effect.UNDERPOWER, Effect.HEX_COLOR_DAMAGE);

		id = 10;
        name = "Liquid Kick";
        description = "<b>" + "Damage: " + MIN_DAMAGE1 + "-" + MAX_DAMAGE1 + " " + DAMAGE_ELEMENT1 + "</b>" + "\n" +
                      "And 50% chance to do:" + "\n" +
                      "    - " + "<b>" + "Damage: " + MIN_DAMAGE2 + "-" + MAX_DAMAGE2 + " " + DAMAGE_ELEMENT2 + "</b>" + "\n" +
                      "    - " + UnderPower_EffecLink + " +" + UNDERPOWER_LEVEL + " levels " + "<b>" + "(" + UNDERPOWER_NB_TURN + " turn)" + "</b>";
        lore = "Todo";
        cost = 250;

        apCost = 4;
        mpCost = 1;
        minRange = 1;
        maxRange = 1;

        flexibleRange    = false;
        lineOfSight      = true;
        castStraightLine = false;

        cooldown             = 0;
        castPerTurn          = 1;
        castPerTurnPerTarget = 0;
    }
	
	void Start() {
		
	}
	
	void Update() {
		
	}
    #endregion

}