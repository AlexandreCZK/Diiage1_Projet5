using Groupe1.Webzine.EntitiesContext;
using Groupe1.Webzine.Entity;
using Groupe1.Webzine.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Groupe1.Webzine.Repository
{
    public class DbStyleRepository : IStyleRepository
    {
        WebzineDbContext _context;

        public DbStyleRepository(WebzineDbContext dbContext)
        {
            _context = dbContext;
        }

        public void Add(Style style)
        {
            if (style == null)
            {
                throw new NullReferenceException("Artiste est nulle");
            }

            if (_context.Styles.FirstOrDefault(s => s.Libelle == style.Libelle) != null)
            {
                throw new Exception($"Le style ({style.IdStyle}) {style.Libelle} existe déja");
                
            }

            _context.Styles.Add(style);
            _context.SaveChanges();
        }

        public void Delete(Style style)
        {
            if (style == null)
            {
                throw new NullReferenceException("Le style est nulle");
            }

            var styleFactory = _context.Styles.First(s => s.IdStyle == style.IdStyle);
            if (styleFactory == null)
            {
                throw new Exception($"Le style ({style.IdStyle}) {style.Libelle} n'existe pas");
            }

            _context.Styles.Remove(styleFactory);
            _context.SaveChanges();
        }

        public Style Find(int id)
        {
            return _context.Styles.First(s => s.IdStyle == id); ;
        }

        public Style Find(string name)
        {
            return _context.Styles.First(s => s.Libelle == name);
        }

        public IEnumerable<Style> FindAll()
        {
            return _context.Styles.ToList();
        }

        public void Update(Style style)
        {
            if (style == null)
            {
                throw new NullReferenceException("Le style est nulle");
            }

            var styleFactory = _context.Styles.FirstOrDefault(s => s.IdStyle == style.IdStyle);
            if (styleFactory == null)
            {
                throw new Exception($"Le style ({style.IdStyle}) {style.Libelle} n'existe pas");
                
            }

            styleFactory.Libelle = style.Libelle;
            _context.Update(styleFactory);
            _context.SaveChanges();
        }
    }
}
