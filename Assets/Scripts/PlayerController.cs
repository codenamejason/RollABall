using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed;

    public Text countText;

    public Text winText;

    private Rigidbody rb;
    // variable to store collectible count
    private int count;


    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        // Set value to 0, Unity editor will not have access to this variable
        count = 0;
        SetCountText();
        winText.text = "";
    }

    // Update is called once per frame
    void Update ()
    {

    }

    void SetCountText()
    {
        // Display the count of collected items
        countText.text = "Collected: " + count.ToString();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"));
        {
            other.gameObject.SetActive(false);
            // increment count for each collectible collected
            count = count + 1;
            // Display the count of collected items
            SetCountText();

            if(count >= 8)
            {
                winText.text = "You Win!";
            }
        }
    }
}