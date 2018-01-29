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

    // PRIVATE

    // PUBLIC

    #endregion

	#region UNITY METHODE
	void Awake() {
		id = 1;
        name = "Fighter Meditation";
        description = "Uncast <link=" + EffectList.FIGHTER_AURA + ">[[Fighter Aura]]</link>\n" +
                      "<link=" + EffectList.FIGHTER_MEDITATION + ">[[Fighter Meditation]]</link> (3 turns)";
        lore = "Todo";
        cost = 250;
    }
	
	void Start() {

	}
	
	void Update() {
		
	}
    #endregion

}