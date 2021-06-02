using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePausePanel : BasePanel
{
    private CanvasGroup canvasGroup;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public override void OnEnter()
    {
        base.OnEnter();
        if (canvasGroup == null)
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1;
    }

    public override void OnExit()
    {
        base.OnExit();
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0;
        UIManager.Instance.PopPanel();
    }

    public void OnSettingPanelClick()
    {
        UIManager.Instance.PushPanel(UIPanelType.Setting_Panel);
    }
}
