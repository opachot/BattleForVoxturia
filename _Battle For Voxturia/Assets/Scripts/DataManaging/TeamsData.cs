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
        DontDestroyOnLoad(gameObject);
    }

    void Start() {

    }

    void Update() {

    }
    #endregion

    public void CreateNewTeam(string teamName) {
        int newId = GetNewId();
        
        ids  .Add(newId);
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

    public bool IsExistingName(string paramName) {
        bool isExistingName = false;

        foreach(string name in names) {
            if(paramName.ToLower() == name.ToLower()) {
                isExistingName = true;
                break;
            }
        }

        return isExistingName;
    }

    public void DeleteTeam(int key) {
        int deletingId = ids[key];
        if(deletingId == usedTeamId) {
            usedTeamId = 0;
        }

        //TODO: Will need to delete other data linked whit the TeamsData such as character.

        ids         .RemoveAt(key);
        names       .RemoveAt(key);
        levels      .RemoveAt(key);
        currentXps  .RemoveAt(key);
        goalXps     .RemoveAt(key);
        victorys    .RemoveAt(key);
        defeats     .RemoveAt(key);
        currentCosts.RemoveAt(key);
        maxCosts    .RemoveAt(key);
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


    #region INTER SCREEN PARAM
    public int ExtraParam_Id {
        get { return extraParam_Id;  }
        set { extraParam_Id = value; }
    }
    #endregion
}