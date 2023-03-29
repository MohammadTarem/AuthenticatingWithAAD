using Microsoft.Identity.Client;
using System.Net.Http.Headers;
var clientId = "00000000-0000-0000-0000-000000000000";
var clientSecret = "sgQ8Q~zPAzLBSgaPIjn3Z~c2F7.Fi1KiiFClJcTk";
var tenantId = "11111111-1111-1111-1111-111111111111";
             

var app = ConfidentialClientApplicationBuilder.Create(clientId)
                                              .WithClientSecret(clientSecret)
                                              .WithTenantId(tenantId)
                                              .Build();


string[] scopes = { "api://22222222-2222-2222-2222-222222222222/.default" };

var token = await app.AcquireTokenForClient(scopes).ExecuteAsync();

HttpClient client = new HttpClient();
client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
Console.WriteLine(token.AccessToken);
var result = await client.GetAsync("https://localhost:5000/data");

Console.WriteLine($"The status code is {result.StatusCode}");
Console.ReadLine();





