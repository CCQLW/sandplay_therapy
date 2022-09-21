using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController characterController;
    public AnimatorController animatorController;

    public float rotateSpeed = 180f;//旋转速度

    [Range(1,2)]
    public float rotateSensitivity = 1;//旋转灵敏度
    public Transform playerTransform;
    public Transform cameraTransform;
    private float rotateOffset;//垂直方向偏移量

    private float horizontalVal;
    private float verticalVal;
    private float verticalSpeed = 0f;
   /*
    落地检测（发射胶囊碰撞体检测）
    */
    public CapsuleCollider capsuleCollider;
    private Vector3 point1;
    private Vector3 point2;
    private float radius;

    public float health;

    void Awake()
    {
        radius = capsuleCollider.radius;
    }

    public bool isGround;

    public float moveSpeed = 5f;//运动速度
    public float maxSpeed  = 10f;
    public float velocity = 0f;//跳跃速度
    public float maxHeight = 2f;//跳跃最大高度
    public float gravity = -20f;//重力加速度

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveController();
        PlayerRotateController();
        PlayerAnimator();
    }

    void PlayerRotateController()
    {
        if(playerTransform == null || cameraTransform == null)return;
        float offset_x = Input.GetAxis("Mouse X");
        float offset_y = Input.GetAxis("Mouse Y");
        playerTransform.Rotate(Vector3.up * rotateSpeed * rotateSensitivity * Time.deltaTime * offset_x);
        rotateOffset -= offset_y * rotateSpeed * rotateSensitivity * Time.deltaTime;
        rotateOffset = Mathf.Clamp(rotateOffset, -30f, 30f);
        Quaternion cameraQua = Quaternion.Euler(new Vector3(rotateOffset, cameraTransform.localEulerAngles.y, cameraTransform.localEulerAngles.z));
        cameraTransform.localRotation = cameraQua;
    }
    void PlayerMoveController()
    {
        if(characterController == null)return;
        Vector3 MoveValue = Vector3.zero;
        horizontalVal = Input.GetAxis("Horizontal");//AD
        verticalVal = Input.GetAxis("Vertical");//WS

        MoveValue += transform.forward * (Time.deltaTime * Time.deltaTime + verticalSpeed *moveSpeed * 2.0f * Time.deltaTime) * 0.5f;
        MoveValue += transform.right * moveSpeed * Time.deltaTime * horizontalVal;
        
        verticalSpeed += verticalVal * Time.deltaTime;
        if(Mathf.Abs(verticalVal) < 0.01f)verticalSpeed = 0f;
        if(verticalSpeed * moveSpeed > maxSpeed)verticalSpeed = maxSpeed / moveSpeed;
        if(verticalSpeed * moveSpeed < maxSpeed * -1.0f)verticalSpeed = - 1.0f * maxSpeed / moveSpeed;
        
        velocity += gravity * Time.deltaTime;
        if(IsGround() && velocity <= 0)
        {
            isGround = true;
            velocity = 0;
            animatorController.setBool("Jump", false);
        }
        if(isGround == true)
        {
            if(Input.GetButtonDown("Jump"))
            {
                animatorController.setBool("Jump", true);
                isGround = false;
                velocity = Mathf.Sqrt(-2 * gravity * maxHeight);
            }
        }
        MoveValue += Vector3.up * velocity * Time.deltaTime;
        characterController.Move(MoveValue);
    }

    bool IsGround()
    {
        point1 = transform.position + transform.up * (radius);
        point2 = transform.position + transform.up * (capsuleCollider.height - radius);
        Collider[] colliders = Physics.OverlapCapsule(point1, point2, radius, LayerMask.GetMask("Ground"));
        if(colliders.Length >=1)return true;
        return false;
    }

    void PlayerAnimator()
    {
        if(Input.GetKey(KeyCode.S))animatorController.setBool("backWalk", true);
        else animatorController.setBool("backWalk", false);
        if(Input.GetKey(KeyCode.A))animatorController.setBool("leftWalk", true);
        else animatorController.setBool("leftWalk", false);
        if(Input.GetKey(KeyCode.D))animatorController.setBool("rightWalk", true);
        else animatorController.setBool("rightWalk", false);
        if(Input.GetKey(KeyCode.E))animatorController.setBool("defend", true);
        else animatorController.setBool("defend", false);
        if(Input.GetKey(KeyCode.W))
        {
            animatorController.setBool("forword", true);
            float val = verticalSpeed;
            if(val > 1f)val = 1f;
            animatorController.setFloat("speed", val);
        }
        else animatorController.setBool("forword", false);
    }
    
}
