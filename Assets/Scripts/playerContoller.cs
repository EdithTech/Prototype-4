using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerContoller : MonoBehaviour
{
    [SerializeField] GameObject _focalPoint;
    [SerializeField] GameObject _powerUpIndicator;

    [SerializeField] float _forwardForce;
    [SerializeField] float _powerUpStrenth = 15f; 

    [SerializeField] bool _hasPoweUp = false; 
    Rigidbody _playerRB;

    // Start is called before the first frame update
    void Start()
    {
        _playerRB = GetComponent<Rigidbody>();
        // _focalPoint = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        _playerRB.AddForce(_focalPoint.transform.forward * verticalInput * _forwardForce);

        _powerUpIndicator.transform.position = transform.position +  new Vector3(0f, -0.2f, 0f);
        
    }

    void OnTriggerEnter(Collider other){
        // Debug.Log(other);
        if(other.gameObject.CompareTag("PowerUp")){
            _hasPoweUp = true;
            _powerUpIndicator.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(startPowerUp());
        }
    }

    void OnCollisionEnter(Collision other){
        // Debug.Log(other);
        if(other.gameObject.CompareTag("Enemy") && _hasPoweUp){
            Vector3 awayFromPlayer = other.gameObject.transform.position - this.transform.position;
            Rigidbody enemy = other.gameObject.GetComponent<Rigidbody>();

            enemy.AddForce(awayFromPlayer * _powerUpStrenth, ForceMode.Impulse);
            Debug.Log(other.gameObject.name);
        }
    }

    IEnumerator startPowerUp(){
        yield return new WaitForSeconds(5f);
        _hasPoweUp = false;
        _powerUpIndicator.SetActive(false);
    }
}
