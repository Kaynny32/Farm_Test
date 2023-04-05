using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;


    [SerializeField]
    TextMeshProUGUI ScoreMony;
    string ScoreMonyStr;
    public int ScoreMonyInt;

    [SerializeField]
    TextMeshProUGUI ScoreBlock;
    string ScoreBlockStr;
    public int ScoreBlockInt;


    void Awake()
    {
        if (instance == null)
            instance = this;        
    }
    private void Update()
    {
        Score();
    }
    void Score()
    {
            ScoreMonyStr = $"Mony:{ScoreMonyInt}";
            ScoreMony.text = ScoreMonyStr;
            ScoreBlockStr = $"{ScoreBlockInt}/40";
            ScoreBlock.text = ScoreBlockStr;
    }
}
