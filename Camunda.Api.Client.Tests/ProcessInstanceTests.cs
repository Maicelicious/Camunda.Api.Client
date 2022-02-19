using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Camunda.Api.Client.ProcessInstance;
using Refit;
using RichardSzalay.MockHttp;
using Xunit;

namespace Camunda.Api.Client.Tests
{
    public class ProcessInstanceTests
    {
        [Fact]
        public async Task GetList()
        {
            MockHttpMessageHandler mockHttp = new MockHttpMessageHandler();

            mockHttp.Expect(HttpMethod.Post, "http://localhost:8080/engine-rest")
                .Respond(HttpStatusCode.OK, "text/html", "OK");


            CamundaClient client = CamundaClient.Create("http://localhost:8080/engine-rest", mockHttp);
            System.Collections.Generic.List<ProcessInstanceInfo> process = await client.ProcessInstances.Query().List();

            Assert.NotNull(process);
        }
    }
}
