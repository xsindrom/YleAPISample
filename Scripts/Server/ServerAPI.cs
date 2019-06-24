using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Utils;

namespace Server
{
    public class ServerAPI : MonoSingleton<ServerAPI>
    {
        private const string CONTENT_TYPE_KEY = "Content-type";
        private const string CONTENT_TYPE_VALUE_APPLICATION_WWW = "application/x-www-form-urlencoded";
        private const string CONTENT_TYPE_VALUE_APPLICATION_JSON = "application/json";
        private const string CONTENT_TYPE_VALUE_TEXT = "text/plain";

        public Task<T2> PostAsync<T1, T2>(T1 request, string method) where T1 : BaseRequest where T2 : BaseResponse, new()
        {
            bool isCompleted = false;
            T2 newResponse = null;

            Action<T2> callback = (response) =>
            {
                newResponse = response;
                isCompleted = true;
            };

            StartCoroutine(PostRoutine(request, callback, method));
            var task = new Task<T2>(() =>
            {
                while (!isCompleted);
                return newResponse;
            });
            task.Start();
            return task;
        }


        public void Post<T1, T2>(T1 request, Action<T2> callback, string method) where T1: BaseRequest where T2 : BaseResponse, new()
        {
            StartCoroutine(PostRoutine(request, callback, method));
        }

        private IEnumerator PostRoutine<T1, T2>(T1 request, Action<T2> callback, string method) where T1:BaseRequest where T2: BaseResponse, new()
        {
            if (request == null)
                yield break;

            var path = request.Path;
            var json = string.Empty;

            if (method == UnityWebRequest.kHttpVerbPOST)
            {
                json = JsonUtility.ToJson(request);
                if (!string.IsNullOrEmpty(json))
                    yield break;
            }

            using (var www = method == UnityWebRequest.kHttpVerbPOST ?
                                       UnityWebRequest.Post(path, json) :
                                       UnityWebRequest.Get(path))
            {
                if (method == UnityWebRequest.kHttpVerbPOST)
                {
                    var data = Encoding.UTF8.GetBytes(json);
                    www.uploadHandler = new UploadHandlerRaw(data);
                }
                www.SetRequestHeader(CONTENT_TYPE_KEY, CONTENT_TYPE_VALUE_TEXT);

                yield return www.SendWebRequest();

                var responseData = www.downloadHandler.text;
                T2 response = null;
                if(!string.IsNullOrEmpty(www.error) || www.isNetworkError)
                {
                    response = new T2() { status = Status.Error };
                    callback?.Invoke(response);
                    yield break;
                }
                response = ((IJsonSerializeObject<T2>)new T2()).FromJson(responseData);
                response.status = (Status)www.responseCode;
                callback?.Invoke(response);
            }
        }

        public void GetImage(string path, Action<Texture2D> callback)
        {
            StartCoroutine(GetImageRoutine(path, callback));
        }

        public IEnumerator GetImageRoutine(string path, Action<Texture2D> callback)
        {
            using (var www = UnityWebRequestTexture.GetTexture(path))
            {
                yield return www.SendWebRequest();

                if (www.isNetworkError || !string.IsNullOrEmpty(www.error))
                {
                    callback?.Invoke(null);
                    yield break;
                }

                DownloadHandlerTexture downloadHandler = (DownloadHandlerTexture)www.downloadHandler;
                if (downloadHandler.isDone)
                {
                    callback?.Invoke(downloadHandler.texture);
                }
            }
        }
    }
}