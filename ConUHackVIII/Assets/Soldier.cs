using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Soldier : MonoBehaviour
{

    [SerializeField] int characterPosition = 1;
    float[] position = { -3f, 0f, 3f };
    float moveDirection;
    bool isMoving = false;

    [SerializeField] GameObject collider1;
    [SerializeField] GameObject collider2;
    [SerializeField] GameObject collider3;
    [SerializeField] GameObject bloodParticles;
    [SerializeField] GameObject shotParticle;

    [SerializeField] public int score = 0;
    [SerializeField] public int health = 3;

    void Start()
    {
        characterPosition = 1;
    }

    void Update()
    {

        if (isMoving)
        {
            transform.position += new Vector3(0f, 10f * moveDirection * Time.deltaTime, 0f);
            if ((moveDirection > 0 && transform.position.y >= position[characterPosition])
                || (moveDirection < 0 && transform.position.y <= position[characterPosition]))
            {
                isMoving = false;
            }

        }

        if ((Input.GetKeyDown(KeyCode.W)) && !isMoving && characterPosition < 2)
        {
            isMoving = true;
            moveDirection = 1f;
            characterPosition++;


        }
        else if ((Input.GetKeyDown(KeyCode.S)) && !isMoving && characterPosition > 0)
        {
            isMoving = true;
            moveDirection = -1f;
            characterPosition--;
        }


        if ((Input.GetKeyDown(KeyCode.Space)) && !isMoving)
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
                        score++;
                    }
                        
                    break;
                case 1:
                    ColliderManager colliderManager2 = collider2.GetComponent<ColliderManager>();
                    if (colliderManager2.canBeShot == true)
                    {
                        Instantiate(shotParticle, transform.position, transform.rotation);
                        Instantiate(bloodParticles, collider2.transform.position, collider2.transform.rotation);
                        Destroy(colliderManager2.currentZombie);
                        score++;
                    }
                    break;
                case 2:
                    ColliderManager  colliderManager1 = collider1.GetComponent<ColliderManager>();
                    if (colliderManager1.canBeShot == true)
                    {
                        Instantiate(shotParticle, transform.position, transform.rotation);
                        Instantiate(bloodParticles, collider1.transform.position, collider1.transform.rotation);
                        Destroy(colliderManager1.currentZombie);
                        score++; 
                    }
                    break;
            }
        }
    }

}
