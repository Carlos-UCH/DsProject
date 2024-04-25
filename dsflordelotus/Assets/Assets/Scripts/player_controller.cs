using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    
    private Rigidbody2D _playerRigidbody2D;
    public float _playerSpeed;
    private Animator _playerAnimator;

    private float _playerInitialSpeed;

    public float _playerRunSpeed;

    private Vector2 _playerDirection;

    private bool _isAttack = false;

    void Start()
    {
        _playerRigidbody2D = GetComponent<Rigidbody2D>();

        _playerAnimator = GetComponent<Animator>(); 

        _playerInitialSpeed = _playerSpeed;

    } 

    // Update is called once per frame
    void Update()
    {
    
        _playerDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (_playerDirection.sqrMagnitude > 0)
        {

            _playerAnimator.SetInteger("Movement", direction());

        }
        else
         {

            _playerAnimator.SetInteger("Movement",0);

        }

        playerRun();

        OnAttack();

        if(_isAttack){
            _playerAnimator.SetInteger("Movement",6);
        }
    
    }

    void FixedUpdate()
    {
        _playerRigidbody2D.MovePosition(_playerRigidbody2D.position + _playerDirection * _playerSpeed * Time.fixedDeltaTime);

    }


    int direction()
    {
            if (_playerDirection.x > 0)
            {
                return 1;
            }
            else if (_playerDirection.x < 0)
            {
                return 2;
            }     
            else if (_playerDirection.y > 0)
            {
                return 3;
            }
            else if (_playerDirection.y < 0)
            {
               return 4;
            }
        
        return 0;
    }


    void playerRun(){

        if (Input.GetKeyDown(KeyCode.LeftShift)){

            _playerSpeed = _playerRunSpeed;

        }

        if (Input.GetKeyUp(KeyCode.LeftShift)){

            _playerSpeed = _playerInitialSpeed;

        }

    }

    void OnAttack(){
        if(Input.GetKeyDown(KeyCode.E)){
            _isAttack = true; 
            _playerSpeed = 0;
        }

        if(Input.GetKeyUp(KeyCode.E)){
            _isAttack = false; 
            _playerSpeed = _playerInitialSpeed;
        }
    }


}


