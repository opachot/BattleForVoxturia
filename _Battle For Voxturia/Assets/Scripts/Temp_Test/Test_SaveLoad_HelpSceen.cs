/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    DAY MONTH YEARS
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test_SaveLoad_HelpSceen : MonoBehaviour {

	#region DECLARATION
    // CONST

    // PRIVATE
    private SaveAndLoad saveAndLoad;

    // PUBLIC

    #endregion

	#region UNITY METHODE
	void Awake() {
		saveAndLoad = GameObject.FindGameObjectWithTag("GameData").GetComponent<TeamsData>().GetComponent<SaveAndLoad>();
    }
	
	void Start() {
		
	}
	
	void Update() {
		
	}
    #endregion

    public void TEMP_TEST_SAVE() {
        saveAndLoad.Save();
    }

    public void TEMP_TEST_LOAD() {
        saveAndLoad.Load();
    }

    public void RETURN() {
        SceneManager.LoadScene("Hub");
    }
}