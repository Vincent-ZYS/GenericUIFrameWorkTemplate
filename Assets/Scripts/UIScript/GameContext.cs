using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The entrance of the testing UI Framework demo.
/// </summary>
public class GameContext : MonoBehaviour
{
    public void OnSettingPanelClick()
    {
        UIManager.Instance.PushPanel(UIPanelType.Setting_Panel);
    }

    public void OnPausePanelClick()
    {
        UIManager.Instance.PushPanel(UIPanelType.Pause_Panel);
    }

    public void OnLogPanelClick()
    {

    }
}
