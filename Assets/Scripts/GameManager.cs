using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Sprite[] partsSprites;
    public GameObject player1;
    public int partsCollected;
    public int partsQuantity;
    public float triesCounter;
    

    [SerializeField] private GameObject winMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Text partsCounterUI;
    [SerializeField] private Text triesCounterUI;
    [SerializeField] private Text timerUI;
    [SerializeField] private Text bestScoreUI;
    [SerializeField] private Text yourScoreUI;
    private GameObject[] parts;
    private float timer;

    private void Awake()
    {
        parts = GameObject.FindGameObjectsWithTag("Part");
        partsQuantity = parts.Length;
        RandomSpriteParts();
    }

    void Start()
    {
        Debug.Log(PlayerPrefs.GetFloat("Highscore"));
        pauseMenu.gameObject.SetActive(false);
        winMenu.gameObject.SetActive(false);
        triesCounter = 0;
        partsCollected = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ShowStatus();
        WinState();
    }

    void ShowStatus()
    {
        partsCounterUI.text = " Parts : " + partsCollected + "/" + partsQuantity;
        triesCounterUI.text = " Tries: " + triesCounter;
        timerUI.text = " Time: " + timer.ToString("f0");
    }

    public void Restart()
    {
        triesCounter = triesCounter + 1f;
    }

    void RandomSpriteParts()
    {
        for (int i = 0; i < parts.Length; i++)
        {
            parts[i].gameObject.GetComponent<SpriteRenderer>().sprite = partsSprites[(Random.Range(0, partsSprites.Length))];
        }
    }

    void WinState()
    {
        if (partsCollected == partsQuantity)
        {
            if (timer < PlayerPrefs.GetFloat("Highscore"))
            {
                 PlayerPrefs.SetFloat("Highscore", timer);
            }
            winMenu.gameObject.SetActive(true);
            yourScoreUI.text = timer.ToString("f0");
            bestScoreUI.text = PlayerPrefs.GetFloat("Highscore").ToString("f0");
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
}
