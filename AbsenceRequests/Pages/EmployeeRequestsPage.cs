// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;
// using AbsenceRequests.Data;
// using AbsenceRequests.Models;
//
// namespace AbsenceRequests.Pages;
//
// public static class EmployeeRequestsPage
// {
//     public static void Run(DataContext context, Employee employee)
//     {
//         Dictionary<int, string> nav = new();
//
//         Output.Keymap();
//         Output.EmployeeInfo(context, employee);
//         Output.ViewEmployeeRequests(context, employee);
//
//         GetInput(context, employee, nav);
//     }
//
//     static void GetInput(DataContext context, Employee employee, Dictionary<int, string> nav)
//     {
//         while (true)
//         {
//             var key = Console.ReadKey(true).Key;
//
//             switch (key)
//             {
//                 case ConsoleKey.Escape:
//                     EmployeePage.Run(context, employee);
//                     return;
//
//                 case ConsoleKey.Q:
//                     Environment.Exit(0);
//                     return;
//
//                 default:
//                     continue;
//             }
//         }
//     }
// }
