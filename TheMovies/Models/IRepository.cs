using System;

namespace TheMovies.Models
{
    interface IRepository
    {
        public void Add();
        public void Remove();
        public void Save();
        public void Load();
    }
}
