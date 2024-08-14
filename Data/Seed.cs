using IronDomeSim.Models;

namespace IronDomeSim.Data
{
    public class Seed
    {
        private readonly AppDbContext _context;
        public Seed(AppDbContext context)
        {
            _context = context; 
        }

        public async Task GoAsync()
        {
            string[] srcs = new string[15];
            for (int i = 1; i <= 15; i++)
            {
                byte[] imageBytes = System.IO.File.ReadAllBytes($"wwwroot/Images/{i}.png");
                srcs[i - 1] = Convert.ToBase64String(imageBytes);
            }

            Weapon w1 = new Weapon()
            {
                Name = "Hades-1",
                Range = 500,
                Speed = 3200,
                ImgBase64 = srcs[0]
            };
            Weapon w2 = new Weapon()
            {
                Name = "Orion Mk-2",
                Range = 1200,
                Speed = 850,
                ImgBase64 = srcs[1]
            };
            Weapon w3 = new Weapon()
            {
                Name = "Scimitar-X",
                Range = 800,
                Speed = 4000,
                ImgBase64 = srcs[2]
            };
            Weapon w4 = new Weapon()
            {
                Name = "Thunderbird-5",
                Range = 300,
                Speed = 1500,
                ImgBase64 = srcs[3]
            };
            Weapon w5 = new Weapon()
            {
                Name = "Tempest-SR",
                Range = 2500,
                Speed = 7500,
                ImgBase64 = srcs[4]
            };
            Weapon w6 = new Weapon()
            {
                Name = "Falcon-P",
                Range = 120,
                Speed = 2200,
                ImgBase64 = srcs[5]
            };
            Weapon w7 = new Weapon()
            {
                Name = "Harpy-3",
                Range = 900,
                Speed = 750,
                ImgBase64 = srcs[6]
            };
            Weapon w8 = new Weapon()
            {
                Name = "Viper-7",
                Range = 650,
                Speed = 3800,
                ImgBase64 = srcs[7]
            };
            Weapon w9 = new Weapon()
            {
                Name = "Barracuda-X1",
                Range = 1600,
                Speed = 850,
                ImgBase64 = srcs[8]
            };
            Weapon w10 = new Weapon()
            {
                Name = "Stiletto-L",
                Range = 200,
                Speed = 2500,
                ImgBase64 = srcs[9]
            };
            Weapon w11 = new Weapon()
            {
                Name = "Archon-10",
                Range = 4000,
                Speed = 12000,
                ImgBase64 = srcs[10]
            };
            Weapon w12 = new Weapon()
            {
                Name = "Phoenix-M2",
                Range = 100,
                Speed = 1200,
                ImgBase64 = srcs[11]
            };
            Weapon w13 = new Weapon()
            {
                Name = "Mirage-4",
                Range = 3200,
                Speed = 10500,
                ImgBase64 = srcs[12]
            };
            Weapon w14 = new Weapon()
            {
                Name = "Spectre-X",
                Range = 400,
                Speed = 1800,
                ImgBase64 = srcs[13]
            };
            Weapon w15 = new Weapon()
            {
                Name = "Venom-8",
                Range = 1800,
                Speed = 900,
                ImgBase64 = srcs[14]
            };

            _context.Weapons.Add(w1);
            _context.Weapons.Add(w2);
            _context.Weapons.Add(w3);
            _context.Weapons.Add(w4);
            _context.Weapons.Add(w5);
            _context.Weapons.Add(w6);
            _context.Weapons.Add(w7);
            _context.Weapons.Add(w8);
            _context.Weapons.Add(w9);
            _context.Weapons.Add(w10);
            _context.Weapons.Add(w11);
            _context.Weapons.Add(w12);
            _context.Weapons.Add(w13);
            _context.Weapons.Add(w14);
            _context.Weapons.Add(w15);
            _context.SaveChanges();
        }
    }
}
