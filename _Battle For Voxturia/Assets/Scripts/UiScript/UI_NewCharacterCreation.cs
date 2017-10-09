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
    private ResourceLoader resourceLoader;
    private Navigation     navigation;
    private ErrorManager   errorManager;

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
		resourceLoader = GameObject.FindGameObjectWithTag("RessourceLoader").GetComponent<ResourceLoader>();
        navigation     = GameObject.FindGameObjectWithTag("Navigation")     .GetComponent<Navigation>();
        errorManager   = gameObject.GetComponent<ErrorManager>();

        GameObject gameData = GameObject.FindGameObjectWithTag("GameData");
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
        bool isValideForCreation = ValidateCreation();

        if(isValideForCreation) {
            string characterName = characterNameInputFieldText.text;

            charactersData.CreateNewTeam(currentTeamId, selectedClassName, characterName);

            navigation.NavigateTo_TeamScreen(currentTeamId);
        }
    }

    public void CancelButton() {
        navigation.NavigateTo_TeamScreen(currentTeamId);
    }


    private void LoadClassPopUp() {

        classPopUp.icon       .sprite = GetCharacterIcon(clickedClassName);
        classPopUp.name       .text   = clickedClassName;
        classPopUp.description.text   = GetCharacterDescription(clickedClassName);
        
        classPopUp.popUp.SetActive(true);
    }

    private Sprite GetCharacterIcon(string className) {
        Sprite classSprite = new Sprite();

        switch (className)
        {
            case "Fighter":
                classSprite = resourceLoader.iconFighterClass;      break;
            case "Hunter":
                classSprite = resourceLoader.iconHunterClass;       break;
            case "Ninja":
                classSprite = resourceLoader.iconNinjaClass;        break;
            case "Guardian":
                classSprite = resourceLoader.iconGuardianClass;     break;
            case "Elementalist":
                classSprite = resourceLoader.iconElementalistClass; break;
            case "GrimReaper":
                classSprite = resourceLoader.iconGrimReaperClass;   break;
            case "Druid":
                classSprite = resourceLoader.iconDruidClass;        break;
            case "Samurai":
                classSprite = resourceLoader.iconSamuraiClass;      break;
            case "Vampire":
                classSprite = resourceLoader.iconVampireClass;      break;
            case "Cyborg":
                classSprite = resourceLoader.iconCyborgClass;       break;
            default:
                classSprite = resourceLoader.emptyIconClass;        break;
        }

        return classSprite;
    }

    private string GetCharacterDescription(string className) {
        string description;

        switch (className)
        {
            case "Fighter":
                description = "TODO: Fighter description";
                break;
            case "Hunter":
                description = "TODO: Hunter description";
                break;
            case "Ninja":
                description = "TODO: Ninja description";
                break;
            case "Guardian":
                description = "TODO: Guardian description";
                break;
            case "Elementalist":
                description = "TODO: Elementalist description";
                break;
            case "GrimReaper":
                description = "TODO: GrimReaper description";
                break;
            case "Druid":
                description = "TODO: Druid description";
                break;
            case "Samurai":
                description = "TODO: Samurai description";
                break;
            case "Vampire":
                description = "TODO: Vampire description";
                break;
            case "Cyborg":
                description = "TODO: Cyborg description";
                break;
            default:
                description = "Error 404: Class description not found.";
                break;
        }

        return description;
    }

    #region ValidateCreation
    private bool ValidateCreation() {
        bool isValidForCreation = true;

        if(!IsNameChoosed()) {
            errorManager.TrowError("Error: You need to choose a character name with a length of at least 3.");
            isValidForCreation = false;
        }
        else if(!IsAvailableName()) {
            errorManager.TrowError("Error: The name is already taken.");
            isValidForCreation = false;
        }
        else if(!IsClassSelected()) {
            errorManager.TrowError("Error: You need to select a class for your new character.");
            isValidForCreation = false;
        }

        return isValidForCreation;
    }


    private bool IsNameChoosed() {
        const int MIN_NAME_LENGTH = 3;

        bool isNameChoosed = characterNameInputFieldText.text.Length >= MIN_NAME_LENGTH;

        return isNameChoosed;
    }

    private bool IsAvailableName() {
        bool isAvailableName = !charactersData.IsExistingName(characterNameInputFieldText.text);

        return isAvailableName;
    }

    private bool IsClassSelected() {
        bool isClassSelected = selectedClassName != null 
                               &&
                               selectedClassName != "";

        return isClassSelected;
    }
    #endregion

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
        defaultColor.normalColor = ConvertToDecimalColor(255, 255, 255, 255);

        // Apply visual indicator.
        classButton.colors = defaultColor;
    }

    private void ShowChoosedClass(Button classButton) {
        // Define visual indicator.
        ColorBlock hightlightColor  = classButton.colors;
        hightlightColor.normalColor = ConvertToDecimalColor(0, 150, 50, 255);

        // Apply visual indicator.
        classButton.colors = hightlightColor;
    }

    private Vector4 ConvertToDecimalColor(float r, float g, float b, float a) {
        Vector4 color = new Vector4(r/255.0f, g/255.0f, b/255.0f, a/255.0f);
        return  color;
    }
    #endregion
}