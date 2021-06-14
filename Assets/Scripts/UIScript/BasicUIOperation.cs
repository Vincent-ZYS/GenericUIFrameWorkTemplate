using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicUIOperation : MonoBehaviour
{
    public GameObject SettingPanelGo;
    public GameObject PausePanelGo;
    private Transform canvasUITf;

    private GameObject currentPausePanelGo;
    private GameObject currentSettingPanelGo;

    private void Awake()
    {
        canvasUITf = GameObject.Find("UICanvas").transform;
    }

    public void OnClickPausePanelClick()
    {
        if(PausePanelGo!=null)
        {
            currentPausePanelGo = Instantiate(PausePanelGo, canvasUITf);
            currentPausePanelGo.transform.Find("Resume_Btn").GetComponent<Button>().onClick.AddListener(OnResumeClick);
            currentPausePanelGo.transform.Find("Setting_Btn").GetComponent<Button>().onClick.AddListener(OnClickSettingPanelClick);
        }
        currentPausePanelGo.SetActive(true);
    }

    public void OnResumeClick()
    {
        Destroy(currentPausePanelGo);
    }
    public void OnClickSettingPanelClick()
    {
        if (SettingPanelGo != null)
        {
            currentSettingPanelGo = Instantiate(SettingPanelGo, canvasUITf);
            currentSettingPanelGo.transform.Find("GameSettingPart/Return_btn").GetComponent<Button>().onClick.AddListener(OnSettingCloseClick);
        }
        currentSettingPanelGo.SetActive(true);
    }

    public void OnSettingCloseClick()
    {
        Destroy(currentSettingPanelGo);
    }
}
