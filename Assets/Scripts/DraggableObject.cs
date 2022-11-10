using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using CodeMonkey.Utils;

public class DraggableObject : MonoBehaviour, IPointerClickHandler
{
    private Rigidbody2D m_rb;
    public Vector3 difference;
    public bool selected;

    public HandManager handManager;
    public BattleSystem battleSystem;

    void Start()
    {
        battleSystem = FindObjectOfType<BattleSystem>();
        m_rb = GetComponent<Rigidbody2D>();
        selected = false;
        m_rb.bodyType = RigidbodyType2D.Static;
    }

    // Update is called once per frame
    void Update()
    {
        if (selected)
        {
            Vector3 newWorldPosition = new Vector3(UtilsClass.GetMouseWorldPosition().x, UtilsClass.GetMouseWorldPosition().y, this.transform.position.z);

            difference = newWorldPosition - transform.position;

            m_rb.velocity = 10 * difference;

            //change collider to be x2
        }

        /*if (Input.GetMouseButtonDown(0) && selected)
        {
            selected = false;
        }*/
    }

    private void OnMouseDrag()
    {

    }

    private void OnMouseDown()
    {
        if (selected)
        {
            selected = false;
            //reset collider to normal
            //store a target position?
            //lerp the card towards target position?
        }

        else
        {
            selected = true;
            m_rb.bodyType = RigidbodyType2D.Dynamic;
            battleSystem.selecting = true;
        }   
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        /*if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (selected)
            {
                selected = false;
            }
            Debug.Log("Right button pressed.");
        }        */  
    }

    private void OnMouseUp()
    {
        selected = false;
        this.transform.position = UtilsClass.GetMouseWorldPosition();
        m_rb.velocity = Vector2.zero;
        m_rb.bodyType = RigidbodyType2D.Static;
        battleSystem.selecting = false;
    }
}
