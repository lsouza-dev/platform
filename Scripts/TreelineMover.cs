using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreelineMover : MonoBehaviour
{
    [SerializeField] private float maxDistance;
    [SerializeField] private float xOffset;


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
}
