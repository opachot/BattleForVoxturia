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

    // PUBLIC
    [System.Serializable] 
    public struct ClassPopUp {
        public GameObject popUp;
        public Image      icon;
        public Text       name;
        public Text       description;
    }
    public ClassPopUp classPopUp;
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
        // Verify if all condition are meet (character name at lest 3 lenght, a selected class.)
        // if condition not meet: activate error pop-up insted.

        // Create (private param clickedClassName will be saved in the char className field, 
        // no need to use the class Switch() condition)

        navigation.NavigateTo_TeamScreen(currentTeamId);
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
    #endregion

    #region Class popUp Buttons
    public void ChooseClassButton() {
        selectedClassName = clickedClassName;

        // Hightlight class button UI.

        CloseClassPopUp();
    }

    public void CancelClassPopUpButton() {
        CloseClassPopUp();
    }


    private void CloseClassPopUp() {
        classPopUp.popUp.SetActive(false);
    }
    #endregion
}