using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ZombieBIrd : MonoBehaviour
{

    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -20)
        {
            player.GetComponent<Soldier>().health--;
            Destroy(gameObject);
        }
    }
}
