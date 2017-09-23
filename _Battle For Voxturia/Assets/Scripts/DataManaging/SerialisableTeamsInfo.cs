﻿/*
Company: Voxturia Game
Author:  Sébastien Godbout
Date:    23 September 2017
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/***************************
 *          -NOTE-
 * Save teams name, levels and other team stats.
 * Save teams character, they skills and they equipment and lvl, etc...
 * Save character reserve list.
 * Save discovered items/budget
 * Save map/quest progression
 * Save option
 * ************************/

[Serializable]
public class SerialisableTeamsInfo {

    #region DECLARATION
    // CONST

    // PRIVATE
    private int[]    teamsId;
    private string[] teamsNames;

    // PUBLIC


    #endregion


    #region GET//SET
    public int[]    TeamsId    { get; set; }
    public string[] TeamsNames { get; set; }
    #endregion
}