/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    11 March 2018
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassRole : MonoBehaviour {

	#region DECLARATION
    // CONST
    const int NB_ROLE = 2;

    const int INDEX_ROLE_1 = 0;
    const int INDEX_ROLE_2 = 1;

    const string DAMAGE_DEALER = "Damage dealer";
    const string HEALER        = "Healer";
    const string BUFFER        = "Buffer";
    const string DEBUFFER      = "Debuffer";
    const string TANK          = "Tank";
    const string PROTECTOR     = "Protector";
    const string POSITIONER    = "Positioner";
    const string SUMMONER      = "Summoner";
    const string RESURRECTER   = "Resurrecter";

    // PRIVATE
    private ResourceLoader resourceLoader;

    // PUBLIC

    #endregion

	#region UNITY METHODE
	void Awake() {
		resourceLoader = GameObject.FindGameObjectWithTag("RessourceLoader").GetComponent<ResourceLoader>();
    }
	
	void Start() {
		
	}
	
	void Update() {
		
	}
    #endregion


    public Sprite[] GetRoleIcons(string className) {
        Sprite[] icons = new Sprite[NB_ROLE];

        switch (className)
        {
            case "Fighter":
                icons[INDEX_ROLE_1] = resourceLoader.iconClassRoleDamageDealer;
                icons[INDEX_ROLE_2] = resourceLoader.iconClassRoleTank;
                break;
            case "Hunter":
                icons[INDEX_ROLE_1] = resourceLoader.iconClassRoleDamageDealer;
                icons[INDEX_ROLE_2] = resourceLoader.iconClassRolePositioner;
                break;
            case "Ninja":
                icons[INDEX_ROLE_1] = resourceLoader.iconClassRoleDamageDealer;
                icons[INDEX_ROLE_2] = resourceLoader.iconClassRoleBuffer;
                break;
            case "Guardian":
                icons[INDEX_ROLE_1] = resourceLoader.iconClassRoleTank;
                icons[INDEX_ROLE_2] = resourceLoader.iconClassRoleProtector;
                break;
            case "Elementalist":
                icons[INDEX_ROLE_1] = resourceLoader.iconClassRoleDebuffer;
                icons[INDEX_ROLE_2] = resourceLoader.iconClassRoleSummoner;
                break;
            case "GrimReaper":
                icons[INDEX_ROLE_1] = resourceLoader.iconClassRoleDebuffer;
                icons[INDEX_ROLE_2] = resourceLoader.iconClassRoleResurrecter;
                break;
            case "Druid":
                icons[INDEX_ROLE_1] = resourceLoader.iconClassRoleHealer;
                icons[INDEX_ROLE_2] = resourceLoader.iconClassRoleResurrecter;
                break;
            case "Samurai":
                icons[INDEX_ROLE_1] = resourceLoader.iconClassRoleBuffer;
                icons[INDEX_ROLE_2] = resourceLoader.iconClassRoleTank;
                break;
            case "Vampire":
                icons[INDEX_ROLE_1] = resourceLoader.iconClassRoleTank;
                icons[INDEX_ROLE_2] = resourceLoader.iconClassRoleSummoner;
                break;
            case "Cyborg":
                icons[INDEX_ROLE_1] = resourceLoader.iconClassRoleDamageDealer;
                icons[INDEX_ROLE_2] = resourceLoader.iconClassRoleHealer;
                break;
            default:
                Debug.Log("Error 404: Class roles icons not founds.");
                break;
        }

        return icons;
    }

    public string[] GetRoleNames(string className) {
        string[] names = new string[NB_ROLE];

        switch (className)
        {
            case "Fighter":
                names[INDEX_ROLE_1] = DAMAGE_DEALER;
                names[INDEX_ROLE_2] = TANK;
                break;
            case "Hunter":
                names[INDEX_ROLE_1] = DAMAGE_DEALER;
                names[INDEX_ROLE_2] = POSITIONER;
                break;
            case "Ninja":
                names[INDEX_ROLE_1] = DAMAGE_DEALER;
                names[INDEX_ROLE_2] = BUFFER;
                break;
            case "Guardian":
                names[INDEX_ROLE_1] = TANK;
                names[INDEX_ROLE_2] = PROTECTOR;
                break;
            case "Elementalist":
                names[INDEX_ROLE_1] = DEBUFFER;
                names[INDEX_ROLE_2] = SUMMONER;
                break;
            case "GrimReaper":
                names[INDEX_ROLE_1] = DEBUFFER;
                names[INDEX_ROLE_2] = RESURRECTER;
                break;
            case "Druid":
                names[INDEX_ROLE_1] = HEALER;
                names[INDEX_ROLE_2] = RESURRECTER;
                break;
            case "Samurai":
                names[INDEX_ROLE_1] = BUFFER;
                names[INDEX_ROLE_2] = TANK;
                break;
            case "Vampire":
                names[INDEX_ROLE_1] = TANK;
                names[INDEX_ROLE_2] = SUMMONER;
                break;
            case "Cyborg":
                names[INDEX_ROLE_1] = DAMAGE_DEALER;
                names[INDEX_ROLE_2] = HEALER;
                break;
            default:
                Debug.Log("Error 404: Class roles names not founds.");
                break;
        }

        return names;
    }
}