﻿using FinalProjectGYM.Models.ClientModel;
using Newtonsoft.Json;
using System;

public static class FileHandle
{
    const string CLIENTFOLDER = "Clients"; 
    const string TRAINERFOLDER = "Coach";

    const string CLIENTFILENAME = "Data.txt";
    const string TRAINERFILENAME = "Data.txt";
    public static void ClientAdd(Client client, bool isAddingFirstTime)//add client to the folder data base
    {
        string clientFolderPath = Path.Combine(CLIENTFOLDER, client.Id);

        if (TryToCreateFolder(clientFolderPath) || !isAddingFirstTime) 
        {
            string ClientFilePath = Path.Combine(clientFolderPath, CLIENTFILENAME);
            string json = JsonConvert.SerializeObject(client);
            File.WriteAllText(ClientFilePath, json);
        }
        else
        {
            Console.WriteLine("This client exist in the system !!!");
            Console.WriteLine("You can change the info in the edit tab ");
        }
    }

    private static bool TryToCreateFolder(string clientFolderPath)//check if the folder exist
    {
        if (!Directory.Exists(clientFolderPath))
        {
            Directory.CreateDirectory(clientFolderPath);
            return true;
        }
        else 
        { 
            return false;
        }
    }

    public static void ClientRemove(string id)//set the activ of the client to false
    {
        string clientFolderPath = Path.Combine(CLIENTFOLDER, id);
        if (Directory.Exists(clientFolderPath))
        {
            string ClientFilePath = Path.Combine(clientFolderPath, CLIENTFILENAME);
            string json = File.ReadAllText(ClientFilePath);
            Client client = JsonConvert.DeserializeObject<Client>(json);
            client.IsActive = false;
            ClientAdd(client, false);
        }
    }

    public static Client[] ClientListCreate()//create list of client modify it(remove all inActive clients) and return the active
    {
        string[] allClientPatchs = Directory.GetDirectories(CLIENTFOLDER);
        Client[] clients = new Client[allClientPatchs.Length];
        int index = 0;

        for (int i = 0; i < allClientPatchs.Length; i++) 
        {
            string[] files = Directory.GetFiles(allClientPatchs[i]);
            string json = File.ReadAllText(files[0]);
            Client client = JsonConvert.DeserializeObject<Client>(json);
            clients[index] = client;
        }

        return DeleteNonActiveClients(clients);
    }

    private static Client[] DeleteNonActiveClients(Client[]clients)//remove all inActive clients
    {
        int sizeOfActiveClients = 0;

        foreach (Client client in clients)
        {
            sizeOfActiveClients += client.IsActive ? 1 : 0;
        }

        Client[] activeClient = new Client[sizeOfActiveClients];
        int index = 0;

        for(int i = 0; i < clients.Length; i++)
        {
            if (clients[i].IsActive)
            {
                activeClient[index] = clients[i];
                index++;
            }
        }

        return activeClient;
    }
}