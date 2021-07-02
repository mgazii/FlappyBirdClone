using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameConstants
{
    // Scene names for easy access
    public enum SCENE
    {
        GAMEPLAYSCENE,STARTSCENE
    }
    // max score key for Player.Prefs
    public static string MAX_SCORE = "_maxScore";
    // start button name for control
    public static string START_BUTTON = "_start_button";
    // obstacle tag for points and death
    public static string OBSTACLE = "Obstacle";
}
