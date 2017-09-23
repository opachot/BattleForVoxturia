/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    20 September 2017
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons_TeamList : MonoBehaviour {

    #region DECLARATION
    // CONST
    private const int MIN_TEAM_NAME_LENGTH = 3;

    // PRIVATE
    private Navigation navigation;
    private GameData   gameData;

    // PUBLIC
    public GameObject createNewTeam_popUp;
    public GameObject error_popUp;

    public InputField newTeamName_inputField;

    public Button createTeam_btn;

    public Text errorText;

    #endregion

    #region UNITY METHODE
    void Awake() {
        navigation = gameObject.GetComponent<Navigation>();
        gameData   = GameObject.FindGameObjectWithTag("GameData").GetComponent<GameData>();
    }
	
	void Start() {
        
	}
	
	void Update() {
		
	}
    #endregion


    #region Default buttons
    public void CreateNewTeamButton() {
        createNewTeam_popUp.SetActive(true);
    }

    public void ReturnButton() {
        navigation.NavigateTo_Hub();
    }
    #endregion

    #region CreateNewTeam popUp buttons
    public void CreateTeamButton() {
        string newName      = newTeamName_inputField.text;
        bool   isValidName = ValidateName(newName);

        if(isValidName) {
            // TODO: Fix the updating of the GameData, save file should use List insted of array.
            // (Beacus if we delete a team, the value will get fucked...)
            // Warning: Serialising List is inneficient, will need to search how to make it performent.
            int emptyIndex = gameData.TeamsId.Length;
            int lastIndex   = gameData.TeamsId[emptyIndex - 1];
            int newId       = lastIndex + 1;

            gameData.TeamsId   [emptyIndex] = newId;
            gameData.TeamsNames[emptyIndex] = newName;

            // TODO: Reload the teamList board.


            // Reset the popUp.
            newTeamName_inputField.text = "";
            createTeam_btn.interactable = false;

            createNewTeam_popUp.SetActive(false);
        }
    }

    public void CancelCreationButton() {
        // Reset the popUp.
        newTeamName_inputField.text = "";
        createTeam_btn.interactable = false;

        createNewTeam_popUp.SetActive(false);
    }
    #endregion

    #region Error popUp buttons
    public void ErrorOkButton() {
        error_popUp.SetActive(false);
        errorText.text = "Unknown Error";
    }
    #endregion


    public void OnInputFieldValueChanged() {
        UpdateCreateTeamButton();
    }

    private void UpdateCreateTeamButton() {
        bool isValidNameLength = newTeamName_inputField.text.Length < MIN_TEAM_NAME_LENGTH;

        if(isValidNameLength) {
            createTeam_btn.interactable = false;
        }
        else {
            createTeam_btn.interactable = true;
        }
    }

    #region Error validation
    private bool ValidateName(string newName) {
        bool isValidName = true;

        if(!IsAvailableName()) {
            TrowError("Error: The name is already taken");
            isValidName = false;
        }
        else if(!IsMoralName()) {
            TrowError("Error: The name is inappropriate");
            isValidName = false;
        }

        return isValidName;
    }

    private bool IsAvailableName() {
        // TODO
        return true;
    }

    private bool IsMoralName() {
        // TODO
        return true;
    }


    private void TrowError(string error) {
        errorText.text = error;
        error_popUp.SetActive(true);
    }
    #endregion
}