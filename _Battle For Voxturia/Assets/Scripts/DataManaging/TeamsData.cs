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

    // PUBLIC
    public List<int>    teamsId;
    public List<string> teamsNames;
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
        teamsNames.Add(teamName);
    }

    public bool IsExistingName(string name) {
        name = name.ToLower();
        bool isExistingName = false;

        foreach(string teamName in teamsNames) {
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
        teamsNames.RemoveAt(teamIndex);
    }
}