/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    23 September 2017
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamsData : MonoBehaviour {

    #region DECLARATION
    // CONST
    const int DEFAULT_LEVEL        = 1;
    const int DEFAULT_CURRENT_XP   = 0;
    const int DEFAULT_GOAL_XP      = 100;
    const int DEFAULT_VICTORY      = 0;
    const int DEFAULT_DEFEAT       = 0;
    const int DEFAULT_CURRENT_COST = 0;
    const int DEFAULT_MAX_COST     = 1000;

    // PRIVATE
    private ErrorManager   errorManager;

    private CharactersData charactersData;

    private int extraParam_Id; /* Inter screen param */

    // PUBLIC
    public List<int>    ids;
    public List<string> names;
    public List<int>    levels;
    public List<int>    currentXps;
    public List<int>    goalXps;
    public List<int>    victorys;
    public List<int>    defeats;
    public List<int>    currentCosts;
    public List<int>    maxCosts;
    public int          usedTeamId;

    #endregion

    #region UNITY METHODE
    void Awake() {
        errorManager   = GameObject.FindGameObjectWithTag("ErrorManager")   .GetComponent<ErrorManager>();

        charactersData = gameObject.GetComponent<CharactersData>();
    }

    void Start() {

    }

    void Update() {

    }
    #endregion

    #region Validate/Create/Delete team
    #region ValidateTeam
    public bool ValidateCreation(string newName) {
        bool isValidName = true;

        if(!IsAvailableName(newName)) {
            errorManager.TrowError("Error: The name is already taken.");
            isValidName = false;
        }
        else if(!IsMoralName(newName)) {
            errorManager.TrowError("Error: The name is inappropriate.");
            isValidName = false;
        }

        return isValidName;
    }


    private bool IsAvailableName(string newTeamName) {
        bool isAvailableName = true;

        foreach(string name in names) {
            if(newTeamName.ToLower() == name.ToLower()) {
                isAvailableName = false;
                break;
            }
        }

        return isAvailableName;
    }

    private bool IsMoralName(string newName) {
        // TODO
        return true;
    }
    #endregion

    #region CreateTeam
    public void CreateNewTeam(string teamName) {
        ids.Add(GetNewId());

        names.Add(teamName);

        // Default value
        levels      .Add(DEFAULT_LEVEL);
        currentXps  .Add(DEFAULT_CURRENT_XP);
        goalXps     .Add(DEFAULT_GOAL_XP);
        victorys    .Add(DEFAULT_VICTORY);
        defeats     .Add(DEFAULT_DEFEAT);
        currentCosts.Add(DEFAULT_CURRENT_COST);
        maxCosts    .Add(DEFAULT_MAX_COST);
    }

    private int GetNewId() {
        int newId;

        if(ids.Count == 0) {
            newId = 1;
        }
        else {
            int previousId = ids[ids.Count - 1];

            newId = previousId + 1;
        }

        return newId;
    }
    #endregion

    #region DeleteTeam
    public void DeleteTeam(int key) {
        int teamId = ids[key];
        if(teamId == usedTeamId) {
            usedTeamId = 0;
        }

        DeleteRecursivelyCharacterInTeam(teamId);

        ids.RemoveAt(key);
        names.RemoveAt(key);
        levels.RemoveAt(key);
        currentXps.RemoveAt(key);
        goalXps.RemoveAt(key);
        victorys.RemoveAt(key);
        defeats.RemoveAt(key);
        currentCosts.RemoveAt(key);
        maxCosts.RemoveAt(key);
    }

    private void DeleteRecursivelyCharacterInTeam(int teamId) {
        int nbTotalCharacter = charactersData.ids.Count;

        for(int i = 0; i < charactersData.ids.Count; i++) {
            int analysedCharacterTeamId = charactersData.teamDataIds[i];

            if(analysedCharacterTeamId == teamId) {
                charactersData.DeleteCharacter(i);

                // Fix the index because we delete data from a List, not an array.
                i--;
                nbTotalCharacter--;
            }

        }
    }
    #endregion
    #endregion


    #region ValidateTeamSelectable
    public bool ValidateTeamSelectable(int key, bool shouldShowError) {
        bool isValidTeam = true;

        if(!IsValidCost(key)) {
            if(shouldShowError) {
                errorManager.TrowError("Error: The team cost is too hight.");
            }

            isValidTeam = false;
        }
        else if(!IsValidCharacterAmount(key)) {
            if(shouldShowError) {
                errorManager.TrowError("Error: You need at lest 1 character in your team.");
            }

            isValidTeam = false;
        }

        return isValidTeam;
    }


    private bool IsValidCost(int key) {
        int currentCost = currentCosts[key];
        int maxCost     = maxCosts    [key];

        bool   isValidTeam = currentCost <= maxCost;
        return isValidTeam;
    }

    private bool IsValidCharacterAmount(int key) {
        bool isValidCharacterAmount = false;

        for(int i = 0; i < charactersData.ids.Count; i++) {
            bool isCharacterInThisTeam = charactersData.teamDataIds[i] == ids[key];

            if(isCharacterInThisTeam) {
                isValidCharacterAmount = true;
                break;
            }
        }

        return isValidCharacterAmount;
    }
    #endregion


    public void UpdateValideSelectedTeam(int key, int testedTeamId) {
        bool isThisTeamSelected = usedTeamId == testedTeamId;

        if(isThisTeamSelected) {
            bool isValidTeam = ValidateTeamSelectable(key, false);

            if(!isValidTeam) {
                UnselectTeam();
            }
        }
    }

    public void UnselectTeam() {
        usedTeamId = 0;
    }


    #region INTER SCREEN PARAM
    public int ExtraParam_Id {
        get { return extraParam_Id;  }
        set { extraParam_Id = value; }
    }
    #endregion
}