using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
//using HTLibrary.Application;

public enum SettingType
{
    gameSetting,
    operationSetting
}
//manage the different part of the panel
public class SettingPanelManager : MonoBehaviour
{
    private static SettingPanelManager _instance;
    public GameSettingConfigure gameStConfigGo;
    public List<Button> btnGroup = new List<Button>();
    public event Action<bool, string> SetPlBtnClickEvent;
    [HideInInspector]
    public SettingType currentSetType = SettingType.gameSetting;
    public GameObject gameSetPartGo;
    public GameObject optSetPartGo;

    public static SettingPanelManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SettingPanelManager>();
            }
            return _instance;
        }
    }

    private void OnEnable()
    {
        SetPlBtnClickEvent += OnSetPanelIsOnOrNot;
    }

    private void OnDisable()
    {
        SetPlBtnClickEvent -= OnSetPanelIsOnOrNot;
    }

    private void Awake()
    {
        if (btnGroup != null)
        {
            foreach (Button btn in btnGroup)
            {
                btn.onClick.AddListener(delegate
                {
                    switch (btn.name)
                    {
                        case "gameSetting_Btn":
                            OnSetPanelBtnClick(btn, SettingType.gameSetting);
                            break;
                        //case "operationSetting_Btn":
                        //    OnSetPanelBtnClick(btn, SettingType.operationSetting);
                        //    break;
                    }
                });
            }
        }
    }

    public void OnSetPanelBtnClick(Button btn, SettingType curSetTyp)
    {
        currentSetType = curSetTyp;
        SetPlBtnClickEvent?.Invoke(true, btn.name);
    }

    public void OnSetPanelIsOnOrNot(bool isOn, string btnName)
    {
        optSetPartGo.SetActive(btnName == "operationSetting_Btn");
        gameSetPartGo.SetActive(btnName == "gameSetting_Btn");
    }

    public void OnReturnBtnClick()
    {
        UIManager.Instance.PopPanel();
    }


    //Extra initial of setting may happen
    private void InitialSettingConfigure()
    {
        //Initial GameSetting part configure
        gameObject.GetComponent<GameSettingPanel>().InitialSaveSetting();

        //Initial OperationSetting part configure
        //TODO
    }
}

