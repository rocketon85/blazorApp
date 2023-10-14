namespace blazorApp.Models.API
{
    public record ApiInfoModel(string Author, string Version);

    public record CarCreateModel(string Name, int FuelId, int BrandId, int ModelId);
    public record CarViewModel(int Id, string FuelName, string BrandName, string ModelName);
    public record AuthRequest(string Username, string Password);


    public record AuthRespModel(int UserId, string Token);

}
