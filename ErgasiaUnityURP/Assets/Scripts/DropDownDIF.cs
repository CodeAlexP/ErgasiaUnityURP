using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropDownDIF : MonoBehaviour
{
    public TextMeshProUGUI output;
    public void HandleInputData(int val){

        if(val==0){
            output.text="0";

        }
        if(val==1){

             output.text="1";
        }
        if(val==2){
            output.text="2";
            
        }
    }
    


}
