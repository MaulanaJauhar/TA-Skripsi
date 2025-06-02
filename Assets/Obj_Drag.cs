using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class Obj_Drag : MonoBehaviour
{

    [HideInInspector]public Vector2 SavePosisi;
    [HideInInspector]public bool isAtasObj;

    Transform saveObj;

    public int ID;
    public Text Teks;
    [Space]

    public UnityEvent onDragBenar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SavePosisi = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        
    }
    private void OnMouseUp()
    {
        if (isAtasObj)
        {
            int ID_tempatdrop = saveObj.GetComponent<Id_Drop>().ID;

            if (ID == ID_tempatdrop)
            {
                transform.SetParent(saveObj);
                transform.localPosition = Vector3.zero;
                transform.localScale = new Vector2(1f, 1f);
                saveObj.GetComponent<SpriteRenderer>().enabled = false;

                saveObj.GetComponent<Rigidbody2D>().simulated = false;
                saveObj.GetComponent<BoxCollider2D>().enabled = false;

                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                onDragBenar.Invoke();

                GameSystem.instance.DataSekarang++;
                Data.DataSkor += 100;

            }
            else
            {
                transform.position = SavePosisi;
                Data.DataDarah --;
            }
        }
        else
        {
            transform.position = SavePosisi;
        }


    }
    public void OnMouseDrag()
    {
        if (!GameSystem.instance.GameSelesai)
        {
        Vector2 Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Pos;  
        }
    }
    private void OnTriggerStay2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("Drop")) 
        {
            isAtasObj = true;
            saveObj = trig.gameObject.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("Drop"))
        {
            isAtasObj = false;
        }
    }
}