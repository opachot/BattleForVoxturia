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

    // PRIVATE
    private int extraParam_TeamId; /* Inter screen param */

    // PUBLIC
    public List<int>    teamsId;
    public List<string> teamsName;
    public int          usedTeamId;
    public List<int>    teamsLevel;
    public List<int>    teamsCurrentXp;
    public List<int>    teamsGoalXp;
    public List<int>    teamsVictory;
    public List<int>    teamsDefeat;
    public List<int>    teamsMatch;
    public List<int>    teamsVDRatio;
    public List<int>    teamsCurrentPower;
    public List<int>    teamsMaxPower;

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
        int newId;
        int nbId = teamsId.Count;

        if(nbId == 0) {
            newId = 1;
        }
        else {
            int previousId = teamsId[nbId - 1];

            newId = previousId + 1;
        }
         
        teamsId.Add(newId);
        teamsName.Add(teamName);
    }

    public bool IsExistingName(string name) {
        name = name.ToLower();
        bool isExistingName = false;

        foreach(string teamName in teamsName) {
            if(name.ToLower() == teamName.ToLower()) {
                isExistingName = true;
                break;
            }
        }

        return isExistingName;
    }


    public void DeleteTeam(int teamIndex) {
        //TODO: Will need to save team id to delete other data linked whit the TeamsData such as character.

        teamsId.RemoveAt(teamIndex);
        teamsName.RemoveAt(teamIndex);
    }



    #region INTER SCREEN PARAM
    public int ExtraParam_TeamId {
        get { return extraParam_TeamId;  }
        set { extraParam_TeamId = value; }
    }
    #endregion
}