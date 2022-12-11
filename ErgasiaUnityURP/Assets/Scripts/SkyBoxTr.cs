using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxTr : MonoBehaviour
{
     public List<Material> SkyBoxtr;
    float timer;
    int i=0;
    bool cd=false;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer>5){
        if(!cd){
            
            
          if(i<7){

          
            RenderSettings.skybox=SkyBoxtr[i];
            i=i+1;
          }else{
            cd=true;
          }
          
                
        }else{

            RenderSettings.skybox=SkyBoxtr[i];
            i=i-1;
            if(i==0){

                cd=false;
            }

        }
            
            timer=0;
        }
       

        timer+=Time.deltaTime;
        updatetimer(timer);
        
    }
    void updatetimer(float curtime){
        float sec=Mathf.FloorToInt(curtime%60);

    }
}
