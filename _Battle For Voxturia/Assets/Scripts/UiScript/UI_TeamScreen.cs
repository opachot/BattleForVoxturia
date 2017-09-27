/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    26 September 2017
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_TeamScreen : MonoBehaviour {

	#region DECLARATION
    // CONST

    // PRIVATE
    private ResourceLoader resourceLoader;
    private Navigation     navigation;
    private TeamsData      teamsData;

    private int currentTeamId;
    private int currentTeamDataKey;

    // PUBLIC
    public Text screenTitle;

    #endregion

	#region UNITY METHODE
	void Awake() {
		resourceLoader = gameObject.GetComponent<ResourceLoader>();
        navigation     = gameObject.GetComponent<Navigation>();
        teamsData      = GameObject.FindGameObjectWithTag("GameData").GetComponent<TeamsData>();
    }
	
	void Start() {
        UseExtraParam();
        FindCurrentTeamDataKey();

        ShowTeamName();
	}
	
	void Update() {
		
	}
    #endregion


    #region Initialisation
    private void UseExtraParam() {
        currentTeamId = teamsData.ExtraParam_TeamId;
        teamsData.ExtraParam_TeamId = 0;
    }

    private void FindCurrentTeamDataKey() {
        bool isKeyFound = false;
        int    nbTeams  = teamsData.teamsId.Count;

        for(int i = 0; i < nbTeams; i++) {
            if(teamsData.teamsId[i] == currentTeamId) {
                currentTeamDataKey = i;
                isKeyFound = true;

                break;
            }
        }

        if(!isKeyFound) {
            Debug.Log("ERROR 404: currentTeamDataKey not found!");
        }
    }


    private void ShowTeamName() {
        string teamName = teamsData.teamsName[currentTeamDataKey];

        screenTitle.text = teamName;
    }
    #endregion

    #region Default buttons
    public void SelectTeamButton() {
        if(IsValideTeam()) {
            teamsData.usedTeamId = currentTeamId;
            navigation.NavigateTo_TeamList();
        }
        else {
            // TODO: SHOW A ERROR POP-UP
        }

    }

    public void ReturnButton() {
        navigation.NavigateTo_TeamList();
    }
    #endregion




    private bool IsValideTeam() {
        int actualPower = teamsData.teamsCurrentPower[currentTeamDataKey];
        int maxPower    = teamsData.teamsMaxPower    [currentTeamDataKey];

        bool   isValideTeam = actualPower <= maxPower;
        return isValideTeam;
    }
}