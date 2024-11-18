using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreelineMover : MonoBehaviour
{
    [SerializeField] private float maxDistance;
    [SerializeField] private float xOffset;

    //[SerializeField] private Transform player; // Refer�ncia ao player
    //[SerializeField] private Transform cameraTransform; // Refer�ncia � c�mera
    //[SerializeField] private float xMin;
    //[SerializeField] private float xMax;

    //private void Awake()
    //{
    //    player = FindObjectOfType<PlayerController>().GetComponent<Transform>();
    //    cameraTransform = Camera.main.transform;
    //}

    //private void Update()
    //{
    //    if (transform.position.x - xMin < cameraTransform.position.x)
    //    {
    //        transform.position = new Vector2(GetNextXPosition(), transform.position.y);
    //    }
    //}

    private void Update()
    {
        // Verifica a dist�ncia entre o objeto e a Cam
        // Se a c�mera for pra frente, diminui o distance
        // Se a c�mera for pra tr�s, aumenta o distance
        float distance = transform.position.x - Camera.main.transform.position.x;

        if (distance > maxDistance)
        {
            //Joga o objeto para tr�s dos �ltimos arbustos
            transform.position -= new Vector3(maxDistance * xOffset,0f,0f);

            // Joga o objeto para frente dos �ltimos arbustsos
        }else if (distance < -maxDistance)
        {
            transform.position += new Vector3(maxDistance * xOffset, 0f, 0f);
        }
    }

    //private float GetNextXPosition()
    //{
    //    float maxX = cameraTransform.position.x + xMax;

    //    // Verifica se existem outros arbustos � frente e ajusta a posi��o para evitar sobreposi��o
    //    foreach (TreelineMover otherBush in FindObjectsOfType<TreelineMover>())
    //    {
    //        if (otherBush != this && otherBush.transform.position.x > transform.position.x)
    //        {
    //            maxX = Mathf.Max(maxX, otherBush.transform.position.x + xMax);
    //        }
    //    }

    //    return maxX;
    //}


}
