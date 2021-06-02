using UnityEngine;
using UnityEngine.UI;
using MoreMountains.TopDownEngine;
using DG.Tweening;


//manage the panel btns' event and initial
public class GameSettingPanel : BasePanel
{
    private CanvasGroup canvasGroup;

    private GameObject confirmPromptGo;
    private Text confirmTxt;
    private bool isResetOrNot = false;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        confirmPromptGo = transform.Find("ConfirmOrNot_Img").gameObject;
        confirmTxt = confirmPromptGo.transform.Find("Bg_Img/notice_txt").GetComponent<Text>();
        confirmPromptGo.transform.localScale = Vector3.zero;
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
        transform.DOScale(Vector3.one, 0.25f).SetUpdate(true);
    }

    public override void OnExit()
    {
        base.OnExit();
        transform.DOScale(Vector3.zero, 0.25f).SetUpdate(true);
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0;
    }

    public void OnConfirmSaveBtnClick()
    {
        Transform btnTrf = transform.Find("GameSettingPart/confirmSave_btn").transform;
        btnTrf.DOPunchPosition(new Vector3(5f, 0, 0), 1f, 3, 0.5f).SetUpdate(true);
        ConfirmToChangeOrReset(false);
    }

    public void OnResetBtnClick()
    {
        Transform btnTrf = transform.Find("GameSettingPart/resetDefault_btn").transform;
        btnTrf.DOPunchPosition(new Vector3(5f, 0, 0), 1f, 3, 0.5f).SetUpdate(true);
        ConfirmToChangeOrReset(true);
    }

    //private void SetAndSaveTheCustomerSetting(GameSettingConfigure gameConfigure)
    //{
    //    //verticalSyn on or not
    //    GameManager.Instance.OpenVsyncCount(gameConfigure.isVerticalSyn);
    //    //fullscreen on or not
    //    GameManager.Instance.OpenFullScreen(gameConfigure.isFullScreen);
    //    //brightness slide
    //    GameManager.Instance.AdjustBrightness(gameConfigure.brightnessSt);
    //    //setResolution
    //    GameManager.Instance.AdjustResolution(gameConfigure.resolutionSt);
    //    //BgMusic on or not
    //    SoundManager.Instance.isOnBgMusicOrNot(gameConfigure.isBgMusicOn);
    //    //Sounds on or not
    //    SoundManager.Instance.isOnSfxOrNot(gameConfigure.isSoundsOn);
    //    //BgMusic slide
    //    SoundManager.Instance.AdjustmentAudio(gameConfigure.bgMusic);
    //    //Sounds slide
    //    SoundManager.Instance.AdjustmentSfx(gameConfigure.sounds);
    //}

    //The extra initial work may happen
    public void InitialSaveSetting()
    {
        //GameSettingConfigure gameConfigure = SettingPanelManager.Instance.gameStConfigGo;
        //SetAndSaveTheCustomerSetting(gameConfigure);
    }

    private void ConfirmToChangeOrReset(bool isReset)
    {
        isResetOrNot = isReset;
        //confirmPromptGo.transform.DOScale(Vector3.one, 0.1f).SetUpdate(true);
        if (isReset)
        {
            confirmTxt.text = "确定要重置当前设置吗？";
        }
        else
        {
            confirmTxt.text = "确定要保存当前设置吗？";
        }
    }

    public void OnConfirmPromptBtnClick()
    {
        if (isResetOrNot)// 是否为重置操作
        {
            //SettingPanelManager.Instance.gameStConfigGo.ResetTheEntireSetting();
            InitialSaveSetting();
            //TODO 重设控件参数 (还差系统设置面板的重置) 本地化
            transform.Find("GameSettingPart/graphicSt_go").GetComponent<GraphicSettingPart>().InitialForComponent(false);
            transform.Find("GameSettingPart/musicSt_go").GetComponent<AudioSettingPart>().InitialForComponent(false);
        }
        else
        {
            //if (SettingPanelManager.Instance.gameStConfigGo != null)
            //{
            //    InitialSaveSetting();
            //    GetComponent<SettingPanelManager>().OnReturnBtnClick();
            //}
        }
        OnCancelPromptBtnClick();
    }

    public void OnCancelPromptBtnClick()
    {
        confirmPromptGo.transform.DOScale(Vector3.zero, 0.1f).SetUpdate(true);
    }
}
