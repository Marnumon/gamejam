using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GravitationalBody : MonoBehaviour
{
    private List<CelestialBody> detect;
    public CelestialBody[] allTheCB;
    public CircleCollider2D theC;
    public Rigidbody2D theRB;

    [Header("星体质量")]
    public float mass;

    [Header("碰撞体积开关")]
    public bool canCollide;

    [Header("引力大小")]
    public float forceMagnitude;

    [Header("引力 / 斥力")]
    public bool isGravitation;

    [Header("引力作用范围")]
    public float forceRange;

    [Header("其他变量")]
    public LayerMask whatCanForce;
    private int isGra;

    // Start is called before the first frame update
    void Start()
    {
        theC = GetComponent<CircleCollider2D>();
        theRB=GetComponent<Rigidbody2D>();

        allTheCB = FindObjectsOfType<CelestialBody>();

        theRB.mass = mass;

        if (canCollide) 
        {
            theC.isTrigger = false;
        }
        else
        {
            theC.isTrigger = true;
        }

        if (isGravitation)
        {
            isGra = 1;
        }
        else
        {
            isGra = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        detect = new List<CelestialBody>();

        foreach (CelestialBody theCB in allTheCB)
        {
            if (Vector2.Distance(transform.position, theCB.transform.position) < forceRange)
            {
                detect.Add(theCB);
            }
        }

        foreach (CelestialBody theCB in detect)
        {
            float radius = Vector2.Distance(transform.position, theCB.transform.position);
            Vector2 Direction = new Vector2(transform.position.x - theCB.transform.position.x, transform.position.y - theCB.transform.position.y);
            
            theCB.theRB.AddForce(Direction * forceMagnitude / radius * isGra, (ForceMode2D)ForceMode.VelocityChange);
        }
    }
}
