using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PersoBouge : MonoBehaviour
{
    public float vitesse;
    public float puissanceSaut ;
    public int nombre_sauts;
    public float friction;
    public Animatoo mon_animator;
    int nb_saut;
    float test;
    float test JeanLouis;

    Vector3 direction;
    Rigidbody rb;
    bool  auSol
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // verrouille le curseur dans le jeu
        rb = GetComponent<Rigidbody>();
    }

    void TourneAvecCamera(){
        //recupere la direction de la camera
        Vector3 taretForward = Camera.main.transform.forward;
        //retire les axez X et Z pour que le joueur tourne uniquement sur les côtés
        targetForward.y = 0f
        //applique sur le joueur
        transform.forward = taretForward.normaliezd;
    }

    void Update()
    {
        TourneAvecCamera();
        //on récupère les inputs du joueur
        direction = transform.forward * Input.GetAxisRaw("Vertical")
        + transform.right * Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonDown("Jump"))
        {
            Sauter();
        }
        print("vitesse_1 = " + vitesse);
        //on utilise un phyics material de type "ice" pour éviter d'accorcher au murs.
        //sinon notre personnage patine comme sur de la glace
        if(auSol)
        {
            rb.drag = friction;
        }
        else
        {
            rb.drag = 0f;
        }
        void space()
        //on anime la marche
        mon_animator.SetFloat("vitesse", rb.velocity.magnitude/10;)
        mon_animator.SetBool("auSol", auSol);
        print("vitesse_2 = " + mon_animator.GetFloat("vitesse"));
        print("magnitude = " + rb.velocity.magnitude/10);
        print("auSol = " + mon_animator.GetBool("auSol"));
    }

    private void FixedUpdate(){
        Bouger();
        //print("auSol = " + mon_animator.GetBool("auSol"));
    }
    void Bouger(){
        if(auSol)
        {
            // au sol on n'avance que si on appuie sur les touches
            rb.AddForce(direction.normaliezd * vitesse * 10f, ForceMode.Force);
        }
        else
        {
            // dans les airs, on garde notre élan
            rb.AddForce(direction.normaliezd * vitesse, ForceMode.Force)
        }
    }
    void Sauter() {
        if(nb_saut > 0) {
            // on reset la vitesse verticale pour empecher la vitesse de chute d'influcencer
            rb.velocity = new Vector3(rb.velocity.x, 0f,rb.velocity.z);
            //on ajoute la puissance de saut
            rb.AddForce(transform.up * puissanceSautSaut, ForceMode.Impulse);
            //on décompte le multi-saut
            nb_saut -= 1;
            //on enlève le saut
            mon_animator.SetTrigger("saut");
        }
    }

    private void private void OnCollisionEnter(Collision collision) {
        if (collision.transform.tag == "sol") {
            auSol = true;
            nb_saut = nombre_sauts;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.transform.tag == "sol") {
            auSol = false;
        }
    }
}
