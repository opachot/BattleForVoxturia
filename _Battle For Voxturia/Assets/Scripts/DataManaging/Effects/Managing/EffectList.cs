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

    // PUBLIC
    [Header("General Effect")]
    public Vitality_Effect      vitality_Effect;
    public Incurable_Effect     incurable_Effect;
    public Vulnerability_Effect vulnerability_Effect;
    [Space(10)]

    [Header("Specific Effect")]
    public FighterMeditation_Effect fighterMeditation_Effect;
    public FighterAura_Effect       fighterAura_Effect;

    #endregion

    #region UNITY METHODE
	void Awake() {
        DontDestroyOnLoad(gameObject);
    }
	
	void Start() {

	}
	
	void Update() {
		
	}
    #endregion
}