using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreelineMover : MonoBehaviour
{
    [SerializeField] private float maxDistance;
    [SerializeField] private float xOffset;


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
}
