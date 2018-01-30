/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    DAY MONTH YEARS
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterMeditation_Effect : Effect {

    #region DECLARATION
    // CONST
    const int HP_BOOST_BY_PERCENT = 30;
    const int RESISTANCE_BOOST_BY_PERCENT = 15;

    // PRIVATE

    // PUBLIC

    #endregion

	#region UNITY METHODE
	void Awake() {
		name = FIGHTER_MEDITATION;
        description = "Increase HP by " + HP_BOOST_BY_PERCENT + "%\n" +
                      "Increase resistance by " + RESISTANCE_BOOST_BY_PERCENT + "%\n" +
                      "(Only unbuffable by the '" + FIGHTER_AURA + "' skill)";
        maxLvl = 1;
        isUnbuffable = false;
        specificClassName = "Fighter";
    }
	
	void Start() {
		
	}
	
	void Update() {
		
	}
    #endregion

}