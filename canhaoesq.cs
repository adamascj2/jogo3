using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class canhaoesq : MonoBehaviour
{
    
    Color m_MouseOverColor = Color.red;
    Color m_OriginalColor;
    MeshRenderer m_Renderer;
    Rigidbody  RB;
    
    void Start()
    {
     m_Renderer = GetComponent<MeshRenderer>();
     m_OriginalColor = m_Renderer.material.color;
     RB = GetComponent<Rigidbody>();  
    }

    void OnMouseOver()
    {
        m_Renderer.material.color = m_MouseOverColor;
        RB.velocity  =   new Vector3(-1, 0, 0);
     }

    void OnMouseExit()
    {
        m_Renderer.material.color = m_OriginalColor;
        RB.velocity  =   new Vector3(0, 0, 0);
    }
}
