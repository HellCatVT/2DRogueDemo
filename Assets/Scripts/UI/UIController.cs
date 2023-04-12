using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIController : Singleton<UIController>
{

    public GameObject MenuPanel;

    public Text Kills;

    public Text BossKills;

    public Text MaxKills;

    public Text EXP;

    public Slider MusicSlider;

    public Slider SoundSlider;

    public AudioSource Music;

    public List<AudioController> Soundlist;

    private void Start()
    {
        Soundlist.Add(PlayerController.Instance.GetComponent<AudioController>());
        Soundlist.Add(PlayerController.Instance.CurrentWeapon.GetComponent<AudioController>());
        Kills.text = PlayerController.Instance.GetComponent<PlayerStats>().AllKills.ToString();
        BossKills.text = PlayerController.Instance.GetComponent<PlayerStats>().AllBossKills.ToString();
        EXP.text = PlayerController.Instance.GetComponent<PlayerStats>().EXP.ToString();
        MaxKills.text = PlayerController.Instance.GetComponent<PlayerStats>().MaxKills.ToString();
    }
    private void Update()
    {
        Pause();
        foreach (var item in Soundlist)
        {
            item.GetComponent<AudioSource>().volume = item.MaxVol * SoundSlider.value;
        }
        Camera.main.GetComponent<AudioSource>().volume = MusicSlider.value;
    }

    public void OnQuitButton()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void ShowMenuPanel()
    {
        
        MenuPanel.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    }

    public void OnExitButton()
    {
        Time.timeScale = 1.0f;
        MenuPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(10000, 10000);
    }

    public void Pause()
    {
        if (GameManager.Instance.GameInput.IsMenuButton())
        {
            Time.timeScale = 0;
            ShowMenuPanel();
        }
    }

    
}
