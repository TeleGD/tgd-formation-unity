using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Can : MonoBehaviour
{
    public Color knockedColor; //couleur de la canette renversée

    private float startHeight; //hauteur de départ
    private bool isKnocked = false; //la canette est-elle tombée ?

    //La fonction start est appelée à la création de l'objet
    void Start()
    {
        startHeight = transform.position.y;
    }

    //La fonction update est appelée à chaque frame
    void Update()
    {
        if(!isKnocked && transform.position.y + 0.2f < startHeight)
        {
            isKnocked = true;
            //on change la couleur de la canette quand elle tombe
            transform.GetChild(0).GetComponent<MeshRenderer>().material.color = knockedColor;
            transform.GetChild(1).GetComponent<MeshRenderer>().material.color = knockedColor;
        }
    }
}
