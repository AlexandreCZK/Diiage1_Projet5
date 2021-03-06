using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Linq;

namespace Groupe1.Webzine.EntitiesContext.Seeder
{
    public class SeedDataSpotify
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = new WebzineDbContext(
               serviceProvider.GetRequiredService<
                   DbContextOptions<WebzineDbContext>>());
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.spotify.com/");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "BQDfVy6MqlqjXvqyw3_cLOqDaxx1cdHGujK_BrS6S0RR7jthy-Y9JV-tAYmy8b7-Sa_fQqIBPBkXAT1FP1PUYTQDVHs7_jzMo0i-89mIw55rqbHpsqGEQL5dOTmcoluOwBIySTmy7rBYj-ERASdkzaJIIn4wLE0");
            AjoutArtiste(context, client);
            AjoutTitre(context, client);
            AjoutCommentaire(context);
            AjoutStyle(context, client);
            //AjoutTitreStyle(context);
        }

        private static void AjoutArtiste(WebzineDbContext context, HttpClient client)
        {

            var response = client.GetAsync(
                "v1/search?q=N&type=artist&market=fr&limit=10"
            ).Result.Content;

            var json = response.ReadAsStringAsync().Result;
            var root = System.Text.Json.JsonSerializer.Deserialize<RootArtists>(json);

            root.Artists.Items.ForEach(a =>
                context.Artistes.Add(new Entity.Artiste
                {
                    IdSpotify = a.Id,
                    Nom = a.Name
                }));

            context.SaveChanges();
        }

        private static void AjoutTitre(WebzineDbContext context, HttpClient client)
        {
            var artites = context.Artistes.ToList();
            foreach (var item in artites)
            {
                var response = client.GetAsync(
                    $"v1/artists/{item.IdSpotify}/albums?market=ES&limit=1"
                    ).Result.Content;

                var json = response.ReadAsStringAsync().Result;
                var rootAlbum = System.Text.Json.JsonSerializer.Deserialize<RootAlbum>(json);

                response = client.GetAsync(
                   $"v1/albums/{rootAlbum.Items[0].Id}/tracks?market=FR&limit=10"
                   ).Result.Content;

                json = response.ReadAsStringAsync().Result;
                var rootTrack = System.Text.Json.JsonSerializer.Deserialize<RootTrack>(json);
                rootTrack.Items.ForEach(t =>
                    context.Titres.Add(new Entity.Titre
                    {
                        Album = rootAlbum.Items[0].Name,
                        IdArtiste = item.IdArtiste,
                        DateCreation = DateTime.Now,
                        Duree = (int)(t.DurationMs / 1000),
                        Chronique = "Ce titre viens de spotify il n'y a pas de chronique disponible",
                        Libelle = t.Name,
                        UrlJaquette = rootAlbum.Items[0].Images[0].Url
                    }));
            }
            context.SaveChanges();
        }

        private static void AjoutCommentaire(WebzineDbContext context)
        {
            var titres = context.Titres.ToList();
            foreach (var item in titres)
            {
                context.Commentaires.Add(new Entity.Commentaire
                {
                    Auteur = "Random",
                    Contenu = "Trop bien !",
                    DateCreation = DateTime.Now,
                    IdTitre = item.IdTitre
                });
            }
            context.SaveChanges();
        }

        private static void AjoutStyle(WebzineDbContext context, HttpClient client)
        {
            var titres = context.Titres.Include(t => t.Artiste).ToList();
            foreach (var item in titres)
            {
                var response = client.GetAsync(
                    $"v1/artists/{item.Artiste.IdSpotify}"
                    ).Result.Content;

                var json = response.ReadAsStringAsync().Result;
                var style = System.Text.Json.JsonSerializer.Deserialize<RootArtist>(json).Genres[0];

                if (!context.Styles.Any(s => s.Libelle == style))
                {
                    context.Styles.Add(new Entity.Style { Libelle = style });
                    context.SaveChanges();
                }
                context.TitresStyles.Add(new Entity.TitreStyle
                {
                    IdStyle = context.Styles.First(s => s.Libelle == style).IdStyle,
                    IdTitre = item.IdTitre
                });
            }
            context.SaveChanges();
        }
    }
}