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

    private ErrorManager errorManager;

    // PUBLIC

    #endregion

	#region UNITY METHODE
	void Awake() {
        DontDestroyOnLoad(gameObject);

        GameObject gameData = GameObject.FindGameObjectWithTag("GameData");
		teamsData      = gameData.GetComponent<TeamsData>();
        charactersData = gameData.GetComponent<CharactersData>();

        errorManager = GameObject.FindGameObjectWithTag("ErrorManager").GetComponent<ErrorManager>();
    }
	
	void Start() {
		
	}
	
	void Update() {
		
	}
    #endregion


    public void NavigateTo_Hub() {
        PrepareToSceneSwitch();

        SceneManager.LoadScene("Hub");
    }

    public void NavigateTo_TeamList() {
        PrepareToSceneSwitch();

        SceneManager.LoadScene("TeamList");
    }

    public void NavigateTo_Shop() {
        PrepareToSceneSwitch();

        SceneManager.LoadScene("Shop");
    }

    public void NavigateTo_Option() {
        PrepareToSceneSwitch();

        SceneManager.LoadScene("Option");
    }

    public void NavigateTo_WorldMap() {
        PrepareToSceneSwitch();

        SceneManager.LoadScene("WorldMap");
    }

    public void NavigateTo_DiscoveredItems() {
        PrepareToSceneSwitch();

        SceneManager.LoadScene("DiscoveredItems");
    }

    public void NavigateTo_Help() {
        PrepareToSceneSwitch();

        SceneManager.LoadScene("Help");
    }

    public void NavigateTo_TeamScreen(int teamId) {
        PrepareToSceneSwitch();

        teamsData.ExtraParam_Id = teamId;
        SceneManager.LoadScene("TeamScreen");
    }

    public void NavigateTo_NewCharacterCreation(int teamId) {
        PrepareToSceneSwitch();

        charactersData.ExtraParam_TeamId = teamId;
        SceneManager.LoadScene("NewCharacterCreation");
    }

    public void NavigateTo_CharacterReserve(int teamId) {
        PrepareToSceneSwitch();

        charactersData.ExtraParam_TeamId = teamId;
        SceneManager.LoadScene("CharacterReserve");
    }

    public void NavigateTo_CharacterCustomisation(int teamId, int characterId) {
        PrepareToSceneSwitch();

        charactersData.ExtraParam_TeamId      = teamId;
        charactersData.ExtraParam_CharacterId = characterId;
        SceneManager.LoadScene("CharacterCustomisation");
    }


    public void QuitGame() {
        Application.Quit();
    }


    private void PrepareToSceneSwitch() {
        errorManager.PlaceErrorPopUpInDontDestroyOnLoad();
    }
}