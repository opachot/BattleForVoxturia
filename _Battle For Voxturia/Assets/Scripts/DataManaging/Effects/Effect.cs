/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    DAY MONTH YEARS
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour {

	#region DECLARATION
    // CONST

    // PRIVATE

    // PROTECTED
    protected new string name;
    protected string     description;
    protected int        maxLvl;
    protected bool       isUnbuffable;
    protected string     specificClassName;

    // PUBLIC

    #endregion


    public string GetName() {
        return name;
    }

    public string GetDescription() {
        return description;
    }

    public int GetMaxLvl() {
        return maxLvl;
    }

    public bool GetIsUnbuffable() {
        return isUnbuffable;
    }

    public string GetSpecificClassName() {
        return specificClassName;
    }
}