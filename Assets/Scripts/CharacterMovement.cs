using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GG.Infrastructure.Utils.Swipe;

public class CharacterMovement : MonoBehaviour
{
    #region Varabiles
    [Header("Character Speed")]
    public float speed;
    [Header("Is Walking?")]
    public bool isWalking;

    public Transform player;

    public GameManager gameManager;

    public CharcterAnims charcterAnims;

    [SerializeField]
    private SwipeListener m_swipeListener;


    private Vector3 _characterPostion;
    private Vector3 _characterMidPostion;
    private Vector3 _characterLeftPostion;
    private Vector3 _characterRightPostion;

    private bool _isInMiddle;

    #endregion

    #region Start , Update
    private void Start()
    {
        player = GetComponent<Transform>();
        Time.timeScale = 1;
        _isInMiddle = true; 
        isWalking = true;
        charcterAnims.WalkingAnimation(isWalking);

    }

    #endregion
    private void LateUpdate()
    {
        player.transform.position += player.transform.forward * Time.deltaTime * speed;

        _characterMidPostion = new Vector3(0, player.transform.position.y, player.transform.position.z);
        _characterLeftPostion = new Vector3(-0.5f, player.transform.position.y, player.transform.position.z);
        _characterRightPostion = new Vector3(0.5f, player.transform.position.y, player.transform.position.z);

        //player.transform.position = Vector3.Lerp(player.transform.position, _characterPostion, 3 * Time.deltaTime);
    }

    #region Movement Functions
    private void OnSwipe(string swipe)
    {
        switch (swipe)
        {
            case "Left":
                GoLeft();
                Debug.Log("TEST");
                break;
            case "Right":
                GoRight();
                break;
        }
    }

    private void GoLeft()
    {
        if (_isInMiddle)
        {
            Debug.Log("sağda solda olması lazım");
            _characterPostion = _characterLeftPostion;
            transform.position = Vector3.Lerp(transform.position, _characterPostion, speed * Time.deltaTime);
            _isInMiddle = false;

        }
        else if (_characterPostion == _characterLeftPostion)
        {
            Debug.Log("already in left");
        }
        else
        {
            GoMid();
        }   
    }

    private void GoRight()
    {
        if (_isInMiddle)
        {
            Debug.Log("sağda olması lazım");
            _characterRightPostion = new Vector3(0.5f, transform.position.y,transform.position.z);
            _characterPostion = _characterRightPostion;
            transform.position = Vector3.Lerp(transform.position, _characterPostion, 5 * Time.deltaTime);
            _isInMiddle = false;

        }
        else if (_characterPostion == _characterRightPostion)
        {
            Debug.Log("already in right");
        }
        else
        {
            GoMid();
        }
    }

    private void GoMid()
    {
        Debug.Log("ortada olması lazım");
        _characterMidPostion = new Vector3(0, player.transform.position.y, player.transform.position.z);
        _characterPostion = _characterMidPostion;
        transform.position = Vector3.Lerp(transform.position, _characterPostion, 5 * Time.deltaTime);  
        _isInMiddle = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Trap")
        {
            gameManager.LoseGame();
            charcterAnims.DeadAnimation();
        }

        if (other.gameObject.tag == "Finish")
        {
            gameManager.FinishLevel();
        }
    }
    #endregion

    #region OnEnable , OnDisable
    private void OnEnable()
    {
        m_swipeListener.OnSwipe.AddListener(OnSwipe);
    }

    private void OnDisable()
    {
        m_swipeListener.OnSwipe.RemoveListener(OnSwipe);
    }
    #endregion
}
//void Start()
//{
//    ölümEkranı.SetActive(false);
//    bitişEkranı.SetActive(false);
//    yürüyor = false;
//    orta = true;
//    sağ = false;
//    sol = false;
//    bölümBitti = false;
//}

// Update is called once per frame
//void Update()
//{
//    if (bölümBitti == false)
//    {
//        yürüyor = true;
//    }
//    //klavye kontrolleri
//    if (Input.GetKeyDown(KeyCode.LeftArrow) && orta == true)
//    {
//        sol = true;
//        sağ = false;
//        orta = false;
//    }
//    if (Input.GetKeyDown(KeyCode.RightArrow) && orta == true)
//    {
//        sağ = true;
//        sol = false;
//        orta = false;
//    }
//    if (Input.GetKeyDown(KeyCode.RightArrow) && sol == true)
//    {
//        orta = true;
//        sol = false;
//        sağ = false;
//    }
//    if (Input.GetKeyDown(KeyCode.LeftArrow) && sağ == true)
//    {
//        orta = true;
//        sol = false;
//        sağ = false;
//    }


//    Vector3 left = new Vector3(1f, transform.position.y, transform.position.z);
//    Vector3 right = new Vector3(-1f, transform.position.y, transform.position.z);
//    Vector3 mid = new Vector3(0f, transform.position.y, transform.position.z);

//    if (yürüyor && öldüm == false)
//    {
//        transform.position += transform.forward * Time.deltaTime * hız;
//    }
//    if (Input.touchCount > 0)
//    {
//        Touch parmak = Input.GetTouch(0);
//        if (parmak.deltaPosition.x > 50.0f)
//        {
//            sağ = true;
//            sol = false;
//        }
//    }

