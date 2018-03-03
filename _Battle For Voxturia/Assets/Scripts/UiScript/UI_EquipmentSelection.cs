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
    private ErrorManager   errorManager;

    private EquipmentFilter equipmentFilter;

    private Items items;

    private Transform list;

    private List<Transform>    equipmentButtonList    = new List<Transform>();
    private List<List<string>> displayedEquipmentList = new List<List<string>>();

    private List<string> selectedEquipment;
    private Transform    highlightedEquipmentButton;

    private int currentTeamId;
    private int currentCharacterId;
    private int currentCharacterDataKey;
    private int equipmentType; // 0 = Helmet; 1 = Armor; 2 = Greave; 3 = Boots; 4 = Jewel;

    // PUBLIC
    public TMP_Text titleScreenText;
    public Button selectSkill_btn;
    public GameObject filter_PopUp;
    [Space(10)]

    [Header("Skill Info Section")]
    public TMP_Text infoName;
    public Image    infoIcon;
    public TMP_Text infoLvlReq;
    public TMP_Text infoCost;
    [Space(5)]
    public TMP_Text effectAndLoreText;
    [Space(5)]
    public Button effect_btn;
    public Button lore_btn;

    #endregion

	#region UNITY METHODE
	void Awake() {
		resourceLoader = GameObject.FindGameObjectWithTag("RessourceLoader").GetComponent<ResourceLoader>();
        navigation     = GameObject.FindGameObjectWithTag("Navigation")     .GetComponent<Navigation>();
        charactersData = GameObject.FindGameObjectWithTag("GameData")       .GetComponent<CharactersData>();
        errorManager   = GameObject.FindGameObjectWithTag("ErrorManager")   .GetComponent<ErrorManager>();

        equipmentFilter = filter_PopUp.GetComponent<EquipmentFilter>();

        GameObject itemsHolder = GameObject.FindGameObjectWithTag("Items");
        items   = itemsHolder.GetComponent<Items>();

        list = GameObject.Find("List").GetComponent<Transform>();
    }
	
	void Start() {
		UseExtraParam();
        FindCharacterDataKey();
        InitEquipmentFilter();

        LoadScreenName();
        LoadEquipmentsList();
        
        ClearEquipmentInfo();
	}
	
	void Update() {
		
	}
    #endregion


    #region Default buttons
    public void EquipmentButton(Transform clickedEquipmentBtn) {
        int? equipmentIndex = FindEquipmentIndex(clickedEquipmentBtn);

        if(equipmentIndex != null) {
            if(selectedEquipment != displayedEquipmentList[(int)equipmentIndex]) {
                selectedEquipment = displayedEquipmentList[(int)equipmentIndex];
                selectSkill_btn.interactable = true;
                
                LoadEquipmentInfo();
            }
            else {
                selectedEquipment = null;
                selectSkill_btn.interactable = false;
                ClearEquipmentInfo();
            }

            ModifieEquipmentButtonVisual(clickedEquipmentBtn);
            HelpingMethod.ClearEventSystemButtonHighlighted();
        }
        else {
            Debug.Log("Error 404: equipment index not found!");
        }
    }

    public void FilterButton() {
        filter_PopUp.SetActive(true);
    }

    public void SelectButton() {
        int characterLvl        = charactersData.levels[currentCharacterDataKey];
        int equipmentLvlRequire = int.Parse(selectedEquipment[(int)Items.ITEM_INFO.LVL_R]);

        if(characterLvl >= equipmentLvlRequire) {
            charactersData.AddEquipment(currentCharacterDataKey, equipmentType, selectedEquipment);

            navigation.NavigateTo_CharacterCustomisation(currentTeamId, currentCharacterId);
        }
        else {
            errorManager.TrowError("Error: Your character level is not high enough to use this equipment. \n" + 
                                   "Your character level: " + characterLvl + "\n" +
                                   "The selected equipment required level: " + equipmentLvlRequire);
        }
    }

    public void CancelButton() {
        navigation.NavigateTo_CharacterCustomisation(currentTeamId, currentCharacterId);
    }

    public void EffectButton() {
        effect_btn.interactable = false;
        lore_btn  .interactable = true;

        LoadEffectOrLore();
    }

    public void LoreButton() {
        lore_btn  .interactable = false;
        effect_btn.interactable = true;

        LoadEffectOrLore();
    }


    public void FilterPopUpApplyButton() {
        LoadEquipmentsList();

        filter_PopUp.SetActive(false);
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

    private void InitEquipmentFilter() {
        int characterLevel = charactersData.levels[currentCharacterDataKey];

        equipmentFilter.DesactivateEquipmentTypeFilter(equipmentType);
        equipmentFilter.SetMaxLvl(characterLevel);
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
        ClearEquipmentList();

        List<List<string>> filteredListOfEquipmentType = equipmentFilter.Filter();

        foreach(List<string> equipment in filteredListOfEquipmentType) {
            InstantiateEquipmentInList(equipment);
        }
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
        TMP_Text  nameText      = nameTransform.GetComponent<TMP_Text>();
        nameText.text = equipmentName;

        // Set equipment cost.
        Transform costTransform = listElement.FindDeepChild("Cost");
        TMP_Text  costText      = costTransform.GetComponent<TMP_Text>();
        costText.text = "Cost: " + equipmentCost;
    }

    private void ClearEquipmentList() {
        selectedEquipment          = null;
        highlightedEquipmentButton = null;

        selectSkill_btn.interactable = false;

        foreach(Transform t in equipmentButtonList) {
            Destroy(t.gameObject);
        }

        equipmentButtonList    = new List<Transform>();
        displayedEquipmentList = new List<List<string>>();

        ClearEquipmentInfo();
    }
    #endregion


    private int? FindEquipmentIndex(Transform equipmentBtn) {
        int? equipmentIndex = null;

        for(int i = 0; i < equipmentButtonList.Count; i++) {
            if(equipmentBtn == equipmentButtonList[i]) {
                equipmentIndex = i;
                break;
            }
        }

        return equipmentIndex;
    }


    #region Button Highlight Methode
    private void ModifieEquipmentButtonVisual(Transform clickedEquipmentBtn) {
        bool isSelecting = clickedEquipmentBtn != highlightedEquipmentButton;

        UnhighlightEquipmentButton();
        if(isSelecting) {
            HighlightEquipmentButton(clickedEquipmentBtn);
        }
    }

    private void UnhighlightEquipmentButton() {
        if(highlightedEquipmentButton != null) {
            Button equipmentButton = highlightedEquipmentButton.GetComponent<Button>();
            Color  color = new Color(255, 255, 255, 255); // White

            // Define visual indicator.
            ColorBlock highlightColor  = equipmentButton.colors;
            highlightColor.normalColor = HelpingMethod.ConvertToDecimalColor(color);

            // Apply visual indicator.
            equipmentButton.colors = highlightColor;

            highlightedEquipmentButton = null;
        }
    }

    private void HighlightEquipmentButton(Transform clickedEquipmentBtn) {
        if(highlightedEquipmentButton == null) {
            Button equipmentButton = clickedEquipmentBtn.gameObject.GetComponent<Button>();
            Color  color = new Color(0, 150, 50, 255); // Green

            // Define visual indicator.
            ColorBlock highlightColor  = equipmentButton.colors;
            highlightColor.normalColor = HelpingMethod.ConvertToDecimalColor(color);

            // Apply visual indicator.
            equipmentButton.colors   = highlightColor;

            highlightedEquipmentButton = clickedEquipmentBtn;
        }
    }
    #endregion


    #region Load Effect or Lore
    private void LoadEffectOrLore() {
        if(selectedEquipment != null) {
            if(effect_btn.interactable) {
                LoadLore();
            }
            else if(lore_btn.interactable) {
                LoadEffect();
            }
            else {
                Debug.Log("Error: Effect and Lore button not interactable!?!?");
            }
        }
    }


    private void LoadEffect() {
        effectAndLoreText.text = "";

        for(int i = (int)Items.ITEM_INFO.AP; i < selectedEquipment.Count; i++) {
            bool isEffectUsed = int.Parse(selectedEquipment[i]) != 0;

            if(isEffectUsed) {
                string effectDescription = items.GetStatsDescription(i);
                string effectValue       = selectedEquipment[i];
                string percentDisplay    = items.GetPercentWhenNeeded(i);

                string effectLine = effectDescription + effectValue + percentDisplay + "\n";

                effectAndLoreText.text += effectLine;
            }
        }
    }

    private void LoadLore() {
        effectAndLoreText.text = selectedEquipment[(int)Items.ITEM_INFO.LORE];
    }
    #endregion


    private void ClearEquipmentInfo() {
        infoName.text   = "-";
        infoIcon.sprite = null;
        infoLvlReq.text = "Required Levels: -";
        infoCost.text   = "Cost: -";
        effectAndLoreText.text = "";
    }

    private void LoadEquipmentInfo() {
        string name   = selectedEquipment[(int)Items.ITEM_INFO.NAME];
        string lvlReq = selectedEquipment[(int)Items.ITEM_INFO.LVL_R];
        string cost   = selectedEquipment[(int)Items.ITEM_INFO.COST];
        infoName  .text = name;
        infoLvlReq.text = "Required Levels: " + lvlReq;
        infoCost  .text = "Cost: " + cost;

        Sprite icon = items.GetIcon(equipmentType, name);
        infoIcon.sprite = icon;

        LoadEffectOrLore();
    }

}