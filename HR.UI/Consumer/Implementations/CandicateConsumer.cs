using AutoMapper;
using HR.Entities.ApiModels.VacancyAppliersModels.Request;
using HR.Entities.ApiModels.VacancyAppliersModels.Response;
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
    public class CandicateConsumer : ICandicateConsumer
    {
        private readonly IHRConfigurations _hrConfigurations;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;
        public CandicateConsumer(IHRConfigurations hrConfigurations,
               IHttpClientFactory httpClientFactory,
               IMapper mapper)
        {
            _httpClientFactory = httpClientFactory;
            _hrConfigurations = hrConfigurations;
            _mapper = mapper;
        }
        public async Task<VacancyAppliersResponse> GetAllVacancyAppliers()
        {
            string apiUrl = _hrConfigurations.ApiUrl;
            string serviceUrl = "api/v1/vacancy-appliers";

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(apiUrl);

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string accessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIiLCJlbWFpbCI6Im9mZmljZXJAZ21haWwuLmNvbSIsImp0aSI6IjEiLCJVc2VySWQiOiIxIiwiVXNlck5hbWUiOiJBbGkiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJIUiBPZmZpY2VyIiwiZXhwIjoxNjY1ODc2NTExLCJpc3MiOiJTZWN1cmVBcGkiLCJhdWQiOiJTZWN1cmVBcGlVc2VycyJ9.R_9wIBVFSjmApq-g57wG0vd4fBsWENqhuK0V139neAQ";
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

            var result = await client.GetAsync(serviceUrl);
            var response = JsonConvert.DeserializeObject<VacancyAppliersResponse>(await result.Content.ReadAsStringAsync());
            return response;
        }

        public async Task<GenericResponse> CreateVacancyApplier(CreateVacancyApplierRequest data)
        {
            string apiUrl = _hrConfigurations.ApiUrl;
            string serviceUrl = $"api/v1/vacancy-appliers";

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(apiUrl);

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string accessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIiLCJlbWFpbCI6Im9mZmljZXJAZ21haWwuLmNvbSIsImp0aSI6IjEiLCJVc2VySWQiOiIxIiwiVXNlck5hbWUiOiJBbGkiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJIUiBPZmZpY2VyIiwiZXhwIjoxNjY1ODc2NTExLCJpc3MiOiJTZWN1cmVBcGkiLCJhdWQiOiJTZWN1cmVBcGlVc2VycyJ9.R_9wIBVFSjmApq-g57wG0vd4fBsWENqhuK0V139neAQ";
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await client.PostAsync(serviceUrl, content);
            var response = JsonConvert.DeserializeObject<GenericResponse>(await result.Content.ReadAsStringAsync());
            return response;
        }
    }
}
