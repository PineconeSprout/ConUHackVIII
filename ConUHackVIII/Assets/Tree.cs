using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{

    [SerializeField] GameObject bloodParticles;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && other.tag == "endWall")
        {
            Destroy(gameObject);
        }
        else if (other != null && other.tag == "player")
        {
            Instantiate(bloodParticles, transform.position, transform.rotation);
            if (player.GetComponent<Soldier>().health > 0)
            {
                player.GetComponent<Soldier>().health--;
            }
        }
    }
}
