using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HTLibrary.Utility;

namespace MoreMountains.TopDownEngine
{
    public class GraphicSettingPart : MonoBehaviour
    {
        //Graphic
        public Toggle verticalSynTgl;
        public Toggle fullScreenTgl;
        public Slider brightnessSld;
        public Dropdown resolutionDpd;

        private bool isInitial = true;

        private void Awake()
        {
            InitalCurrentStatus(true);
            //InitialForComponent(true);
        }

        #region Graphic Setting
        public void OnVerticalSynTglClick(bool isOn)
        {
            SettingPanelManager.Instance.gameStConfigGo.isVerticalSyn = verticalSynTgl.isOn;
        }

        public void OnFullScreenTgClick(bool isOn)
        {
            SettingPanelManager.Instance.gameStConfigGo.isFullScreen = fullScreenTgl.isOn;
        }

        public void OnBrightnessSld(float val)
        {
            val = brightnessSld.value;
            SettingPanelManager.Instance.gameStConfigGo.brightnessSt = val/10;
            if(!isInitial)
            {
                SettingPrompt.Instance.ShowPrompt("亮度", val * 10);
            }
        }

        public void OnResolutionDpdwn(string optionStr)
        {
            optionStr = resolutionDpd.captionText.text;
            SettingPanelManager.Instance.gameStConfigGo.resolutionIndex = ResolutionOption(optionStr);
            SettingPanelManager.Instance.gameStConfigGo.resolutionSt = optionStr;
        }

        private int ResolutionOption(string optionStr)
        {
            int resolutIndex = 0;
            switch (optionStr)
            {
                case "1024x768": resolutIndex = 0; break;
                case "1600x900": resolutIndex = 1; break;
                case "1920x1080": resolutIndex = 2; break;
                default:
                    optionStr = "1024x768";
                    SettingPanelManager.Instance.gameStConfigGo.resolutionIndex = 0;
                    resolutIndex = 0;
                    break;
            }
            return resolutIndex;
        }
        #endregion

        //initial works
        public void InitialForComponent(bool isFirstTime)
        {
            isInitial = !isFirstTime;//false;
            verticalSynTgl.isOn = SettingPanelManager.Instance.gameStConfigGo.isVerticalSyn;
            fullScreenTgl.isOn = SettingPanelManager.Instance.gameStConfigGo.isFullScreen;
            brightnessSld.value = SettingPanelManager.Instance.gameStConfigGo.brightnessSt * 10;
            resolutionDpd.value = SettingPanelManager.Instance.gameStConfigGo.resolutionIndex;
            isInitial = isFirstTime;
        }

        private void InitalCurrentStatus(bool isFirstTime)
        {
            LoadSetting();

            verticalSynTgl.isOn = QualitySettings.vSyncCount==1?true:false;
            SettingPanelManager.Instance.gameStConfigGo.isVerticalSyn = verticalSynTgl.isOn;

            fullScreenTgl.isOn = Screen.fullScreen;
            SettingPanelManager.Instance.gameStConfigGo.isFullScreen = fullScreenTgl.isOn;

            brightnessSld.value = Screen.brightness;
            SettingPanelManager.Instance.gameStConfigGo.brightnessSt = brightnessSld.value;

            resolutionDpd.value = ResolutionOption(Screen.width.ToString()+"x"+Screen.height.ToString());
            SettingPanelManager.Instance.gameStConfigGo.resolutionIndex = resolutionDpd.value;

            isInitial = !isFirstTime;
        }

        void SaveSetting()
        {
            //PlayerPrefs.SetInt(Consts.VSycnCount, QualitySettings.vSyncCount);
            PlayerPrefs.Save();
        }

        void LoadSetting()
        {
            //QualitySettings.vSyncCount = PlayerPrefs.GetInt(Consts.VSycnCount, 1);

        }

        private void OnDestroy()
        {
            SaveSetting();
        }

    }
}
