using Groupe1.Webzine.Entity;
using Groupe1.Webzine.Entity.Factory;
using Groupe1.Webzine.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Groupe1.Webzine.Repository
{
    public class LocalStyleRepository : IStyleRepository
    {
        private static List<Style> _styles = LocalStyleFactory.CreerStyles();

        public void Add(Style style)
        {
            if (style != null)
            {
                if (_styles.FirstOrDefault(s => s.Libelle == style.Libelle) == null)
                {
                    style.IdStyle = _styles.Count + 1;
                    _styles.Add(style);
                }
                else
                {
                    throw new Exception($"Le style ({style.IdStyle}) {style.Libelle} existe déja");
                }
            }
            else
            {
                throw new NullReferenceException("Artiste est nulle");
            }
        }

        public void Delete(Style style)
        {
            if (style != null)
            {
                var styleFactory = _styles.FirstOrDefault(s => s.IdStyle == style.IdStyle);
                if (styleFactory != null)
                {
                    _styles.Remove(styleFactory);
                }
                else
                {
                    throw new Exception($"Le style ({style.IdStyle}) {style.Libelle} n'existe pas");
                }

            }
            else
            {
                throw new NullReferenceException("Le style est nulle");
            }
        }

        public Style Find(int id)
        {
            var style = _styles.FirstOrDefault(s => s.IdStyle == id);
            if (style == null)
            {
                throw new NullReferenceException("Le style avec l'id :" + id + " n'existe pas");
            }

            return style;
        }

        public Style Find(string name)
        {
            return _styles.FirstOrDefault(s => s.Libelle == name);
        }

        public IEnumerable<Style> FindAll()
        {
            return _styles;
        }

        public void Update(Style style)
        {
            if (style != null)
            {
                var styleFactory = _styles.FirstOrDefault(s => s.IdStyle == style.IdStyle);
                if (styleFactory != null)
                {
                    styleFactory.Libelle = style.Libelle;
                }
                else
                {
                    throw new Exception($"Le style ({style.IdStyle}) {style.Libelle} n'existe pas");
                }

            }
            else
            {
                throw new NullReferenceException("Le style est nulle");
            }
        }
    }
}
