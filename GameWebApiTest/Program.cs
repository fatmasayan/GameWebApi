// See https://aka.ms/new-console-template for more information
using GameWebApiTest.Sevices;

class Program
{
    static async Task Main(string[] args)
    {
        ClientService clientService = new ClientService();

        var responseList = await clientService.SendClientAPI();
        await clientService.WriteResponseTimesToExcel(responseList);

    }
}

//
