using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public LineRenderer[] lineRenderers;
    public Transform[] stripPositions;
    public Transform center;
    public Transform idlePosition;

    public Vector3 currentPosition;
    public float maxLength;
    public float bottomBoundary;




    bool isMouseDown;

    public GameObject roosterPrefab;

    public float roosterPositionOffset;
    Rigidbody2D rooster;
    Collider2D roosterCollider;

    public float force;


    

    void Start()
    {
        lineRenderers[0].positionCount = 2;
        lineRenderers[1].positionCount = 2;
        lineRenderers[0].SetPosition(0, stripPositions[0].position);
        lineRenderers[1].SetPosition(0, stripPositions[1].position);
        CreateRooster();
    }

    void CreateRooster()
    {
        rooster = Instantiate(roosterPrefab).GetComponent<Rigidbody2D>();
        roosterCollider = rooster.GetComponent<Collider2D>();
        roosterCollider.enabled = false;
        rooster.isKinematic = true;
        ResetStrips();



   
    }


    void Update()
    {
        if (isMouseDown)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10;



            currentPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            currentPosition = center.position + Vector3.ClampMagnitude(currentPosition - center.position, maxLength);
            currentPosition = ClampBoundary(currentPosition);

            SetStrips(currentPosition);
        }


        if (roosterCollider)
        {
            roosterCollider.enabled = true;
        }
        else
        {
            ResetStrips();
        }
    }

      private void OnMouseDown()
    {
        isMouseDown = true;
        
       
    }

    private void OnMouseUp()
    {
        isMouseDown = false;
        Shoot(); 
        currentPosition = idlePosition.position;
    }

    void Shoot()
    {
      if (rooster == null) return;
        rooster.isKinematic = false;
        Vector3 RoosterForce = (currentPosition - center.position) * force * -1;
        rooster.velocity = RoosterForce;

        rooster.GetComponent<Rooster>().Release();

        rooster = null;
        roosterCollider = null;
        Invoke("CreateRooster", 2);
    }



    void ResetStrips()
    {
        currentPosition = idlePosition.position;
        SetStrips(currentPosition);
    }

    void SetStrips(Vector3 position)
    {
        lineRenderers[0].SetPosition(1, position);
        lineRenderers[1].SetPosition(1, position);
       
        if (rooster)
        {
            Vector3 dir = position - center.position;
            rooster.transform.position = position + dir.normalized * roosterPositionOffset;
            rooster.transform.right = -dir.normalized;
        } 
    }


        Vector3 ClampBoundary(Vector3 vector)
        {
            vector.y = Mathf.Clamp(vector.y, bottomBoundary, 1000);
            return vector;
        }
    }

