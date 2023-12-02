using System.Net.Http.Json;

using blazorApp.Models.API;
using blazorApp.Extensions;
using Microsoft.Extensions.Primitives;
using static System.Net.WebRequestMethods;

namespace blazorApp.Services
{
    public class APIService
    {
        private readonly HttpClient httpClient;
        private static string token = string.Empty;
        public APIService(HttpClient httpClient) {
            this.httpClient = httpClient;
        }

        public async Task<ApiInfoModel?> Info()
        {
            return await httpClient.GetFromJsonAsync<ApiInfoModel>("api/info");
        }

        public async Task<AuthRespModel?> Authenticate(AuthRequest auth)
        {
            var resp = await httpClient.PostAsJsonAsync<AuthRespModel, AuthRequest>("api/v2/user/authenticate", auth);
            token = resp?.Token ?? "";

            return resp;
        }

        public async Task<CarViewModel?> CarAdd(CarCreateModel req)
        {
            return await httpClient.PostAsJsonAsync<CarViewModel, CarCreateModel>("api/v1/car/add", req, token);
        }

        public async Task<CarViewModel[]?> CarList()
        {
            return await httpClient.GetFromJsonAsync<CarViewModel[]>("api/v1/car/cars", token);
        }
    }
}