//    if (öldüm)
//    {
//        yürüyor = false;
//        ölümEkranı.SetActive(true);
//    }
//    if (bölümBitti && öldüm == false && yürüyor == false)
//    {
//        bitişEkranı.SetActive(true);
//    }


//    if (öldüm == false && sağ)
//    {
//        transform.position = Vector3.Lerp(transform.position, sağa, 5 * Time.deltaTime);
//        //sağ = false;
//    }
//    if (öldüm == false && orta)
//    {
//        transform.position = Vector3.Lerp(transform.position, ortaya, 5 * Time.deltaTime);
//        //orta = false;
//    }

//    if (öldüm == false && sol)
//    {
//        transform.position = Vector3.Lerp(transform.position, sola, 5 * Time.deltaTime);
//        //sol = false;
//    }
//    if (bölümBitti)
//    {
//        StartCoroutine(Final());
//        #region obez final
//        if (kiloAlmaVerme.GetComponent<CharcterWeightController>().KG == 170f)
//        {
//            finalObez = true;
//        }
//        if (kiloAlmaVerme.GetComponent<CharcterWeightController>().KG == 180f)
//        {
//            finalObez = true;
//        }
//        if (kiloAlmaVerme.GetComponent<CharcterWeightController>().KG == 190f)
//        {
//            finalObez = true;
//        }
//        if (kiloAlmaVerme.GetComponent<CharcterWeightController>().KG >= 200f)
//        {
//            finalObez = true;
//        }
//        #endregion
//        #region çok kilolu final



//        if (kiloAlmaVerme.GetComponent<CharcterWeightController>().KG == 160f)
//        {
//            finalCokKilolu = true;
//        }
//        if (kiloAlmaVerme.GetComponent<CharcterWeightController>().KG == 150f)
//        {
//            finalCokKilolu = true;
//        }
//        if (kiloAlmaVerme.GetComponent<CharcterWeightController>().KG == 140f)
//        {
//            finalCokKilolu = true;
//        }
//        if (kiloAlmaVerme.GetComponent<CharcterWeightController>().KG == 130f)
//        {
//            finalCokKilolu = true;
//        }
//        if (kiloAlmaVerme.GetComponent<CharcterWeightController>().KG == 120f)
//        {
//            finalCokKilolu = true;
//        }
//        #endregion
//        #region kilolu final

//        if (kiloAlmaVerme.GetComponent<CharcterWeightController>().KG == 110f)
//        {
//            finalKilolu = true;
//        }
//        if (kiloAlmaVerme.GetComponent<CharcterWeightController>().KG == 100f)
//        {
//            finalKilolu = true;
//        }
//        if (kiloAlmaVerme.GetComponent<CharcterWeightController>().KG == 90f)
//        {
//            finalKilolu = true;
//        }
//        if (kiloAlmaVerme.GetComponent<CharcterWeightController>().KG == 80f)
//        {
//            finalKilolu = true;
//        }
//        #endregion
//        #region haif kilolu final

//        if (kiloAlmaVerme.GetComponent<CharcterWeightController>().KG == 70f)
//        {
//            finalHafifKilo = true;
//        }
//        if (kiloAlmaVerme.GetComponent<CharcterWeightController>().KG == 60f)
//        {
//            finalHafifKilo = true;
//        }
//        if (kiloAlmaVerme.GetComponent<CharcterWeightController>().KG == 50f)
//        {
//            finalHafifKilo = true;
//        }
//        if (kiloAlmaVerme.GetComponent<CharcterWeightController>().KG == 40f)
//        {
//            finalHafifKilo = true;
//        }
//        #endregion
//        #region zayıf final

//        if (kiloAlmaVerme.GetComponent<CharcterWeightController>().KG == 30f)
//        {
//            finalZayıf = true;
//        }
//        if (kiloAlmaVerme.GetComponent<CharcterWeightController>().KG == 20f)
//        {
//            finalZayıf = true;
//        }
//        if (kiloAlmaVerme.GetComponent<CharcterWeightController>().KG == 10f)
//        {
//            finalZayıf = true;
//        }
//        if (kiloAlmaVerme.GetComponent<CharcterWeightController>().KG <= 0f)
//        {
//            finalZayıf = true;
//        }
//        #endregion
//    }
//}


//IEnumerator Final()
//{
//    if (finalObez == true)
//    {
//        yield return new WaitForSeconds(0f);
//        isWalking = false;
//    }
//    if (finalCokKilolu == true)
//    {
//        yield return new WaitForSeconds(2.3f);
//        isWalking = false;
//    }
//    if (finalKilolu == true)
//    {
//        yield return new WaitForSeconds(4f);
//        isWalking = false;
//    }
//    if (finalHafifKilo == true)
//    {
//        yield return new WaitForSeconds(5.5f);
//        isWalking = false;
//    }
//    if (finalZayıf == true)
//    {
//        yield return new WaitForSeconds(6.3f);
//        isWalking = false;
//    }