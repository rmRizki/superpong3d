using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    [SerializeField] int force;
    [SerializeField] float speed;

    int scoreP1;
    int scoreP2;

    Text scoreP1UI;
    Text scoreP2UI;

    Rigidbody rigid;

    GameObject panelSelesai;
    Text txPemenang;

    AudioSource audio;
    [SerializeField] AudioClip hitSound;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        Vector3 direction = new Vector3(2, 0, 0).normalized;
        rigid.AddForce(direction * force);

        scoreP1 = 0;
        scoreP2 = 0;

        scoreP1UI = GameObject.Find("Score1").GetComponent<Text>();
        scoreP2UI = GameObject.Find("Score2").GetComponent<Text>();

        panelSelesai = GameObject.Find("PanelSelesai");
        panelSelesai.SetActive(false);

        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "WallKanan")
        {
            scoreP1 += 1;
            TampilkanScore();
            ResetBall();
            Vector3 direction = new Vector3(2, 0, 0).normalized;
            rigid.AddForce(direction * force);
            if (scoreP1 == 5)
            {
                panelSelesai.SetActive(true);
                txPemenang = GameObject.Find("Pemenang").GetComponent<Text>();
                txPemenang.text = "Player Putih Menang!";
                Destroy(gameObject);
                return;
            }
        }
        if (other.gameObject.name == "WallKiri")
        {
            scoreP2 += 1;
            TampilkanScore();
            ResetBall();
            Vector3 direction = new Vector3(-2, 0, 0).normalized;
            rigid.AddForce(direction * force);
            if (scoreP2 == 5)
            {
                panelSelesai.SetActive(true);
                txPemenang = GameObject.Find("Pemenang").GetComponent<Text>();
                txPemenang.text = "Player Merah Pemenang!";
                Destroy(gameObject);
                return;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        audio.PlayOneShot(hitSound);

        if (collision.gameObject.name == "Player1" || collision.gameObject.name == "Player2" || collision.gameObject.name == "WallAtas" || collision.gameObject.name == "WallBawah")
        {
            float angle = (transform.position.z - collision.transform.position.z) * 5f;
            Vector3 direction = new Vector3(rigid.velocity.x,rigid.velocity.y, angle).normalized;
            rigid.velocity = new Vector3(0, 0, 0);
            rigid.AddForce(direction * force * speed);
        }
    }

    void ResetBall()
    {
        transform.localPosition = new Vector3(0, 0, 0);
        rigid.velocity = new Vector3(0, 0, 0);
    }

    void TampilkanScore()
    {
        scoreP1UI.text = scoreP1.ToString();
        scoreP2UI.text = scoreP2.ToString();
    }
}
