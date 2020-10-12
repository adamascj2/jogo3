using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
 
public class vitoria: MonoBehaviourPun
{
 AudioSource  MyAudioSource;
    public static bool   liberou = false; 
    string nome = "Nome Sobrenome";
    string mensagemenviadaC;
    string mensagemrecebidaC;
    string scriptnoservidor ="http://americo.somee.com/gravanome.aspx";
    
    string msgLimpa;
    string mensagemNaLista;

   void Start()
   {
     MyAudioSource = GetComponent<AudioSource>();
     mensagemNaLista = "ENTRE COM Nome e Sobrenome.EX: Carlos Pontes";  
    }

    void OnGUI ()
   {
     GUIStyle myButtonStyle = new GUIStyle(GUI.skin.button);
     myButtonStyle.fontSize = 60;
     Font myFont1 = (Font)Resources.Load("Fonts/comic", typeof(Font));
     myButtonStyle.font = myFont1;
     myButtonStyle.normal.textColor = Color.yellow;
     myButtonStyle.hover.textColor = Color.yellow; 

     if(GUI.Button(new Rect(1250,Screen.height -  150,500,200), "VITORIOSOS",myButtonStyle))
     {
         PhotonNetwork.LoadLevel("Vitoriosos");
     }
 
      
     GUIStyle myTextStyle = new GUIStyle(GUI.skin.textField);
     myTextStyle.fontSize = 60;
     Font myFont2 = (Font)Resources.Load("Fonts/comic", typeof(Font));
     myTextStyle.font = myFont2;
     myTextStyle.normal.textColor = Color.white;
     myTextStyle.hover.textColor = Color.white;
     
     nome = GUI.TextField (new Rect (0,100,1000,80), nome,myTextStyle );
      

     GUIStyle myLabelStyle = new GUIStyle(GUI.skin.label);
     myLabelStyle.fontSize = 60;
     Font myFont3 = (Font)Resources.Load("Fonts/comic", typeof(Font));
     myLabelStyle.font = myFont3;
     myLabelStyle.normal.textColor = Color.yellow;
     myLabelStyle.hover.textColor = Color.yellow; 
     GUI.Label(new Rect(0,0,3000,120),mensagemNaLista,myLabelStyle);
      
   }  


    IEnumerator OnTriggerEnter(Collider other)
    {
      if(other.gameObject.tag == "robot"){
        liberou=true;
        MyAudioSource.Play();
        mensagemNaLista = "NOME ENVIADO.AGUARDE!";  
        mensagemenviadaC = nome.Replace(" ","_");
 
 
        if(mensagemenviadaC !="Nome_Sobrenome"){  
          
          using (WWW www = new WWW(scriptnoservidor+"?mensagemenviadaC="+mensagemenviadaC)) 
         {
           Debug.Log("DENTRO");
           yield return www;
           mensagemrecebidaC = www.text;
           mensagemNaLista = (mensagemrecebidaC.Split("$"[0]))[0].ToString();
           mensagemNaLista = mensagemNaLista.Replace("_"," ");
         }
        }
        else{
          mensagemNaLista = "NÃO FOI ENTRADO NOME!";
        }
     }   
   }
}

    