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
    [Header("************ General Effect ************")]
    [Header("Action Effect")]
    [Header("Movement Effect")]
    [Header("Sight Effect")]
    [Header("Life Effect")]
    public Vitality_Effect      vitality_Effect;
    public Incurable_Effect     incurable_Effect;
    [Header("Protection Effect")]
    public Vulnerability_Effect vulnerability_Effect;
    [Header("Damage Effect")]
    public UnderPower_Effect    underPower_Effect;
    public Preparation_Effect   preparation_Effect;
    public Power_Effect         power_Effect;
    public Powerless_Effect     powerless_Effect;
    [Space(10)]

    [Header("************ Specific Effect ************")]
    [Header("Fighter Effect")]
    public FighterMeditation_Effect fighterMeditation_Effect;
    public FighterAura_Effect       fighterAura_Effect;
    /*[Header("Hunter Effect")]
    [Header("Ninja Effect")]
    [Header("Elementalist Effect")]
    [Header("Samurai Effect")]
    [Header("Vampire Effect")]
    [Header("Cyborg Effect")]*/
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