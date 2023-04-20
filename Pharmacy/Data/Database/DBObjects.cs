using Azure.Core;
using Faker.Extensions;
using Pharmacy.Data.Models;
using System.Runtime.Serialization;
using System.Security.Policy;

namespace Pharmacy.Data.Database
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {
            if (!content.MedicalForm.Any())
            {
                content.MedicalForm.AddRange(
                    new MedicalForm(){Name = "Таблетка"},
                    new MedicalForm(){Name = "Капсула"},
                    new MedicalForm(){Name = "Порошок"},
                    new MedicalForm(){Name = "Рідина"}

                );
            }
            if (!content.UserType.Any())
            {
                content.UserType.AddRange(
                    new UserType() {Name="Admin"},
                    new UserType() {Name="Client"}
                );
            }
            content.SaveChanges();

            if (!content.User.Any())
            {
                content.User.Add(new User()
                {
                    Surname = "Глущенко",
                    Name = "Олександр",
                    MiddleName = "Валентинович",
                    PhoneNumber = "+380532349387",
                    Email = "admin@info",
                    Password = "2FeO34RYzgb7xbt2pYxcpA==",
                    UserTypeId = 1
                }) ;
            }
            if (!content.DeliveryCompany.Any())
            {
                content.DeliveryCompany.AddRange(
                    new DeliveryCompany() {Name="Укрпошта"},
                    new DeliveryCompany() {Name="Нова пошта"},
                    new DeliveryCompany() {Name="Meest"}
                );
            }
            content.SaveChanges();
            if (!content.Substance.Any())
            {
                content.Substance.AddRange(
                    new Substance() { Name="Ацетилсаліцилова кислота"},
                    new Substance() { Name="Кофеїн"},
                    new Substance() { Name = "Етиловий спирт" },
                    new Substance() { Name = "Крахмаль" },
                    new Substance() { Name = "Целлюлоза" },
                    new Substance() { Name = "Кальцій" },
                    new Substance() { Name = "Нафанізол нітрат" },
                    new Substance() { Name = "Мед" },
                    new Substance() { Name = "Сахароза" },
                    new Substance() { Name = "Глюкоза" },
                    new Substance() { Name = "Ментол" },
                    new Substance() { Name = "Макрогол" }
                );
                content.SaveChanges();

            }
            if (!content.Manufacturer.Any())
            {
                content.Manufacturer.AddRange(
                    new Manufacturer() { Name = "Дарниця" },
                    new Manufacturer() { Name = "Elit-Farm" },
                    new Manufacturer() { Name = "MethLab" }

                );
                content.SaveChanges();
            }
            if (!content.Category.Any())
            {
                content.Category.Add(
                    new Category() {
                        Name = "Ліки",
                        Description = Faker.Lorem.Sentence()
                });
                content.SaveChanges();
                content.Category.AddRange(
                    new Category() { 
                        Name = "Знеболювальне",
                        Description = Faker.Lorem.Sentence(),
                        ParentCategoryId = 1
                    },
                    new Category()
                    {
                        Name = "Жарознижаюче",
                        Description = Faker.Lorem.Sentence(),
                        ParentCategoryId = 1
                    },
                    new Category()
                    {
                        Name = "Противірусне",
                        Description = Faker.Lorem.Sentence(),
                        ParentCategoryId = 1
                    }
                );
                content.SaveChanges();

            }

            if (!content.Drug.Any() && !content.DrugPackaging.Any()) {
                string[] DrugNames = new string[]
                {
                    "Невролексин", "Антифламекс", "Гіпнофорт", "Гастроклін", "Кардіопротек", "Парацетамол", "Остеоревіт", "Рендоксил", "Синусін", "Гепатонікс", "Локсидерм", "Тревоцил", "Мігралін", "Алергостоп", "Ревітолізин", "Травісил", "Уродрон", "Холестоконтроль", "Іммунофорс", "Реналекс"
                };
                for(int i = 0; i < 20; i++)
                {
                    int[] doses = new int[] { 250, 400, 500 };
                    var drug = new Drug()
                    {
                        Name = DrugNames[i],
                        Instruction = Faker.Lorem.Sentence(),
                        FormId = content.MedicalForm.Rand().Id,
                        Dose = doses[Faker.Number.RandomNumber(doses.Length - 1)],
                        Aindication = Faker.Lorem.Sentence(),
                        Contraindication = Faker.Lorem.Sentence(),
                        SideEffects = Faker.Lorem.Sentence(),
                    };
                    content.Drug.Add(drug);
                    content.SaveChanges();
                    for(int j=0;j<Faker.Number.RandomNumber(1,5); j++)
                    {
                   
                        content.DrugSubstance.Add(
                            new DrugSubstance()
                            {
                                DrugId = drug.Id,
                                SubstanceId = j+1,
                                Quantity = Faker.Number.RandomNumber(30, 80)
                            }
                        );
                        content.SaveChanges();
                      
                    }
                   
                    var good = new DrugPackaging()
                    {
                        Name = drug.Name,
                        Price = float.Parse(Faker.Commerce.Price()),
                        Description = Faker.Lorem.Sentence(),
                        StorageQuantity = 30,
                        DrugId = drug.Id,
                        PackQuantity = 6,
                        Weight = 0.1f,
                        ManufacturerId = Faker.Number.RandomNumber(1, 3),
                        PhotoPath = "/img/drug-cover.jpg",
                        CategoryId = Faker.Number.RandomNumber(2,5)
                       
                    };
                    content.Good.Add(good);
                    content.SaveChanges();
                    content.Good.Add(new DrugPackaging()
                    {
                        Name = good.Name,
                        Price = 2*good.Price+10,
                        Description = good.Description,
                        StorageQuantity = 30,
                        DrugId = drug.Id,
                        ManufacturerId = Faker.Number.RandomNumber(1, 3),
                        PackQuantity = good.PackQuantity *2,
                        PhotoPath = "/img/drug-cover.jpg",
                        CategoryId = Faker.Number.RandomNumber(2, 5)
                    });
                    content.SaveChanges();



                }

            }
            if (!content.OrderStatus.Any())
            {
                content.OrderStatus.AddRange(
                    new OrderStatus() { Name = "Created"},
					new OrderStatus() { Name = "Confirmed" },
					new OrderStatus() { Name = "Shipped" },
					new OrderStatus() { Name = "Delivered" },
					new OrderStatus() { Name = "Done" }
			    );
                content.SaveChanges();
            }
		}
    }
}
