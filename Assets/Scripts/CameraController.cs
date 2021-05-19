using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private Transform target;

    [SerializeField] private float smoothSpeed;

    [SerializeField] private float minX, maxX, minY, maxY;


    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();//MARKER dont forget to tag player as tag
    }

    private void LateUpdate()
    {
        //traditional camera
        //transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

        //MARKER smoothly move Camera
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, target.position.y, transform.position.z), smoothSpeed * Time.deltaTime);

        //MARKER Limit the Range
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX),//x limit range
                                       Mathf.Clamp(transform.position.y, minY, maxY),//y limit range
                                         transform.position.z);
    }

}
