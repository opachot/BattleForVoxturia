/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    20 Fabruary 2018
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_EquipmentSelection : MonoBehaviour {

	#region DECLARATION
    // CONST
    private const int HELMET = 0;
    private const int ARMOR  = 1;
    private const int GREAVE = 2;
    private const int BOOTS  = 3;
    private const int JEWEL  = 4;

    // PRIVATE
    private ResourceLoader resourceLoader;
    private Navigation     navigation;
    private CharactersData charactersData;

    private Items items;
    private Helmets helmets;
    private Armors  armors;
    private Greaves greaves;
    private Boots   boots;
    private Jewels  jewels;

    private Transform list;

    private List<Transform>    equipmentButtonList    = new List<Transform>();
    private List<List<string>> displayedEquipmentList = new List<List<string>>();

    private List<string> selectedEquipment;
    private Transform    highlightedEquipmentButton;

    private int currentTeamId;
    private int currentCharacterId;
    private int currentCharacterDataKey;
    private int currentEquipmentId;
    private int equipmentType; // 0 = Helmet; 1 = Armor; 2 = Greave; 3 = Boots; 4 = Jewel;

    // PUBLIC
    public TMP_Text titleScreenText;

    #endregion

	#region UNITY METHODE
	void Awake() {
		resourceLoader = GameObject.FindGameObjectWithTag("RessourceLoader").GetComponent<ResourceLoader>();
        navigation     = GameObject.FindGameObjectWithTag("Navigation")     .GetComponent<Navigation>();
        charactersData = GameObject.FindGameObjectWithTag("GameData")       .GetComponent<CharactersData>();

        GameObject itemsHolder = GameObject.FindGameObjectWithTag("Items");
        items   = itemsHolder.GetComponent<Items>();
        helmets = itemsHolder.GetComponent<Helmets>();
        armors  = itemsHolder.GetComponent<Armors>();
        greaves = itemsHolder.GetComponent<Greaves>();
        boots   = itemsHolder.GetComponent<Boots>();
        jewels  = itemsHolder.GetComponent<Jewels>();

        list = GameObject.Find("List").GetComponent<Transform>();
    }
	
	void Start() {
		UseExtraParam();
        FindCharacterDataKey();
        FindcurrentEquiped();

        LoadScreenName();
        LoadEquipmentsList();
        
        // TODO
        /*
         * ClearEquipmentInfo();
        */
	}
	
	void Update() {
		
	}
    #endregion


    #region Default buttons
    public void EquipmentButton(Transform clickedEquipmentBtn) {
        /*int? skillIndex = FindSkillIndex(clickedSkillBtn);

        if(skillIndex != null) {
            if(selectedSkill != displayedSkillList[(int)skillIndex]) {
                selectedSkill = displayedSkillList[(int)skillIndex];
                selectSkill_btn.interactable = true;
                
                LoadSkillInfo(selectedSkill);
            }
            else {
                selectedSkill = null;
                selectSkill_btn.interactable = false;
                ClearSkillInfo();
            }

            ModifieSkillButtonVisual(clickedSkillBtn);
            HelpingMethod.ClearEventSystemButtonHighlighted();
        }
        else {
            Debug.Log("Error 404: Skill index not found!");
        }*/
    }

    public void FilterButton() {
        // TODO. (look in gameDesign MakeUp folder for more detail)
    }

    public void SelectButton() {
        /*charactersData.AddSkill(currentCharacterDataKey, selectedSkill);

        navigation.NavigateTo_CharacterCustomisation(currentTeamId, currentCharacterId);*/
    }

    public void CancelButton() {
        navigation.NavigateTo_CharacterCustomisation(currentTeamId, currentCharacterId);
    }

    public void EffectButton() {
        /*effect_btn.interactable = false;
        lore_btn  .interactable = true;

        LoadEffectOrLore();*/
    }

    public void LoreButton() {
        /*lore_btn  .interactable = false;
        effect_btn.interactable = true;

        LoadEffectOrLore();*/
    }
    #endregion


    private void UseExtraParam() {
        currentTeamId      = charactersData.ExtraParam_TeamId;
        currentCharacterId = charactersData.ExtraParam_CharacterId;
        equipmentType      = items         .ExtraParam_ItemType;

        charactersData.ExtraParam_TeamId      = 0;
        charactersData.ExtraParam_CharacterId = 0;
        items         .ExtraParam_ItemType    = 0;
    }

    private void FindCharacterDataKey() {
        for(int i = 0; i < charactersData.ids.Count; i++) {
            if(charactersData.ids[i] == currentCharacterId) {
                currentCharacterDataKey = i;
                break;
            }
        }
    }

    private void FindcurrentEquiped() {
        int equipmentId;

        switch (equipmentType)
        {
            case HELMET:
                equipmentId = charactersData.helmetIds[currentCharacterDataKey]; break;
            case ARMOR:
                equipmentId = charactersData.armorIds[currentCharacterDataKey];  break;
            case GREAVE:
                equipmentId = charactersData.greaveIds[currentCharacterDataKey]; break;
            case BOOTS:
                equipmentId = charactersData.bootsIds[currentCharacterDataKey];  break;
            case JEWEL:
                equipmentId = charactersData.jewelIds[currentCharacterDataKey];  break;
            default:
                equipmentId = 0;                                                 break;
        }

        currentEquipmentId = equipmentId;
    }


    private void LoadScreenName() {
        string screenName;

        switch (equipmentType)
        {
            case HELMET:
                screenName = "Helmet Selection"; break;
            case ARMOR:
                screenName = "Armor Selection";  break;
            case GREAVE:
                screenName = "Greave Selection"; break;
            case BOOTS:
                screenName = "Boots Selection";  break;
            case JEWEL:
                screenName = "Jewel Selection";  break;
            default:
                screenName = "Error 404: Equipment type not found"; break;
        }

        titleScreenText.text = screenName;
    }

    #region Equipment list loading
    private void LoadEquipmentsList() {
        List<List<string>> listOfEquipmentType = FindListOfCurrentEquipmentType();
        // TODO: FILTER THAT LIST TO CREATE A NEW LIST BUT FILTERED (discovered equipment and filter). (Add isEquipmentAlreadyUsed in filter?)
        //List<List<string>> filteredList = ;

        foreach(List<string> equipment in listOfEquipmentType) {
            if(!IsEquipmentAlreadyUsed(equipment)) {
                InstantiateEquipmentInList(equipment);
            }
        }
    }

    private List<List<string>> FindListOfCurrentEquipmentType() {
        List<List<string>> listOfEquipmentType;

        switch (equipmentType)
        {
            case HELMET:
                listOfEquipmentType = helmets.GetAllItems(); break;
            case ARMOR:
                listOfEquipmentType = armors.GetAllItems();  break;
            case GREAVE:
                listOfEquipmentType = greaves.GetAllItems(); break;
            case BOOTS:
                listOfEquipmentType = boots.GetAllItems();   break;
            case JEWEL:
                listOfEquipmentType = jewels.GetAllItems();  break;
            default:
                listOfEquipmentType = new List<List<string>>(); break;
        }

        return listOfEquipmentType;
    }

    private bool IsEquipmentAlreadyUsed(List<string> equipment) {
        int equipmentIdIndex = (int)Items.ITEM_INFO.ID;
        int equipmentId = int.Parse(equipment[equipmentIdIndex]);

        bool isSkillAlreadyUsed = equipmentId == currentEquipmentId;

        return isSkillAlreadyUsed;
    }

    private void InstantiateEquipmentInList(List<string> equipment) {
        Transform listElement = Instantiate(resourceLoader.skillAndEquipmentListingElement, list).transform;

        FixListElementButton(listElement, equipment);

        equipmentButtonList   .Add(listElement);
        displayedEquipmentList.Add(equipment);
    }

    private void FixListElementButton(Transform listElement, List<string> equipment) {
        string equipmentName = equipment[(int)Items.ITEM_INFO.NAME];
        string equipmentCost = equipment[(int)Items.ITEM_INFO.COST];
        Sprite equipmentIcon = items.GetIcon(equipmentType, equipmentName);

        // Set equipmentButton onClick event.
        Button equipmentButton = listElement.GetComponent<Button>();
        equipmentButton.onClick.AddListener(() => EquipmentButton(listElement));

        // Set equipment icon.
        Transform iconTransform = listElement.FindDeepChild("Icon");
        Image     iconImage     = iconTransform.GetComponent<Image>();
        iconImage.sprite = equipmentIcon;

        // Set equipment name.
        Transform nameTransform = listElement.FindDeepChild("Name");
        Text      nameText      = nameTransform.GetComponent<Text>();
        nameText.text = equipmentName;

        // Set equipment cost.
        Transform costTransform = listElement.FindDeepChild("Cost");
        Text      costText      = costTransform.GetComponent<Text>();
        costText.text = "Cost: " + equipmentCost;
    }
    #endregion

}