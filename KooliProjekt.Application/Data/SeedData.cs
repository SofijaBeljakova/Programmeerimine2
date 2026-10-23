using System.Linq;

namespace KooliProjekt.Application.Data
{
    public static class SeedData
    {
        public static void Generate(ApplicationDbContext context)
        {
            if (context.TodoLists.Any())
            {
                return; 
            }

            SeedTodoLists(context);
            SeedTodoItems(context);
        }

        private static void SeedTodoLists(ApplicationDbContext context)
        {
            for (var i = 1; i <= 35; i++)
            {
                var list = new TodoLists
                {
                    Title = $"List {i}",
                    UserId = 1
                };
                context.TodoLists.Add(list);
            }

            context.SaveChanges();
        }

        private static void SeedTodoItems(ApplicationDbContext context)
        {
            for (var i = 1; i <= 35; i++)
            {
                var item = new TodoItem
                {
                    Title = $"Item {i}",
                    TodoListId = 1
                };
                context.TodoItems.Add(item);
            }

            context.SaveChanges();
        }
    }
}