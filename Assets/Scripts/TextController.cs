using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour
{
    RectTransform thisRect;
    public void Awake()
    {
        thisRect = transform.GetComponent<RectTransform>();
    }
    public void Update()
    {
        thisRect.localPosition += Vector3.up *5;

        if (thisRect.position.y < -200)
        {
            Destroy(transform.gameObject);
        }
    }
}
