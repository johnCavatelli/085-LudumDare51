using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    private Transform camTransform;
    // Start is called before the first frame update
    void Start()
    {
        camTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        RotateSprite();
    }

    public void RotateSprite()
    {
        Vector3 target = camTransform.position - transform.position;
        float newYangle = Mathf.Atan2(target.z, target.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, -1 * newYangle - 90, 0);
    }
}
