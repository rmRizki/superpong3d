using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] string axis;
    [SerializeField] float batasAtas;
    [SerializeField] float batasBawah;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis(axis) * speed * Time.deltaTime;
        float nextPost = transform.position.z + move;
        if(nextPost > batasAtas)
        {
            move = 0;
        }
        if(nextPost < batasBawah)
        {
            move = 0;
        }
        transform.Translate(0, 0, move);
    }
}
