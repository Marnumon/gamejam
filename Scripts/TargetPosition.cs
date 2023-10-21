using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "TargetPlanet")
        {
            //AudioManager.instance.PlayLevelVictory();

            Debug.Log("ÓÎÏ·Ê¤Àû");

            //UIController.instance.LevelCompleteUI();
        }
    }
}
