using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 

 
  public class canhaoatira : MonoBehaviour
 {
   Color m_MouseOverColor = Color.yellow;
   Color m_OriginalColor;
   MeshRenderer m_Renderer;
    Rigidbody  RB;
    RaycastHit hiti; 
    public Transform explosionPrefab;
    AudioSource m_MyAudioSource;
   
    void Start()
    {
      m_Renderer = GetComponent<MeshRenderer>();
      m_OriginalColor = m_Renderer.material.color;
     m_MyAudioSource = GetComponent<AudioSource>();
          
     }

    void OnMouseOver()
    {
      m_Renderer.material.color = m_MouseOverColor;
        
      Vector3 fwd = transform.TransformDirection(Vector3.forward);
      if(Physics.Raycast(transform.position,fwd , out   hiti, Mathf.Infinity)){
          
         m_MyAudioSource.Play();
         Instantiate(explosionPrefab, hiti.point,Quaternion.LookRotation(hiti.normal));
         if(hiti.rigidbody.tag=="pedra") Destroy(hiti.collider.gameObject,.5f);

       }
       else{
        Debug.Log("Did not Hit");
          
       }
        
    }

    void OnMouseExit()
    {
        // Reset the color of the GameObject back to normal
        m_Renderer.material.color = m_OriginalColor;
 
    }
}

