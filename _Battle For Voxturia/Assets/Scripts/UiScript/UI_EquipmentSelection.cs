/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    20 Fabruary 2018
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_EquipmentSelection : MonoBehaviour {

	#region DECLARATION
    // CONST

    // PRIVATE
    private ResourceLoader resourceLoader;
    private Navigation     navigation;
    private CharactersData charactersData;
    private Items          items;

    private Transform list;
    private List<Transform> equipmentButtonList = new List<Transform>();

    //Skill     selectedEquipment;
    Transform highlightedEquipmentButton;

    private int currentTeamId;
    private int currentCharacterId;
    private int currentCharacterDataKey;
    private int equipmentType; // 0 = Helmet; 1 = Armor; 2 = Greave; 3 = Boots; 4 = Jewel;

    // PUBLIC

    #endregion

	#region UNITY METHODE
	void Awake() {
		resourceLoader = GameObject.FindGameObjectWithTag("RessourceLoader").GetComponent<ResourceLoader>();
        navigation     = GameObject.FindGameObjectWithTag("Navigation")     .GetComponent<Navigation>();
        charactersData = GameObject.FindGameObjectWithTag("GameData")       .GetComponent<CharactersData>();

        GameObject itemsHolder = GameObject.FindGameObjectWithTag("Items");
        items = itemsHolder.GetComponent<Items>();

        list = GameObject.Find("List").GetComponent<Transform>();
    }
	
	void Start() {
		UseExtraParam();
        FindCharacterDataKey();
        
        // TODO
        /*
        LoadEquipmentsList();
        ClearEquipmentInfo();
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

}