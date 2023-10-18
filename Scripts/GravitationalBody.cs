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

    [Header("��������")]
    public float mass;

    [Header("��ײ�������")]
    public bool canCollide;

    [Header("������С")]
    public float forceMagnitude;

    [Header("���� / ����")]
    public bool isGravitation;

    [Header("�������÷�Χ")]
    public float forceRange;

    [Header("��������")]
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
