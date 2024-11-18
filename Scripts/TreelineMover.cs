using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreelineMover : MonoBehaviour
{
    [SerializeField] private float maxDistance;
    [SerializeField] private float xOffset;

    //[SerializeField] private Transform player; // Referência ao player
    //[SerializeField] private Transform cameraTransform; // Referência à câmera
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
        // Verifica a distância entre o objeto e a Cam
        // Se a câmera for pra frente, diminui o distance
        // Se a câmera for pra trás, aumenta o distance
        float distance = transform.position.x - Camera.main.transform.position.x;

        if (distance > maxDistance)
        {
            //Joga o objeto para trás dos últimos arbustos
            transform.position -= new Vector3(maxDistance * xOffset,0f,0f);

            // Joga o objeto para frente dos últimos arbustsos
        }else if (distance < -maxDistance)
        {
            transform.position += new Vector3(maxDistance * xOffset, 0f, 0f);
        }
    }

    //private float GetNextXPosition()
    //{
    //    float maxX = cameraTransform.position.x + xMax;

    //    // Verifica se existem outros arbustos à frente e ajusta a posição para evitar sobreposição
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
