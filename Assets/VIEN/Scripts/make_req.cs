using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

class make_req
{

    //private List<float> _x = new List<float>();
    float[] _x;
    float[] _y;
    float X;
    float Y;
    //private List<float> _y = new List<float>();
    //private List<float> _t = new List<float>();


    private string _response;

    public make_req(RawCoordinates coordinates)
    {
        _x = coordinates.X;
        _y = coordinates.Y;
    }

    public bool MyRemoteCertificateValidationCallback(System.Object sender,
    X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
        bool isOk = true;
        // If there are errors in the certificate chain,
        // look at each error to determine the cause.
        if (sslPolicyErrors != SslPolicyErrors.None)
        {
            for (int i = 0; i < chain.ChainStatus.Length; i++)
            {
                if (chain.ChainStatus[i].Status == X509ChainStatusFlags.RevocationStatusUnknown)
                {
                    continue;
                }
                chain.ChainPolicy.RevocationFlag = X509RevocationFlag.EntireChain;
                chain.ChainPolicy.RevocationMode = X509RevocationMode.Online;
                chain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 1, 0);
                chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllFlags;
                bool chainIsValid = chain.Build((X509Certificate2)certificate);
                if (!chainIsValid)
                {
                    isOk = false;
                    break;
                }
            }
        }
        return isOk;
    }


    public void Req()
    {
        ServicePointManager.ServerCertificateValidationCallback = MyRemoteCertificateValidationCallback;

        var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://inputtools.google.com/request?ime=handwriting&app=quickdraw&dbg=1&cs=1&oe=UTF-8");
        httpWebRequest.ContentType = "application/json";
        httpWebRequest.Method = "POST";

        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        {
            string json = @"{

    ""input_type"": 0,
	""requests"": [{
		""language"": ""quickdraw"",
		""writing_guide"": {
			""width"": 1536,
			""height"": 358

        },
		""ink"": [

            [[";
            foreach (float x in _x)
            {
                /*   X = x;
                   if (X < 0)
                       X = x * -1;
                   json += X*100;
                  */
                json += x;
                json += ",";
            }
            json = json.Remove(json.LastIndexOf(","), 1);
            json += "],[";

            foreach (float y in _y)
            {
                /*    Y = y;
                    if (Y < 0)
                        Y = y * -1;
                    json += Y*100;
                */
                json += Y;
                json += ",";
            }
            json = json.Remove(json.LastIndexOf(","), 1);
            json += "],[";

            foreach (float y in _y)
            {
                int i = 0;
                json += i;
                json += ",";
                i++;
            }
            json = json.Remove(json.LastIndexOf(","), 1);
            json += "]";

            json += @"
 
			]
		]
	}]
}";

            streamWriter.Write(json);
            streamWriter.Flush();
            streamWriter.Close();
        }

        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            List<string> searchobjects = new List<string> { "line", "house", "car", "triangle" };
            string resp = streamReader.ReadToEnd();

            bool found = false;
            string element="";
            foreach (string a in searchobjects)
            {

                if (resp.IndexOf(a) != -1)
                {
                    found = true;
                    element = a;
                    break;
                }

            }
            if (found)
            {
                Debug.Log(element + " found");
            }
            else
            {
                Debug.Log(resp);
            }

        }
    }
}
