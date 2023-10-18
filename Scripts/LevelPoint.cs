using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelPoint : MonoBehaviour
{
    public string levelToLoad, levelToCheck, levelName;
    public bool isPassed, isLocked;

    public GameObject locked;
    public Text passed;

    // Start is called before the first frame update
    void Start()
    {
        if (levelToLoad != null)
        {
            isPassed = false;

            if(PlayerPrefs.HasKey(levelToLoad + "_isPassed"))
            {
                if(PlayerPrefs.GetInt(levelToLoad + "_isPassed") == 1)
                {
                    isPassed = true;
                }
            }

            if (isPassed == true)
            {
                passed.text = "√";
            }

            isLocked = true;

            if (levelToCheck != null)
            {
                if (PlayerPrefs.HasKey(levelToCheck + "_unlocked"))
                {
                    if (PlayerPrefs.GetInt(levelToCheck + "_unlocked") == 1)
                    {
                        isLocked = false;
                    }
                }

                if(levelToLoad == levelToCheck)
                {
                    isLocked = false;
                }
            }

            if(isLocked == false)
            {
                locked.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LastUpdate()    //游戏结束，再次更新关卡选择的状态
    {
        if (levelToLoad != null)
        {
            isPassed = false;

            if (PlayerPrefs.HasKey(levelToLoad + "_isPassed"))
            {
                if (PlayerPrefs.GetInt(levelToLoad + "_isPassed") == 1)
                {
                    isPassed = true;
                }
            }

            if (isPassed == true)
            {
                passed.text = "√";
            }

            isLocked = true;

            if (levelToCheck != null)
            {
                if (PlayerPrefs.HasKey(levelToCheck + "_unlocked"))
                {
                    if (PlayerPrefs.GetInt(levelToCheck + "_unlocked") == 1)
                    {
                        isLocked = false;
                    }
                }

                if (levelToLoad == levelToCheck)
                {
                    isLocked = false;
                }
            }

            if (isLocked == false)
            {
                locked.SetActive(false);
            }
        }
    }
}

