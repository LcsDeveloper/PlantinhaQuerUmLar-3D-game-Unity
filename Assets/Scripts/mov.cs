using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mov : MonoBehaviour
{
    bool start;

    public GameObject cam;

    public GameObject dSOL;

    public GameObject dCHUVA;

    Vector3 dir;

    Rigidbody rig;

    public float speed, jP, jP2;

    float sensi, X, x, rotV;

    public bool front, escala, isGround, chuva, sol;

    Animator anim;

    public GameObject FALA;
    public Text oqDizer;

    public GameObject SOLicon;
    public GameObject CHUVAicon;

    void Start()
    {

        anim = GetComponent<Animator>();

        sensi = cam.GetComponent<cam>().sensi;

        rig = GetComponent<Rigidbody>();

        StartCoroutine("inicio");
    }

    IEnumerator inicio(){
        start = false;
        FALA.SetActive(true);
        anim.SetInteger("transi", 1);
        oqDizer.text = "Ola!!";
        yield return new WaitForSeconds(3);
        oqDizer.text = "Você pode me ajudar??";
        yield return new WaitForSeconds(4);
        oqDizer.text = "Estou em cima de minha mamãe, você a vê??";
        yield return new WaitForSeconds(5);
        oqDizer.text = "Ela foi cortada...";
        yield return new WaitForSeconds(3);
        oqDizer.text = "Tenho medo de ficar aqui, não quero crescer em um lugar onde meu futuro não é garantido...";
        yield return new WaitForSeconds(6);
        oqDizer.text = "Ouvi falar que atrás das montanhas existe um lugar bom!!";
        yield return new WaitForSeconds(5);
        oqDizer.text = "Poderia me levar??";
        yield return new WaitForSeconds(3);
        oqDizer.text = "Eu tenho algumas habilidades...";
        yield return new WaitForSeconds(4);
        oqDizer.text = "Posso escalar alguns barrancos quando o clima é quente e estou sem folhas...";
        yield return new WaitForSeconds(6);
        oqDizer.text = "E quando chove, posso pular mais alto, e planar até chegar ao chão!!";
        yield return new WaitForSeconds(6);
        oqDizer.text = "Eu sei que os humanos estão alterando o clima, então você poderia me ajudar!!";
        yield return new WaitForSeconds(6);
        FALA.SetActive(false);
        start = true;
    }

    
    void Update()
    {

        if(start){

            clima();

            if(escala && sol){
                escalar();
                dir = new Vector3(0, 0, 0);
            }else{
                move();
                rig.useGravity = true;
            }

            if(!isGround && !escala){
                anim.SetInteger("transi", 4);
            }
        }

    }

    void FixedUpdate(){
        if(start){
            if(front){
                rot();
            }

            transform.Translate(dir * speed * Time.deltaTime);

        }
    }

    void clima(){
        if(Input.GetButtonDown("Fire1")){
            if(chuva){
                chuva = false;
                sol = true;
            }else{
                chuva = true;
                sol = false;
            }
        }
        if(chuva){
            dCHUVA.SetActive(true);
            dSOL.SetActive(false);
            CHUVAicon.SetActive(true);
            SOLicon.SetActive(false);
        }else{
            dCHUVA.SetActive(false);
            dSOL.SetActive(true);
            CHUVAicon.SetActive(false);
            SOLicon.SetActive(true);
        }
    }

    void rot(){

        x = cam.GetComponent<cam>().x;

        transform.eulerAngles = new Vector3(transform.rotation.x, x + rotV, transform.rotation.z);
    }

    void move(){
        if(Input.GetAxisRaw("Fire3") > 0){
            dir = new Vector3(0, 0, 1);
            front = true;
            rotV = 90;
            anim.SetInteger("transi", 2);
        }

        else if(Input.GetAxisRaw("Fire3") < 0){
            dir = new Vector3(0, 0, 1);
            front = true;
            rotV = -90;
            anim.SetInteger("transi", 2);
        }

        else if(Input.GetAxisRaw("Fire2") > 0){
            dir = new Vector3(0, 0, 1);
            front = true;
            rotV = 0;
            anim.SetInteger("transi", 2);
        }

        else if(Input.GetAxisRaw("Fire2") < 0){
            dir = new Vector3(0, 0, 1);
            front = true;
            rotV = 180;
            anim.SetInteger("transi", 2);
        }
        
        else{
            dir = new Vector3(0, 0, 0);
            front = false;
            anim.SetInteger("transi", 1);
        }

        if((Input.GetAxisRaw("Jump") > 0) && isGround){
            anim.Play("pulo");

            if(chuva){
                rig.drag = 2;
                rig.velocity = Vector3.up * jP*jP2;
            }else{
                rig.drag = 0;
                rig.velocity = Vector3.up * jP;
            }
        }

    }

    void escalar(){
        rig.drag = 0;

        front = false;

        rig.useGravity = false;

        if(Input.GetAxisRaw("Fire2") > 0){
            rig.velocity = Vector3.up * speed;
            anim.SetInteger("transi", 5);
        }
        
        else if(Input.GetAxisRaw("Fire2") < 0){
            rig.velocity = -Vector3.up * speed;
            anim.SetInteger("transi", 5);
        }

        else if(Input.GetAxisRaw("Fire3") > 0){
            rig.velocity = Vector3.right * speed;
            anim.SetInteger("transi", 5);
        }

        else if(Input.GetAxisRaw("Fire3") < 0){
            rig.velocity = -Vector3.right * speed;
            anim.SetInteger("transi", 5);
        }

        else{
            rig.velocity = Vector3.zero;
            //anim.SetInteger("transi", 6);
            anim.Play("paradoESC");
        }

        if(Input.GetAxisRaw("Fire1") > 0){
            rig.velocity = -Vector3.forward * speed;
            rig.useGravity = true;
        }
    }

    void OnCollisionEnter(Collision colli){
        if(colli.collider.tag == "escalavel"){
            escala = true;
        }
        if(colli.collider.tag == "ground"){
            isGround = true;
        }
    }

    void OnCollisionExit(Collision colli){
        if(colli.collider.tag == "escalavel"){
            escala = false;
        }
        if(colli.collider.tag == "ground"){
            isGround = false;
        }
    }
    
}
