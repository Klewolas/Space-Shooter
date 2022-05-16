using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OyunKontrol : MonoBehaviour
{
    [SerializeField] private GameObject asteroid;
    [SerializeField] private Vector3 randomPos;
    [SerializeField] private float baslangicBekleme;
    [SerializeField] private float olusturmaBekleme;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private TMP_Text restartText;
    
    
    int score;
    bool yenidenBaslaKontrol = false;
    bool oyunBittiKontrol = false;
    void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score;
        StartCoroutine(olustur());
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && yenidenBaslaKontrol)
        {
            SceneManager.LoadScene("Level1");
        }
    }
    IEnumerator olustur()
    {
        yield return new WaitForSeconds(baslangicBekleme);
        while(true)
        {
            Vector3 vec = new Vector3(Random.Range(-randomPos.x, randomPos.x), 0, randomPos.z);
            Instantiate(asteroid, vec, Quaternion.identity);
            yield return new WaitForSeconds(olusturmaBekleme);

            if (oyunBittiKontrol)
            {
                restartText.text = "Press R to restart.";
                yenidenBaslaKontrol = true;
                break;
            }
        }
    }
    public void scoreArttir (int gelenScore)
    {
        score += gelenScore;
        scoreText.text = "Score: " + score;
    }
    public void oyunBitti()
    {
        gameOverText.text = "GAME OVER!!";
        oyunBittiKontrol = true;
    }
}
