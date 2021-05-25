using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UIPanelTypeObjectInfo : ISerializationCallbackReceiver
{
    [NonSerialized]
    public UIPanelType panelType;
    public string panelTypeString;
    public string path;

    void ISerializationCallbackReceiver.OnAfterDeserialize()
    {
        UIPanelType type = (UIPanelType)Enum.Parse(typeof(UIPanelType), panelTypeString);
        panelType = type;
    }

    void ISerializationCallbackReceiver.OnBeforeSerialize()
    {

    }
}
