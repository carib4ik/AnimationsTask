using UnityEngine;

public class InputController : MonoBehaviour
{
    private Animator _animator;
    private float _speed;
    private float _strafeSpeed;
    
    private static readonly int Speed = Animator.StringToHash("speed");
    private static readonly int Jump = Animator.StringToHash("jump");
    private static readonly int StrafeSpeed = Animator.StringToHash("strafeSpeed");
    private static readonly int Attack = Animator.StringToHash("attack");

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetFloat(Speed, _speed);
        _animator.SetFloat(StrafeSpeed, _strafeSpeed);
        _animator.SetInteger(Attack, 0);

        ControlCharacter();
    }

    private void ControlCharacter()
    {
        MoveForward();
        MoveBackward();
        MoveRight();
        MoveLeft();
        Jumping();
        Fight();
    }
    
    private void MoveForward()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _speed = 1;
        }
        
        if (Input.GetKeyUp(KeyCode.W))
        {
            _speed = 0;
        }
    }

    private void MoveBackward()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            _speed = -1;
        }
        
        if (Input.GetKeyUp(KeyCode.S))
        {
            _speed = 0;
        }
    }
    
    private void MoveRight()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            _strafeSpeed = 1;
        }
        
        if (Input.GetKeyUp(KeyCode.D))
        {
            _strafeSpeed = 0;
        }
    }
    
    private void MoveLeft()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _strafeSpeed = -1;
        }
        
        if (Input.GetKeyUp(KeyCode.A))
        {
            _strafeSpeed = 0;
        }
    }

    private void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetTrigger(Jump);
        }
    }

    private void Fight()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            var number = Random.Range(1, 3);
            
            _animator.SetInteger(Attack, number);
        }
    }
}