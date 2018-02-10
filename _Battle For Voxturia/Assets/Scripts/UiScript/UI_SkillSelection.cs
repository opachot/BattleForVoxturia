/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    09 February 2018
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_SkillSelection : MonoBehaviour {

	#region DECLARATION
    // CONST

    // PRIVATE
    private ResourceLoader resourceLoader;
    private Navigation     navigation;
    private CharactersData charactersData;

    private SkillList skillList;

    private int currentTeamId;
    private int currentCharacterId;
    private int currentCharacterDataKey;

    // PUBLIC
    [Header("Skill Info Section")]
    public Text       skillName;
    public Image      skillIcon;
    [Space(5)]
    public GameObject skillEffectSection;
    [Space(5)]
    public Button effect_btn;
    public Button lore_btn;
    [Space(5)]
    public TMP_Text effectText;
    public Text     loreText;
    [Space(5)]
    public Text skillValue_Ap;
    public Text skillValue_Mp;
    public Text skillValue_Range;

    public Text skillValue_UpPo;
    public Text skillValue_Fov;
    public Text skillValue_Cil;

    public Text skillValue_Cd;
    public Text skillValue_Cpt;
    public Text skillValue_Cptpt;

    #endregion

	#region UNITY METHODE
	void Awake() {
		resourceLoader = GameObject.FindGameObjectWithTag("RessourceLoader").GetComponent<ResourceLoader>();
        navigation     = GameObject.FindGameObjectWithTag("Navigation")     .GetComponent<Navigation>();
        charactersData = GameObject.FindGameObjectWithTag("GameData")       .GetComponent<CharactersData>();

        // The list of all the skills.
        GameObject skillsHolder = GameObject.FindGameObjectWithTag("Skills");
        skillList = skillsHolder.GetComponent<SkillList>();
    }
	
	void Start() {
		UseExtraParam();
        FindCharacterDataKey();

        LoadSkillsList();
	}
	
	void Update() {
		
	}
    #endregion


    #region Default buttons
    public void SkillButton(Transform clickedSkillBtn) {
        // TODO: when instantiating all skills buttons, will need to fix they event (ex: UI_TeamList)



        /*int skillId = FindSkillId(skillSlot);

        // Keep in memory the selection for the Remove btn.
        isEquipmentSelected = false;
        isSkillSelected     = true;
        slotIndexSelected   = skillSlot;

        ClearSelectionSection();

        if(skillId != 0) {
            string className = charactersData.classNames[currentCharacterDataKey];
            Skill skill = skillList.GetSkill(className, skillId);

            selectedIcon.sprite = skill.GetIcon();
            selectedCost.text = "Cost: " + skill.GetCost();

            selectedName.text = skill.GetName();
            selectedLore.text = skill.GetLore();

            selectedSkillValue_Ap.transform.parent.gameObject.SetActive(true);

            selectedSkillValue_Ap   .text = skill.GetApCost().ToString();
            selectedSkillValue_Mp   .text = skill.GetMpCost().ToString();
            selectedSkillValue_Range.text = skill.GetMinRange() + "-" + skill.GetMaxRange();
            selectedSkillValue_UpPo .text = HelpingMethod.ConvertBoolToIndicator(skill.GetFlexibleRange());
            selectedSkillValue_Fov  .text = HelpingMethod.ConvertBoolToIndicator(skill.GetLineOfSight());
            selectedSkillValue_Cil  .text = HelpingMethod.ConvertBoolToIndicator(skill.GetCastStraightLine());
            selectedSkillValue_Cd   .text = skill.GetCooldown()            .ToString();
            selectedSkillValue_Cpt  .text = skill.GetCastPerTurn()         .ToString();
            selectedSkillValue_Cptpt.text = skill.GetCastPerTurnPerTarget().ToString();

            selectedSkillEffect.text = skill.GetDescription();
            
            remove_btn.interactable = true;
        }
        else {
            navigation.NavigateTo_SkillSelection(currentTeamId, currentCharacterId);
        }*/
    }

    public void SelectButton() {
        // TODO

        navigation.NavigateTo_CharacterCustomisation(currentTeamId, currentCharacterId);
    }

    public void CancelButton() {
        navigation.NavigateTo_CharacterCustomisation(currentTeamId, currentCharacterId);
    }

    public void EffectButton() {
        /*effect_btn.interactable = false;
        loreSection.SetActive(false);

        lore_btn.interactable = true;
        equipmentEffectSection.SetActive(true);
        skillEffectSection    .SetActive(true);*/
    }

    public void LoreButton() {
        /*lore_btn.interactable = false;
        equipmentEffectSection.SetActive(false);
        skillEffectSection    .SetActive(false);

        effect_btn.interactable = true;
        loreSection.SetActive(true);*/
    }
    #endregion


    private void UseExtraParam() {
        currentTeamId      = charactersData.ExtraParam_TeamId;
        currentCharacterId = charactersData.ExtraParam_CharacterId;

        charactersData.ExtraParam_TeamId      = 0;
        charactersData.ExtraParam_CharacterId = 0;
    }

    private void FindCharacterDataKey() {
        for(int i = 0; i < charactersData.ids.Count; i++) {
            if(charactersData.ids[i] == currentCharacterId) {
                currentCharacterDataKey = i;
                break;
            }
        }
    }

    private void LoadSkillsList() {
        // TODO
    }
}