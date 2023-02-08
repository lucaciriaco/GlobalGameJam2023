using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public int BigNodesActivated;
    [SerializeField] private TextMeshProUGUI NodesCounterUI;
    [SerializeField] private TextMeshProUGUI timerUI;
    private GameObject[] bigNodes;
    [SerializeField] private float timer;

    private void Awake()
    {
        bigNodes = GameObject.FindGameObjectsWithTag("Bignode");
    }

    private void Start()
    {
        BigNodesActivated = 0;
    }

    void Update()
    {
        ShowStatus();
        if(BigNodesActivated == bigNodes.Length)
        {
            WinState();
        }
        timer += Time.deltaTime;
    }

    void ShowStatus()
    {
        NodesCounterUI.text = " Nodes : ";
        timerUI.text = " Time: " + timer.ToString("f0");
    }

    void WinState()
    {

    }
}
