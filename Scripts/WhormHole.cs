using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhormHole : MonoBehaviour
{
    private Transform pointToTaleport;

    private bool isTeleporting = false;

    private List<WhormHole> detect;
    private WhormHole[] allTheWH;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        allTheWH = FindObjectsOfType<WhormHole>();
        detect = new List<WhormHole>();

        foreach (WhormHole theWH in allTheWH)
        {
            detect.Add(theWH);
        }

        detect.Remove(this);

        foreach (WhormHole theWH in detect)
        {
            pointToTaleport = theWH.transform;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isTeleporting)
        {
            StartCoroutine(TeleportObjectCo(other.transform, pointToTaleport));
        }
    }

    public IEnumerator TeleportObjectCo(Transform other, Transform pointToTeleport)
    {
        isTeleporting = true;

        Collider2D collider2D = other.GetComponent<Collider2D>();
        collider2D.enabled = false;

        other.position = pointToTeleport.position;

        yield return new WaitForSeconds(1f);

        collider2D.enabled = true;

        isTeleporting = false;
    }
}
