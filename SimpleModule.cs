using System.Collections.Generic;
using Nancy;
using System.Linq;
using Newtonsoft.Json;

namespace EcoConception
{
    public class SimpleModule : NancyModule
    {
        public static List<Person> people { get; set; } = new List<Person>();

        public SimpleModule()
        {
            Get("/", _ => "Hello on application");

            Get("/users", _ =>
            {
                var item = people.Select(x => new { Id = x.Id, Name = x.Name }).ToList();

                return JsonConvert.SerializeObject(item);
            });

            Get("/users/{id}", p =>
            {
                var item = people.Where(i => i.Id == p.id).Select(x => new { Id = x.Id, Name = x.Name }).ToList();

                return JsonConvert.SerializeObject(item);
            });

            Delete("/users/{id}", p =>
            {
                var item = people.SingleOrDefault(x => x.Id == p.id);
                people.Remove(item);
                return JsonConvert.SerializeObject(item);
            });

            Put("/users/{name}/{password}", p =>
            {
                var id = people.Select(x => x.Id).Max() + 1;
                var item = new Person() { Id = id, Name = p.name, Password = p.password };
                people.Add(item);
                return JsonConvert.SerializeObject(item);
            });

            Post("/authentify/{name}/{password}", p =>
            {
                var item = people.SingleOrDefault(x => x.Name.Equals(p.name) && x.Password.Equals(p.password));                

                if (item != null)
                {
                    var person = new Person() { Id = item.Id, Name = item.Name };
                    return JsonConvert.SerializeObject(person);
                }
                else
                {
                    return new Person() { Id = 0, Name = null, Password = null };
                }                
            });
        }
    }
}
