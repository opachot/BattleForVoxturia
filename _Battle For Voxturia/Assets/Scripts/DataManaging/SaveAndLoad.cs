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

        FileStream            computerFile_Teams = File.Create(Application.persistentDataPath + "/teamsInfo.dat");
        SerialisableTeamsData computerData_Teams = new SerialisableTeamsData();

        // TODO: Encryption

        // Write TeamsData to computer data.
        computerData_Teams.teamsId    = teamsData.teamsId;
        computerData_Teams.teamsNames = teamsData.teamsNames;

        bf.Serialize(computerFile_Teams, computerData_Teams);
        computerFile_Teams.Close();

        // Console line to help debugging.
        DebugLog_Saving(computerData_Teams);
    }

    public void Load() {
        if(File.Exists(Application.persistentDataPath + "/teamsInfo.dat")) {
            BinaryFormatter bf = new BinaryFormatter();

            FileStream            computerFile_Teams = File.Open(Application.persistentDataPath + "/teamsInfo.dat", FileMode.Open);
            SerialisableTeamsData computerData_Teams = (SerialisableTeamsData)bf.Deserialize(computerFile_Teams);
            computerFile_Teams.Close();

            // TODO: Decryption

            // Write computer data to TeamsData.
            teamsData.teamsId    = computerData_Teams.teamsId;
            teamsData.teamsNames = computerData_Teams.teamsNames;

            // Console line to help me debug.
            DebugLog_Loading(teamsData);
        }
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