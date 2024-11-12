using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform sky;
    [SerializeField] private Transform treelines;
    [SerializeField] private PlayerController player;
  
    [Range(0f,1f)]
    [SerializeField] private float parallaxSpeed;

    private Transform cam;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        cam = Camera.main.transform;
    }

    private void LateUpdate()
    {
        sky.position = new Vector3(cam.position.x,cam.position.y,sky.position.z);
        treelines.position = new Vector3(cam.position.x * parallaxSpeed,treelines.position.y,treelines.position.z);

    }
}
