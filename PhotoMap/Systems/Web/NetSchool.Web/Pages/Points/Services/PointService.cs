using NetSchool.Web.Pages.Points.Models;
using System.Net.Http.Json;

namespace NetSchool.Web.Pages.Points.Services;

public class PointService(HttpClient httpClient) : IPointService
{
    public async Task AddPoint(CreateModel model)
    {
        var requestContent = JsonContent.Create(model);
        var response = await httpClient.PostAsync("v1/point", requestContent);

        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
    }

    public async Task DeletePoint(Guid pointId)
    {
        var response = await httpClient.DeleteAsync($"v1/point/{pointId}");

        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
    }

    public async Task EditPoint(Guid pointId, UpdateModel model)
    {
        var requestContent = JsonContent.Create(model);
        var response = await httpClient.PutAsync($"v1/point/{pointId}", requestContent);

        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
    }

    public async Task<PointModel> GetPoint(Guid pointId)
    {
        var response = await httpClient.GetAsync($"v1/point/{pointId}");
        if (!response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }

        return await response.Content.ReadFromJsonAsync<PointModel>() ?? new();
    }

    public async Task<IEnumerable<PointCategoryModel>> GetPointCategoryList()
    {
        var response = await httpClient.GetAsync("/v1/pointcategory");
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        return await response.Content.ReadFromJsonAsync<IEnumerable<PointCategoryModel>>() ?? new List<PointCategoryModel>();
    }


    public async Task<IEnumerable<PointModel>> GetPoints()
    {
        var response = await httpClient.GetAsync("v1/point");
        if (!response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }

        return await response.Content.ReadFromJsonAsync<IEnumerable<PointModel>>() ?? new List<PointModel>();
    }

}
