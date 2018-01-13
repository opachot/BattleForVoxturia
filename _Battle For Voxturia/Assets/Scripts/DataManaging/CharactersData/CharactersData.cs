/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    29 September 2017
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersData : MonoBehaviour {

	#region DECLARATION
    // CONST
    const int DEFAULT_LEVEL          = 1;
    const int DEFAULT_CURRENT_XP     = 0;
    const int DEFAULT_GOAL_XP        = 100;

    const int DEFAULT_SKILL_ONE_ID   = 0;
    const int DEFAULT_SKILL_TWO_ID   = 0;
    const int DEFAULT_SKILL_THREE_ID = 0;
    const int DEFAULT_SKILL_FOUR_ID  = 0;
    const int DEFAULT_SKILL_FIVE_ID  = 0;

    const int DEFAULT_HELMET_ID      = 0;
    const int DEFAULT_ARMOR_ID       = 0;
    const int DEFAULT_GREAVE_ID      = 0;
    const int DEFAULT_BOOTS_ID       = 0;
    const int DEFAULT_JEWEL_ID       = 0;

    const int DEFAULT_COST           = 500;

    // PRIVATE
    private ResourceLoader resourceLoader;
    private ErrorManager   errorManager;

    private int extraParam_TeamId;      /* Inter screen param */
    private int extraParam_CharacterId; /* Inter screen param */

    // PUBLIC
    public List<int>    ids;
    public List<int>    teamDataIds;

    public List<string> classNames;

    public List<string> names;
    public List<int>    levels;
    public List<int>    currentXps;
    public List<int>    goalXps;

    public List<int>    skillOneIds;
    public List<int>    skillTwoIds;
    public List<int>    skillThreeIds;
    public List<int>    skillFourIds;
    public List<int>    skillFiveIds;
    
    public List<int>    helmetIds;
    public List<int>    armorIds;
    public List<int>    greaveIds;
    public List<int>    bootsIds;
    public List<int>    jewelIds;

    public List<int>    costs;

    #endregion

	#region UNITY METHODE
	void Awake() {
		resourceLoader = GameObject.FindGameObjectWithTag("RessourceLoader").GetComponent<ResourceLoader>();
        errorManager   = GameObject.FindGameObjectWithTag("ErrorManager")   .GetComponent<ErrorManager>();
    }
	
	void Start() {
		
	}
	
	void Update() {
		
	}
    #endregion


    #region Validate/Create/Delete character
    #region ValidateCharacter
    public bool ValidateCreation(string newCharacterName, string selectedClassName) {
        bool isValidForCreation = true;

        if(!IsNameChoosed(newCharacterName)) {
            errorManager.TrowError("Error: You need to choose a character name with a length of at least 3.");
            isValidForCreation = false;
        }
        else if(!IsAvailableName(newCharacterName)) {
            errorManager.TrowError("Error: The name is already taken.");
            isValidForCreation = false;
        }
        else if(!IsClassSelected(selectedClassName)) {
            errorManager.TrowError("Error: You need to select a class for your new character.");
            isValidForCreation = false;
        }

        return isValidForCreation;
    }


    private bool IsNameChoosed(string newCharacterName) {
        const int MIN_NAME_LENGTH = 3;

        bool isNameChoosed = newCharacterName.Length >= MIN_NAME_LENGTH;

        return isNameChoosed;
    }

    private bool IsAvailableName(string newCharacterName) {
        bool isAvailableName = true;

        foreach(string name in names) {
            if(newCharacterName.ToLower() == name.ToLower()) {
                isAvailableName = false;
                break;
            }
        }

        return isAvailableName;
    }

    private bool IsClassSelected(string selectedClassName) {
        bool isClassSelected = selectedClassName != null 
                               &&
                               selectedClassName != "";

        return isClassSelected;
    }
    #endregion

    #region CreateCharacter
    public void CreateNewCharacter(int teamId, string className, string characterName) {
        ids.Add(GetNewId());

        teamDataIds.Add(teamId);
        classNames .Add(className);
        names      .Add(characterName);

        // Default value
        levels       .Add(DEFAULT_LEVEL);
        currentXps   .Add(DEFAULT_CURRENT_XP);
        goalXps      .Add(DEFAULT_GOAL_XP);
                      
        skillOneIds  .Add(DEFAULT_SKILL_ONE_ID);
        skillTwoIds  .Add(DEFAULT_SKILL_TWO_ID);
        skillThreeIds.Add(DEFAULT_SKILL_THREE_ID);
        skillFourIds .Add(DEFAULT_SKILL_FOUR_ID);
        skillFiveIds .Add(DEFAULT_SKILL_FIVE_ID);
                      
        helmetIds    .Add(DEFAULT_HELMET_ID);
        armorIds     .Add(DEFAULT_ARMOR_ID);
        greaveIds    .Add(DEFAULT_GREAVE_ID);
        bootsIds     .Add(DEFAULT_BOOTS_ID);
        jewelIds     .Add(DEFAULT_JEWEL_ID);

        costs        .Add(DEFAULT_COST);
    }

    private int GetNewId() {
        int newId;

        if(ids.Count == 0) {
            newId = 1;
        }
        else {
            int previousId = ids[ids.Count - 1];

            newId = previousId + 1;
        }

        return newId;
    }
    #endregion

    public void DeleteCharacter(int key) {
        ids          .RemoveAt(key);
        teamDataIds  .RemoveAt(key);

        classNames   .RemoveAt(key);

        names        .RemoveAt(key);
        levels       .RemoveAt(key);
        currentXps   .RemoveAt(key);
        goalXps      .RemoveAt(key);

        skillOneIds  .RemoveAt(key);
        skillTwoIds  .RemoveAt(key);
        skillThreeIds.RemoveAt(key);
        skillFourIds .RemoveAt(key);
        skillFiveIds .RemoveAt(key);

        helmetIds    .RemoveAt(key);
        armorIds     .RemoveAt(key);
        greaveIds    .RemoveAt(key);
        bootsIds     .RemoveAt(key);
        jewelIds     .RemoveAt(key);

        costs        .RemoveAt(key);
    }
    #endregion


    public Sprite GetCharacterIcon(string className) {
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

    public string GetCharacterDescription(string className) {
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


    #region INTER SCREEN PARAM
    public int ExtraParam_TeamId {
        get { return extraParam_TeamId;  }
        set { extraParam_TeamId = value; }
    }

    public int ExtraParam_CharacterId {
        get { return extraParam_CharacterId;  }
        set { extraParam_CharacterId = value; }
    }
    #endregion
}