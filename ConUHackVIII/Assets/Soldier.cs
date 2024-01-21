using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Soldier : MonoBehaviour
{

    [SerializeField] int characterPosition = 1;
    [SerializeField] AudioClip highBird;
    [SerializeField] AudioClip midBird;
    [SerializeField] AudioClip lowBird;
    [SerializeField] AudioClip music;
    [SerializeField] public static float speed = 1f;
    [SerializeField] public int combo = 0;

    float[] position = { -3f, 0f, 3f };
    float moveDirection;
    bool isMoving = false;
    float scoreGoal = 500;
    [SerializeField] GameObject collider1;
    [SerializeField] GameObject collider2;
    [SerializeField] GameObject collider3;
    [SerializeField] GameObject bloodParticles;
    [SerializeField] GameObject shotParticle;

    
    [SerializeField] public float score = 0;
    [SerializeField] public int health = 3;

    void Start()
    {
        characterPosition = 1;


    }

    void Update()
    {
        if(score >= scoreGoal)
        {
            speed += 0.01f;
            scoreGoal *= 2;
        }



        if (isMoving)
        {
            transform.position += new Vector3(0f, 10f * moveDirection * Time.deltaTime * speed, 0f);
            if ((moveDirection > 0 && transform.position.y >= position[characterPosition])
                || (moveDirection < 0 && transform.position.y <= position[characterPosition]))
            {
                isMoving = false;
            }

        }

        if (((Input.GetKeyDown(KeyCode.W)) || (Input.GetKeyDown(KeyCode.JoystickButton3))) && !isMoving && characterPosition < 2)
        {
            isMoving = true;
            moveDirection = 1f;
            characterPosition++;


        }
        else if (((Input.GetKeyDown(KeyCode.S)) || (Input.GetKeyDown(KeyCode.JoystickButton1))) && !isMoving && characterPosition > 0)
        {
            isMoving = true;
            moveDirection = -1f;
            characterPosition--;
        }


        if (((Input.GetKeyDown(KeyCode.Space)) || (Input.GetKeyDown(KeyCode.JoystickButton7))) && !isMoving)
        {
            Debug.Log(characterPosition);
            switch (characterPosition)
            {
                case 0:
                    ColliderManager colliderManager3 = collider3.GetComponent<ColliderManager>();
                    if (colliderManager3.canBeShot == true)
                    {
                        Instantiate(shotParticle, transform.position, transform.rotation);
                        Instantiate(bloodParticles, collider3.transform.position, collider3.transform.rotation);
                        Destroy(colliderManager3.currentZombie);
                        combo++;
                        score += 100f * (1f + combo*0.02f);
                        AudioSource.PlayClipAtPoint( highBird , transform.position, 5f);
                    }
                        
                    break;
                case 1:
                    ColliderManager colliderManager2 = collider2.GetComponent<ColliderManager>();
                    if (colliderManager2.canBeShot == true)
                    {
                        Instantiate(shotParticle, transform.position, transform.rotation);
                        Instantiate(bloodParticles, collider2.transform.position, collider2.transform.rotation);
                        Destroy(colliderManager2.currentZombie);
                        combo++;
                        score += 100f * (1f + combo * 0.02f);
                        AudioSource.PlayClipAtPoint(midBird, transform.position, 5f);
                    }
                    break;
                case 2:
                    ColliderManager  colliderManager1 = collider1.GetComponent<ColliderManager>();
                    if (colliderManager1.canBeShot == true)
                    {
                        Instantiate(shotParticle, transform.position, transform.rotation);
                        Instantiate(bloodParticles, collider1.transform.position, collider1.transform.rotation);
                        Destroy(colliderManager1.currentZombie);
                        combo++;
                        score += 100f * (1f + combo * 0.02f);
                        AudioSource.PlayClipAtPoint(lowBird, transform.position, 5f);
                    }
                    break;
            }
        }
    }

}
