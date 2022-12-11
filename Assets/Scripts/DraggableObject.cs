using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.EventSystems;
using UnityEngine;
using CodeMonkey.Utils;

public class DraggableObject : MonoBehaviour
{
    private Rigidbody2D m_rb;
    public Vector3 difference;
    public bool selected;

    public GameObject handManager;
    public BattleSystem battleSystem;
    public HandManager handScript;


    //what array am I currently a part of
    public GameObject currentLocation;
    //what array have I most recently touched
    public GameObject targetLocation;

    void Start()
    {
        currentLocation = this.gameObject;
        targetLocation = this.gameObject;
        handManager = GameObject.Find("Hand Manager");
        handScript = handManager.GetComponent<HandManager>();
        battleSystem = FindObjectOfType<BattleSystem>();
        m_rb = GetComponent<Rigidbody2D>();
        selected = false;
        m_rb.bodyType = RigidbodyType2D.Static;
    }

    // Update is called once per frame
    void Update()
    {
        if (!battleSystem.paused)
        {
            UpdateLocation();
            UpdateCardPosition();
        }

        /*if (Input.GetMouseButtonDown(0) && selected)
        {
            selected = false;
        }*/


    }

    private void UpdateCardPosition()
    {
        if (selected)
        {
            Vector3 newWorldPosition = new Vector3(UtilsClass.GetMouseWorldPosition().x, UtilsClass.GetMouseWorldPosition().y, this.transform.position.z);

            difference = newWorldPosition - transform.position;

            m_rb.velocity = 10 * difference;

        }

        else
        {
            if (currentLocation.tag == "HandManager")
            {
                PositionInHand();
            }

            else if (currentLocation.tag == "GridCell")
            {
                this.transform.position = new Vector3(currentLocation.transform.position.x, currentLocation.transform.position.y, this.transform.position.z);
            }
        }

    }

    private void PositionInHand()
    {
        this.transform.position = new Vector3((handScript.cardAnchor.transform.position.x) + (handScript.hand.IndexOf(this.gameObject) * 1), handManager.transform.position.y, this.transform.position.z);
    }

    void UpdateLocation()
    {
        if (!battleSystem.selecting && currentLocation != targetLocation)
        {
            //card going from hand to field
            if (currentLocation.tag == "HandManager" && targetLocation.tag == "GridCell")
            {
                //remove the card from hand list
                var hand = currentLocation.GetComponent<HandManager>().hand;
                hand.Remove(this.gameObject);

                //add that card into the designated grid cell
                var thisCell = targetLocation.GetComponent<GridCell>();
                thisCell.myCard = this.gameObject;
                currentLocation = targetLocation;
            }

            else if (currentLocation.tag == "GridCell" && targetLocation.tag == "HandManager")
            {
                var hand = targetLocation.GetComponent<HandManager>().hand;
                hand.Add(this.gameObject);

                currentLocation.GetComponent<GridCell>().myCard = null;
                currentLocation = targetLocation;
            }

            else if (currentLocation.tag == "GridCell" && targetLocation.tag == "GridCell")
            {
                targetLocation.GetComponent<GridCell>().myCard = this.gameObject;

                currentLocation.GetComponent<GridCell>().myCard = null;
                currentLocation = targetLocation;
            }

            else 
            {
                handManager.GetComponent<HandManager>().hand.Add(this.gameObject);
                currentLocation = handManager;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (battleSystem.selecting && collision.gameObject.layer == 7)
        {
            if (collision.gameObject.tag == "HandManager")
            {
                targetLocation = collision.gameObject;
            }
            
            else if (collision.gameObject.tag == "GridCell")
            {
                targetLocation = collision.gameObject;
            }
        }
    }

    private void OnMouseUp()
    {
        if (!battleSystem.paused)
        {
            selected = false;
            this.transform.position = UtilsClass.GetMouseWorldPosition();
            m_rb.velocity = Vector2.zero;
            m_rb.bodyType = RigidbodyType2D.Static;
            battleSystem.selecting = false;
        }
    }

    private void OnMouseDrag()
    {

    }

    private void OnMouseDown()
    {
        if (!battleSystem.paused)
        {
            if (selected)
            {
                selected = false;
            }

            else
            {
                selected = true;
                m_rb.bodyType = RigidbodyType2D.Dynamic;
                battleSystem.selecting = true;
            }
        }
    }

    public void PlayCard()
    {
        Debug.Log("Do damage or something");
        Destroy(this.gameObject);
    }
}
