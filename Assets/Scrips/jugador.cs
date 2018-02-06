using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// No te olvides que es Key Sensitive
public class jugador : MonoBehaviour {

    public float velocidad = 3f;
    Animator anim;
    Rigidbody2D rb2d;
    Vector2 movimiento;

    public GameObject initialMap;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();

        Camera.main.GetComponent<Seguimiento_Camara>().SetBound(initialMap);
	}
	
	// Update is called once per frame
	void Update () {

        movimiento = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
            );
        if (movimiento != Vector2.zero)
        {
            anim.SetFloat("MovX", movimiento.x);
            anim.SetFloat("MovY", movimiento.y);
            anim.SetBool("Caminando", true);
        } else {
            anim.SetBool("Caminando", false);
        }
    }

    private void FixedUpdate() {

        rb2d.MovePosition(rb2d.position + movimiento * velocidad * Time.deltaTime);    
    }






}
