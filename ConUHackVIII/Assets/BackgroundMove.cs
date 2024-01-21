using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{

    Vector3 startPosition;
    float repeatWidth;
    [SerializeField] float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        repeatWidth = GetComponent<BoxCollider2D>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.left * Time.deltaTime * speed);
        if(transform.position.x < startPosition.x - repeatWidth)
        {
            transform.position = startPosition;
        }
    }
}
