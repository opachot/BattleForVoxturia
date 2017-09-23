/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    23 September 2017
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour {

    #region DECLARATION
    // CONST
    
    // PRIVATE
    private int[]    teamsId;
    private string[] teamsNames;

    // PUBLIC

    #endregion

    #region UNITY METHODE
    void Awake() {
        DontDestroyOnLoad(gameObject);
    }
	
	void Start() {
        
	}
	
	void Update() {
		
	}
	#endregion
	
    #region GET//SET
    public int[]    TeamsId    { get; set; }
    public string[] TeamsNames { get; set; }
    #endregion
}