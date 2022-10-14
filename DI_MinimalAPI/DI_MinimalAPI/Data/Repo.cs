namespace DI.Data
{
    public class Repo : IRepo
    {
        private SuperHeroContext _SuperHeroContext;

        public Repo(SuperHeroContext superHeroContext)
        {
            _SuperHeroContext = superHeroContext;
        }

        public List<T> GetAllSuperHero<T>() where T : class
        {
            var result = _SuperHeroContext.Set<T>().ToList();
            return result;
        }

        public T GetSuperHeroById<T>(int id) where T : class
        {
            var superhero = _SuperHeroContext.Set<T>().Find(id);
            if (superhero == null) return null;
            return superhero;
        }

        public T AddSuperHero<T>(T s) where T : class
        {
            if (s == null) return null;
            _SuperHeroContext.Set<T>().Add(s);
            _SuperHeroContext.SaveChanges();
            return s;
        }

        public T UpdateSuperHero<T>(T s) where T : class
        {
            _SuperHeroContext.Set<T>().Update(s);
            _SuperHeroContext.SaveChanges();
            return s;
        }

        public T DeleteSuperHeroById<T>(int id) where T : class
        {
            var superhero = _SuperHeroContext.Set<T>().Find(id);
            if (superhero == null) return null;
            _SuperHeroContext.Set<T>().Remove(superhero);
            _SuperHeroContext.SaveChanges();
            return superhero;
        }

    }
}
