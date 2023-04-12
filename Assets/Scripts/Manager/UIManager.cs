using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor.SearchService;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{

    public RectTransform GameOverPanel;

    public RectTransform PausePanel;

    public Text KillText;

    public Text BossKillText;

    public Text EXPGainText;

    public Slider SoundSlider;

    public Slider MusicSlider;

    public AudioSource Music;

    public List<AudioSource> SoundList;

    public int KillCount;

    public int BossKillCount;

    public int EXPGainCount;

    public int Kills;

    public int BossKills;

    public int EXPGain;



    public bool IsActivated = false;

    private void OnEnable()
    {
        PlayerController.PlayerDie += ShowGameOverPanel;
    }
    private void OnDisable()
    {
        PlayerController.PlayerDie -= ShowGameOverPanel;
    }
    // Start is called before the first frame update
    void Start()
    {
        SoundList.Add(PlayerController.Instance.GetComponent<AudioSource>());
        SoundList.Add(PlayerController.Instance.CurrentWeapon.GetComponent<AudioSource>());
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var item in SoundList)
        {
            item.volume = item.GetComponent<AudioController>().MaxVol*SoundSlider.value;
        }
        Music.volume = MusicSlider.value;
        Pause();
        StaticUpdate();
    }

    public void ShowGameOverPanel()
    {
        GameOverPanel.anchoredPosition = Vector2.zero;
        SetActivate();
    }

    public void ShowPausePanel()
    {
        PausePanel.anchoredPosition = Vector2.zero;
    }

    public void OnResume()
    {
        Time.timeScale = 1.0f;
        PausePanel.anchoredPosition = new Vector2(1000,1000);
    }



    public void OnBackToStartMenu()
    {
        PlayerController.Instance.PlayerAnimator.SetBool("IsDie", false);
        GameManager.Instance.Player.GetComponent<PlayerController>().SetHP();
        GameManager.Instance.Player.transform.position = Vector3.zero;
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void ReleasePause()
    {
        Time.timeScale = 1.0f;
    }

    public void Pause()
    {
        if (GameManager.Instance.GameInput.IsMenuButton())
        {
            ShowPausePanel();
            Time.timeScale = 0;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void StaticUpdate()
    {
        if (IsActivated)
        {
            if (Kills != KillCount)
                KillCount++;
            else
            {
                if (BossKills != BossKillCount)
                    BossKillCount++;
                else
                {
                    if (EXPGain != EXPGainCount)
                        EXPGainCount++;
                }
            }
            SetText();
        }
    }


    /// <summary>
    /// 更改显示内容
    /// </summary>
    private void SetText()
    {
        EXPGainText.text = EXPGainCount.ToString();
        KillText.text = KillCount.ToString();
        BossKillText.text = BossKillCount.ToString();
    }

    /// <summary>
    /// 设置激活
    /// </summary>
    public void SetActivate()
    {
        Kills = GameManager.Instance.Player.GetComponent<PlayerStats>().Kills;
        BossKills = GameManager.Instance.Player.GetComponent<PlayerStats>().BossKills;
        EXPGain = GameManager.Instance.Player.GetComponent<PlayerStats>().EXPGain;
        IsActivated = true;
    }
}
