using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    private bool normal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        normal = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (normal)
        {
            if (other.tag == "TargetPlanet")
            {
                other.gameObject.SetActive(false);

                LevelManager.instance.GameOver();
            }
            else
            {
                other.gameObject.SetActive(false);
            }
        }
    }
}
