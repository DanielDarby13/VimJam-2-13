using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset_Timer : MonoBehaviour
{
    [SerializeField]
    private GameObject Player_Object;
    [SerializeField]
    private int Seconds_Until_Return;
    private Vector3 Original_Position;
    private bool Projecting = false;
    private CharacterController Controller;
    
    // Start is called before the first frame update
    void Start()
    {
        Controller = Player_Object.GetComponent<ThirdPersonMovement>().controller;
        Original_Position = Player_Object.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Projecting == false)
            {
                Projecting = true;
                Astral_Projection();
            }
        }
    }

    private void Astral_Projection()
    {
        Original_Position = Player_Object.transform.position;
        StartCoroutine(Projection_Clock());
    }

    IEnumerator Projection_Clock()
    {
        yield return new WaitForSeconds(Seconds_Until_Return);
        Player_Object.GetComponent<ThirdPersonMovement>().Can_Move = false;
        Controller.Move(new Vector3(0, 0, 0));
        Player_Object.transform.position = Original_Position;
        yield return new WaitForSeconds(0.1f);
        Player_Object.GetComponent<ThirdPersonMovement>().Can_Move = true;
        Projecting = false;
    }
}
