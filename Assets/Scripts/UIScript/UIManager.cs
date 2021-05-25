using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    /// <summary>
    /// The private _instance paramtere use for this script.
    /// </summary>
    private UIManager _instance;
    /// <summary>
    /// A dictionary to store the panel's prefab path information.
    /// </summary>
    private Dictionary<UIPanelType, string> panelPathDict;

    private Dictionary<UIPanelType, BasePanel> panelDict;

    /// <summary>
    /// The Singleton pattern function for other scripts to get this UIManager.
    /// </summary>
    /// <returns></returns>
    public UIManager Intance()
    {
        if(_instance == null)
        {
            _instance = FindObjectOfType<UIManager>();
        }
        return _instance;
    }

    /// <summary>
    /// The UIManager Constrcutor, implemented once the Instance function is called.
    /// </summary>
    public UIManager()
    {
        ParseUIPanelTypeJsonFile();
    }

    [Serializable]
    class UIPanelTypeJson
    {
        public List<UIPanelTypeObjectInfo> infoList = new List<UIPanelTypeObjectInfo>();
    }

    /// <summary>
    /// Parse the "UIPanelType" Json file to acquire the object inside of it.
    /// </summary>
    private void ParseUIPanelTypeJsonFile()
    {
        panelPathDict = new Dictionary<UIPanelType, string>();
        TextAsset ta = Resources.Load<TextAsset>("UIPanelType");
        UIPanelTypeJson jsonObject = JsonUtility.FromJson<UIPanelTypeJson>(ta.text);
        foreach(UIPanelTypeObjectInfo info in jsonObject.infoList)
        {
            panelPathDict.Add(info.panelType, info.path);
        }
    }
}
