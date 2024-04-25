using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class LifeSystem : MonoBehaviour
{

    public int vida;
    public int vidaMax; 

    public Image[] barra; 
    public Sprite cheio;
    public Sprite vazio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HealthLogic();
    }

    void HealthLogic(){

        if(vida > vidaMax){
            vida = vidaMax;
        }

        for (int i = 0; i < barra.Length; i++)
        {
            if(i < vida){
                barra[i].sprite = cheio;
            }
            else{
                barra[i].sprite = vazio;
            }

            if(i < vidaMax){
                barra[i].enabled = true;
            }
            else{
                barra[i].enabled = false; 
            }
        }
    }
}
