/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    17 Fabruary 2018
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerless_Effect : Effect {

	#region DECLARATION
    // CONST
    private const int POWER_REDUCTION_PER_LVL = 1;

    // PRIVATE
    
    // PUBLIC

    #endregion

	#region UNITY METHODE
	void Awake() {
		name = POWERLESS;
        description = "Reduce power by " + POWER_REDUCTION_PER_LVL + " (per level)";
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