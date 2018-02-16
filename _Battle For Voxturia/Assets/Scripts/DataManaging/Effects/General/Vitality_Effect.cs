/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    15 Fabruary 2018
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vitality_Effect : Effect {

	#region DECLARATION
    // CONST
    private const int HP_BOOST_IN_PERCENT_PER_LVL = 1;

    // PRIVATE

    // PUBLIC

    #endregion

	#region UNITY METHODE
	void Awake() {
		name = VITALITY;
        description = "Increase HP by " + HP_BOOST_IN_PERCENT_PER_LVL + "% (per level)";
        maxLvl = 100;
        isUnbuffable = true;
        specificClassName = "";
    }
	
	void Start() {
		
	}
	
	void Update() {
		
	}
    #endregion

}