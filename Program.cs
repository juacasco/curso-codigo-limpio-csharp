using System;
using System.Collections.Generic;

namespace ToDo
{
    internal class Program
    {
        public static List<string> listOfTasks { get; set; }

        static void Main(string[] args)
        {
            listOfTasks = new List<string>();
            MenuOptions selectedMenu;
            do
            {
                selectedMenu = (MenuOptions)ShowMainMenu();
                if (selectedMenu == MenuOptions.AddTask)
                {
                    ShowMenuAddTask();
                }
                else if (selectedMenu == MenuOptions.RemoveTask)
                {
                    ShowMenuRemoveTask();
                }
                else if (selectedMenu == MenuOptions.ListTasks)
                {
                    ShowMenuListTasks();
                }
            } while (selectedMenu != MenuOptions.Exit);
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
            string userSelection = Console.ReadLine();
            return Convert.ToInt32(userSelection);
        }

        public static void ShowMenuRemoveTask()
        {
            try
            {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");
                // Show current taks
                for (int i = 0; i < listOfTasks.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + listOfTasks[i]);
                }
                Console.WriteLine("----------------------------------------");

                string userInput = Console.ReadLine();
                // Remove one position
                int indexToRemove = Convert.ToInt32(userInput) - 1;
                if (indexToRemove > -1)
                {
                    if (listOfTasks.Count > 0)
                    {
                        string task = listOfTasks[indexToRemove];
                        listOfTasks.RemoveAt(indexToRemove);
                        Console.WriteLine("Tarea " + task + " eliminada");
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public static void ShowMenuAddTask()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string taskToAdd = Console.ReadLine();
                listOfTasks.Add(taskToAdd);
                Console.WriteLine("Tarea registrada");
            }
            catch (Exception)
            {
            }
        }

        public static void ShowMenuListTasks()
        {
            if (listOfTasks == null || listOfTasks.Count == 0)
            {
                Console.WriteLine("No hay tareas por realizar");
            } 
            else
            {
                Console.WriteLine("----------------------------------------");
                for (int i = 0; i < listOfTasks.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + listOfTasks[i]);
                }
                Console.WriteLine("----------------------------------------");
            }
        }
    }
    public enum MenuOptions
    {
        AddTask = 1,
        RemoveTask = 2,
        ListTasks = 3,
        Exit = 4
    }
}
