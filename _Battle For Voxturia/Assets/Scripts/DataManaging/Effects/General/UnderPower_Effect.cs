/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    20 january 2018
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderPower_Effect : Effect {

	#region DECLARATION
    // CONST
    private const int FINAL_DAMAGE_REDUCTION_IN_PERCENT_PER_LVL = 1;
    
    // PRIVATE

    // PUBLIC

    #endregion

	#region UNITY METHODE
	void Awake() {
		name = UNDERPOWER;
        description = "Reduce final damage by " + FINAL_DAMAGE_REDUCTION_IN_PERCENT_PER_LVL + "% (per level)";
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