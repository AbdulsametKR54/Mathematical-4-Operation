using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EntryManager : MonoBehaviour
{
    public GameObject dataBoard;
    public GameObject deletedButon;
    public GameObject firstSahne, secondSahne, thirdSahne;
    public GameObject playButon, quitButon, scoreTableButon, closeButon, settingsButon, settingCloseButon;
    private bool deletedButtonClicked = false;
    bool kosul=false;
    // Start is called before the first frame update
    void Start()
    {
        firstSahne.SetActive(true);
        secondSahne.SetActive(false);
        thirdSahne.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void playButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void scoreTableButton()
    {
        firstSahne.SetActive(false);
        secondSahne.SetActive(true);
        DataManager.Instance.LoadData();
        dataBoard.transform.GetChild(0).GetComponent<Text>().text = "Total Score: " + DataManager.Instance.totalScore.ToString();
    }
    public void deletedButton() 
    {
        DataManager.Instance.totalScore = DataManager.Instance.totalScore-DataManager.Instance.totalScore;
        DataManager.Instance.SaveData();
        scoreTableButton();
    }
    public void closeButton()
    {
        firstSahne.SetActive(true);
        secondSahne.SetActive(false);
    }
    public void quitButton()
    {
        Application.Quit();
    }
    public void settingButton()
    {
        thirdSahne.SetActive(true);
        secondSahne.SetActive(false);
        firstSahne.SetActive(false);
    }
    public void settingCloseButton()
    {
        secondSahne.SetActive(false);
        thirdSahne.SetActive(false);
        firstSahne.SetActive(true);
    }
}
