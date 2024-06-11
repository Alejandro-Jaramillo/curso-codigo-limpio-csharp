namespace ToDo;

internal class Program
{
    public static List<string> TaskList { get; set; } = new List<string>();

    static void Main(string[] args)
    {
        int menuSelected = 0;
        do
        {
            menuSelected = ShowMainMenu();
            if ((Menu)menuSelected == Menu.Add)
            {
                ShowMenuAdd();
            }
            else if ((Menu)menuSelected == Menu.Remove)
            {
                ShowMenuRemove();
            }
            else if ((Menu)menuSelected == Menu.list)
            {
                ShowMenuMenuTaskList();
            }
        } while ((Menu)menuSelected != Menu.Exit);
    }
    /// <summary>
    /// Show the main menu 
    /// </summary>
    /// <returns>Returns option indicated by user</returns>
    public static int ShowMainMenu()
    {
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Ingrese la opción a realizar: ");
        Console.WriteLine("1. Nueva tarea");
        Console.WriteLine("2. Remover tarea");
        Console.WriteLine("3. Tareas pendientes");
        Console.WriteLine("4. Salir");

        // Read line
        string OptionSelected = Console.ReadLine();
        return Convert.ToInt32(OptionSelected);
    }

    public static void ShowMenuRemove()
    {
        try
        {
            Console.WriteLine("Ingrese el número de la tarea a remover: ");
            // Show current taks
            SeeList();

            string OptionSelected = Console.ReadLine();
            // Remove one position
            int indexToRemove = Convert.ToInt32(OptionSelected) - 1;
            if (indexToRemove > (TaskList.Count - 1) || indexToRemove < 0)
            {
                Console.WriteLine("Numero de tarea seleccionado invalidado");
            }
            else
            {
                if (indexToRemove > -1 && TaskList.Count > 0)
                {
                    string task = TaskList[indexToRemove];
                    TaskList.RemoveAt(indexToRemove);
                    Console.WriteLine($"Tarea {task} eliminada");

                }

            }
        }
        catch (Exception)
        {
            Console.WriteLine("Ha ocurrido un error al intentar eliminar la tarea seleccionada");
        }
    }

    public static void ShowMenuAdd()
    {
        try
        {
            Console.WriteLine("Ingrese el nombre de la tarea: ");
            string AddTask = Console.ReadLine();
            TaskList.Add(AddTask);
            Console.WriteLine("Tarea registrada");
        }
        catch (Exception)
        {
        }
    }

    public static void ShowMenuMenuTaskList()
    {
        if (TaskList?.Count > 0)
        {
            SeeList();

        }
        else
        {
            Console.WriteLine("No hay tareas por realizar");
        }
    }
    public enum Menu
    {
        Add = 1,
        Remove = 2,
        list = 3,
        Exit = 4
    }
    public static void SeeList()
    {
        Console.WriteLine("----------------------------------------");
        var indexTask = 1;
        TaskList.ForEach(x => Console.WriteLine($"{indexTask++} . {x}"));
        Console.WriteLine("----------------------------------------");
    }
}

