using Groupe1.Webzine.Entity;
using Groupe1.Webzine.Entity.Factory;
using Groupe1.Webzine.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Groupe1.Webzine.Repository
{
    public class LocalArtisteRepository : IArtisteRepository
    {
        private static List<Artiste> _artistes = LocalArtisteFactory.CreerArtistes();

        public void Add(Artiste artiste)
        {
            if (artiste != null)
            {
                if (_artistes.FirstOrDefault(a => a.Nom == artiste.Nom) == null)
                {
                    artiste.IdArtiste = _artistes.Count + 1;
                    _artistes.Add(artiste);
                }
                else
                {
                    throw new Exception($"L'artiste {artiste.Nom} existe déja");
                }
            }
            else
            {
                throw new NullReferenceException("Artiste est nulle");
            }
        }

        public void Delete(Artiste artiste)
        {
            if (artiste != null)
            {
                var artisteFactory = _artistes.FirstOrDefault(a => a.IdArtiste == artiste.IdArtiste);
                if (artisteFactory != null)
                {
                    _artistes.Remove(artisteFactory);
                }
                else
                {
                    throw new Exception($"L'artiste ({artiste.IdArtiste}) {artiste.Nom} n'existe pas");
                }
            }
            else
            {
                throw new NullReferenceException("Artiste est nul");
            }
        }

        public Artiste Find(int id)
        {
            var artiste = _artistes.Find(a => a.IdArtiste == id);
            if (artiste == null)
            {
                throw new NullReferenceException("L'artiste avec l'id : " + id + " n'existe pas");
            }
            return artiste;
        }
        
        public Artiste Find(string nom)
        {
            var artiste = _artistes.Find(a => a.Nom == nom);
            if (artiste == null)
            {
                throw new NullReferenceException($"L'artiste avec le nom : {nom} n'existe pas");
            }
            return artiste;
        }

        public IEnumerable<Artiste> FindAll()
        {
            return _artistes;
        }

        public void Update(Artiste artiste)
        {
            if (artiste != null)
            {
                var artisteFactory = _artistes.FirstOrDefault(a => a.IdArtiste == artiste.IdArtiste);
                if (artisteFactory != null)
                {
                    artisteFactory.Nom = artiste.Nom;
                    artisteFactory.Biographie = artiste.Biographie;
                }
                else
                {
                    throw new Exception($"L'artiste ({artiste.IdArtiste}) {artiste.Nom} n'existe pas");
                }
            }
            else
            {
                throw new NullReferenceException("Artiste est nulle");
            }
        }
    }
}
