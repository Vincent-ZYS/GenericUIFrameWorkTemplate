using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    /// <summary>
    /// The private _instance paramtere use for this script.
    /// </summary>
    //private static UIManager _instance;
    /// <summary>
    /// To store the current main canvas.
    /// </summary>
    private Transform canvasTransform;
    /// <summary>
    /// A dictionary to store the panel's prefab path information.
    /// </summary>
    private Dictionary<UIPanelType, string> panelPathDict;
    /// <summary>
    /// Store different UIPanelType's BasePanel component into the dictionary.
    /// </summary>
    private Dictionary<UIPanelType, BasePanel> panelDict;

    /// <summary>
    /// The UI Panel Stack to push,pop,peek the current initiated UI Panel to display.
    /// </summary>
    private Stack<BasePanel> panelStack;

    /// <summary>
    /// The Singleton pattern function for other scripts to get this UIManager.
    /// </summary>
    /// <returns></returns>
    //public static UIManager Intance()
    //{
    //    if(_instance == null)
    //    {
    //        _instance = FindObjectOfType<UIManager>();
    //    }
    //    return _instance;
    //}

    private Transform CanvasTransform
    {
        get
        {
            if(canvasTransform == null)
            {
                canvasTransform = GameObject.Find("UICanvas").transform;
            }
            return canvasTransform;
        }
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
        TextAsset ta = Resources.Load<TextAsset>("UIResource/UIPanelType");
        UIPanelTypeJson jsonObject = JsonUtility.FromJson<UIPanelTypeJson>(ta.text);
        foreach(UIPanelTypeObjectInfo info in jsonObject.infoList)
        {
            panelPathDict.Add(info.panelType, info.path);
        }
    }

    public void PushPanel(UIPanelType panelType)
    {
        if(panelStack == null)
        {
            panelStack = new Stack<BasePanel>();
        }
        if(panelStack.Count > 0)
        {
            BasePanel curTopPanel = panelStack.Peek();
            curTopPanel.OnPause();
        }
        BasePanel curPushPanel = GetPanel(panelType);
        curPushPanel.OnEnter();
        panelStack.Push(curPushPanel);
    }

    public void PopPanel()
    {
        if(panelStack == null)
        {
            panelStack = new Stack<BasePanel>();
        }
        if (panelStack.Count <= 0) { return; }
        BasePanel curPopPanel = panelStack.Pop();
        curPopPanel.OnExit();
        if(panelStack.Count > 0)
        {
            BasePanel curTopPanel = panelStack.Peek();
            curTopPanel.OnResume();
        }
    }

    public BasePanel GetPanel(UIPanelType panelType)
    {
        if(panelDict == null)
        {
            panelDict = new Dictionary<UIPanelType, BasePanel>();
        }
        BasePanel curPanel = panelDict.TryGet(panelType);
        if(curPanel == null)
        {
            string panelPrefabPath = panelPathDict.TryGet(panelType);
            GameObject instPanelGo = GameObject.Instantiate(Resources.Load(panelPrefabPath)) as GameObject;
            instPanelGo.transform.SetParent(CanvasTransform,false);
            if(panelDict.ContainsKey(panelType) == false)
            {
                panelDict.Add(panelType, instPanelGo.GetComponent<BasePanel>());
            }
            return instPanelGo.GetComponent<BasePanel>();
        }else
        {
            return curPanel;
        }
    }
}
