using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HTLibrary.Utility;

namespace MoreMountains.TopDownEngine
{
    public class AudioSettingPart : MonoBehaviour
    {
        public Toggle bgMusicTgl;
        public Toggle soundsTgl;
        public Slider bgMusicSld;
        public Slider soundsSld;

        private bool isInitial = true;

        private void Awake()
        {
            InitalCurrentStatus(true);
            //InitialForComponent(true);
        }

        public void OnBgMusicTglClick(bool isOn)
        {
            SettingPanelManager.Instance.gameStConfigGo.isBgMusicOn = bgMusicTgl.isOn;
            if(!bgMusicTgl.isOn)
            {
                bgMusicSld.value = 1f;
            }else
            {
                bgMusicSld.value = 5f;
            }    
            bgMusicSld.interactable = bgMusicTgl.isOn;
        }

        public void OnSoundsTglClick(bool isOn)
        {
            SettingPanelManager.Instance.gameStConfigGo.isSoundsOn = soundsTgl.isOn;
            if (!soundsTgl.isOn)
            {
                soundsSld.value = 1f;
            }
            else
            {
                soundsSld.value = 5f;
            }
            soundsSld.interactable = soundsTgl.isOn;
        }

        public void OnBgMusicSlide(float val)
        {
            val = bgMusicSld.value;
            SettingPanelManager.Instance.gameStConfigGo.bgMusic = val/10;
            if(!isInitial)
            {
                SettingPrompt.Instance.ShowPrompt("背景音乐", val * 10);
            }
        }

        public void OnSoundsSlide(float val)
        {
            val = soundsSld.value;
            SettingPanelManager.Instance.gameStConfigGo.sounds = val/10;
            if(!isInitial)
            {
                SettingPrompt.Instance.ShowPrompt("音效", val * 10);
            }
        }

        public void InitialForComponent(bool isFirstTime)
        {
            isInitial = !isFirstTime;
            bgMusicTgl.isOn = SettingPanelManager.Instance.gameStConfigGo.isBgMusicOn;
            soundsTgl.isOn = SettingPanelManager.Instance.gameStConfigGo.isSoundsOn;
            bgMusicSld.value = SettingPanelManager.Instance.gameStConfigGo.bgMusic * 10;
            soundsSld.value = SettingPanelManager.Instance.gameStConfigGo.sounds * 10;
            isInitial = isFirstTime;
        }

        private void InitalCurrentStatus(bool isFirstTime)
        {
            //bgMusicTgl.isOn = SoundManager.Instance.IsMusicOn;//IsBackgroundMusicPlaying();
            SettingPanelManager.Instance.gameStConfigGo.isBgMusicOn = bgMusicTgl.isOn;

            //soundsTgl.isOn = SoundManager.Instance.IsSfxOn;
            SettingPanelManager.Instance.gameStConfigGo.isSoundsOn = soundsTgl.isOn;

            //bgMusicSld.value = SoundManager.Instance.GetBackgroundMusicVolume() * 10;//PlayerPrefs.GetFloat(Consts.Music);
            //SettingPanelManager.Instance.gameStConfigGo.bgMusic = SoundManager.Instance.GetBackgroundMusicVolume();

            //soundsSld.value = SoundManager.Instance.GetSfxVolume() * 10;
            //SettingPanelManager.Instance.gameStConfigGo.sounds = SoundManager.Instance.GetSfxVolume();

            isInitial = !isFirstTime;
        }
    }
}