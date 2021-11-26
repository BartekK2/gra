using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    [Range(5.0f, 15.0f)]
    public float speed = 5.0f;
    public float cameraSpeed = 300.0f;
    public float jumpForce = 300.0f;

    private float actualSpeed;

    public Camera m_MainCamera;
    new Rigidbody rigidbody;

    public bool isgrounded = true;

    private Vector3 wczesniejsza_pozycja;


    // Start is called before the first frame update
    void Awake()
    {
        m_MainCamera = Camera.main;
        actualSpeed = speed;
        rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        m_MainCamera.transform.localEulerAngles = Vector3.zero;
        m_MainCamera.transform.rotation = Quaternion.identity;
        wczesniejsza_pozycja = m_MainCamera.transform.localPosition;
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, (float)1.0);
    }

    void LimitCamera(int min = 60, int max = 320)
    {
        // LIMIT OBROTU KAMERY NA WYSOKOŚĆ
        // **Bug do naprawy** czasami nie wiadomo czemu do lokalnej rotacji dodaje sie 120 XD
        Vector3 rot = m_MainCamera.transform.eulerAngles;
        // print(rot.x);
        if (rot.x > min && rot.x < 180)
            m_MainCamera.transform.rotation = Quaternion.Euler(min, rot.y, rot.z);
        if (rot.x < max && rot.x > 180)
            m_MainCamera.transform.rotation = Quaternion.Euler(max, rot.y, rot.z);
        if (rot.x < 0)
            m_MainCamera.transform.rotation = Quaternion.Euler(min, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        isgrounded = IsGrounded();

        if ((horizontal != 0 || vertical != 0) && GetComponent<AudioSource>().isPlaying == false)
        {
            GetComponent<AudioSource>().Play();
        }
        if (horizontal == 0 && vertical == 0)
        {
            GetComponent<AudioSource>().Stop();
        }

        //Poruszanie sie
        transform.position += vertical * transform.forward * actualSpeed * Time.deltaTime;
        transform.position += horizontal * transform.right * actualSpeed * Time.deltaTime;

        //Obróć gracza w osi szerokości

        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * cameraSpeed * Time.deltaTime);

        // Obróć kamere w osi wysokości
        if (Input.GetAxis("Mouse Y") < 5 && Input.GetAxis("Mouse Y") > -5) // Przy szybkich ruchach myszki sie jakiś syf dzieje xD
            m_MainCamera.transform.Rotate(-Vector3.right * Input.GetAxis("Mouse Y") * cameraSpeed * Time.deltaTime);

        LimitCamera(60, 320);

        // SKAKANIE
        if (Input.GetKeyDown("space") && isgrounded)
        {
            rigidbody.AddForce(Vector3.up * jumpForce);
        }

        // BIEGANIE
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            actualSpeed = speed * 6f;
            GetComponent<AudioSource>().pitch = 1.5f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            actualSpeed = speed;
            GetComponent<AudioSource>().pitch = 1f;
        }

        // KUCANIE
        if (Input.GetKeyDown(KeyCode.LeftControl) && !Input.GetKey(KeyCode.LeftShift))
        {
            actualSpeed = speed * 0.5f;
            GetComponent<BoxCollider>().size = new Vector3(1, 0.6f, 1);
            m_MainCamera.transform.localPosition = new Vector3(wczesniejsza_pozycja.x, wczesniejsza_pozycja.y - 0.4f, wczesniejsza_pozycja.z);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl) || (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey(KeyCode.LeftControl)))
        {
            actualSpeed = speed;
            m_MainCamera.transform.localPosition = wczesniejsza_pozycja;
            GetComponent<BoxCollider>().size = new Vector3(1, 1, 1);

        }


    }
}
