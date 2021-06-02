using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MoreMountains.TopDownEngine;


public class TypeChoseAnim : MonoBehaviour
{
    public bool isSettingBtn = false;
    //if not settingbtn panel, chose the itemtype
    //public ItemType btnType;
    //if is settingbtn panel, chose this type
    public SettingType setBtnType;

    private Animator btnAnim;

    void OnEnable()
    {
        if (!isSettingBtn)
        {
            //InventoryBtnManager.Instance.BtnClickAnimChangeEvent += ClickAnimChange;
        }
        else
        {
            SettingPanelManager.Instance.SetPlBtnClickEvent += SetBtnClickChange;
        }
    }

    void OnDisable()
    {
        if (!isSettingBtn)
        {
            //InventoryBtnManager.Instance.BtnClickAnimChangeEvent -= ClickAnimChange;
        }
        else
        {
            SettingPanelManager.Instance.SetPlBtnClickEvent -= SetBtnClickChange;
        }
    }

    void Awake()
    {
        if (!isSettingBtn)
        {
            btnAnim = GetComponent<Animator>();
        }
    }

    void Start()
    {
        if (!isSettingBtn)
        {
            //if (btnType == InventoryBtnManager.Instance.currentBtnType)
            //{
            //    GetComponent<Animator>().SetBool("isChose", true);
            //}
            //else
            //{
            //    GetComponent<Image>().color = new Color(186 / 255f, 186 / 255f, 186 / 255f);
            //}
        }
        else
        {
            if (setBtnType == SettingPanelManager.Instance.currentSetType)
            {
                GetComponent<Image>().color = new Color(1f, 1f, 1f);
                transform.Find("Text").GetComponent<Text>().color = new Color(253 / 255f, 253 / 255f, 253 / 255f);
            }
            else
            {
                GetComponent<Image>().color = new Color(147 / 255f, 147 / 255f, 147 / 255f);
                transform.Find("Text").GetComponent<Text>().color = new Color(195 / 255f, 195 / 255f, 195 / 255f);
            }
        }
    }

    //the btn click change for inventory
    private void ClickAnimChange(bool isChose, string btnName)
    {
        if (btnName != gameObject.name)
        {
            btnAnim.SetBool("isChose", isChose);
            GetComponent<Image>().color = new Color(186 / 255f, 186 / 255f, 186 / 255f);
        }
        else
        {
            GetComponent<Image>().color = new Color(1, 1, 1);
        }
    }

    //the btn click change for setting panel
    private void SetBtnClickChange(bool isChose, string btnName)
    {
        if (btnName != gameObject.name)
        {
            GetComponent<Image>().color = new Color(147 / 255f, 147 / 255f, 147 / 255f);
            transform.Find("Text").GetComponent<Text>().color = new Color(195 / 255f, 195 / 255f, 195 / 255f);
        }
        else
        {
            GetComponent<Image>().color = new Color(1f, 1f, 1f);
            transform.Find("Text").GetComponent<Text>().color = new Color(253 / 255f, 253 / 255f, 253 / 255f);
        }
    }
    //TODO代码待优化
}
