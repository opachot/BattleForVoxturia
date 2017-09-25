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
    private ResourceLoader resourceLoader;
    private Navigation     navigation;
    private TeamsData      teamsData;

    private Transform list;

    private Transform deleteConfirmationPopUp_SelectedTeam;

    // PUBLIC
    public GameObject createNewTeam_PopUp;
    public GameObject deleteConfirmaton_PopUp;
    public GameObject error_PopUp;

    public InputField newTeamName_inputField;

    public Button createTeam_btn;

    public Text deleteConfirmationMessage; 
    public Text errorMessage;

    #endregion

    #region UNITY METHODE
    void Awake() {
        resourceLoader = gameObject.GetComponent<ResourceLoader>();
        navigation     = gameObject.GetComponent<Navigation>();
        teamsData      = GameObject.FindGameObjectWithTag("GameData").GetComponent<TeamsData>();

        list = GameObject.Find("List").GetComponent<Transform>();
    }
	
	void Start() {
        GenerateTeamsList();
	}
	
	void Update() {
		
	}
    #endregion


    #region Default buttons
    public void CreateNewTeamButton() {
        createNewTeam_PopUp.SetActive(true);
    }

    public void ReturnButton() {
        navigation.NavigateTo_Hub();
    }

    public void TeamNameButton(Transform selectedTeam) {
        int selectedTeamIndex = FindSelectedTeamIndex(selectedTeam);

        int selectedTeamId = teamsData.teamsId[selectedTeamIndex];
        navigation.NavigateTo_SelectedTeam(selectedTeamId);
    }

    public void TeamDeleteButton(Transform selectedTeam) {
        int selectedTeamIndex   = FindSelectedTeamIndex(selectedTeam);
        string selectedTeamName = teamsData.teamsNames[selectedTeamIndex];

        deleteConfirmationPopUp_SelectedTeam = selectedTeam;
        deleteConfirmationMessage.text = "Do you really want to delete \n" + '"' + selectedTeamName + '"' + "?";
        deleteConfirmaton_PopUp.SetActive(true);
    }
    #endregion

    #region CreateNewTeam popUp buttons
    public void CreateTeamButton() {
        string newName     = newTeamName_inputField.text;
        bool   isValidName = ValidateName(newName);

        if(isValidName) {
            teamsData.CreateNewTeam(newName);

            UpdateTeamsList();

            CloseCreateNewTeamPopUp();
        }
    }

    public void CancelCreationButton() {
        CloseCreateNewTeamPopUp();
    }

    private void CloseCreateNewTeamPopUp() {
        newTeamName_inputField.text = "";
        createTeam_btn.interactable = false;

        createNewTeam_PopUp.SetActive(false);
    }
    #endregion

    #region DeleteConfirmation popUp buttons
    public void YesDeleteButton() {
        int selectedTeamIndex = FindSelectedTeamIndex(deleteConfirmationPopUp_SelectedTeam);

        teamsData.DeleteTeam(selectedTeamIndex);
        UpdateTeamsList();

        deleteConfirmaton_PopUp.SetActive(false);
    }

    public void NoDeleteButton() {
        deleteConfirmaton_PopUp.SetActive(false);
    }
    #endregion

    #region Error popUp buttons
    public void ErrorOkButton() {
        error_PopUp.SetActive(false);
        errorMessage.text = "Unknown Error";
    }
    #endregion


    #region Update teams list
    private void UpdateTeamsList() {
        CleanTeamsList();
        GenerateTeamsList();
    }

    private void CleanTeamsList() {
        foreach(Transform team in list) {
            Destroy(team.gameObject);
        }
    }

    private void GenerateTeamsList() {
        int nbRegisteredTeam = teamsData.teamsId.Count;

        for(int i = 0; i < nbRegisteredTeam; i++) {
            InstantiateTeamInTeamsList(i);
        }
    }

    private void InstantiateTeamInTeamsList(int teamIndex) {
        Transform listElement = Instantiate(resourceLoader.teamListingElement).transform;
        listElement.SetParent(list);

        FixListElementButton(listElement, teamIndex);
    }

    private void FixListElementButton(Transform listElement, int teamIndex) {
        // Set teamNameButton onClick event.
        Button teamNameButton   = listElement.Find("Redirect_btn").GetComponent<Button>();
        teamNameButton.onClick.AddListener(()   => TeamNameButton(listElement));

        // Set teamDeleteButton onClick event.
        Button teamDeleteButton = listElement.Find("Delete_btn").GetComponent<Button>();
        teamDeleteButton.onClick.AddListener(() => TeamDeleteButton(listElement));

        // Set TeamName on button.
        Text listElementTeamName = teamNameButton.transform.GetChild(0).GetComponent<Text>();
        listElementTeamName.text = teamsData.teamsNames[teamIndex];
    }
    #endregion

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
        errorMessage.text = error;
        error_PopUp.SetActive(true);
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


    private int FindSelectedTeamIndex(Transform selectedTeam) {
        int selectedTeamIndex = 0;

        int index = 0;
        foreach(Transform team in list) {
            bool selectedTeamFound = team == selectedTeam;

            if(selectedTeamFound) {
                selectedTeamIndex = index;
                break;
            }

            index++;
        }

        return selectedTeamIndex;
    }
}