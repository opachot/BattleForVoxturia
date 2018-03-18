/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    26 September 2017
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_TeamScreen : MonoBehaviour {

	#region DECLARATION
    // CONST

    // PRIVATE
    private ResourceLoader resourceLoader;
    private Navigation     navigation;

    private TeamsData      teamsData;
    private CharactersData charactersData;

    private int currentTeamId;
    private int currentTeamDataKey;
    List<int>   teamCharacterKeys;

    // keep in memory the clicked character key and id for the other pop-up.
    private int clickedCharacterKey;
    private int clickedCharacterId;

    // PUBLIC
    public GameObject editCharacterMenu_PopUp;
    public GameObject addCharacterMenu_PopUp;
    public GameObject deleteConfirmaton_PopUp;

    public Button characterSlot1_btn;
    public Button characterSlot2_btn;
    public Button characterSlot3_btn;
    public Button characterSlot4_btn;

    public Button selectTeam_btn;

    public TMP_Text screenTitle;

    public TMP_Text statsLevel;
    public TMP_Text statsXp;
    public TMP_Text statsVictory;
    public TMP_Text statsDefeat;
    public TMP_Text statsMatch;
    public TMP_Text statsVDRatio;
    public TMP_Text statsCost;

    public TMP_Text deleteConfirmationMessage;

    #endregion

	#region UNITY METHODE
	void Awake() {
		resourceLoader = GameObject.FindGameObjectWithTag("RessourceLoader").GetComponent<ResourceLoader>();
        navigation     = GameObject.FindGameObjectWithTag("Navigation")     .GetComponent<Navigation>();

        GameObject gameData = GameObject.FindGameObjectWithTag("GameData");
        teamsData      = gameData.GetComponent<TeamsData>();
        charactersData = gameData.GetComponent<CharactersData>();
    }
	
	void Start() {
        UseExtraParam();
        currentTeamDataKey = teamsData.FindTeamDataKey(currentTeamId);

        UpdateSelectAndUnselectTeamBtn();

        ShowTeamName();
        ShowTeamStats();

        LoadTeamCharacters();
	}

    void Update() {
		
	}
    #endregion


    #region Initialisation
    private void UseExtraParam() {
        currentTeamId = teamsData.ExtraParam_Id;
        teamsData.ExtraParam_Id = 0;
    }

    private void FindCharactersDataKeys() {
        int nbCharacter = charactersData.ids.Count;

        for(int i = 0; i < nbCharacter; i++) {
            if(charactersData.teamDataIds[i] == currentTeamId) {
                teamCharacterKeys.Add(i);
            }
        }
    }


    private void ShowTeamName() {
        string teamName = teamsData.names[currentTeamDataKey];

        screenTitle.text = teamName;
    }

    private void ShowTeamStats() {
        // Get the data
        int   teamLevel     = teamsData.levels      [currentTeamDataKey];
        int   teamCurrentXp = teamsData.currentXps  [currentTeamDataKey];
        int   teamGoalXp    = teamsData.goalXps     [currentTeamDataKey];
        int   teamVictory   = teamsData.victorys    [currentTeamDataKey];
        int   teamDefeat    = teamsData.defeats     [currentTeamDataKey];
        int   teamMatch     = teamVictory + teamDefeat;
        float teamVDRatio   = CalculatingVDRatio(teamVictory, teamDefeat);

        // Calculating % xp
        int xpPercentage = Mathf.RoundToInt((teamCurrentXp * 1.0f / teamGoalXp * 1.0f) * 100);

        // Use the data on the Team Stats display.
        statsLevel  .text = teamLevel    .ToString();
        statsXp     .text = teamCurrentXp.ToString() + " / " + teamGoalXp + " (" + xpPercentage + "%)";
        statsVictory.text = teamVictory  .ToString();
        statsDefeat .text = teamDefeat   .ToString();
        statsMatch  .text = teamMatch    .ToString();
        statsVDRatio.text = teamVDRatio  .ToString();

        ShowTeamCost();
    }

    private void ShowTeamCost() {
        // Get the data
        int teamCurrentCost = teamsData.GetTeamCost(currentTeamId);
        int teamMaxCost     = teamsData.maxCosts[currentTeamDataKey];

        statsCost.text = teamCurrentCost.ToString() + " / " + teamMaxCost;

        if(teamCurrentCost > teamMaxCost) {
            // Red (Unselectable)
            statsCost.color = HelpingMethod.ConvertToDecimalColor(150, 0, 0, 255);
        }
        else {
            // Black (Selectable)
            statsCost.color = HelpingMethod.ConvertToDecimalColor(50, 50, 50, 255);
        }
    }

    private void ShowCharactersFeature() {
        Button[] charactersButtons = {characterSlot1_btn,
                                      characterSlot2_btn,
                                      characterSlot3_btn,
                                      characterSlot4_btn};

        for(int i = 0; i < charactersButtons.Length; i++) {
            bool isCharacterExisting = i < teamCharacterKeys.Count;

            Image      buttonIcon    = charactersButtons[i].transform.Find("Icon")         .GetComponent<Image>();
            GameObject nameBox       = charactersButtons[i].transform.Find("NameBox")      .gameObject;
            TMP_Text   nameBoxText   = nameBox             .transform.Find("CharacterName").GetComponent<TMP_Text>();
            TMP_Text   characterCost = charactersButtons[i].transform.Find("CharacterCost").GetComponent<TMP_Text>();

            if(isCharacterExisting) {
                // Set class icon.
                buttonIcon.sprite = charactersData.GetCharacterIcon(charactersData.classNames[teamCharacterKeys[i]]);

                // Set character name.
                nameBoxText.text = charactersData.names[teamCharacterKeys[i]];

                // Set character cost.
                characterCost.text = "Cost: " + charactersData.costs[teamCharacterKeys[i]];
            }
            else {
                // Set default icon.
                buttonIcon.sprite = resourceLoader.addCharacterIconClass;

                // Hide nameBox.
                nameBox.SetActive(false);

                // Hide character cost.
                characterCost.gameObject.SetActive(false);
            }
        }
    }
    #endregion

    #region Default buttons
    public void AddCharacterButton(int slotNumber) {
        bool isCharacterOnSlot = slotNumber <= teamCharacterKeys.Count;

        if(isCharacterOnSlot) {
            int keyIndex = slotNumber - 1;

            // Keep the info for the popUps.
            clickedCharacterKey = teamCharacterKeys[keyIndex];
            clickedCharacterId  = charactersData.ids[clickedCharacterKey];

            editCharacterMenu_PopUp.SetActive(true);
        }
        else {
            VeryfiyingChooseCharacterInReserveBtnInteractibility();
            addCharacterMenu_PopUp.SetActive(true);
        }
    }

    public void SelectAndUnselectTeamButton() {
        bool isTeamAlreadySelected = currentTeamId == teamsData.usedTeamId;

        // Unselect.
        if(isTeamAlreadySelected) {
            teamsData.usedTeamId = 0;
            UpdateSelectAndUnselectTeamBtn();
        }
        // Select.
        else { 
            bool isValidTeam = teamsData.ValidateTeamSelectable(currentTeamDataKey, currentTeamId, true);

            if(isValidTeam) {
                teamsData.usedTeamId = currentTeamId;
                UpdateSelectAndUnselectTeamBtn();
            }    
        }  
    }

    public void ReturnButton() {
        navigation.NavigateTo_TeamList();
    }
    #endregion

    #region editCharacterMenu popUp buttons
    public void ModifyCharacterButton() {
        navigation.NavigateTo_CharacterCustomisation(currentTeamId, clickedCharacterId);
    }

    public void RemoveCharacterFromTeamButton() {
        // Remove in the data the link to team.
        charactersData.teamDataIds[clickedCharacterKey] = 0;

        // Reload (character display) + (Team cost).
        LoadTeamCharacters();
        ShowTeamCost();

        // Unselect current team if necessary.
        teamsData.UpdateValideSelectedTeam(currentTeamDataKey, currentTeamId);
        UpdateSelectAndUnselectTeamBtn();

        CloseEditCharacterMenuPopUp();
    }

    public void DeleteCharacterButton() {
        string characterName = charactersData.names[clickedCharacterKey];

        deleteConfirmationMessage.text = "Do you really want to delete \n" + '"' + characterName + '"' + "?";
        deleteConfirmaton_PopUp.SetActive(true);
    }

    public void CancelEditCharacterMenuButton() {
        CloseEditCharacterMenuPopUp();
    }


    private void CloseEditCharacterMenuPopUp() {
        editCharacterMenu_PopUp.SetActive(false);
    }
    #endregion

    #region addCharacterMenu popUp buttons
    public void CreateCharacterButton() {
        navigation.NavigateTo_NewCharacterCreation(currentTeamId);
    }

    public void ChooseExistingCharacterButton() {
        navigation.NavigateTo_CharacterReserve(currentTeamId);
    }

    public void CancelAddCharacterMenuButton() {
        CloseAddCharacterMenuPopUp();
    }


    private void VeryfiyingChooseCharacterInReserveBtnInteractibility() {
        Button chooseCharacterInReserve_btn = addCharacterMenu_PopUp.transform.FindDeepChild("Choose_btn").GetComponent<Button>();

        // Disable by default.
        chooseCharacterInReserve_btn.interactable = false;

        // Should be interactable?
        for(int i = 0; i < charactersData.ids.Count; i++) {
            bool isCharacterInReserve = charactersData.teamDataIds[i] == 0; 

            if(isCharacterInReserve) {
                chooseCharacterInReserve_btn.interactable = true;
                break;
            }
        }
    }

    private void CloseAddCharacterMenuPopUp() {
        addCharacterMenu_PopUp.SetActive(false);
    }
    #endregion

    #region DeleteConfirmation popUp buttons
    public void YesDeleteButton() {
        charactersData.DeleteCharacter(clickedCharacterKey);

        // Reload (character display) + (Team cost).
        LoadTeamCharacters();
        ShowTeamCost();

        // Unselect current team if necessary.
        teamsData.UpdateValideSelectedTeam(currentTeamDataKey, currentTeamId);
        UpdateSelectAndUnselectTeamBtn();

        deleteConfirmaton_PopUp.SetActive(false);
        CloseEditCharacterMenuPopUp();
        clickedCharacterId = 0;
    }

    public void NoDeleteButton() {
        deleteConfirmaton_PopUp.SetActive(false);
    }
    
    #endregion


    private float CalculatingVDRatio(int teamVictory, int teamDefeat) {
        float ratio;

        // (Protect from divided by 0 exeption)
        if(teamDefeat == 0) {
            if(teamVictory == 0) {
                // No match played.
                ratio = 1;
            }
            else {
                ratio = teamVictory;
            }
        }
        else {
            ratio = (float)teamVictory / teamDefeat;

            // Round to 2 decimal.
            ratio = Mathf.Round(ratio * 100f) / 100f;
        }

        return ratio;
    }

    private void LoadTeamCharacters() {
        teamCharacterKeys = new List<int>();

        FindCharactersDataKeys();
        ShowCharactersFeature();
    }

    private void UpdateSelectAndUnselectTeamBtn() {
        bool isTeamAlreadySelected = currentTeamId == teamsData.usedTeamId;

        if(isTeamAlreadySelected) {
            selectTeam_btn.transform.Find("Text").GetComponent<TMP_Text>().text = "Unselect team";
        }
        else {
            selectTeam_btn.transform.Find("Text").GetComponent<TMP_Text>().text = "Select team";
        }
    }
}