/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    19 September 2017
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour {

	#region DECLARATION
    // CONST

    // PRIVATE
    private TeamsData      teamsData;
    private CharactersData charactersData;

    // PUBLIC

    #endregion

	#region UNITY METHODE
	void Awake() {
        DontDestroyOnLoad(gameObject);

        GameObject gameData = GameObject.FindGameObjectWithTag("GameData");
		teamsData      = gameData.GetComponent<TeamsData>();
        charactersData = gameData.GetComponent<CharactersData>();
    }
	
	void Start() {
		
	}
	
	void Update() {
		
	}
    #endregion


    public void NavigateTo_Hub() {
        SceneManager.LoadScene("Hub");
    }

    public void NavigateTo_TeamList() {
        SceneManager.LoadScene("TeamList");
    }

    public void NavigateTo_Shop() {
        SceneManager.LoadScene("Shop");
    }

    public void NavigateTo_Option() {
        SceneManager.LoadScene("Option");
    }

    public void NavigateTo_WorldMap() {
        SceneManager.LoadScene("WorldMap");
    }

    public void NavigateTo_DiscoveredItems() {
        SceneManager.LoadScene("DiscoveredItems");
    }

    public void NavigateTo_Help() {
        SceneManager.LoadScene("Help");
    }

    public void NavigateTo_TeamScreen(int teamId) {
        teamsData.ExtraParam_Id = teamId;

        SceneManager.LoadScene("TeamScreen");
    }

    public void NavigateTo_NewCharacterCreation(int teamId) {
        charactersData.ExtraParam_TeamId = teamId;
        SceneManager.LoadScene("NewCharacterCreation");
    }

    public void NavigateTo_CharacterReserve(int teamId) {
        charactersData.ExtraParam_TeamId = teamId;
        SceneManager.LoadScene("CharacterReserve");
    }

    public void NavigateTo_CharacterCustomisation(int teamId, int characterId) {
        charactersData.ExtraParam_TeamId      = teamId;
        charactersData.ExtraParam_CharacterId = characterId;
        SceneManager.LoadScene("CharacterReserve");
    }


    public void QuitGame() {
        Application.Quit();
    }
}