using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ZombieBIrd : MonoBehaviour
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
            Debug.Log("here");
            player.GetComponent<Soldier>().health--;
            Destroy(gameObject);
        } else if (other != null && other.tag == "player")
        {
            Instantiate(bloodParticles, transform.position, transform.rotation);
            player.GetComponent<Soldier>().health--;
            Destroy(gameObject);
        }
    }

}
