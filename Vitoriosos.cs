using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
 
public class Vitoriosos: MonoBehaviourPun
{
  string mensagemrecebidaC;
  string scriptnoservidor ="http://americo.somee.com/lenomes.aspx";
   string mensagemNaLista;
   Rect windowRect  =  new Rect (100, 100, 2000, 1200); // se mudar, verificar no Inspector
   Vector2 scrollViewVector  = Vector2.zero;

   IEnumerator Start()
   {
       using (WWW www = new WWW(scriptnoservidor)) 
       {
         yield return www;
         mensagemrecebidaC = www.text;
         mensagemNaLista = (mensagemrecebidaC.Split("$"[0]))[0].ToString();
        } 
     
    }

       void OnGUI ()
   {
     GUIStyle myButtonStyle = new GUIStyle(GUI.skin.button);
     myButtonStyle.fontSize = 60;
     Font myFont1 = (Font)Resources.Load("Fonts/comic", typeof(Font));
     myButtonStyle.font = myFont1;
     myButtonStyle.normal.textColor = Color.yellow;
     myButtonStyle.hover.textColor = Color.yellow; 

     if(GUI.Button(new Rect(1250,Screen.height -  150,500,200), "REINICIAR",myButtonStyle))
     {
         PhotonNetwork.LoadLevel("Cena2");
     }
 
      
     GUIStyle myWinStyle = new GUIStyle(GUI.skin.window);
     myWinStyle.fontSize = 60;
     Font myFont5 = (Font)Resources.Load("Fonts/comic", typeof(Font));
     myWinStyle.font = myFont5;
     myWinStyle.normal.textColor = Color.white;
     myWinStyle.hover.textColor = Color.white;
 
     windowRect = GUI.Window (1, windowRect, janela1,  "LISTA DE NOMES VITORIOSOS",myWinStyle); 
      
   }  

 void janela1 (int windowID  ) {
    GUIStyle myTAStyle = new GUIStyle(GUI.skin.textArea);
     myTAStyle.fontSize = 60;
     Font myFont3 = (Font)Resources.Load("Fonts/comic", typeof(Font));
     myTAStyle.font = myFont3;
     myTAStyle.normal.textColor = Color.yellow;
     myTAStyle.hover.textColor = Color.yellow;

     GUI.DragWindow (new Rect (0,0, 10000, 2000));  
      scrollViewVector=GUI.BeginScrollView (new Rect (10,100,3000,1650),  scrollViewVector, new Rect (0, 100, 0, 2000 ));  
     GUI.TextArea (new Rect (100, 100, 2000, 5000), mensagemNaLista,myTAStyle);  
 }
     
}

    