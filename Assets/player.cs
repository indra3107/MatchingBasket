using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    private int Speed = 20;
    private int xlimit = 32;
    public static int score = 0;
    public static int scoreakhir;
    public Text scoretext;
    private int timer = 30;
    public Text timertext;
    private int life = 3;

    public string currentColor;
    public SpriteRenderer sr;
    public static int highscore = 0;

    public Color colorPurple;
    public Color colorGreen;
    public Color colorRed;

    // Start is called before the first frame update
    void Start()
    {
        SetRandomColor();
        StartCoroutine(HitungMundur());
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.D))
        { // Fungsi untuk mendapatkan kode Keyboard D.
            transform.Translate(Vector3.right * Speed * Time.deltaTime); //Fungsi untuk gerakan karakter ke kanan sesuai dengan kecepatan input.
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -xlimit, xlimit), transform.position.y, transform.position.z);//batas gerakan pemain di kamera
        }
        if (Input.GetKey(KeyCode.A))
        { // Fungsi untuk mendapatkan kode Keyboard D.
            transform.Translate(Vector3.left * Speed * Time.deltaTime); //Fungsi untuk gerakan karakter ke kanan sesuai dengan kecepatan input.
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -xlimit, xlimit), transform.position.y, transform.position.z);
        }
    }

    void SetRandomColor()
    {
        int idx = Random.Range(0, 3);

        switch (idx)
        {
            case 0:
                currentColor = "Purple";
                sr.color = colorPurple;
                break;
            case 1:
                currentColor = "Red";
                sr.color = colorRed;
                break;
            case 2:
                currentColor = "Green";
                sr.color = colorGreen;
                break;
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != currentColor)
        {
            other.gameObject.SetActive(false);
            life = life - 1;
            if(life == 0)
            {
                scoreakhir = score;
                if(scoreakhir > highscore)
                {
                    highscore = scoreakhir;
                }
                score = 0;
                Debug.Log("gameOver");
                SceneManager.LoadScene("GameOver");
            }
        }
        if (other.tag == currentColor)
        {

            other.gameObject.SetActive(false);
            AddScore();
            AddTimer();
        }
    }

    
    void AddScore()
    {
        score = score + 30;
        scoretext.text =  score.ToString();
    }

    void AddTimer()
    {
        timer = timer + 2;
        timertext.text = timer.ToString();
    }

    IEnumerator HitungMundur()
    {
        while (timer > 0)
        {

            yield return new WaitForSeconds(1);
            timer--;
            timertext.text = timer.ToString();
        }
        scoreakhir = score;
        score = 0;
        SceneManager.LoadScene("GameOver");
    }
}
