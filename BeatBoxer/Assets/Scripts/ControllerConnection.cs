using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class ControllerConnection : MonoBehaviour
{
    PlayerControls control1;
    //PlayerControls control2;

    public GameObject panel;
    public Text p1Check;
    //public Text p2Check;

    public GameObject player1;
    //public GameObject player2;

    Vector2 move1;
    //Vector2 move2;
    Vector2 rot1;
    //Vector2 rot2;

    // Start is called before the first frame update
    void Awake()
    {
        control1 = new PlayerControls();
        //control2 = new PlayerControls();

        var user1 = InputUser.PerformPairingWithDevice(InputSystem.GetDevice("DualShock4GamepadHID"));
        //var user2 = InputUser.PerformPairingWithDevice(InputSystem.GetDevice("DualShock4GamepadHID1"));

        user1.AssociateActionsWithUser(control1);
        //user2.AssociateActionsWithUser(control2);

        control1.Menu.Select.performed += ctx => Select(p1Check);
        //control2.Menu.Select.performed += ctx => Select(p2Check);
    }

    // Update is called once per frame
    void Update()
    {
        if (p1Check.text == "OK" && panel.activeSelf) // && p2Check.text == "OK"
        {
            panel.SetActive(false);
            control1.Menu.Disable();
            //control2.Menu.Disable();

            control1.Gameplay.Enable();
            //control2.Gameplay.Enable();

            control1.Gameplay.Move.performed += ctx => move1 = ctx.ReadValue<Vector2>();
            control1.Gameplay.Move.canceled += ctx => move1 = Vector2.zero;
            //control2.Gameplay.Move.performed += ctx => move2 = ctx.ReadValue<Vector2>();
            //control2.Gameplay.Move.canceled += ctx => move2 = Vector2.zero;

            control1.Gameplay.Rotate.performed += ctx => rot1 = ctx.ReadValue<Vector2>();
            //control2.Gameplay.Rotate.performed += ctx => rot2 = ctx.ReadValue<Vector2>();

            control1.Gameplay.Dash.performed += ctx => Dash(player1, move1);
            //control2.Gameplay.Dash.performed += ctx => Dash(player2, move2);

            control1.Gameplay.Attack1.performed += ctx => Attack1(player1);
            //control2.Gameplay.Attack1.performed += ctx => Attack1(player2);

            control1.Gameplay.Attack2.performed += ctx => Attack2(player1);
            //control2.Gameplay.Attack2.performed += ctx => Attack2(player2);

            control1.Gameplay.Ultimate.performed += ctx => Ultimate(player1);
            //control2.Gameplay.Ultimate.performed += ctx => Ultimate(player2);
        }
        else if (!panel.activeSelf)
        {
            Vector3 m1 = new Vector3(move1.x, 0, move1.y) * Time.deltaTime * 8;
            //Vector3 m2 = new Vector3(move2.x, 0, move2.y) * Time.deltaTime * 8;
            player1.transform.Translate(m1, Space.World);
            //player2.transform.Translate(m2, Space.World);

            Vector3 r1 = new Vector3(player1.transform.position.x + rot1.x, 1, player1.transform.position.z + rot1.y);
            //Vector3 r2 = new Vector3(player2.transform.position.x + rot2.x, 1, player2.transform.position.z + rot2.y);
            player1.transform.LookAt(r1, Vector3.up);
            //player2.transform.LookAt(r2, Vector3.up);
        }
    }

    void Select(Text t)
    {
        t.text = "OK";
    }

    void Dash(GameObject player, Vector2 move)
    {
        Vector3 m = new Vector3(move.x * 4, 0, move.y * 4) * Time.deltaTime * 6;
        player.transform.Translate(m, Space.World);
    }

    void Attack1(GameObject player)
    {
        player.GetComponent<Player>().shootMyBullet(player.GetComponent<Player>().Meshs[0]);
    }

    void Attack2(GameObject player)
    {
        player.GetComponent<Player>().shootMyBullet(player.GetComponent<Player>().Meshs[1]);
    }

    void Ultimate(GameObject player)
    {

    }

    private void OnEnable()
    {
        control1.Menu.Enable();
        //control2.Menu.Enable();
    }

    private void OnDisable()
    {
        control1.Gameplay.Disable();
        //control2.Gameplay.Disable();
    }
}
