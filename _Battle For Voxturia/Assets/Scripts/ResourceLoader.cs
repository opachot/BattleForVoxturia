/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    23 September 2017
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceLoader : MonoBehaviour {

    #region DECLARATION
    // CONST

    // PRIVATE

    // PUBLIC
    [Header("Character Icon")]
    public Sprite emptyIconClass;
    public Sprite addCharacterIconClass;
    [Space(10)]
    public Sprite iconFighterClass;
    public Sprite iconHunterClass;
    public Sprite iconNinjaClass;
    public Sprite iconGuardianClass;
    public Sprite iconElementalistClass;
    public Sprite iconGrimReaperClass;
    public Sprite iconDruidClass;
    public Sprite iconSamuraiClass;
    public Sprite iconVampireClass;
    public Sprite iconCyborgClass;
    [Space(10)]

    [Header("Equipment Icon")]
    public Sprite emptyIconHelmet;
    public Sprite emptyIconArmor;
    public Sprite emptyIconGreave;
    public Sprite emptyIconBoots;
    public Sprite emptyIconJewel;
    [Space(10)]

    [Header("Skill Icon")]
    public Sprite emptyIconSkill;

    [Header("---------- Specific Screen ----------")]
        [Header("TeamList Screen")]
        public GameObject teamListingElement;

        [Header("CharacterReserve Screen")]
        public GameObject characterReserveListingElement;

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