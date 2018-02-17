/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    16 Fabruary 2018
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_Effect : Effect {

	#region DECLARATION
    // CONST
    private const int POWER_BOOST_PER_LVL = 1;

    // PRIVATE

    // PUBLIC

    #endregion

	#region UNITY METHODE
	void Awake() {
		name = POWER;
        description = "Increase power by " + POWER_BOOST_PER_LVL + " (per level)";
        maxLvl = 1000;
        isUnbuffable = true;
        specificClassName = "";
    }
	
	void Start() {
		
	}
	
	void Update() {
		
	}
    #endregion

}