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

    // PRIVATE
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

    #endregion

	#region UNITY METHODE
	void Awake() {
		
    }
	
	void Start() {
		
	}
	
	void Update() {
		
	}
	#endregion
	

    public void CreateNewTeam(int teamId, string className, string characterName) {
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
    }

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

    public bool IsExistingName(string paramName) {
        bool isExistingName = false;

        foreach(string name in names) {
            if(paramName.ToLower() == name.ToLower()) {
                isExistingName = true;
                break;
            }
        }

        return isExistingName;
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