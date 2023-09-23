using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollisionDetector : MonoBehaviour
{
    private DetectedObjectsList objectList;

    private void Start()
    {
        objectList = GetComponent<DetectedObjectsList>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        objectList.DetectedObjects.Add(collision);
    }
}