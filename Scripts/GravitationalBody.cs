using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GravitationalBody : MonoBehaviour
{
    public static GravitationalBody instance;

    private List<CelestialBody> detect;
    private CelestialBody[] allTheCB;

    public CircleCollider2D theC;
    public Rigidbody2D theRB;

    [Header("引力大小")]
    public float forceMagnitude;

    [Header("引力 / 斥力")]
    public bool isGravitation;

    [Header("引力作用范围")]
    public float forceRange;

    [Header("其他变量")]
    private float isGra;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        theC = GetComponent<CircleCollider2D>();
        theRB = GetComponent<Rigidbody2D>();

        if (isGravitation)
        {
            isGra = 1f;
        }
        else
        {
            isGra = -1f;
        }

    }

    // Update is called once per frame
    void Update()
    {
        allTheCB = FindObjectsOfType<CelestialBody>();
        detect = new List<CelestialBody>();

        foreach (CelestialBody theCB in allTheCB)
        {
            if (Vector2.Distance(transform.position, theCB.transform.position) < forceRange)
            {
                detect.Add(theCB);
            }
        }

        detect.Remove(this.GetComponent<CelestialBody>());

        foreach (CelestialBody theCB in detect)
        {
            float radius = Vector2.Distance(transform.position, theCB.transform.position);
            Vector2 Direction = new Vector2(transform.position.x - theCB.transform.position.x, transform.position.y - theCB.transform.position.y);

            theCB.theRB.AddForce(Direction * forceMagnitude * Mathf.Pow(theCB.mass, 1f / 3f) * .01f / radius * isGra, (ForceMode2D)ForceMode.VelocityChange);
        }
    }
}
