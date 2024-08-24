using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SettingsScript : MonoBehaviour
{
    public GameObject easyButon, normalButon, hardButon;
    static public int gamedifficulty = 1;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
    }
    public void EasyButton()
    {
        gamedifficulty = 1;
        SceneManager.LoadScene(1);
    }
    public void NormalButton()
    {
        gamedifficulty = 2;
        SceneManager.LoadScene(1);
    }
    public void HardButton()
    {
        gamedifficulty = 3;
        SceneManager.LoadScene(1);
    }
}
