/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    28 January 2018
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectList : MonoBehaviour {

    #region DECLARATION
    // CONST

    // PRIVATE
    // General Effect


    // Specific Effect
    FighterMeditation_Effect fighterMeditation_Effect;

    // PUBLIC

    #endregion

    #region UNITY METHODE
	void Awake() {
        DontDestroyOnLoad(gameObject);

        fighterMeditation_Effect = gameObject.GetComponent<FighterMeditation_Effect>();
    }
	
	void Start() {

	}
	
	void Update() {
		
	}
    #endregion


    public FighterMeditation_Effect GetFighterMeditation() {
        return fighterMeditation_Effect;
    }

}