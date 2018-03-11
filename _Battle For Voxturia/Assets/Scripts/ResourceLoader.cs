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
    [Space(10)]

    [Header("Class Roles Icon")]
    public Sprite emptyIconClassRole;
    public Sprite iconClassRoleDamageDealer;
    public Sprite iconClassRoleHealer;
    public Sprite iconClassRoleBuffer;
    public Sprite iconClassRoleDebuffer;
    public Sprite iconClassRoleTank;
    public Sprite iconClassRoleProtector;
    public Sprite iconClassRolePositioner;
    public Sprite iconClassRoleSummoner;
    public Sprite iconClassRoleResurrecter;

    [Header("---------- Specific Screen ----------")]
        [Header("TeamList Screen")]
        public GameObject teamListingElement;

        [Header("CharacterReserve Screen")]
        public GameObject characterReserveListingElement;

        [Header("Skill & Equipment Selection Screen")]
        public GameObject skillAndEquipmentListingElement;

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