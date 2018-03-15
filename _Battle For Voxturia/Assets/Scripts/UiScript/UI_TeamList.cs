/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    20 September 2017
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class UI_TeamList : MonoBehaviour {

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

    public InputField newTeamName_inputField;

    public Button createTeam_btn;

    public TMP_Text noTeamText;

    public TMP_Text deleteConfirmationMessage;
    #endregion

    #region UNITY METHODE
    void Awake() {
        resourceLoader = GameObject.FindGameObjectWithTag("RessourceLoader").GetComponent<ResourceLoader>();
        navigation     = GameObject.FindGameObjectWithTag("Navigation")     .GetComponent<Navigation>();
        teamsData      = GameObject.FindGameObjectWithTag("GameData")       .GetComponent<TeamsData>();

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
        bool   isValidTeam = teamsData.ValidateCreation(newName);

        if(isValidTeam) {
            teamsData.CreateNewTeam(newName);
            int newTeamId = teamsData.ids.Last();

            navigation.NavigateTo_TeamScreen(newTeamId);
        }
    }

    public void CancelCreationButton() {
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

        ManagingEmptyListMsg();

        for(int i = 0; i < nbRegisteredTeam; i++) {
            InstantiateTeamInTeamsList(i);
        }
    }

    private void ManagingEmptyListMsg() {
        int nbRegisteredTeam = teamsData.ids.Count;

        if(nbRegisteredTeam > 0) {
            // Hide
            noTeamText.gameObject.SetActive(false);
        }
        else {
            // Show
            noTeamText.gameObject.SetActive(true);
        }
    }

    private void InstantiateTeamInTeamsList(int teamIndex) {
        Transform listElement = Instantiate(resourceLoader.teamListingElement, list).transform;

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
        usedTeamColor.normalColor = HelpingMethod.ConvertToDecimalColor(0, 150, 50, 255);

        // Apply visual indicator.
        teamNameButton.colors   = usedTeamColor;
        teamDeleteButton.colors = usedTeamColor;
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