using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warp : MonoBehaviour {

    public GameObject target;
    public GameObject targetmap; //mapa destino

    //variable etapa de transicion
    bool start = false;
    bool isfadein = false;
    float alpha = 0;
    float fadetime = 1f;

    private void Awake()
    {
        //Esconder warps
        GetComponent<SpriteRenderer>().enabled = false;
        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
    }

    //activar transicion de entrada
    void FadeIn()
    {
        start = true;
        isfadein = true;
    }

    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag ("Jugador"))
        {
            FadeIn();
            other.GetComponent<Animator>().enabled = false;
            other.GetComponent<jugador>().enabled = false;
            yield return new WaitForSeconds(fadetime);
            other.transform.position = target.transform.GetChild(0).transform.position;
            Camera.main.GetComponent<Seguimiento_Camara>().SetBound(targetmap);
            FadeOut();
            other.GetComponent<Animator>().enabled = true;
            other.GetComponent<jugador>().enabled = true;
        }
    }

    //etapa de transicion por medio de un cuadrado dibujado
    void OnGUI()
    {
        if (!start)
            return;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);

        //Creacion textura temporal
        Texture2D  tex;
        tex = new Texture2D(1, 1);
        tex.SetPixel(0, 0, Color.black);
        tex.Apply();

        //Dibujo de textura sobre pantalla
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), tex);

        //Control de la transparencia
        if (isfadein) {
            alpha = Mathf.Lerp(alpha, 1.1f, fadetime = Time.deltaTime);
        } else{
            alpha = Mathf.Lerp(alpha, -0.1f, fadetime = Time.deltaTime);
            if (alpha < 0) start = false;
        }
    }

    //activar transicion de salida 
    void FadeOut() {
        isfadein = false;
    }

}
