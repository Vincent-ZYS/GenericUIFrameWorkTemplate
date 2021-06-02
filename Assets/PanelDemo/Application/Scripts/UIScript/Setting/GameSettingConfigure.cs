using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettingConfigure : ScriptableObject
{
    //Graphic setting
    public string resolutionSt = "1024x768";
    [HideInInspector]
    public int resolutionIndex = 0;
    public float brightnessSt = 0.5f;
    public bool isFullScreen = true;
    public bool isVerticalSyn = false;

    //Audio setting
    public float bgMusic = 0.5f;
    public float sounds = 0.5f;
    public bool isBgMusicOn = true;
    public bool isSoundsOn = true;

    //System setting
    public string languageOption = "简体中文";

    public void ResetTheEntireSetting()
    {
        resolutionSt = "1024x768";
        resolutionIndex = 0;
        brightnessSt = 0.5f;
        isFullScreen = true;
        isVerticalSyn = false;
        bgMusic = 0.5f;
        sounds = 0.5f;
        isBgMusicOn = true;
        isSoundsOn = true;
        languageOption = "简体中文";
    }
}