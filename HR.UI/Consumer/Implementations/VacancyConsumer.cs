using AutoMapper;
using HR.Entities.ApiModels.VacancyModels.Request;
using HR.Entities.ApiModels.VacancyModels.Response;
using HR.Entities.EnvironmentConfigurations.Interface;
using HR.Entities.GenericModels;
using HR.UI.Consumer.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace HR.UI.Consumer.Implementations
{
    public class VacancyConsumer : IVacancyConsumer
    {
        private readonly IHRConfigurations _hrConfigurations;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;
        public VacancyConsumer(IHRConfigurations hrConfigurations,
               IHttpClientFactory httpClientFactory,
               IMapper mapper)
        {
            _httpClientFactory = httpClientFactory;
            _hrConfigurations = hrConfigurations;
            _mapper = mapper;
        }

        public async Task<VacanciesResponse> GetAllVacancies()
        {
            string apiUrl = _hrConfigurations.ApiUrl;
            string serviceUrl = "api/v1/vacancy";

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(apiUrl);

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string accessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIiLCJlbWFpbCI6Im1hbmFnZXJAZ21haWwuLmNvbSIsImp0aSI6IjIiLCJVc2VySWQiOiIyIiwiVXNlck5hbWUiOiJtZSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkhSIE1hbmFnZXIiLCJleHAiOjE2NjU4NzI1MTEsImlzcyI6IlNlY3VyZUFwaSIsImF1ZCI6IlNlY3VyZUFwaVVzZXJzIn0.sAdYBOtn8VmDNBM93B6S8SJ6XFzocRARFkKd9a6I9EQ";
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

            var result = await client.GetAsync(serviceUrl);
            var response = JsonConvert.DeserializeObject<VacanciesResponse>(await result.Content.ReadAsStringAsync());
            return response;
        }

        public async Task<GenericResponse> CreateVacancy(CreateVacancyRequest data)
        {
            string apiUrl = _hrConfigurations.ApiUrl;
            string serviceUrl = $"api/v1/vacancy";

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(apiUrl);

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string accessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIiLCJlbWFpbCI6Im1hbmFnZXJAZ21haWwuLmNvbSIsImp0aSI6IjIiLCJVc2VySWQiOiIyIiwiVXNlck5hbWUiOiJtZSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkhSIE1hbmFnZXIiLCJleHAiOjE2NjU4NzI1MTEsImlzcyI6IlNlY3VyZUFwaSIsImF1ZCI6IlNlY3VyZUFwaVVzZXJzIn0.sAdYBOtn8VmDNBM93B6S8SJ6XFzocRARFkKd9a6I9EQ";
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await client.PostAsync(serviceUrl, content);
            var response = JsonConvert.DeserializeObject<GenericResponse>(await result.Content.ReadAsStringAsync());
            return response;
        }
    }
}
