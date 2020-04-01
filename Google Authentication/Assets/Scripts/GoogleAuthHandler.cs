using Proyecto26;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GoogleAuthHandler
{
    private static string ClientId = "312862448567-a4mnajrhoh0dm6miivj78nn8qr9n0ee5.apps.googleusercontent.com";
    private static string ClientSecret = "BBa7o8481QEtSEV03Dz1IyKr";

    public static void GetUserCode()
    {
        string requestUrl = $"https://accounts.google.com/o/oauth2/v2/auth" +
                            $"?client_id={ClientId}" +
                            $"&redirect_uri=urn:ietf:wg:oauth:2.0:oob" +
                            $"&response_type=code" +
                            $"&scope=email";

        Application.OpenURL(requestUrl);
    }

    public static void ExchangeAuthCodeWithIDToken(string code, Action<string> callback)
    {
        Debug.Log("step 1");
        string requestUrl = $"https://oauth2.googleapis.com/token" +
                            $"?client_id={ClientId}" +
                            $"&client_secret={ClientSecret}" +
                            $"&code={code}" +
                            $"&grant_type=authorization_code" +
                            $"&redirect_uri=urn:ietf:wg:oauth:2.0:oob";

        RestClient.Post(requestUrl , null)
            .Then(
                onResolved: response =>
                {
                    Debug.Log("step 2");
                    var data = StringSerializationAPI.Deserialize(typeof(GoogleIDToken), response.Text) as GoogleIDToken;
                    callback(data.id_token);
                });
    }
}
