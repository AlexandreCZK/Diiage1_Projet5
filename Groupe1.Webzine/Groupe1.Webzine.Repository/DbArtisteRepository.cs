using Groupe1.Webzine.EntitiesContext;
using Groupe1.Webzine.Entity;
using Groupe1.Webzine.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Groupe1.Webzine.Repository
{
    public class DbArtisteRepository : IArtisteRepository
    {
        WebzineDbContext _context;

        public DbArtisteRepository(WebzineDbContext dbContext)
        {
            _context = dbContext;
        }

        public void Add(Artiste artiste)
        {
            if (artiste == null)
            {
                throw new NullReferenceException("Artiste est nul");
            }
            if (_context.Artistes.FirstOrDefault(a => a.Nom == artiste.Nom) != null)
            {
                throw new Exception($"L'artiste {artiste.Nom} existe déja");
            }

            _context.Artistes.Add(artiste);
            _context.SaveChanges();
        }

        public void Delete(Artiste artiste)
        {
            if (artiste == null)
            {
                throw new NullReferenceException("Artiste est nul");
            }
            var artisteFactory = _context.Artistes.FirstOrDefault(a => a.IdArtiste == artiste.IdArtiste);
            if (artisteFactory == null)
            {
                throw new Exception($"L'artiste ({artiste.IdArtiste}) {artiste.Nom} n'existe pas");
            }
            _context.Artistes.Remove(artisteFactory);
            _context.SaveChanges();
        }

        public Artiste Find(int id)
        {
            var artiste = _context.Artistes
                .Include(a => a.Titres)
                .First(a => a.IdArtiste == id);
            return artiste;
        }

        public Artiste Find(string nom)
        {
            return _context.Artistes.Include(a => a.Titres).First(a => a.Nom == nom);
        }

        public IEnumerable<Artiste> FindAll()
        {
            return _context.Artistes.ToList();
        }

        public void Update(Artiste artiste)
        {
            if (artiste == null)
            {
                throw new NullReferenceException("Artiste est nulle");
            }
            var artisteFactory = _context.Artistes.FirstOrDefault(a => a.IdArtiste == artiste.IdArtiste);
            if (artisteFactory == null)
            {
                throw new Exception($"L'artiste ({artiste.IdArtiste}) {artiste.Nom} n'existe pas");
            }
            artisteFactory.Nom = artiste.Nom;
            artisteFactory.Biographie = artiste.Biographie;

            _context.Update(artisteFactory);
            _context.SaveChanges();
        }
    }
}
