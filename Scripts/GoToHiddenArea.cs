using System.Collections;
using UnityEngine;

public class GoToHiddenArea : MonoBehaviour
{
    public GameObject spA, spB;

    void Start()
    {
        spA = this.gameObject;
    }

    void OnTriggerStay2D (Collider2D trig)
    {
        if (Input.GetKey("up"))
        {
            trig.gameObject.transform.position = spB.gameObject.transform.position;
            Destroy(spB);
        }
    }
}
