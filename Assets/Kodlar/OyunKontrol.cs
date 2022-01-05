using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OyunKontrol : MonoBehaviour
{
    public GameObject asteroid;
    public Vector3 randomPos;
    public float baslangicBekleme;
    public float donguBekleme;
    public float olusturmaBekleme;
    int score;
    public Text text;
    public Text oyunBittiText;
    public Text yenidenBaslaText;
    bool yenidenBaslaKontrol = false;
    bool oyunBittiKontrol = false;
    void Start()
    {
        score = 0;
        text.text = "Score: " + score;
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
            for (int i = 0; i < 10; i++)
            {
                Vector3 vec = new Vector3(Random.Range(-randomPos.x, randomPos.x), 0, randomPos.z);
                Instantiate(asteroid, vec, Quaternion.identity);
                yield return new WaitForSeconds(olusturmaBekleme);
            }
            //yield return new WaitForSeconds(donguBekleme);
            if(oyunBittiKontrol)
            {
                yenidenBaslaText.text = "Yeniden Baslamak Icin R Tusuna Basiniz.";
                yenidenBaslaKontrol = true;
                break;
            }
        }
    }
    public void scoreArttir (int gelenScore)
    {
        score += gelenScore;
        text.text = "Score: " + score;
    }
    public void oyunBitti()
    {
        oyunBittiText.text = "OYUN BITTI!!";
        oyunBittiKontrol = true;
    }
}
