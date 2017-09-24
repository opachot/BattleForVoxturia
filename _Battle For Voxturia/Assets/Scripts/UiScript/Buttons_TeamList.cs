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
    private TeamsData   teamsData;

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
    }
	
	void Start() {
        teamsData   = GameObject.FindGameObjectWithTag("GameData").GetComponent<TeamsData>();
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
        string newName     = newTeamName_inputField.text;
        bool   isValidName = ValidateName(newName);

        if(isValidName) {
            teamsData.AddNewTeam(newName);

            // TODO: Reload the teamList board.

            CloseCreateNewTeamPopUp();
        }
    }

    public void CancelCreationButton() {
        CloseCreateNewTeamPopUp();
    }

    private void CloseCreateNewTeamPopUp() {
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

        if(!IsAvailableName(newName)) {
            TrowError("Error: The name is already taken");
            isValidName = false;
        }
        else if(!IsMoralName(newName)) {
            TrowError("Error: The name is inappropriate");
            isValidName = false;
        }

        return isValidName;
    }

    private bool IsAvailableName(string newName) {
        bool isAvailableName = !teamsData.IsExistingName(newName);

        return isAvailableName;
    }

    private bool IsMoralName(string newName) {
        // TODO
        return true;
    }


    private void TrowError(string error) {
        errorText.text = error;
        error_popUp.SetActive(true);
    }
    #endregion
}