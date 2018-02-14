/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    13 February 2018
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterAura_Effect : Effect {

	#region DECLARATION
    // CONST
    const int POWER_BOOST = 200;
    const int AP_BOOST    = 1;

    // PRIVATE

    // PUBLIC

    #endregion

	#region UNITY METHODE
	void Awake() {
		name = FIGHTER_AURA;
        description = "Increase Power by " + POWER_BOOST + "\n" +
                      "Increase AP by " + AP_BOOST + "\n" +
                      "(Only unbuffable by the '" + FIGHTER_MEDITATION + "' skill)";
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