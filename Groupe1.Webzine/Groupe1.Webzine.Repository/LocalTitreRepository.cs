using Groupe1.Webzine.Entity;
using Groupe1.Webzine.Entity.Factory;
using Groupe1.Webzine.Repository.Contracts;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Groupe1.Webzine.Repository
{
    public class LocalTitreRepository : ITitreRepository
    {
        private static List<Titre> _titres = LocalTitreFactory.CreerTitres();

        public void Add(Titre titre)
        {
            if (titre != null)
            {
                if (_titres.FirstOrDefault(t => t.Libelle == titre.Libelle && t.Artiste.Nom == titre.Artiste.Nom) == null)
                {
                    titre.IdTitre = _titres.Count + 1;
                    titre.Commentaires = new List<Commentaire>();
                    _titres.Add(titre);
                }
                else
                {
                    throw new Exception($"Le titre ({titre.IdTitre}) {titre.Libelle} de {titre.Artiste.Nom} existe déja");
                }
            }
            else
            {
                throw new NullReferenceException("Le titre est null");
            }
        }

        public int Count()
        {
            return _titres.Count;
        }

        public void Delete(Titre titre)
        {
            if (titre != null)
            {
                var titreFactory = _titres.FirstOrDefault(t => t.IdTitre == titre.IdTitre);
                if (titreFactory != null)
                {
                    _titres.Remove(titreFactory);
                }
                else
                {
                    throw new Exception($"Le titre ({titre.IdTitre}) {titre.Libelle} de {titre.Artiste.Nom} n'existe pas");
                }
            }
            else
            {
                throw new NullReferenceException("Le titre est null");
            }
        }

        public Titre Find(int idTitre)
        {
            var titre = _titres.FirstOrDefault(titre => titre.IdTitre == idTitre);
            if (titre == null)
            {
                throw new NullReferenceException("Le titre avec l'id :" + idTitre + " n'existe pas");
            }
            return titre;
        }

        public IEnumerable<Titre> FindAll()
        {
            return _titres;
        }

        public IEnumerable<Titre> FindTitres(int offset, int limit)
        {
            return _titres.Skip(offset).Take(limit);
        }

        public void IncrementNbLectures(Titre titre)
        {
            if (titre != null)
            {
                var titreFactory = _titres.FirstOrDefault(t => t.IdTitre == titre.IdTitre);
                if (titreFactory != null)
                {
                    titreFactory.NbLectures++;
                }
                else
                {
                    throw new Exception($"Le titre ({titre.IdTitre}) {titre.Libelle} de {titre.Artiste.Nom} n'existe pas");
                }
            }
            else
            {
                throw new NullReferenceException("Le titre est null");
            }
        }

        public void IncrementNbLikes(Titre titre)
        {
            if (titre != null)
            {
                var titreFactory = _titres.FirstOrDefault(t => t.IdTitre == titre.IdTitre);
                if (titreFactory != null)
                {
                    titreFactory.NbLikes++;
                }
                else
                {
                    throw new Exception($"Le titre ({titre.IdTitre}) {titre.Libelle} de {titre.Artiste.Nom} n'existe pas");
                }
            }
            else
            {
                throw new NullReferenceException("Le titre est null");
            }
        }

        public IEnumerable<Titre> Search(string mot)
        {
            return _titres.Where(t => t.Libelle.ToLower().Contains(mot.ToLower()));
        }

        public IEnumerable<Titre> SearchByStyle(string libelle)
        {
            IStyleRepository styleRepository = new LocalStyleRepository();
            var style = styleRepository.FindAll().First(s => s.Libelle == libelle);

            return _titres.SelectMany(x => x.TitresStyles.Where(t => t.IdStyle == style.IdStyle).Select(t => x));
        }

        public void Update(Titre titre)
        {
            if (titre != null)
            {
                var titreFactory = _titres.FirstOrDefault(s => s.IdTitre == titre.IdTitre);
                if (titreFactory != null)
                {
                    titreFactory.Artiste.Nom = titre.Artiste.Nom;
                    titreFactory.Libelle = titre.Libelle;
                    titreFactory.Album = titre.Album;
                    titreFactory.Chronique = titre.Chronique;
                    titreFactory.DateSortie = titre.DateSortie;
                    titreFactory.Duree = titre.Duree;
                    titreFactory.UrlJaquette = titre.UrlJaquette;
                    titreFactory.UrlEcoute = titre.UrlEcoute;
                }
                else
                {
                    throw new Exception($"Le style ({titre.IdTitre}) {titre.Libelle} n'existe pas");
                }

            }
            else
            {
                throw new NullReferenceException("Le style est nulle");
            }
        }
    }
}
