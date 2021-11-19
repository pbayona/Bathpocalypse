using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Componente de rotacion para los objetos de la tienda
public class rotateSkin : MonoBehaviour
{
    void Update()
    {
          gameObject.transform.RotateAround(gameObject.transform.position, Vector3.up, 20 * Time.deltaTime);
    }
}
