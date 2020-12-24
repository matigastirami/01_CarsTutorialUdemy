using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Props
    //[HideInInspector] -> Modificador para que no aparezca en la interfaz unity
    // SerializeField permite que aunque sea privado se pueda modificar en unity (Pero otros scripts no pueden acceder a modificar)
    [Range(0, 20), SerializeField, Tooltip("Velocidad lineal máxima")]
    private float speed = 15.0f;

    [Range(0, 45), SerializeField, Tooltip("Velocidad de giro")]
    private float turnSpeed = 35.0f; // 10 Grados/seg

    private float horizontalInput, verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Inicio: " + gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Move the vehicle forward
        // Esto no se suele usar porque hay que hacer los cálculos
        //this.transform.position = new Vector3(10, 20, 30);
        // Ecuación del MRU. deltaTime es el tiempo entre frames
        transform.Translate(speed * Time.deltaTime *  Vector3.forward * verticalInput); // 0, 0, 1 -> Esto es 1m/s en el eje Z, si lo multiplico por un valor X será X m/s la velocidad

        // Para girar, como el positivo de X es a derecha, podemos multiplicar el vector (1,0,0) por la velocidad de giro
        transform.Rotate(turnSpeed * Time.deltaTime * Vector3.up * horizontalInput);
    }
}
