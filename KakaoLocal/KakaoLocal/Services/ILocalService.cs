namespace KakaoLocal
{
    public interface ILocalService
    {
        public Task<KakaoLocalResult?> SearchPlaceAsync(string keyword);
    }
}
