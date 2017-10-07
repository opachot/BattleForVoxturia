/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    07 October 2017
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_NewCharacterCreation : MonoBehaviour {

	#region DECLARATION
    // CONST

    // PRIVATE
    private ResourceLoader resourceLoader;
    private Navigation     navigation;
    private ErrorManager   errorManager;

    private TeamsData      teamsData;
    private CharactersData charactersData;

    private int currentTeamId;

    // keep in memory the clicked class name for the creation process.
    private string clickedClassName;

    // PUBLIC

    #endregion

	#region UNITY METHODE
	void Awake() {
		resourceLoader = GameObject.FindGameObjectWithTag("RessourceLoader").GetComponent<ResourceLoader>();
        navigation     = GameObject.FindGameObjectWithTag("Navigation")     .GetComponent<Navigation>();
        errorManager   = gameObject.GetComponent<ErrorManager>();

        GameObject gameData = GameObject.FindGameObjectWithTag("GameData");
        teamsData      = gameData.GetComponent<TeamsData>();
        charactersData = gameData.GetComponent<CharactersData>();
    }
	
	void Start() {
		UseExtraParam();
	}
	
	void Update() {
		
	}
    #endregion

    #region Initialisation
    private void UseExtraParam() {
        currentTeamId = teamsData.ExtraParam_Id;
        teamsData.ExtraParam_Id = 0;
    }
    #endregion

    #region Default buttons
    public void ClassButton(string className) {
        clickedClassName = className;

        // Open class info pop-up.
    }

    public void CreateCharacterButton() {
        // Verifi if all condition are meet (character name at lest 3 lenght, a selected class.)
        // if condition not meet: activate error pop-up insted.

        // Create (private param clickedClassName will be saved in the char className field, 
        // no need to use the class Switch() condition)

        navigation.NavigateTo_TeamScreen(currentTeamId);
    }

    public void CancelButton() {
        navigation.NavigateTo_TeamScreen(currentTeamId);
    }
    #endregion

    #region ClassInfoButton
    public void SelectClassButton() {
        

        // select the class (hightlight?)

        ClosePopUpClassInfo();
    }

    public void CancelClassInfoButton() {
        ClosePopUpClassInfo();
    }


    private void ClosePopUpClassInfo() {
        // Close pop-up.
    }
    #endregion
}