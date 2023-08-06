// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
string apiUrl = "http://localhost:5185/";
HttpClient client = new HttpClient();
client.BaseAddress = new Uri(apiUrl);
HttpResponseMessage response = await client.GetAsync("api/Query/startprocess");
Console.WriteLine(response);