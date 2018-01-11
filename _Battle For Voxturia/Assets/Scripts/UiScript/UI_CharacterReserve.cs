/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    09 January 2018
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_CharacterReserve : MonoBehaviour {

	#region DECLARATION
    // CONST

    // PRIVATE
    private ResourceLoader resourceLoader;
    private Navigation     navigation;
    private CharactersData charactersData;
    private TeamsData      teamsData;

    private Transform list;

    private List<int> charactersKeys;

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

        list = GameObject.Find("List").GetComponent<Transform>();

        charactersKeys = new List<int>();
    }
	
	void Start() {
		GenerateCharactersList();
	}
	
	void Update() {
		
	}
    #endregion


    #region Default buttons
    public void SelectCharacter(Transform selectedCharacter) {
        // TODO: Verify if the class already exist in the team, if yes, show an error msg to warn the played he can,t have 2 time the same class.

        // TODO: Add character in the right team and remove it from the reserve.
        // TODO: Run the verification if the team need to be unselected if was selected (Due to a cost busting).

        navigation.NavigateTo_TeamScreen(0);    // TODO: PASS THE TEAM ID.
    }

    public void CancelButton() {
        navigation.NavigateTo_TeamScreen(0);    // TODO: PASS THE TEAM ID.
    }

    public void CharacterButton(Transform selectedCharacter) {
        // TODO: int selectedCharacterDataKey = FindSelectedCharacterDataKey(selectedCharacter);

        // TODO: Save the selected character icon in a global variable?
        // TODO: Highlight the character button.

        // TODO: Load the character info section.
    }

    public void DeleteCharacterButton(Transform selectedCharacter) {
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
}