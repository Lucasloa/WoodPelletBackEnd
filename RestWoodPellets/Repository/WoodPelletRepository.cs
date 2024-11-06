using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodPelletsLib
{
    public class WoodPelletRepository
    {
        private int _nextId = 6;

        private readonly List<WoodPellet> _woodPellets = new()
        {
            new WoodPellet(1, "BioWood", 4995, 4),
            new WoodPellet(2, "BioWood", 5195, 4),
            new WoodPellet(3, "BillingPile", 5125, 1),
            new WoodPellet(4, "GoldenWoodPellet", 5995, 5),
            new WoodPellet(5, "GoldenWoodPellet", 5795, 5)
            // new WoodPellet() { Id = _nextId++, Brand = "BioWood", Price = 4995, Quality = 4);
            // Husk jeg skulle havde lavet ID ikke noget man selv skriver ind.
        };

        public WoodPelletRepository()
        {
        }
        // Opgave 9
        public IEnumerable<WoodPellet> Get(int? quality = null, string? brand = null, string? orderBy = null)
        {
            IEnumerable<WoodPellet> result = new List<WoodPellet>(_woodPellets);

  
            if (quality.HasValue)
            {
                result = result.Where(m => m.Quality == quality.Value);
            }

   
            if (!string.IsNullOrEmpty(brand))
            {
                result = result.Where(m => m.Brand.Contains(brand, StringComparison.OrdinalIgnoreCase));
            }

    
            if (!string.IsNullOrEmpty(orderBy))
            {
                orderBy = orderBy.ToLower();
                switch (orderBy)
                {
                    case "quality":
                    case "quality_asc":
                        result = result.OrderBy(m => m.Quality);
                        break;
                    case "quality_desc":
                        result = result.OrderByDescending(m => m.Quality);
                        break;

                    case "price":
                    case "price_asc":
                        result = result.OrderBy(m => m.Price);
                        break;
                    case "price_desc":
                        result = result.OrderByDescending(m => m.Price);
                        break;
                       
                }
            }

            return result;
        }

        public WoodPellet? GetById(int id)
        {
            return _woodPellets.Find(wood => wood.Id == id);
        }
        public IEnumerable<WoodPellet> GetAll()
        {
            // Her returnerer vi en KOPI af listen og ikke selve listen. 
            return new List<WoodPellet>(_woodPellets);
        }
        public WoodPellet Add(WoodPellet wood)
        {
            wood.Validate();
            wood.Id = _nextId++;
            _woodPellets.Add(wood);
            return wood;
            // Husk at vi kalder validate så vi ikke får et ulovligt objekt lagt ind.
        }
        // Opgave 9
        public WoodPellet? Update(int id, WoodPellet wood)
        {
            wood.Validate();
            WoodPellet? existingWood = GetById(id);
            if (existingWood == null)
            {
                return null;
            }
            existingWood.Brand = wood.Brand;
            existingWood.Price = wood.Price;
            existingWood.Quality = wood.Quality;
            return existingWood;
            // Husk at vi kalder validate her så vi ikke opdaterer med ulovlige værdier.
        }
        public WoodPellet? Remove(int id)
        {
            WoodPellet? woodPellet = GetById(id);
            if (woodPellet == null)
            {
                return null;
            }
            _woodPellets.Remove(woodPellet);
            return woodPellet;
        }

    }
}
