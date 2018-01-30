using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguimiento_Camara : MonoBehaviour {

    public GameObject seguir; 
    
	// Update is called once per frame
	void FixedUpdate () {
	 float posX = seguir.transform.position.x;
     float posY = seguir.transform.position.y;

     transform.position = new Vector3(posX, posY, transform.position.z);
    }
}
