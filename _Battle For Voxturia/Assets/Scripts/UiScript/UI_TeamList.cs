/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    20 September 2017
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_TeamList : MonoBehaviour {

    #region DECLARATION
    // CONST
    private const int MIN_TEAM_NAME_LENGTH = 3;

    // PRIVATE
    private ResourceLoader resourceLoader;
    private Navigation     navigation;
    private ErrorManager   errorManager;
    private TeamsData      teamsData;

    private Transform list;

    private Transform deleteConfirmationPopUp_SelectedTeam;

    // PUBLIC
    public GameObject createNewTeam_PopUp;
    public GameObject deleteConfirmaton_PopUp;

    public InputField newTeamName_inputField;

    public Button createTeam_btn;

    public Text deleteConfirmationMessage; 
    public Text errorMessage;

    #endregion

    #region UNITY METHODE
    void Awake() {
        resourceLoader = gameObject.GetComponent<ResourceLoader>();
        navigation     = gameObject.GetComponent<Navigation>();
        errorManager   = gameObject.GetComponent<ErrorManager>();
        teamsData      = GameObject.FindGameObjectWithTag("GameData").GetComponent<TeamsData>();

        list = GameObject.Find("List").GetComponent<Transform>();
    }
	
	void Start() {
        GenerateTeamsList();
	}
	
	void Update() {
		
	}
    #endregion


    private int FindSelectedTeamDataKey(Transform selectedTeam) {
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

    #region Default buttons
    public void CreateNewTeamButton() {
        createNewTeam_PopUp.SetActive(true);

        newTeamName_inputField.Select();
    }

    public void ReturnButton() {
        navigation.NavigateTo_Hub();
    }

    public void TeamNameButton(Transform selectedTeam) {
        int selectedTeamDataKey = FindSelectedTeamDataKey(selectedTeam);

        int selectedTeamId = teamsData.ids[selectedTeamDataKey];
        navigation.NavigateTo_TeamScreen(selectedTeamId);
    }

    public void TeamDeleteButton(Transform selectedTeam) {
        int selectedTeamDataKey   = FindSelectedTeamDataKey(selectedTeam);
        string selectedTeamName = teamsData.names[selectedTeamDataKey];

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
        int teamDataKey = FindSelectedTeamDataKey(deleteConfirmationPopUp_SelectedTeam);

        teamsData.DeleteTeam(teamDataKey);
        UpdateTeamsList();

        deleteConfirmaton_PopUp.SetActive(false);
    }

    public void NoDeleteButton() {
        deleteConfirmaton_PopUp.SetActive(false);
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
        int nbRegisteredTeam = teamsData.ids.Count;

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
        listElementTeamName.text = teamsData.names[teamIndex];

        // Show a visual indicator to show the used team.
        if(IsUsedTeam(teamIndex)) {
            ShowUsedTeam(teamNameButton, teamDeleteButton);
        }
    }

    private bool IsUsedTeam(int teamIndex) {
        bool isUsedTeam = teamsData.ids[teamIndex] == teamsData.usedTeamId;

        return isUsedTeam;
    }

    private void ShowUsedTeam(Button teamNameButton, Button teamDeleteButton) {
        // Define visual indicator.
        ColorBlock usedTeamColor  = teamNameButton.colors;
        usedTeamColor.normalColor = ConvertToDecimalColor(0, 150, 50, 255);

        // Apply visual indicator.
        teamNameButton.colors   = usedTeamColor;
        teamDeleteButton.colors = usedTeamColor;
    }

    private Vector4 ConvertToDecimalColor(float r, float g, float b, float a) {
        Vector4 color = new Vector4(r/255.0f, g/255.0f, b/255.0f, a/255.0f);
        return  color;
    }
    #endregion

    #region ValidateName
    private bool ValidateName(string newName) {
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

    private bool IsAvailableName(string newName) {
        bool isAvailableName = !teamsData.IsExistingName(newName);

        return isAvailableName;
    }

    private bool IsMoralName(string newName) {
        // TODO
        return true;
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
}