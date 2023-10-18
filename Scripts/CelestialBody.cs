using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialBody : MonoBehaviour
{
    public static CelestialBody instance;

    public Rigidbody2D theRB;
    public Collider2D theC;

    [Header("星体质量")]
    public float mass;

    [Header("碰撞体积开关")]
    public bool canCollide;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        theC = GetComponent<Collider2D>();

        theRB.mass = mass;

        if (canCollide)
        {
            theC.isTrigger = false;
        }
        else
        {
            theC.isTrigger = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
