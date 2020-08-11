using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class Playfab_Auth : MonoBehaviour
{
    public MP_Manager mp;
    LoginWithPlayFabRequest loginRequest;

    public InputField User;
    public InputField Pass;
    public InputField Email;
    public bool isAuthenticated;
    public Text message;
    //public GameObject LoginUI;
    // Start is called before the first frame update
    void Start()
    {
        Email.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Login()
    {
        loginRequest = new LoginWithPlayFabRequest();
        loginRequest.Username = User.text;
        loginRequest.Password = Pass.text;
        PlayFabClientAPI.LoginWithPlayFab(loginRequest, result => {
            //If account is found
            message.text = "Welcome!" + User.text + ",  Connecting..." ;
            isAuthenticated = true;
            mp.connectToMaster();
            Debug.Log("You are now logged in!!");
        } , error => {
            //If account is not found
            message.text = "Failed to Login[" + error.ErrorMessage + "]";
            isAuthenticated = false;
            Email.gameObject.SetActive(true);
            Debug.Log(error.ErrorMessage);
        }, null);
    }
    public void Register()
    {
        RegisterPlayFabUserRequest request = new RegisterPlayFabUserRequest();
        request.Email =  Email.text;
        request.Username = User.text;
        request.Password = Pass.text;
        PlayFabClientAPI.RegisterPlayFabUser(request, result => {
            message.text = "Your account has been created!" ;
        }, error => {
            message.text = "Failed to create your account [" + error.ErrorMessage + "]"; 
        });
    } 
}