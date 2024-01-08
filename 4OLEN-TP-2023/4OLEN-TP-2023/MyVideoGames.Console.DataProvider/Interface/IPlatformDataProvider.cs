using MyVideoGames.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVideoGames.Console.DataProvider.Interface
{
    public interface IPlatformDataProvider
    {
        public Platform? GetPlatformById(int platformId);
        public IEnumerable<Platform>? GetPlatforms();
        public void Add(Platform PlatformToAdd);
        public void Update(Platform Platform);
        public void Delete(int gameId);
    }
}