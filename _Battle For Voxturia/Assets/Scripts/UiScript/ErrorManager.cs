/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    28 September 2017
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ErrorManager : MonoBehaviour {

    #region DECLARATION
    // CONST
    const string DEFAULT_MESSAGE = "Unknown Error";

    // PRIVATE

    // PUBLIC
    [System.Serializable] 
    public struct ErrorPopUp {
        public GameObject popUp;
        public Text       message;
    }
    public ErrorPopUp errorPopUp;
    #endregion

	#region UNITY METHODE
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Update() {
		
	}
    #endregion

    // Called by delegate.
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        PlaceErrorPopUpInCanvas();
    }

    #region ErrorPopUp hierarchy move
    private void PlaceErrorPopUpInCanvas() {
        GameObject canvas = GameObject.Find("Canvas");

        if(canvas != null) {
            gameObject.transform.SetParent(canvas.transform);
        }
    }

    public void PlaceErrorPopUpInDontDestroyOnLoad() {
        gameObject.transform.parent = null;
        DontDestroyOnLoad(gameObject);
    }
    #endregion


    #region Default buttons
    public void ErrorOkButton() {
        errorPopUp.popUp.SetActive(false);
        errorPopUp.message.text = DEFAULT_MESSAGE;
    }
    #endregion


    public void TrowError(string error) {
        errorPopUp.message.text = error;
        errorPopUp.popUp.SetActive(true);
    }
}