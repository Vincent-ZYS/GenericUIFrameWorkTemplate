using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HTLibrary.Utility
{
    public class SettingPrompt : MonoBehaviour
    {
        private static SettingPrompt _instance;
        private CanvasGroup canvasGp;
        private Text setTitleTxt;
        private Text valChangeTxt;

        private void Awake()
        {
            canvasGp = GetComponent<CanvasGroup>();
            canvasGp.alpha = 0f;
            setTitleTxt = transform.Find("setTitle_txt").GetComponent<Text>();
            valChangeTxt = transform.Find("sldPercent_txt").GetComponent<Text>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonUp(0)&&canvasGp.alpha>0)
            {
                StartCoroutine(FadeToHide());
            }
        }

        public static SettingPrompt Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = FindObjectOfType<SettingPrompt>();
                }
                return _instance;
            }
        }

        public void ShowPrompt(string title, float val)
        {
            canvasGp.alpha = 1f;
            setTitleTxt.text = title;
            valChangeTxt.text = val.ToString() + "%";
        }

        IEnumerator FadeToHide()
        {
            yield return null;
            while(canvasGp.alpha>0)
            {
                canvasGp.alpha -= Time.unscaledDeltaTime*1.7f;
                yield return null;
            }
        }
    }
}
