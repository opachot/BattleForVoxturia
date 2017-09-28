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
    private TeamsData teamsData;

    // PUBLIC

    #endregion

	#region UNITY METHODE
	void Awake() {
        teamsData = gameObject.GetComponent<TeamsData>();
    }
	
	void Start() {
		
	}
	
	void Update() {
		
	}
    #endregion


    public void Save() {
        BinaryFormatter bf = new BinaryFormatter();

        FileStream            computerTeamsFile = File.Create(Application.persistentDataPath + "/Teams.dat");
        SerialisableTeamsData computerTeamsData = new SerialisableTeamsData();

        // TODO: Encryption

        // Write TeamsData to computer data.
        TeamsData_To_ComputerTeamsData(computerTeamsData);

        bf.Serialize(computerTeamsFile, computerTeamsData);
        computerTeamsFile.Close();

        // Console line to help debugging.
        DebugLog_Saving(computerTeamsData);
    }

    public void Load() {
        if(File.Exists(Application.persistentDataPath + "/Teams.dat")) {
            BinaryFormatter bf = new BinaryFormatter();

            FileStream            computerTeamsFile = File.Open(Application.persistentDataPath + "/Teams.dat", FileMode.Open);
            SerialisableTeamsData computerTeamsData = (SerialisableTeamsData)bf.Deserialize(computerTeamsFile);
            computerTeamsFile.Close();

            // TODO: Decryption

            // Write computer data to TeamsData.
            ComputerTeamsData_To_TeamsData(computerTeamsData);
            
            // Console line to help me debug.
            DebugLog_Loading(teamsData);
        }
    }


    private void TeamsData_To_ComputerTeamsData(SerialisableTeamsData computerTeamsData) {
        computerTeamsData.ids          = teamsData.ids;
        computerTeamsData.names        = teamsData.names;
        computerTeamsData.levels       = teamsData.levels;
        computerTeamsData.currentXps   = teamsData.currentXps;
        computerTeamsData.goalXps      = teamsData.goalXps;
        computerTeamsData.victorys     = teamsData.victorys;
        computerTeamsData.defeats      = teamsData.defeats;
        computerTeamsData.currentCosts = teamsData.currentCosts;
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
        teamsData.currentCosts = computerTeamsData.currentCosts;
        teamsData.maxCosts     = computerTeamsData.maxCosts;
        teamsData.usedTeamId   = computerTeamsData.usedTeamId;
    }


    #region DEBUGGING METHODE
    public void DebugLog_Saving(SerialisableTeamsData computerData_Teams) {
        Debug.Log("Saving completed!");

        string json = JsonUtility.ToJson(computerData_Teams);
        Debug.Log(json);
    }

    public void DebugLog_Loading(TeamsData gameData) {
        Debug.Log("Loading completed!");

        string json = JsonUtility.ToJson(gameData);
        Debug.Log(json);
    }
    #endregion
}