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
    private ErrorManager   errorManager;
    private TeamsData      teamsData;

    private int currentTeamId;
    private int currentTeamDataKey;

    // PUBLIC
    public Text screenTitle;

    public Text statsLevel;
    public Text statsXp;
    public Text statsVictory;
    public Text statsDefeat;
    public Text statsMatch;
    public Text statsVDRatio;
    public Text statsCost;

    public Text errorMessage;

    #endregion

	#region UNITY METHODE
	void Awake() {
		resourceLoader = gameObject.GetComponent<ResourceLoader>();
        navigation     = gameObject.GetComponent<Navigation>();
        errorManager   = gameObject.GetComponent<ErrorManager>();
        teamsData      = GameObject.FindGameObjectWithTag("GameData").GetComponent<TeamsData>();
    }
	
	void Start() {
        UseExtraParam();
        FindCurrentTeamDataKey();

        ShowTeamName();
        ShowTeamStats();
	}
	
	void Update() {
		
	}
    #endregion


    #region Initialisation
    private void UseExtraParam() {
        currentTeamId = teamsData.ExtraParam_Id;
        teamsData.ExtraParam_Id = 0;
    }

    private void FindCurrentTeamDataKey() {
        bool isKeyFound = false;
        int    nbTeams  = teamsData.ids.Count;

        for(int i = 0; i < nbTeams; i++) {
            if(teamsData.ids[i] == currentTeamId) {
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
        string teamName = teamsData.names[currentTeamDataKey];

        screenTitle.text = teamName;
    }

    private void ShowTeamStats() {
        // Get the data
        int   teamLevel       = teamsData.levels      [currentTeamDataKey];
        int   teamCurrentXp   = teamsData.currentXps  [currentTeamDataKey];
        int   teamGoalXp      = teamsData.goalXps     [currentTeamDataKey];
        int   teamVictory     = teamsData.victorys    [currentTeamDataKey];
        int   teamDefeat      = teamsData.defeats     [currentTeamDataKey];
        int   teamMatch       = teamVictory + teamDefeat;
        float teamVDRatio     = CalculatingVDRatio(teamVictory, teamDefeat);
        int   teamCurrentCost = teamsData.currentCosts[currentTeamDataKey];
        int   teamMaxCost     = teamsData.maxCosts    [currentTeamDataKey];

        // Use the data on the Team Stats display.
        statsLevel  .text = teamLevel      .ToString();
        statsXp     .text = teamCurrentXp  .ToString() + " / " + teamGoalXp;
        statsVictory.text = teamVictory    .ToString();
        statsDefeat .text = teamDefeat     .ToString();
        statsMatch  .text = teamMatch      .ToString();
        statsVDRatio.text = teamVDRatio    .ToString();
        statsCost   .text = teamCurrentCost.ToString() + " / " + teamMaxCost;
    }
    #endregion

    #region Default buttons
    public void SelectTeamButton() {
        bool   isValidTeam = ValidateTeam();

        if(isValidTeam) {
            teamsData.usedTeamId = currentTeamId;
            navigation.NavigateTo_TeamList();
        }
    }

    public void ReturnButton() {
        navigation.NavigateTo_TeamList();
    }
    #endregion


    #region ValidateTeam
    private bool ValidateTeam() {
        bool isValidTeam = true;

        if(!IsValideCost()) {
            errorManager.TrowError("Error: The team cost is too hight.");
            isValidTeam = false;
        }
        else if(!IsValidCharacterAmount()) {
            errorManager.TrowError("Error: You need at lest 1 character in your team.");
            isValidTeam = false;
        }

        return isValidTeam;
    }

    private bool IsValideCost() {
        int currentCost = teamsData.currentCosts[currentTeamDataKey];
        int maxCost     = teamsData.maxCosts    [currentTeamDataKey];

        bool   isValidTeam = currentCost <= maxCost;
        return isValidTeam;
    }

    private bool IsValidCharacterAmount() {
        bool isValidCharacterAmount = true;

        // TODO: Search whit the key in the character data to find if any character idTeamData is equal to currentTeamId.

        return isValidCharacterAmount;
    }
    #endregion

    private float CalculatingVDRatio(int teamVictory, int teamDefeat) {
        const float FLOAT_CONVERTER = 1.0f;
        float ratio;

        // (Protect from divided by 0 exeption)
        if(teamDefeat == 0) {
            ratio = teamVictory;
        }
        else {
            ratio = teamVictory * FLOAT_CONVERTER / teamDefeat;

            // Round to 2 decimal.
            ratio = Mathf.Round(ratio * 100f) / 100f;
        }

        return ratio;
    }
}