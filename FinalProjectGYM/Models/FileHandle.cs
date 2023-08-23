using FinalProjectGYM.Models.ClientModel;
using Newtonsoft.Json;
using System;

public static class FileHandle
{
    const string CLIENTFOLDER = "Clients"; 
    const string TRAINERFOLDER = "Coach";

    const string CLIENTFILENAME = "Data.txt";
    const string TRAINERFILENAME = "Data.txt";
    public static void ClientAdd(Client client)//add client to the folder data base
    {
        string clientFolderPath = Path.Combine(CLIENTFOLDER, client.Id);

        TryToCreateFolder(clientFolderPath);
        string ClientFilePath = Path.Combine(clientFolderPath, CLIENTFILENAME);
        string json = JsonConvert.SerializeObject(client);
        File.WriteAllText(ClientFilePath, json);
    }

    private static void TryToCreateFolder(string clientFolderPath)//check if the folder exist
    {
        if (!Directory.Exists(clientFolderPath))
        {
            Directory.CreateDirectory(clientFolderPath);
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
            ClientAdd(client);
        }
    }

    public static Client[] ClientListCreate()//create list of client modify it(remove all inActive clients) and return the active
    {
        string clientFolderPath = Path.Combine(CLIENTFOLDER);
        string[] allClientPatchs = Directory.GetDirectories(clientFolderPath);
        Client[] clients = new Client[allClientPatchs.Length];

        for (int i = 0; i < allClientPatchs.Length; i++) 
        {
            string[] files = Directory.GetFiles(allClientPatchs[i]);
            string json = File.ReadAllText(files[0]);
            Client client = JsonConvert.DeserializeObject<Client>(json);
            clients[i] = client;
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

    public static bool IsClientExist(string id)
    {
        string clientFolderPath = Path.Combine(CLIENTFOLDER, id);

        return Directory.Exists(clientFolderPath);
    }

    public static void ClientUpdateIdChanged(Client client, string id)
    {
        string clientFolderPath = Path.Combine(CLIENTFOLDER, id);
        File.Delete(clientFolderPath);
        ClientAdd(client);
    }

    public static Client GetClientById(string id)
    {
        string clientFolderPath = Path.Combine(CLIENTFOLDER, id);
        string ClientFilePath = Path.Combine(clientFolderPath, CLIENTFILENAME);
        string json = File.ReadAllText(ClientFilePath);
        Client client = JsonConvert.DeserializeObject<Client>(json);

        return client;
    }
}
