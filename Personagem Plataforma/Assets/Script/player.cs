using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float Velocidade;

    public float ForcaPulo;

    private bool VerificaChao;

    public Transform ChaoVerificador;


    // Update is called once per frame
    void Update()
    {

        Movimentacao();
    }

    void Movimentacao()
    {
        VerificaChao = Physics2D.Linecast(transform.position, ChaoVerificador.position, 1 << LayerMask.NameToLayer("Chao"));
        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Translate(Vector2.right * Velocidade * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }
        if(Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(Vector2.right * Velocidade * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 180);
        }
        if(Input.GetButtonDown("Jump") && VerificaChao)
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * ForcaPulo);
        }
    }
}
