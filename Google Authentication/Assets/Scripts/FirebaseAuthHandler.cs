using Proyecto26;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirebaseAuthHandler 
{
    private const string API_KEY = "AIzaSyAnZrrvN0ywbDIvA9owDOGLvW0Wal1M6_M";

    public static void SignInWithToken(string token, string providerId)
    {
        Debug.Log("step 3");
        string payLoad = $"{{\"postBody\":\"id_token ={token} & providerId ={providerId}\",\"requestUri\":\"http://localhost\",\"returnIdpCredential\":true,\"returnSecureToken\":true}}";

        string requestUrl = $"https://identitytoolkit.googleapis.com/v1/accounts:signInWithIdp" +
                            $"?key={API_KEY}";

        RestClient.Post(requestUrl, payLoad)
            .Then( response =>
            {
                Debug.Log("step 4");
                Debug.Log(response.Text);
            });
            
    }
}
