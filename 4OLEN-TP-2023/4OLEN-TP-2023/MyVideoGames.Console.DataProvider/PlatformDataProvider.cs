using Microsoft.EntityFrameworkCore;
using MyVideoGames.Console.DataProvider.Interface;
using MyVideoGames.DataContext;
using MyVideoGames.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVideoGames.Console.DataProvider
{
    public class PlatformDataProvider : IPlatformDataProvider
    {
        private readonly MainDbContext _context;

        public PlatformDataProvider(MainDbContext context)
        {
            _context = context;
        }

        public Platform? GetPlatformById(int platformId)
        {
            return _context.Platforms.SingleOrDefault(platform => platform.Id == platformId);
        }

        public IEnumerable<Platform> GetPlatforms()
        {
            IEnumerable<Platform>? platforms = _context.Platforms;
            return platforms;
        }

        public void Add(Platform platformToAdd)
        {
            _context.Add(platformToAdd);
            _context.SaveChanges();
        }

        public void Update(Platform platformToUpdate)
        {
            _context.Update(platformToUpdate);
            _context.SaveChanges();
        }

        public void Delete(int platformId)
        {
            _context.Platforms.Remove(GetPlatformById(platformId));
            _context.SaveChanges();
        }

    }
}