using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguimiento_Camara : MonoBehaviour {

    Transform target;
    float tLx, tLy, bRx, bRy;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Jugador").transform;
       
    }
    //Ajuste de resolucion
    private void Start()
    {
        Screen.SetResolution(800, 800, true);
    }
    // Update is called once per frame
    void Update () {
        if (!Screen.fullScreen || Camera.main.aspect != 1)
        {
            Screen.SetResolution(800, 800, true);
        }
        if (Input.GetKey("escape")) Application.Quit();

	     transform.position = new Vector3(
            Mathf.Clamp(target.position.x,tLx,bRx),
            Mathf.Clamp(target.position.y,bRy,tLy),
            transform.position.z
            );
    }
    //Limite de camara con respecto al mapa
    public void SetBound (GameObject map) {
        Tiled2Unity.TiledMap config = map.GetComponent<Tiled2Unity.TiledMap>();
        float cameraSize = Camera.main.orthographicSize;

        tLx = map.transform.position.x + cameraSize;
        tLy = map.transform.position.y - cameraSize;
        bRx = map.transform.position.x + config.NumTilesWide - cameraSize;
        bRy = map.transform.position.y - config.NumTilesHigh + cameraSize;
    }




}
