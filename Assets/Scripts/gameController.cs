using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameController : MonoBehaviour {

    public GameObject gift;
    public GameObject coal;
    public GameObject chimney;

    public Sprite goodChimney;
    public Sprite badChimney;
    public Sprite success;
    public Sprite failure;

    public Text scoreText;

    public AudioSource successSound;
    public AudioSource failureSound;

    public float chimneySpeed;
    public bool giftSelected;

    int score;

	// Use this for initialization
	void Start ()
    {
        giftSelected = true;

        score = 0;
        scoreText.text = "Score: " + score;
    }

    private void Update()
    {
        checkInput();

    }

    void FixedUpdate ()
    {

        moveChimneys();

        if (Mathf.Repeat(Time.timeSinceLevelLoad, 1.0f) == 0)
        {
            generateChimneys();
        }
    }

    void checkInput()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.tag == "Chimney")
                {
                    if (hit.collider.GetComponent<chimneyController>().isGood == giftSelected)
                    {
                        if (!hit.collider.GetComponent<chimneyController>().counted)
                        {
                            hit.collider.GetComponent<SpriteRenderer>().sprite = success;
                            hit.collider.GetComponent<chimneyController>().counted = true;
                            score += 10;
                            scoreText.text = "Score: " + score;
                            successSound.Play();
                        }
                    }
                    else
                    {
                        if (!hit.collider.GetComponent<chimneyController>().counted)
                        {
                            hit.collider.GetComponent<SpriteRenderer>().sprite = failure;
                            hit.collider.GetComponent<chimneyController>().counted = true;
                            score -= 50;
                            scoreText.text = "Score: " + score;
                            failureSound.Play();
                        }
                    }
                }


                if (hit.collider.tag == "Gift")
                {
                    if (!giftSelected)
                    {
                        gift.GetComponent<clickController>().setSelected();
                        coal.GetComponent<clickController>().setUnselected();
                        giftSelected = true;
                    }
                }

                if (hit.collider.tag == "Coal")
                {
                    if (giftSelected)
                    {
                        coal.GetComponent<clickController>().setSelected();
                        gift.GetComponent<clickController>().setUnselected();
                        giftSelected = false;
                    }
                }

            }
        }
    }

    void moveChimneys()
    {
        GameObject[] go = GameObject.FindGameObjectsWithTag("Chimney");
        foreach (GameObject chimney in go)
        {
            chimney.transform.Translate(new Vector2(0.0f, -chimneySpeed));
        }
    }

    void generateChimneys()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject newChimney = Instantiate<GameObject>(chimney);
            newChimney.transform.SetPositionAndRotation(new Vector3(600 + i * 250, 150, 0), Quaternion.identity);
            if (Random.Range(0.0f, 100.0f) > 50)
            {
                newChimney.GetComponent<SpriteRenderer>().sprite = badChimney;
                newChimney.GetComponent<chimneyController>().isGood = false;
            }
            else
            {
                newChimney.GetComponent<SpriteRenderer>().sprite = goodChimney;
                newChimney.GetComponent<chimneyController>().isGood = true;
            }
        }
    }

}
