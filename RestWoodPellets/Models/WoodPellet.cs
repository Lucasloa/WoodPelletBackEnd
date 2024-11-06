namespace WoodPelletsLib
{
    public class WoodPellet
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }
        public int Quality { get; set; }

        public WoodPellet()
        {
        }

        public WoodPellet(int id, string brand, int price, int quality)
        {
            Id = id;
            Brand = brand;
            Price = price;
            Quality = quality;
        }

        public void ValidateBrand()
        {
            if (Brand == null)
            {
                throw new ArgumentNullException("Brand er lig med null");
                // Husk at tjek for nulls fordi man får den FORKERTE exception her. hvis man opretter en nyt objekt starter den uintialiseret derfor STARTER DEN som NULL. 
                // så her får man argumentnullreferenceexception.
            }
            if (Brand.Length < 2)
            {
                throw new ArgumentOutOfRangeException("Brand længden minimum 2 karakterer");
            }

        }
        public void ValidatePrice()
        {
            if (Price < 0)
            {
                throw new ArgumentOutOfRangeException("Pris skal være positiv");
            }
        }
        public void ValidateQuality()
        {
            if (Quality < 1 || Quality > 5)
            {
                throw new ArgumentOutOfRangeException("Kvalitet må ikke være under 0 eller over 5");
            }
        }
        public void Validate()
        {
            ValidateBrand();
            ValidatePrice();
            ValidateQuality();
        }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Brand)}={Brand}, {nameof(Price)}={Price.ToString()}, {nameof(Quality)}={Quality.ToString()}}}";
        }
        //husk at overwrite equals og gethashcode hvis der bliver lavet et library.
    }
}
