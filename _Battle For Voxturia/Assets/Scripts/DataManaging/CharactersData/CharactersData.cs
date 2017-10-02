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