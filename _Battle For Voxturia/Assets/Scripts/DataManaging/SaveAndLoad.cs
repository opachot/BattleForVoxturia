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
    private GameData gameData;

    // PUBLIC

    #endregion

	#region UNITY METHODE
	void Awake() {
        gameData = gameObject.GetComponent<GameData>();
    }
	
	void Start() {
		
	}
	
	void Update() {
		
	}
    #endregion


    public void Save() {
        BinaryFormatter bf   = new BinaryFormatter();

        FileStream            computerFile_Teams = File.Create(Application.persistentDataPath + "/teamsInfo.dat");
        SerialisableTeamsInfo ComputerData_Teams = new SerialisableTeamsInfo();

        // TODO: Encryption

        // Write GameData to computer data.
        ComputerData_Teams.TeamsId    = gameData.TeamsId;
        ComputerData_Teams.TeamsNames = gameData.TeamsNames;

        //--------------------testing values-----------------------
        const int NB_TEAM = 3;
        ComputerData_Teams.TeamsNames = new string[NB_TEAM];
        string[] myTeamsNames = new string[] {"TrolololTeam",
                                              "xyzTeam"     ,
                                              "metaTeam"    };

        for(int i = 0; i < NB_TEAM; i++) {
            ComputerData_Teams.TeamsNames[i] = myTeamsNames[i];
        }
        //---------------------------------------------------------

        bf.Serialize(computerFile_Teams, ComputerData_Teams);
        computerFile_Teams.Close();

        Debug.Log("Saving completed!");
    }

    public void Load() {
        if(File.Exists(Application.persistentDataPath + "/teamsInfo.dat")) {
            BinaryFormatter bf   = new BinaryFormatter();

            FileStream            computerFile_Teams = File.Open(Application.persistentDataPath + "/teamsInfo.dat", FileMode.Open);
            SerialisableTeamsInfo ComputerData_Teams = (SerialisableTeamsInfo)bf.Deserialize(computerFile_Teams);
            computerFile_Teams.Close();

            // TODO: Decryption

            // Write computer data to GameData.
            gameData.TeamsId    = ComputerData_Teams.TeamsId;
            gameData.TeamsNames = ComputerData_Teams.TeamsNames;

            Debug.Log("Loading completed!");
        }
    }
}