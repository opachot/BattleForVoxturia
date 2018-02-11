/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    20 january 2018
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillList : MonoBehaviour {

    #region DECLARATION
    // CONST

    // PRIVATE
    private List<Skill> fighterSkills      = new List<Skill>();
    private List<Skill> hunterSkills       = new List<Skill>();
    private List<Skill> ninjaSkills        = new List<Skill>();
    private List<Skill> guardianSkills     = new List<Skill>();
    private List<Skill> elementalistSkills = new List<Skill>();
    private List<Skill> grimReaperSkills   = new List<Skill>();
    private List<Skill> druidSkills        = new List<Skill>();
    private List<Skill> samuraiSkills      = new List<Skill>();
    private List<Skill> vampireSkills      = new List<Skill>();
    private List<Skill> cyborgSkills       = new List<Skill>();

    // PUBLIC

    #endregion

	#region UNITY METHODE
	void Awake() {
        DontDestroyOnLoad(gameObject);

        LoadFighterSkills();
        LoadHunterSkills();
        LoadNinjaSkills();
        LoadGuardianSkills();
        LoadElementalistSkills();
        LoadGrimReaperSkills();
        LoadDruidSkills();
        LoadSamuraiSkills();
        LoadVampireSkills();
        LoadCyborgSkills();
    }
	
	void Start() {
		
	}
	
	void Update() {
		
	}
    #endregion


    #region Load Skills
    private void LoadFighterSkills() {
        GameObject skills = transform.Find("FighterSkills").gameObject;

        fighterSkills.Add(skills.GetComponent<FighterMeditation_Skill>());

    }

    private void LoadHunterSkills() {
        GameObject skills = transform.Find("HunterSkills").gameObject;

    }

    private void LoadNinjaSkills() {
        GameObject skills = transform.Find("NinjaSkills").gameObject;

    }

    private void LoadGuardianSkills() {
        GameObject skills = transform.Find("GuardianSkills").gameObject;

    }

    private void LoadElementalistSkills() {
        GameObject skills = transform.Find("ElementalistSkills").gameObject;

    }

    private void LoadGrimReaperSkills() {
        GameObject skills = transform.Find("GrimReaperSkills").gameObject;

    }

    private void LoadDruidSkills() {
        GameObject skills = transform.Find("DruidSkills").gameObject;

    }

    private void LoadSamuraiSkills() {
        GameObject skills = transform.Find("SamuraiSkills").gameObject;

    }

    private void LoadVampireSkills() {
        GameObject skills = transform.Find("VampireSkills").gameObject;

    }

    private void LoadCyborgSkills() {
        GameObject skills = transform.Find("CyborgSkills").gameObject;

    }
    #endregion


    public Skill GetSkill(string className, int skillId) {
        Skill skill = null;
        List<Skill> classSkillList = FindClassSkillList(className);

        for(int i = 0; i < classSkillList.Count; i++) {
            bool isSkillFound = classSkillList[i].GetId() == skillId;

            if(isSkillFound) {
                skill = classSkillList[i];
                break;
            }
        }

        return skill;
    }

    public Sprite GetSkillSprite(string className, int skillId) {
        Sprite skillSprite = new Sprite();
        List<Skill> classSkillList = FindClassSkillList(className);

        for(int i = 0; i < classSkillList.Count; i++) {
            bool isSkillFound = classSkillList[i].GetId() == skillId;

            if(isSkillFound) {
                skillSprite = classSkillList[i].GetIcon();
                break;
            }
        }

        return skillSprite;
    }

    public int GetTotalCost(string className, int skillId1, int skillId2, int skillId3, int skillId4, int skillId5) {
        int totalCost = 0;
        List<Skill> classSkillList = FindClassSkillList(className);

        for(int i = 0; i < classSkillList.Count; i++) {
            int idInList = classSkillList[i].GetId();

            bool isSkillFound = idInList == skillId1 || 
                                idInList == skillId2 ||
                                idInList == skillId3 ||
                                idInList == skillId4 ||
                                idInList == skillId5;

            if(isSkillFound) {
                totalCost += classSkillList[i].GetCost();
            }
        }

        return totalCost;
    }


    public List<Skill> FindClassSkillList(string className) {
        List<Skill> classSkillList;

        switch (className)
        {
            case "Fighter":
                classSkillList = fighterSkills;      break;
            case "Hunter":
                classSkillList = hunterSkills;       break;
            case "Ninja":
                classSkillList = ninjaSkills;        break;
            case "Guardian":
                classSkillList = guardianSkills;     break;
            case "Elementalist":
                classSkillList = elementalistSkills; break;
            case "GrimReaper":
                classSkillList = grimReaperSkills;   break;
            case "Druid":
                classSkillList = druidSkills;        break;
            case "Samurai":
                classSkillList = samuraiSkills;      break;
            case "Vampire":
                classSkillList = vampireSkills;      break;
            case "Cyborg":
                classSkillList = cyborgSkills;       break;
            default:
                Debug.Log("Error 404: Skill list not found");
                classSkillList = new List<Skill>();
                break;
        }

        return classSkillList;
    }
        
}