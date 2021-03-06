using Groupe1.Webzine.EntitiesContext;
using Groupe1.Webzine.Entity;
using Groupe1.Webzine.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Groupe1.Webzine.Repository
{
    public class DbCommentaireRepository : ICommentaireRepository
    {
        WebzineDbContext _context;

        public DbCommentaireRepository(WebzineDbContext dbContext)
        {
            _context = dbContext;
        }

        public void Add(Commentaire commentaire)
        {
            if (commentaire == null)
            {
                throw new NullReferenceException("Le commentaire est nulle");
            }
            commentaire.DateCreation = DateTime.Now;
            _context.Commentaires.Add(commentaire);
            _context.SaveChanges();
        }

        public void Delete(Commentaire commentaire)
        {
            if (commentaire == null)
            {
                throw new NullReferenceException("Artiste est nulle");

            }
            var commentaireFactory = _context.Commentaires.First(c => c.IdCommentaire == commentaire.IdCommentaire);
            _context.Commentaires.Remove(commentaireFactory);
            _context.SaveChanges();
        }

        public Commentaire Find(int id)
        {
            return _context.Commentaires.Include(c => c.Titre).First(c => c.IdCommentaire == id);
        }

        public IEnumerable<Commentaire> FindAll()
        {
            return _context.Commentaires.Include(c => c.Titre).ToList();
        }
    }
}
