using Pharmacy.Data.Interfaces;
using Pharmacy.Data.Models;

namespace Pharmacy.Data.Mocks
{
    public class MockCategory : MockGeneral<Category>, ICategory
    {
        public MockCategory(List<Category> listContent) : base(listContent)
        {
            listContent.AddRange(new List<Category>() {
                new Category()
                {
                    Id=1,
                    Name = "Ліки",
                    Description = Faker.Lorem.Sentence()
                },
                new Category()
                {
                    Id = 2,
                    Name = "Знеболювальне",
                    Description = Faker.Lorem.Sentence(),
                    ParentCategoryId = 1
                },
                new Category()
                {
                    Id = 3,
                    Name = "Жарознижаюче",
                    Description = Faker.Lorem.Sentence(),
                    ParentCategoryId = 1
                },
                new Category()
                {
                    Id = 4,
                    Name = "Противірусне",
                    Description = Faker.Lorem.Sentence(),
                    ParentCategoryId = 1
                }
                }
            );
        }

        public Category GetByName(string name)
        {
            return ListContent.FirstOrDefault(cat => cat.Name.Equals(name));
        }
    }
}
