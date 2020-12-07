using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSelect : MonoBehaviour
{
    public int index = 0;
    public GameObject[] Characters;
    public bool charSelected = false;
    
    
    Vector2 Charv;

    void Update()
    {
        for (int i = 0; i == Characters.Length; i++)
        {
            GameObject CharDE = Characters[i];
            var script = CharDE.GetComponent<MovementShooting>();
            script.enabled = false;
            charSelected = false;
            
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            index++;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            index--;
        }

        if (index > Characters.Length )
        {
            index = 0;
        }

        if (index < 0)
        {
            index = Characters.Length;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            charSelected = true;
        }
        if (!charSelected)
        {
            GameObject character = Characters[index];
            Transform chaPos = character.GetComponent<Transform>();
            chaPos.position = chaPos.position - chaPos.position;
        }
        else
        {
            GameObject character = Characters[index];
            var script = character.GetComponent<MovementShooting>();
            script.enabled = true;

            for (int i = 0; i == Characters.Length; i++)
            {
                GameObject CharMil = Characters[i];
                Transform CharMilTran = CharMil.GetComponent<Transform>();
                if (i != index)
                {
                    CharMilTran.position = CharMilTran.position + CharMilTran.position + CharMilTran.position;
                }
                
               

            }

        }
       
            
    }
}
