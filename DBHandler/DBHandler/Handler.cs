using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHandler
{
    public class Handler
    {
        StarWarsEntities db = new StarWarsEntities();

        public List<Charakter> queryCharacters()
        {
            var query = from charakter in db.Charakter
                        select charakter;

            return query.ToList();
        }

        public void addCharakter(String name, Boolean isForceUser, String side, String HomePlanet)
        {
            List<Planet> Planet = this.getPlanetByName(HomePlanet);

            if (Planet.Count() == 0)
            {
                Planet = this.createPlanet(HomePlanet);
            }

            Charakter temp = new Charakter(name, isForceUser, side, Planet[0].Id, Planet[0]);
            db.Charakter.Add(temp);
            db.SaveChanges();

        }

        private List<Planet> createPlanet(string Name)
        {
            Planet temp = new Planet(Name);
            db.Planet.Add(temp);
            db.SaveChanges();
            return getPlanetByName(Name);
        }

        private List<Planet> getPlanetByName(String planetName)
        {
            var query = from planet in db.Planet
                        where planet.Name.Contains(planetName)
                        select planet;

            return query.ToList();

        }

      
    }
    }
