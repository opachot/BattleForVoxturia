/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    07 October 2017
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_NewCharacterCreation : MonoBehaviour {

	#region DECLARATION
    // CONST

    // PRIVATE
    private Navigation     navigation;

    private CharactersData charactersData;

    private int currentTeamId;

    private string clickedClassName;
    private string selectedClassName;

    private Button selectedClassButton;

    // PUBLIC
    [System.Serializable] 
    public struct ClassPopUp {
        public GameObject popUp;
        public Image      icon;
        public Text       name;
        public Text       description;
    }
    public ClassPopUp classPopUp;

    public Text characterNameInputFieldText;
    #endregion

	#region UNITY METHODE
	void Awake() {
        navigation = GameObject.FindGameObjectWithTag("Navigation")     .GetComponent<Navigation>();

        GameObject gameData = GameObject.FindGameObjectWithTag("GameData");
        charactersData      = gameData.GetComponent<CharactersData>();
    }
	
	void Start() {
		UseExtraParam();
	}
	
	void Update() {

	}
    #endregion


    #region Initialisation
    private void UseExtraParam() {
        currentTeamId = charactersData.ExtraParam_TeamId;
        charactersData.ExtraParam_TeamId = 0;
    }
    #endregion


    #region Default buttons
    public void ClassButton(string className) {
        clickedClassName = className;

        LoadClassPopUp();
    }

    public void CreateCharacterButton() {
        string characterName = characterNameInputFieldText.text;
        string className     = selectedClassName;

        bool isValideForCreation = charactersData.ValidateCreation(characterName, className);

        if(isValideForCreation) {
            charactersData.CreateNewCharacter(currentTeamId, selectedClassName, characterName);

            navigation.NavigateTo_TeamScreen(currentTeamId);
        }
    }

    public void CancelButton() {
        navigation.NavigateTo_TeamScreen(currentTeamId);
    }


    private void LoadClassPopUp() {

        classPopUp.icon       .sprite = charactersData.GetCharacterIcon(clickedClassName);
        classPopUp.name       .text   = clickedClassName;
        classPopUp.description.text   = charactersData.GetCharacterDescription(clickedClassName);
        
        classPopUp.popUp.SetActive(true);
    }
    #endregion

    #region Class popUp Buttons
    public void ChooseClassButton() {
        if(selectedClassButton != null) {
            resetChoosedClass(selectedClassButton);
        }

        selectedClassName   = clickedClassName;
        selectedClassButton = FindChoosedClassButton();

        ShowChoosedClass(selectedClassButton);

        CloseClassPopUp();
    }

    public void CancelClassPopUpButton() {
        CloseClassPopUp();
    }


    private void CloseClassPopUp() {
        classPopUp.popUp.SetActive(false);
    }


    private Button FindChoosedClassButton() {
        string buttonName         = "Class" + selectedClassName + "_btn";
        Button choosedClassButton = GameObject.Find(buttonName).GetComponent<Button>();

        return choosedClassButton;
    }

    private void resetChoosedClass(Button classButton) {
        // Define visual indicator.
        ColorBlock defaultColor  = classButton.colors;
        defaultColor.normalColor = HelpingMethod.ConvertToDecimalColor(255, 255, 255, 255);

        // Apply visual indicator.
        classButton.colors = defaultColor;
    }

    private void ShowChoosedClass(Button classButton) {
        // Define visual indicator.
        ColorBlock hightlightColor  = classButton.colors;
        hightlightColor.normalColor = HelpingMethod.ConvertToDecimalColor(0, 150, 50, 255);

        // Apply visual indicator.
        classButton.colors = hightlightColor;
    }
    #endregion
}