/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    DAY MONTH YEARS
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class testTextMeshProLinkEvent : MonoBehaviour, IPointerClickHandler {

	#region DECLARATION
    // CONST

    // PRIVATE
    private TMP_Text m_TextComponent;

    // PUBLIC

    #endregion

	#region UNITY METHODE
	void Awake() {
		m_TextComponent = gameObject.GetComponent<TMP_Text>();
    }
	
	void Start() {
		
	}
	
	void Update() {
		
	}
    #endregion


    public void OnPointerClick(PointerEventData pointerEventData)
    {
        int linkIndex = TMP_TextUtilities.FindIntersectingLink(m_TextComponent, Input.mousePosition, Camera.main);
        if(linkIndex != -1) {
            TMP_LinkInfo linkInfo = m_TextComponent.textInfo.linkInfo[linkIndex];
            Debug.Log(linkInfo.GetLinkID());
        }

        m_TextComponent.text = "<link=potato>HelloWorld</link> well hi there! <link=hum>test</link>";
    }

}