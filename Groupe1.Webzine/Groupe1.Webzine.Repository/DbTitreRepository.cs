using Groupe1.Webzine.EntitiesContext;
using Groupe1.Webzine.Entity;
using Groupe1.Webzine.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Groupe1.Webzine.Repository
{
    public class DbTitreRepository : ITitreRepository
    {
        WebzineDbContext _context;
        public IStyleRepository _styleRepository { get; set; }

        public DbTitreRepository(WebzineDbContext dbContext, IStyleRepository iStyle)
        {
            _context = dbContext;
            _styleRepository = iStyle;
        }

        public void Add(Titre titre)
        {
            if (titre == null)
            {
                throw new NullReferenceException("Le titre est null");
            }
            if (_context.Titres.Any(t => t.Libelle == titre.Libelle && t.IdArtiste == titre.IdArtiste))
            {
                throw new Exception($"Le titre ({titre.IdTitre}) {titre.Libelle} de {titre.Artiste.Nom} existe déja");
            }
            _context.Titres.Add(titre);
            _context.SaveChanges();
        }

        public int Count()
        {
            return _context.Titres.ToList().Count;
        }

        public void Delete(Titre titre)
        {
            if (titre == null)
            {
                throw new NullReferenceException("Le titre est null");
            }

            var titreFactory = _context.Titres.First(t => t.IdTitre == titre.IdTitre);

            _context.Titres.Remove(titreFactory);
            _context.SaveChanges();
        }

        public Titre Find(int idTitre)
        {
            return _context.Titres
                .Include(t => t.TitresStyles)
                .Include(t => t.Artiste)
                .Include(t => t.Commentaires)
                .First(t => t.IdTitre == idTitre);
        }

        public IEnumerable<Titre> FindAll()
        {
            return _context.Titres
                .Include(t => t.Artiste)
                .Include(t => t.Commentaires)
                .Include(t => t.TitresStyles)
                .ToList();
        }

        public IEnumerable<Titre> FindTitres(int offset, int limit)
        {
            return _context.Titres.Skip(offset).Take(limit).ToList();
        }

        public void IncrementNbLectures(Titre titre)
        {
            if (titre != null)
            {
                throw new NullReferenceException("Le titre est null");
            }

            var titreFactory = _context.Titres.FirstOrDefault(t => t.IdTitre == titre.IdTitre);
            if (titreFactory == null)
            {
                throw new Exception($"Le titre ({titre.IdTitre}) {titre.Libelle} de {titre.Artiste.Nom} n'existe pas");
            }

            titreFactory.NbLectures++;
            _context.Update(titreFactory);
            _context.SaveChanges();
        }

        public void IncrementNbLikes(Titre titre)
        {
            if (titre == null)
            {
                throw new NullReferenceException("Le titre est null");
            }

            var titreFactory = _context.Titres.FirstOrDefault(t => t.IdTitre == titre.IdTitre);
            if (titreFactory == null)
            {
                throw new Exception($"Le titre ({titre.IdTitre}) {titre.Libelle} de {titre.Artiste.Nom} n'existe pas");
            }

            titreFactory.NbLikes++;
            _context.Update(titreFactory);
            _context.SaveChanges();
        }

        public IEnumerable<Titre> Search(string mot)
        {
            return _context.Titres.Where(t => t.Libelle.ToLower().Contains(mot.ToLower()));
        }

        public IEnumerable<Titre> SearchByStyle(string libelle)
        {
            var style = _styleRepository.FindAll().First(s => s.Libelle == libelle);
            return _context.Titres.Where(t => t.TitresStyles.All(tS => tS.IdStyle == style.IdStyle)).Include(t => t.Artiste).ToList();
        }

        public void Update(Titre titre)
        {
            if (titre == null)
            {
                throw new NullReferenceException("Le style est nulle");
            }

            var titreFactory = _context.Titres.FirstOrDefault(s => s.IdTitre == titre.IdTitre);
            if (titreFactory == null)
            {
                throw new Exception($"Le style ({titre.IdTitre}) {titre.Libelle} n'existe pas");
            }

            titreFactory.Libelle = titre.Libelle;
            titreFactory.Album = titre.Album;
            titreFactory.Chronique = titre.Chronique;
            titreFactory.DateSortie = titre.DateSortie;
            titreFactory.Duree = titre.Duree;
            titreFactory.UrlJaquette = titre.UrlJaquette;
            titreFactory.UrlEcoute = titre.UrlEcoute;
            _context.Update(titreFactory);
            _context.SaveChanges();
        }
    }
}
