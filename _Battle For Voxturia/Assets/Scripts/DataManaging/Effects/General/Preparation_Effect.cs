/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    16 Fabruary 2018
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preparation_Effect : Effect {

    #region DECLARATION
    // CONST
    private const int NEXT_SKILL_FINAL_DAMAGE_BOOST_IN_PERCENT_PER_LVL = 1;

    // PRIVATE

    // PUBLIC

    #endregion

	#region UNITY METHODE
	void Awake() {
		name = PREPARATION;
        description = "Increase the next skill final damage by " + NEXT_SKILL_FINAL_DAMAGE_BOOST_IN_PERCENT_PER_LVL + "% (per level)";
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