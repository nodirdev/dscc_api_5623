using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/Filter")]
    [ApiController]
    public class FilterController : ControllerBase
    {
        private readonly IRepositoryProduct _productRepository;
        private readonly IRepositoryCategory _cartegoryRepository;
        public FilterController(IRepositoryProduct productRepository, IRepositoryCategory cat)
        {
            _productRepository = productRepository;
            _cartegoryRepository = cat;
        }

        private readonly int ItemsPerPage = 5;

        // POST api/filter
        [HttpPost]
        public Object Post([FromBody]ProductFilters filters)
        {
            if (_productRepository.GetProducts().Count() == 0)
                PopulateProducts();

            List<Product> ps = _productRepository.GetProducts().ToList();

            if (filters.Title.Length > 0)
                ps = ps.Where(p => p.Title.ToLower().Contains(filters.Title.ToLower())).ToList();

            if (filters.CategoryId > 0)
                ps = ps.Where(p => p.CategoryId == filters.CategoryId).ToList();

            if (filters.PriceFrom > 0)
                ps = ps.Where(p => p.Price >= filters.PriceFrom).ToList();

            if (filters.PriceTo > 0)
                ps = ps.Where(p => p.Price <= filters.PriceTo).ToList();

            if (filters.ASC)
                ps = ps.OrderBy(p => p.Price).ToList();
            else
                ps = ps.OrderByDescending(p => p.Price).ToList();

            int pageCount = (int)Math.Ceiling((double)(ps.Count() / ItemsPerPage)) + 1;

            int skip = ItemsPerPage * (filters.Page - 1);

            bool canPage = skip < ps.Count();

            if (!canPage)
                filters.Page = 1;

            ps = ps.Skip(skip).Take(ItemsPerPage).ToList();

            return Ok(new { Page = filters.Page, PageCount = pageCount, Products = ps });
        }

        [HttpGet]
        public Object Get()
        {
            return _cartegoryRepository.GetCategories().ToList();
        }

        private void PopulateProducts()
        {
            var products = _productRepository;

            // add product========================================================
            Product p1 = new Product();
            p1.CategoryId = 1;
            p1.Title = "ULTRABOOST 20 SHOES";
            p1.Description = "TOUCH DOWN WITH CONTROL, RIDE WITH COMFORT.\nA new day.A new run.Make it your best.These high-performance shoes feature a foot-hugging knit upper. Stitched -in reinforcement is precisely placed to give you support in the places you need it most. The soft elastane heel delivers a more comfortable fit.Responsive cushioning returns energy to your stride with every footstrike for that I-could - run - forever feeling.";
            p1.Price = 180;
            p1.Amount = 100;
            products.InsertProduct(p1);

            Product p2 = new Product();
            p2.CategoryId = 1;
            p2.Title = "ADILETTE CLOUDFOAM SLIDES";
            p2.Description = "SHOWER-READY SLIDES WITH A SOFT, CONTOURED FOOTBED.\nIdeal for the pool deck or shower, these men's slides feature a quick-drying Cloudfoam footbed that cradles your feet with soft cushioning. The bandage-style upper shows off contrast 3-Stripes for a classic athletic look. The EVA outsole provides lightweight comfort.";
            p2.Price = 25;
            p2.Amount = 100;
            products.InsertProduct(p2);

            Product p3 = new Product();
            p3.CategoryId = 1;
            p3.Title = "NMD_R1 SHOES";
            p3.Description = "TECH-INSPIRED SNEAKERS WITH A STRETCHY MESH UPPER.\nNMD footwear continues on its progressive spiral in fresh new combinations of urban style and running - inspired design\nThese men's sneakers borrow inspiration from tech innovations. The stretchy mesh upper is made from twisted two-tone yarn, giving the upper a textured look. EVA inserts cushion your steps, while Boost keeps energy coming when you need it. Best of all, the NMD_R1 shoes feel as comfy as a pair of socks.";
            p3.Price = 130;
            p3.Amount = 100;
            products.InsertProduct(p3);

            Product p4 = new Product();
            p4.CategoryId = 1;
            p4.Title = "BOSTON SUPERXR1 SHOES";
            p4.Description = "AN '80S RUNNING STYLE THAT'S PAIRED WITH MODERN CUSHIONING.\nThe original Boston Super was a marathon sneaker that first took flight in the mid-'80s on the world-famous route that runs from Hopkinton to Back Bay. These shoes bring back the retro mesh-and-suede design and add modern cushioning. Lightweight and breathable, they offer energy return in every stride.";
            p4.Price = 70;
            p4.Amount = 100;
            products.InsertProduct(p4);

            Product p5 = new Product();
            p5.CategoryId = 1;
            p5.Title = "SOLARGLIDE 19 SHOES";
            p5.Description = "NEUTRAL RUNNING SHOES THAT DELIVER COMFORT OVER THE LONG HAUL.\nWhen running is a part of every day, you want gear you don't have to think about. These adidas shoes are your tried-and-true partner for long-distance runs. Energized cushioning works with a flexible outsole to deliver a smooth and comfortable ride. A stability rail keeps your stride feeling balanced.";
            p5.Price = 140;
            p5.Amount = 100;
            products.InsertProduct(p5);

            Product p6 = new Product();
            p6.CategoryId = 2;
            p6.Title = "TEE";
            p6.Description = "THIS INFANTS' ALLOVER SUSHI-PRINT T-SHIRT IS FULL OF FLAVOR.\nLittle style. Full of flavor.A bold adidas Trefoil logo stands out in the middle of this cute allover sushi - print t - shirt.All - cotton keeps little ones comfortable.";
            p6.Price = 20;
            p6.Amount = 100;
            products.InsertProduct(p6);

            Product p7 = new Product();
            p7.CategoryId = 2;
            p7.Title = "TREFOIL HOODIE";
            p7.Description = "A COZY HOODIE THAT SHOWS OFF ADIDAS PRIDE.\nThe Trefoil has been standing out since its 1972 debut.This hoodie celebrates its iconic style with a Trefoil logo front and center.A kangaroo pouch pocket keeps your everyday belongings close.The pullover sweatshirt is made of cotton French terry for a cozy feel.";
            p7.Price = 65;
            p7.Amount = 100;
            products.InsertProduct(p7);

            Product p8 = new Product();
            p8.CategoryId = 2;
            p8.Title = "BADGE OF SPORT TEE";
            p8.Description = "A CASUAL TEE FOR EVERYDAY COMFORT.\nFor days on the move or nights on the town, this t - shirt lets everyone know whose team you play for. It's made of soft cotton jersey for all-day comfort. A bold contrast adidas Badge of Sport stands out on the chest.";
            p8.Price = 25;
            p8.Amount = 100;
            products.InsertProduct(p8);

            Product p9 = new Product();
            p9.CategoryId = 2;
            p9.Title = "SST TRACK JACKET";
            p9.Description = "A TRACK JACKET WITH ICONIC 3-STRIPES STYLE.\nRetro style, defined and amplified. The SST track jacket debuted on the court in 1979, when it quickly became an essential for tennis training. It's made in the original sporty polyester fabric that's smooth inside and out and just slightly stretchy.";
            p9.Price = 75;
            p9.Amount = 100;
            products.InsertProduct(p9);

            Product p0 = new Product();
            p0.CategoryId = 2;
            p0.Title = "PALMESTON TRACK JACKET";
            p0.Description = "A TRACK JACKET WITH A LOOK BORROWED FROM THE ARCHIVES.\nThe original Palmeston track jacket came out in 1990.This track jacket revives the look with the same iconic color panels.It's made of interlock for an authentic, sporty feel.";
            p0.Price = 90;
            p0.Amount = 100;
            products.InsertProduct(p0);

            Product pp1 = new Product();
            pp1.CategoryId = 3;
            pp1.Title = "3-STRIPES PANTS";
            pp1.Description = "OPEN-HEM WORKOUT PANTS WITH AN ELASTIC WAIST.\nKeep up with your fitness goals in these comfortable pants.They're cut for a regular fit and feature open hems and a drawcord elastic waist. Side pockets provide a spot to stash your workout essentials.";
            pp1.Price = 40;
            pp1.Amount = 100;
            products.InsertProduct(pp1);

            Product pp2 = new Product();
            pp2.CategoryId = 3;
            pp2.Title = "TIRO 19 TRAINING PANTS";
            pp2.Description = "BREATHABLE PANTS THAT ARE BUILT TO MOVE.\nTrain hard. Stay cool. These soccer pants battle the heat with breathable, quick-drying fabric.They're made for a slim fit, with mesh details for extra airflow. Ankle zips allow you to pull them on or off over shoes.";
            pp2.Price = 45;
            pp2.Amount = 100;
            products.InsertProduct(pp2);

            Product pp3 = new Product();
            pp3.CategoryId = 3;
            pp3.Title = "SST TRACK PANTS";
            pp3.Description = "TRACK PANTS INSPIRED BY ADIDAS' RICH HISTORY.\nSee these track pants? They're a piece of adidas history. The SST track suit was designed in 1979 for tennis training. It quickly became a legendary look in the street style world. These track pants stay true to the design of the first track suits with a slim fit and tapered legs. Wear it with tees or go matchy-matchy with a 3-Stripes track jacket on top.";
            pp3.Price = 65;
            pp3.Amount = 100;
            products.InsertProduct(pp3);

            Product pp4 = new Product();
            pp4.CategoryId = 3;
            pp4.Title = "ADIDAS Z.N.E. PANTS";
            pp4.Description = "SLIM-FITTING PANTS WITH SECURE ZIP POCKETS IN THE FRONT AND BACK.\nDon't let anything weigh you down or hold you back. With a hint of stretch, the adidas Z.N.E. Pants give you a premium fit and feel. Multiple zip pockets hold your phone, keys or cash, keeping your hands, and your mind, open and free.";
            pp4.Price = 85;
            pp4.Amount = 100;
            products.InsertProduct(pp4);

            Product pp5 = new Product();
            pp5.CategoryId = 3;
            pp5.Title = "ALPHASKIN SPORT+ LONG 3-STRIPES TIGHTS";
            pp5.Description = "BODY-WRAPPING TIGHTS MADE FOR COOL, DRY COMFORT.\nFocus on your squats and lunges in these breathable long tights. Done in stretchy fabric, they feature a compression fit that wraps your body and follows every move you make. Built to manage heat and moisture, the tights include mesh inserts for targeted airflow as you dial up the intensity.";
            pp5.Price = 50;
            pp5.Amount = 100;
            products.InsertProduct(pp5);

            Product pp6 = new Product();
            pp6.CategoryId = 4;
            pp6.Title = "MINI LOGO RELAXED HAT";
            pp6.Description = "CLEAN AND SIMPLE, WITH A SUBTLE ADIDAS ACCENT.\nFeminine proportions give this hat effortless elegance.Styled in classic cotton, the relaxed six-panel design is embroidered with a small Trefoil logo. An adjustable strap closure offers a made -for-you fit.";
            pp6.Price = 18;
            pp6.Amount = 100;
            products.InsertProduct(pp6);

            Product pp7 = new Product();
            pp7.CategoryId = 4;
            pp7.Title = "WASHED DAD CAP";
            pp7.Description = "THE FIT AND FEEL OF AN OLD FAVORITE.\nA washed treatment gives this dad hat the look and feel of a well - worn favorite.Made of cotton twill, it has a pre - curved brim for ready - to - wear style.A simple adidas patch adds a sporty finishing touch.";
            pp7.Price = 28;
            pp7.Amount = 100;
            products.InsertProduct(pp7);

            Product pp8 = new Product();
            pp8.CategoryId = 4;
            pp8.Title = "ORIGINALS RELAXED STRAP-BACK HAT";
            pp8.Description = "A CASUAL CAP WITH ADIDAS ORIGINALS STYLE.\nThis men's hat has low-key Trefoil style with an embroidered logo on the front. Made of washed canvas, the hat has a crushable, packable design and an adjustable back strap so you can personalize the fit.";
            pp8.Price = 16;
            pp8.Amount = 100;
            products.InsertProduct(pp8);

            Product pp9 = new Product();
            pp9.CategoryId = 4;
            pp9.Title = "SST CAP";
            pp9.Description = "A SIMPLE CAP GETS AN UPDATE INSPIRED BY THE ADIDAS SUPERSTAR SHOE.\nAnother way to show off your adidas Superstar shoe love. Built of cotton twill, this cap features an embroidered tribute to the ever-popular adidas Superstar shoe with the famous shell - toe.The pre - curved brim makes it ready to wear from day one.";
            pp9.Price = 28;
            pp9.Amount = 100;
            products.InsertProduct(pp9);

            Product pp0 = new Product();
            pp0.CategoryId = 4;
            pp0.Title = "UV SUN HAT";
            pp0.Description = "A DURABLE GOLF SUN HAT BUILT TO HANDLE THE HEAT.\nSplit fairways in 3 - Stripes style all summer long.This adidas Sun Hat delivers extra coverage in sweltering conditions so you can maintain your focus. Find the perfect fit without distraction.";
            pp0.Price = 40;
            pp0.Amount = 100;
            products.InsertProduct(pp0);

        }
    }
}