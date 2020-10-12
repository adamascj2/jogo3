using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
 
public class Duelo: MonoBehaviourPun
{
  public string   entrante;
  public PhotonView photonView;
  AudioSource m_MyAudioSource; 
   
   void Start()
   {
     photonView = this.GetComponent<PhotonView>(); 
     entrante =  photonView.ViewID.ToString();
     m_MyAudioSource = GetComponent<AudioSource>();
    
    }  
          
         IEnumerator OnTriggerEnter(Collider other)
         {
           if(vitoria.liberou && other.gameObject.tag == "bala"){
              m_MyAudioSource.Play();//robot tem "dead" de audio clip
              photonView = gameObject.GetComponent<PhotonView>(); 
              entrante =  photonView.ViewID.ToString();
              GameObject GOx = GameObject.Find("robot(Clone)"+entrante);
              yield return new WaitForSeconds(0.01f);//gambiarra!!!!
              GOx.transform.position = GameObject.Find("Entrada").transform.position ;  
              GOx.transform.rotation = GameObject.Find("Entrada").transform.rotation ; 
            }
          }
 
}
