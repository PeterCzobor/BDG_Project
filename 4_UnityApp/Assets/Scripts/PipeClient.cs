using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using System.IO;
using UnityEngine;
using System.Threading.Tasks;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class PipeClient
{
    static string message = string.Empty;

    public static bool running = false;

    static string serverPath = "";

    public static void StartClient()
    {
        if(!running)
        {
#if UNITY_EDITOR
            serverPath = @"C:\Users\czobo\Desktop\boardgame\Debug\net6.0\";
#else
        string directory = AppDomain.CurrentDomain.BaseDirectory;
        serverPath = Path.Combine(directory, @"Release\net6.0");
#endif
            serverPath = Path.Combine(serverPath, "server.exe");
            Process.Start(serverPath);

            Task.Run(() => ConnectToPipeServerAsync());
            running = true;
        }
    }

    public static void SendMessageToServer(string msg)
    {
        message = msg;
    }

    static List<string> received = new List<string>();
    public static bool messageGot = false;
    public static List<string> GetMessageFromServer()
    {
        messageGot = false;
        return received;
    }

    public static void ShutDown()
    {
        message = "shutdown";
    }

    static async Task ConnectToPipeServerAsync()
    {
        try
        {
            using (NamedPipeClientStream pipeClient = new NamedPipeClientStream(".", "UnityPipe", PipeDirection.InOut))
            {
                Debug.Log("Client attempting to connect...");
                pipeClient.Connect();
                Debug.Log("Connected!");
                using (StreamReader reader = new StreamReader(pipeClient))
                using (StreamWriter writer = new StreamWriter(pipeClient) { AutoFlush = true })
                {
                    while (running)
                    {
                        if (message != string.Empty)
                        {
                            await writer.WriteLineAsync(message);
                            if(message == "shutdown")
                            {
                                running = false;
                                break;
                            }

                            received.Clear();
                            string line;
                            while ((line = await reader.ReadLineAsync()) != "END")
                                received.Add(line);
                            messageGot = true;
                            message = string.Empty;
                        }
                    }
                    Debug.Log("Shutdown client...");
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Pipe connection error: " + e.Message);
        }
    }

}
