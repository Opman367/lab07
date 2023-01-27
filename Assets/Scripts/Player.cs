      using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    private Rigidbody PlayerRB;
    [SerializeField] private GameObject GameOverBG;

    void Start()
    {
        PlayerRB = this.gameObject.GetComponent<Rigidbody>();
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
        if (GameOverBG.activeSelf == true)
        {
            GameOverBG.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            PlayerRB.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        thisAnimation.Play();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        { 
            GameOverBG.SetActive(true);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PassedPole")
        {
            GameManager.thisManager.UpdateScore(10);
        }
    }
}
