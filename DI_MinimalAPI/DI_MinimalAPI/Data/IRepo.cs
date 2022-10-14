namespace DI.Data
{
    public interface IRepo
    {
        List<T> GetAllSuperHero<T>() where T : class;
        T GetSuperHeroById<T>(int id) where T : class;
        T AddSuperHero<T>(T s) where T : class;
        T UpdateSuperHero<T>(T s) where T : class;
        T DeleteSuperHeroById<T>(int id) where T : class;
    }
}
