using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TigerForge;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public int totalScore = 0;
    private int score;
    EasyFileSave myFile;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            StartProcess();
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void StartProcess()
    {
        myFile = new EasyFileSave();
        LoadData();
    }
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            GameObject.Find("score").GetComponent<Text>().text = score.ToString();
        }
    }
    public void SaveData()
    {
        totalScore += score;
        myFile.Add("totalScore", totalScore);
        myFile.Save();
    }
    public void LoadData()
    {
        if(myFile.Load())
        {
            totalScore = myFile.GetInt("totalScore");
        }
    }
}
