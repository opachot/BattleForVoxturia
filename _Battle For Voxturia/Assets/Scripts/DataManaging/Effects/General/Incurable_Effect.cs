/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    15 Fabruary 2018
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Incurable_Effect : Effect {

	#region DECLARATION
    // CONST

    // PRIVATE

    // PUBLIC

    #endregion

	#region UNITY METHODE
	void Awake() {
        // Format link for description.
        string Vitality_EffecLink = FormatEffectLink(Effect.VITALITY, Effect.HEX_COLOR_LIFE);
        
		name = INCURABLE;
        description = "Can't regain HP except by " + Vitality_EffecLink + "\n" +
                      "(Can't be unbuffed)";
        maxLvl = 1;
        isUnbuffable = false;
        specificClassName = "";
    }
	
	void Start() {
		
	}
	
	void Update() {
		
	}
    #endregion

}