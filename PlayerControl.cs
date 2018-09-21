using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    public float speed;
    public Text countText;
    public Text pickupCountText;
    public Text winText;
    private int count;
    private int pickupCount;
    private Rigidbody rb;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        pickupCount = 0;
        SetCountText();

        winText.text = "";
        
    }

        void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }
    void OnTriggerEnter (Collider other)
    {
      if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            pickupCount = pickupCount + 1;
            //pickupCount++;
            SetCountText ();
        } 
    
      if (other.gameObject.CompareTag("RedPickUp"))
        {
            other.gameObject.SetActive(false);
            count = count - 1;
            //pickupCount++;
            SetCountText();
        }
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        pickupCountText.text = "Total: " + pickupCount.ToString();

        if (pickupCount >= 12)
        {
            winText.text = "You Finished with score "+ countText.text;
        }
    }
}
//pickupCountText.text = "Total: " + pickupCount.ToString();
//pickupCountText.text = "Total:";