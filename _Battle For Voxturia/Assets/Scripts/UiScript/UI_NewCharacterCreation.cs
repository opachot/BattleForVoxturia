/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    07 October 2017
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class UI_NewCharacterCreation : MonoBehaviour {

	#region DECLARATION
    // CONST

    // PRIVATE
    private ResourceLoader resourceLoader;
    private Navigation     navigation;
    private ClassRole      classRole;

    private CharactersData charactersData;
    private TeamsData      teamsData;

    private int currentTeamId;

    private string selectedClassName;
    private Button selectedClassButton;

    // PUBLIC
    public Transform classSection;
    [Space(10)]

    [Header("Info Section")]
    public TMP_Text infoName;
    public Image    infoIcon;
    public TMP_Text infoCost;
    [Space(5)]
    public TMP_Text infoDescription;
    public ScrollRect descriptionViewScrollRect;
    [Space(5)]
    public Image    infoIconRole1;
    public TMP_Text infoNameRole1;
    public Image    infoIconRole2;
    public TMP_Text infoNameRole2;

    public Text characterNameInputFieldText;
    #endregion

	#region UNITY METHODE
	void Awake() {
        resourceLoader = GameObject.FindGameObjectWithTag("RessourceLoader").GetComponent<ResourceLoader>();
        navigation     = GameObject.FindGameObjectWithTag("Navigation")     .GetComponent<Navigation>();
        classRole      = gameObject.GetComponent<ClassRole>();

        GameObject gameData = GameObject.FindGameObjectWithTag("GameData");
        charactersData      = gameData.GetComponent<CharactersData>();
        teamsData           = gameData.GetComponent<TeamsData>();
    }
	
	void Start() {
		UseExtraParam();
        DisableAlreadyUsedClass();
        CleanClassInfo();
	}
	
	void Update() {

	}
    #endregion


    #region Initialisation
    private void UseExtraParam() {
        currentTeamId = charactersData.ExtraParam_TeamId;
        charactersData.ExtraParam_TeamId = 0;
    }

    private void DisableAlreadyUsedClass() {
        int nbCharacter = charactersData.ids.Count;

        for(int i = 0; i < nbCharacter; i++) {
            if(charactersData.teamDataIds[i] == currentTeamId) {
                string characterClassName = charactersData.classNames[i];
                string classNameBtn = "Class" + characterClassName + "_btn";

                Button classBtn = classSection.Find(classNameBtn).GetComponent<Button>();
                classBtn.interactable = false;
            }
        }
    }
    #endregion


    #region Default buttons
    public void ClassButton(string className) {
        if(className != selectedClassName) {
            // Reset the visual selection indicator.
            resetChoosedClass(selectedClassButton);

            // Update the selected Values.
            selectedClassName   = className;
            selectedClassButton = FindChoosedClassButton();

            // Show the visual selection indicator.
            ShowChoosedClass(selectedClassButton);

            LoadClassInfo();
        }
        else {
            // Reset the visual selection indicator.
            resetChoosedClass(selectedClassButton);

            // Update the selected Values.
            selectedClassName   = null;
            selectedClassButton = null;

            CleanClassInfo();
        }

        HelpingMethod.ClearEventSystemButtonHighlighted();
    }

    public void CreateCharacterButton() {
        string characterName = characterNameInputFieldText.text;
        string className     = selectedClassName;

        bool isValideForCreation = charactersData.ValidateCreation(characterName, className);

        if(isValideForCreation) {
            charactersData.CreateNewCharacter(currentTeamId, selectedClassName, characterName);
            int newCharacterId = charactersData.ids.Last();

            // Unselect current team if necessary.
            int teamDataKey = teamsData.FindTeamDataKey(currentTeamId);
            teamsData.UpdateValideSelectedTeam(teamDataKey, currentTeamId);

            navigation.NavigateTo_CharacterCustomisation(currentTeamId, newCharacterId);
        }
    }

    public void CancelButton() {
        navigation.NavigateTo_TeamScreen(currentTeamId);
    }
    #endregion


    private Button FindChoosedClassButton() {
        string buttonName         = "Class" + selectedClassName + "_btn";
        Button choosedClassButton = GameObject.Find(buttonName).GetComponent<Button>();

        return choosedClassButton;
    }

    #region Class info section management
    private void CleanClassInfo() {
        infoName       .text   = "-";
        infoIcon       .sprite = null;
        infoCost       .text   = "Cost: -";
        infoDescription.text   = "";
        
        // Roles
        infoIconRole1.sprite = resourceLoader.emptyIconClassRole;
        infoNameRole1.text   = "-";
        infoIconRole2.sprite = resourceLoader.emptyIconClassRole;
        infoNameRole2.text   = "-";

        // Fix ScrollView
        infoDescription.AdjustTMPBlockHeight();
        descriptionViewScrollRect.ScrollToTop();
    }

    private void LoadClassInfo() {
        const int INDEX_ROLE_1 = 0;
        const int INDEX_ROLE_2 = 1;

        infoName       .text   = selectedClassName;
        infoIcon       .sprite = charactersData.GetCharacterIcon(selectedClassName);
        infoCost       .text   = "Cost: " + charactersData.GetCost();
        infoDescription.text   = charactersData.GetCharacterDescription(selectedClassName);

        // Roles
        Sprite[] rolesSprites = classRole.GetRoleIcons(selectedClassName);
        string[] rolesNames   = classRole.GetRoleNames(selectedClassName);

        infoIconRole1.sprite = rolesSprites[INDEX_ROLE_1];
        infoNameRole1.text   = rolesNames  [INDEX_ROLE_1];
        infoIconRole2.sprite = rolesSprites[INDEX_ROLE_2];
        infoNameRole2.text   = rolesNames  [INDEX_ROLE_2];

        // Fix ScrollView
        infoDescription.AdjustTMPBlockHeight();
        descriptionViewScrollRect.ScrollToTop();
    }
    #endregion


    #region Selection visual indicator management
    private void resetChoosedClass(Button classButton) {
        if(classButton != null) {
            // Define visual indicator.
            ColorBlock defaultColor  = classButton.colors;
            defaultColor.normalColor = HelpingMethod.ConvertToDecimalColor(255, 255, 255, 255);

            // Apply visual indicator.
            classButton.colors = defaultColor;
        }
        
    }

    private void ShowChoosedClass(Button classButton) {
        if(classButton != null) {
            // Define visual indicator.
            ColorBlock hightlightColor  = classButton.colors;
            hightlightColor.normalColor = HelpingMethod.ConvertToDecimalColor(0, 150, 50, 255);

            // Apply visual indicator.
            classButton.colors = hightlightColor;
        }
    }
    #endregion
}