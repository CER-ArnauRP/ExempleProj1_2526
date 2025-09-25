using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NauJugador : MonoBehaviour
{
    public float vel = 10f;

    private Camera camera;

    Vector3 limitInferiorEsquerra;
    Vector3 limitSuperiorDret;

    //public GameObject jugador;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;

        limitInferiorEsquerra = camera.ViewportToWorldPoint(new Vector2(0, 0));
        limitSuperiorDret = camera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    // Update is called once per frame
    void Update()
    {
        
        MovimentNau();
        
    }

    void MovimentNau()
    {
        // Control límits pantalla.
        


        // Moviment nau.
        float direccioHoritzontal = Input.GetAxisRaw("Horizontal");
        float direccioVertical = Input.GetAxisRaw("Vertical");
        Vector3 direccio = new Vector3(direccioHoritzontal, direccioVertical, 0).normalized;// (x, y, z)
        //Debug.Log("direccio=" + direccio);

        Vector3 nouDesplacament = new Vector3(
            vel * direccio.x * Time.deltaTime,
            vel * direccio.y * Time.deltaTime,
            vel * direccio.z * Time.deltaTime
        );
        //Debug.Log("Time.deltaTime=" + Time.deltaTime);


        // Apliquem el vector desplaçament a l'objecte.
        //transform.position += nouDesplacament;

        //Vector3 novaPos = transform.position;

        // Control dels límits de la pantalla
        // El mètode Math.Clamp, ens retorna el primer paràmetre.
        //      Però, si aquest primer paràmetre, té un valor més petit que el segon paràmetre,
        //          retornarà el segon paràmetre. I, si el primer, té un valor més gran que el tercer 
        //          paràmetre, ens retornarà el tercer paràmetre.
        nouDesplacament.x = Math.Clamp(nouDesplacament.x, limitInferiorEsquerra.x, limitSuperiorDret.x);
        nouDesplacament.y = Math.Clamp(nouDesplacament.y, limitInferiorEsquerra.y, limitSuperiorDret.y);

        transform.position += nouDesplacament;
    }
}
