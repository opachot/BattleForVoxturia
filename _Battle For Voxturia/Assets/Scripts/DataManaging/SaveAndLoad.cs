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

/***************************
 *          -NOTE-
 * Will need to acces all the thing that will need to be saved.
 * ************************/

public class SaveAndLoad : MonoBehaviour {

	#region DECLARATION
    // CONST

    // PRIVATE

    // PUBLIC

    #endregion

	#region UNITY METHODE
	void Awake() {
        print("Application.persistentDataPath: " + Application.persistentDataPath);
    }
	
	void Start() {
		
	}
	
	void Update() {
		
	}
    #endregion


    public void Save() {
        BinaryFormatter bf   = new BinaryFormatter();
        FileStream      file = File.Create(Application.persistentDataPath + "/teamsInfo.dat");

        SerialisableTeamsInfo teamsData = new SerialisableTeamsInfo();

        //--------------------testing values-----------------------
        // Need to encrypt and only pass a string

        const int NB_TEAM = 3;
        teamsData.teamsNames = new string[NB_TEAM];
        string[] myTeamsNames = new string[] {"TrolololTeam",
                                              "xyzTeam"     ,
                                              "metaTeam"    };

        for(int i = 0; i < NB_TEAM; i++) {
            teamsData.teamsNames[i] = myTeamsNames[i];
        }
        //---------------------------------------------------------

        bf.Serialize(file, teamsData);
        file.Close();

        print("Saving completed!");
        print("Saved teams names: " + teamsData.teamsNames[0] + " - " + teamsData.teamsNames[1] + " - " + teamsData.teamsNames[2]);
    }

    public void Load() {
        if(File.Exists(Application.persistentDataPath + "/teamsInfo.dat")) {
            BinaryFormatter bf   = new BinaryFormatter();
            FileStream      file = File.Open(Application.persistentDataPath + "/teamsInfo.dat", FileMode.Open);

            SerialisableTeamsInfo teamsData = (SerialisableTeamsInfo)bf.Deserialize(file);
            file.Close();
            // Need to decript

            print("Loading completed!");
            print("Loaded teams names: " + teamsData.teamsNames[0] + " - " + teamsData.teamsNames[1] + " - " + teamsData.teamsNames[2]);
        }
    }
}