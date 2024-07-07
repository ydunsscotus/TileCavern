using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private Vector3 startpos;
    private Vector3 camStartPos;
    private float lengthX, lengthY;
    public GameObject cam;
    public float parallaxEffectX;
    public float parallaxEffectY;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position;
        camStartPos = cam.transform.position;
        lengthX = GetComponent<SpriteRenderer>().bounds.size.x;
        lengthY = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        float distX = (cam.transform.position.x - camStartPos.x) * parallaxEffectX;
        float distY = (cam.transform.position.y - camStartPos.y) * parallaxEffectY;
        transform.position = new Vector3(startpos.x + distX, startpos.y + distY, transform.position.z);
    }
}
