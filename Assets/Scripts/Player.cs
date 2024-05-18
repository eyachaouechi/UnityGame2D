using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public GameObject panel;
    public GameObject GameOver;
    public int score = 0;
    public float speed = 5.0f;
    public Text Win;
    public Text keyAmount;
    private SpriteRenderer sprite;
	float currentTime = 0f;
    float startingTime = 60f;
    public TextMeshProUGUI countdownText; 
	public bool Done =false;
    // Start is called before the first frame update
    void Start()
    {
		   currentTime = startingTime;
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
	   if (Done == false)
        { if (currentTime.ToString("0") == "0"){
			GameOver.SetActive(true);
			
			}
            else{ currentTime -= 1 * Time.deltaTime;
			 
				  countdownText.text = currentTime.ToString("0");
		
	 if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            sprite.flipX = false;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            sprite.flipX = true;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }

		}
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Keys")
        {
            score++;
            keyAmount.text = "Fruits: " + score;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Exit")
        {
            panel.SetActive(true);
            Destroy(collision.gameObject);
			Done= true;
        }
    }
}
