using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameScripts : MonoBehaviour
{
    // Start is called before the first frame update
    public Text Sayi1, Sayi2, Islem, Esittir, Sonuc, Yanýt;
    public Text zaman, durum, zorluk, süre, zorlukcarp;
    public Text score;
    int sayi1, sayi2, islemIsareti;
    static public float zamanSayac;
    int zorlukTavan = 15, zorlukTaban = 1;
    int skor;
    static public int controller;
    int zorlukCarpaný;
    int islemSonucu;
    void Start()
    {
        //DataManager.Instance.Score = 0;
        dortIslem();
        Zorluk();
        cevapKontrol();
    }    
    // Update is called once per frame
    void Update()
    {
        if(zamanSayac >= 0)
        {
            zamanSayac -= Time.deltaTime;
            zaman.text = (int)zamanSayac + "";
            zamanKalan(zamanSayac);
        }
        controller=skor;
    }
    public void Zorluk()
    {
        switch (SettingsScript.gamedifficulty)
        {
            case 1:
                zamanSayac = 90;
                zorlukTavan = 25;
                zorlukTaban = 1;
                zorlukCarpaný = 1;
                zorluk.text = "Easy";
                süre.text = zamanSayac + "";
                zorlukcarp.text = zorlukCarpaný + "";
                break;
            case 2:
                zamanSayac = 60;
                zorlukTavan = 65;
                zorlukTaban = 25;
                zorlukCarpaný = 2;
                zorluk.text = "Normal";
                süre.text = zamanSayac + "";
                zorlukcarp.text = zorlukCarpaný + "";
                break;
            case 3:
                zamanSayac = 30;
                zorlukTaban = 50;
                zorlukTavan = 100;
                zorlukCarpaný = 3;
                zorluk.text = "Hard";
                süre.text = zamanSayac + "";
                zorlukcarp.text = zorlukCarpaný + "";
                break;
        }
    }
    public void cevapKontrol()
    {
        if (islemSonucu == int.Parse(Yanýt.text))
        {
            skor++;
            score.text = skor*zorlukCarpaný + "";
            Sonuc.text = "Dogru";
            dortIslem();
        }
        else if(islemSonucu != int.Parse(Yanýt.text))
        {
            skor--;
            score.text = skor * zorlukCarpaný + "";
            Sonuc.text = "Yanlýs";
        }
        if (zamanSayac >= 0)
        {
            DataManager.Instance.Score=skor*zorlukCarpaný;
            
        }
    }
    public void dortIslem()
    {
        if (zamanSayac >= 0)
        {
            Yanýt.text = " ";
            sayi1 = Random.Range(zorlukTaban, zorlukTavan);
            sayi2 = Random.Range(zorlukTaban, zorlukTavan);
            islemIsareti = Random.Range(1, 5);
            sonuc();
        }
    }
    public void sonuc()
    {
        switch (islemIsareti)
        {
            case 1:
                Islem.text = "+";
                islemSonucu = sayi1 + sayi2;
                break;
            case 2:
                Islem.text = "-";
                islemSonucu = sayi1 - sayi2;
                break;
            case 3:
                Islem.text = "x";
                islemSonucu = sayi1 * sayi2;
                break;
            case 4:
                Islem.text = "/";
                if (sayi1 < sayi2)
                {
                    sayi2 = Random.Range(1, sayi1 + 1);
                }
                islemSonucu = sayi1 / sayi2;
                break;
        }
        Sayi1.text = sayi1 + "";
        Sayi2.text = sayi2 + "";
        Esittir.text = "=";
    }
    public void zamanKalan(float zamanSayac)
    {
        if (zamanSayac < 0)
        {
            durum.text = "Süre bitti.";
            zamanSayac = 0;
        }
    }
}