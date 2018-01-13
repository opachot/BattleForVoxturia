/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    23 September 2017
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveAndLoad : MonoBehaviour {

    #region DECLARATION
    // CONST

    // PRIVATE
    private TeamsData      teamsData;
    private CharactersData charactersData;

    // PUBLIC

    #endregion

	#region UNITY METHODE
	void Awake() {
        DontDestroyOnLoad(gameObject);

        teamsData      = gameObject.GetComponent<TeamsData>();
        charactersData = gameObject.GetComponent<CharactersData>();
    }
	
	void Start() {
		
	}
	
	void Update() {
		
	}
    #endregion


    public void Save() {
        BinaryFormatter bf = new BinaryFormatter();

        FileStream computerTeamsFile      = File.Create(Application.persistentDataPath + "/Teams.dat");
        FileStream computerCharactersFile = File.Create(Application.persistentDataPath + "/Characters.dat");

        SerialisableTeamsData      computerTeamsData      = new SerialisableTeamsData();
        SerialisableCharactersData computerCharactersData = new SerialisableCharactersData();

        TeamsData_To_ComputerTeamsData          (computerTeamsData);
        CharactersData_To_ComputerCharactersData(computerCharactersData);

        bf.Serialize(computerTeamsFile,      computerTeamsData);
        bf.Serialize(computerCharactersFile, computerCharactersData);

        computerTeamsFile     .Close();
        computerCharactersFile.Close();

        Debug.Log("Saving...");
    }

    public void Load() {
        BinaryFormatter bf = new BinaryFormatter();

        // LOAD TEAMS
        if(File.Exists(Application.persistentDataPath + "/Teams.dat")) {
            FileStream            computerTeamsFile = File.Open(Application.persistentDataPath + "/Teams.dat", FileMode.Open);
            SerialisableTeamsData computerTeamsData = (SerialisableTeamsData)bf.Deserialize(computerTeamsFile);
            computerTeamsFile     .Close();

            ComputerTeamsData_To_TeamsData(computerTeamsData);
            
        }

        // LOAD CHARACTERS
        if(File.Exists(Application.persistentDataPath + "/Characters.dat")) {
            FileStream                 computerCharactersFile = File.Open(Application.persistentDataPath + "/Characters.dat", FileMode.Open);
            SerialisableCharactersData computerCharactersData = (SerialisableCharactersData)bf.Deserialize(computerCharactersFile);
            computerCharactersFile.Close();
            
            ComputerCharactersData_To_CharactersData(computerCharactersData);
        }

        Debug.Log("Loading...");
    }

    #region TeamsData
    private void TeamsData_To_ComputerTeamsData(SerialisableTeamsData computerTeamsData) {
        computerTeamsData.ids          = teamsData.ids;
        computerTeamsData.names        = teamsData.names;
        computerTeamsData.levels       = teamsData.levels;
        computerTeamsData.currentXps   = teamsData.currentXps;
        computerTeamsData.goalXps      = teamsData.goalXps;
        computerTeamsData.victorys     = teamsData.victorys;
        computerTeamsData.defeats      = teamsData.defeats;
        computerTeamsData.maxCosts     = teamsData.maxCosts;
        computerTeamsData.usedTeamId   = teamsData.usedTeamId;
    }

    private void ComputerTeamsData_To_TeamsData(SerialisableTeamsData computerTeamsData) {
        teamsData.ids          = computerTeamsData.ids;
        teamsData.names        = computerTeamsData.names;
        teamsData.levels       = computerTeamsData.levels;
        teamsData.currentXps   = computerTeamsData.currentXps;
        teamsData.goalXps      = computerTeamsData.goalXps;
        teamsData.victorys     = computerTeamsData.victorys;
        teamsData.defeats      = computerTeamsData.defeats;
        teamsData.maxCosts     = computerTeamsData.maxCosts;
        teamsData.usedTeamId   = computerTeamsData.usedTeamId;
    }
    #endregion

    #region CharactersData
    private void CharactersData_To_ComputerCharactersData(SerialisableCharactersData computerCharactersData) {
        computerCharactersData.ids           = charactersData.ids;
        computerCharactersData.teamDataIds   = charactersData.teamDataIds;

        computerCharactersData.classNames    = charactersData.classNames;

        computerCharactersData.names         = charactersData.names;
        computerCharactersData.levels        = charactersData.levels;
        computerCharactersData.currentXps    = charactersData.currentXps;
        computerCharactersData.goalXps       = charactersData.goalXps;

        computerCharactersData.skillOneIds   = charactersData.skillOneIds;
        computerCharactersData.skillTwoIds   = charactersData.skillTwoIds;
        computerCharactersData.skillThreeIds = charactersData.skillThreeIds;
        computerCharactersData.skillFourIds  = charactersData.skillFourIds;
        computerCharactersData.skillFiveIds  = charactersData.skillFiveIds;

        computerCharactersData.helmetIds     = charactersData.helmetIds;
        computerCharactersData.armorIds      = charactersData.armorIds;
        computerCharactersData.greaveIds     = charactersData.greaveIds;
        computerCharactersData.bootsIds      = charactersData.bootsIds;
        computerCharactersData.jewelIds      = charactersData.jewelIds;

        computerCharactersData.costs         = charactersData.costs;
    }

    private void ComputerCharactersData_To_CharactersData(SerialisableCharactersData computerCharactersData) {
        charactersData.ids           = computerCharactersData.ids;
        charactersData.teamDataIds   = computerCharactersData.teamDataIds;
 
        charactersData.classNames    = computerCharactersData.classNames;
     
        charactersData.names         = computerCharactersData.names;
        charactersData.levels        = computerCharactersData.levels;
        charactersData.currentXps    = computerCharactersData.currentXps;
        charactersData.goalXps       = computerCharactersData.goalXps;
     
        charactersData.skillOneIds   = computerCharactersData.skillOneIds;
        charactersData.skillTwoIds   = computerCharactersData.skillTwoIds;
        charactersData.skillThreeIds = computerCharactersData.skillThreeIds;
        charactersData.skillFourIds  = computerCharactersData.skillFourIds;
        charactersData.skillFiveIds  = computerCharactersData.skillFiveIds;
        
        charactersData.helmetIds     = computerCharactersData.helmetIds;
        charactersData.armorIds      = computerCharactersData.armorIds;
        charactersData.greaveIds     = computerCharactersData.greaveIds;
        charactersData.bootsIds      = computerCharactersData.bootsIds;
        charactersData.jewelIds      = computerCharactersData.jewelIds;

        charactersData.costs         = computerCharactersData.costs;
    }
    #endregion
}