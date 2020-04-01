using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{

    [SerializeField] InputField code;

    public void OnClickGetGoogleCode()
    {
        GoogleAuthHandler.GetUserCode();
    }


    public void OnClickSignInGoogle()
    {
        Debug.Log("Code: " + code.text);

        GoogleAuthHandler.ExchangeAuthCodeWithIDToken(code.text, id_token =>
        {
            Debug.Log("id_token: " + id_token);

            FirebaseAuthHandler.SignInWithToken(id_token, "google.com");
        });
    }
}
