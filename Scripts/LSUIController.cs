using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LSUIController : MonoBehaviour
{
    public static LSUIController instance;

    public GameObject mainUI;

    private void Awake()
    {
        instance = this; 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowUI()
    {
        gameObject.SetActive(true);

        mainUI.SetActive(false);
    }

    public void HideUI()
    {
        gameObject.SetActive(false);

        mainUI.SetActive(true);
    }

    public void LevelToLoad(LevelPoint levelInfo)
    {
        UIController.instance.FadeToBlack();

        SceneManager.LoadScene(levelInfo.levelName);
    }

}
