using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonPuzzleSub : MonoBehaviour
{
    public GameObject Personaje;
    public float Orden;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == Personaje.name)
        {
            GetComponent<Animator>().SetBool("Estado", true);

        }
    }
}
