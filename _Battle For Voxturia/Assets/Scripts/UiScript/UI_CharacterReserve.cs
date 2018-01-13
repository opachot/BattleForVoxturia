/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    09 January 2018
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_CharacterReserve : MonoBehaviour {

	#region DECLARATION
    // CONST

    // PRIVATE
    private ResourceLoader resourceLoader;
    private Navigation     navigation;
    private CharactersData charactersData;
    private TeamsData      teamsData;
    private ErrorManager   errorManager;

    private Transform list;

    private List<Transform> charactersButtons;
    private List<int>       charactersKeys;

    private int currentTeamId;
    private int selectedCharacterDataKey;
    private Button highlightedCharacterButton;

    // PUBLIC
    [Header("Character Info Section")]
    public Text       characterName;
    public GameObject characterIcon;
    public Button     deleteCharacter_btn;
    [Space(10)]

    [Header("Delete Confirmation Pop-Up")]
    public GameObject deleteConfirmation_PopUp;
    public Text       deleteConfirmationMessage; 

    #endregion

	#region UNITY METHODE
	void Awake() {
		resourceLoader = GameObject.FindGameObjectWithTag("RessourceLoader").GetComponent<ResourceLoader>();
        navigation     = GameObject.FindGameObjectWithTag("Navigation")     .GetComponent<Navigation>();
        charactersData = GameObject.FindGameObjectWithTag("GameData")       .GetComponent<CharactersData>();
        teamsData      = GameObject.FindGameObjectWithTag("GameData")       .GetComponent<TeamsData>();
        errorManager   = GameObject.FindGameObjectWithTag("ErrorManager")   .GetComponent<ErrorManager>();

        list = GameObject.Find("List").GetComponent<Transform>();

        charactersButtons = new List<Transform>();
        charactersKeys    = new List<int>();
    }
	
	void Start() {
        UseExtraParam();
		GenerateCharactersList();
	}
	
	void Update() {
		
	}
    #endregion


    #region Default buttons
    public void SelectCharacter() {
        if(!IsClassAlreadyInTeam()) {
            // Put the character in the team.
            charactersData.teamDataIds[selectedCharacterDataKey] = currentTeamId;
            
            // Unselect current team if necessary.
            int teamDataKey = teamsData.FindTeamDataKey(currentTeamId);
            teamsData.UpdateValideSelectedTeam(teamDataKey, currentTeamId);

            navigation.NavigateTo_TeamScreen(currentTeamId);
        }
        else {
            errorManager.TrowError("Error: The class already exist in the team.");
        }
    }

    public void CancelButton() {
        navigation.NavigateTo_TeamScreen(currentTeamId);
    }

    public void CharacterButton(Transform selectedCharacter) {
        selectedCharacterDataKey = FindSelectedCharacterDataKey(selectedCharacter);

        ModifieCharacterButtonVisual(selectedCharacter);


        // TODO: Load the character info section.


        // Fix the button glitch that make it staying highlighted.
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void DeleteCharacterButton() {
        string characterName = "";                // TODO: Find a way to get the character name to delete.

        deleteConfirmationMessage.text = "Do you really want to delete \n" + '"' + characterName + '"' + "?";
        deleteConfirmation_PopUp.SetActive(true);
    }
    #endregion

    #region DeleteConfirmation popUp buttons
    public void YesDeleteButton() {
        // TODO: int characterDataKey = FindSelectedCharacterDataKey(selectedCharacterIcon);

        // TODO: charactersData.DeleteCharacter(key);

        // TODO: Clean character info section.
        // TODO: UpdateCharactersList();

        deleteConfirmation_PopUp.SetActive(false);
    }

    public void NoDeleteButton() {
        deleteConfirmation_PopUp.SetActive(false);
    }
    #endregion

    #region Character list generation
    private void GenerateCharactersList() {
        for(int i = 0; i < charactersData.ids.Count; i++) {
            bool isCharacterInReserve = charactersData.teamDataIds[i] == 0; 

            if(isCharacterInReserve) {
                charactersKeys.Add(i);

                InstantiateCharacterInList(i);
            }
        }
    }

    private void InstantiateCharacterInList(int characterIndex) {
        Transform listElement = Instantiate(resourceLoader.characterReserveListingElement, list).transform;
        charactersButtons.Add(listElement);

        FixListElementButton(listElement, characterIndex);
    }

    private void FixListElementButton(Transform listElement, int characterIndex) {
        // Set characterButton onClick event.
        Button characterButton = listElement.GetComponent<Button>();
        characterButton.onClick.AddListener(()   => CharacterButton(listElement));

        // Set characterButton Icon.
        Image  characterButtonIcon = listElement.Find("Icon").GetComponent<Image>();
        string className = charactersData.classNames[characterIndex];
        Sprite classIcon = charactersData.GetCharacterIcon(className);

        characterButtonIcon.sprite = classIcon;

        // Set characterButton nameBox.
        Text   characterButtonNameBox = listElement.FindDeepChild("CharacterName").GetComponent<Text>();
        string characterName = charactersData.names[characterIndex];

        characterButtonNameBox.text = characterName;
    }
    #endregion


    private void UseExtraParam() {
        currentTeamId = charactersData.ExtraParam_TeamId;
        charactersData.ExtraParam_TeamId = 0;
    }

    private int FindSelectedCharacterDataKey(Transform selectedCharacter) {
        int characterKeyIndex = 0;

        for(int i = 0; i < charactersButtons.Count; i++) {
            bool isButtonIndexFound = charactersButtons[i] == selectedCharacter;

            if(isButtonIndexFound) {
                characterKeyIndex = i;
                break;
            }
        }

        int selectedCharacterDataKey = charactersKeys[characterKeyIndex];
        return selectedCharacterDataKey;
    }


    private bool IsClassAlreadyInTeam() {
        bool isClassAlreadyInTeam = false;

        for(int i = 0; i < charactersData.ids.Count; i++) {
            bool isCharacterInTeam = charactersData.teamDataIds[i] == currentTeamId;

            if(isCharacterInTeam) {
                isClassAlreadyInTeam = charactersData.classNames[i] == charactersData.classNames[selectedCharacterDataKey];

                if(isClassAlreadyInTeam) {
                    break;
                }
            }
        }

        return isClassAlreadyInTeam;
    }


    private void ModifieCharacterButtonVisual(Transform selectedCharacter) {
        bool isUnselecting = selectedCharacter.gameObject.GetComponent<Button>() == highlightedCharacterButton;

        UnhighlightCharacterButton();
        if(!isUnselecting) {
            HighlightCharacterButton(selectedCharacter);
        }
    }

    private void UnhighlightCharacterButton() {
        if(highlightedCharacterButton != null) {
            Button characterButton = highlightedCharacterButton;
            Color  color = new Color(255, 255, 255, 255); // White

            // Define visual indicator.
            ColorBlock highlightColor  = characterButton.colors;
            highlightColor.normalColor = HelpingMethod.ConvertToDecimalColor(color);

            // Apply visual indicator.
            characterButton.colors   = highlightColor;

            highlightedCharacterButton = null;
        }
    }

    private void HighlightCharacterButton(Transform selectedCharacter) {
        if(highlightedCharacterButton == null) {
            Button characterButton = selectedCharacter.gameObject.GetComponent<Button>();
            Color  color = new Color(0, 150, 50, 255); // Green

            // Define visual indicator.
            ColorBlock highlightColor  = characterButton.colors;
            highlightColor.normalColor = HelpingMethod.ConvertToDecimalColor(color);

            // Apply visual indicator.
            characterButton.colors   = highlightColor;

            highlightedCharacterButton = characterButton;
        }
    }
}