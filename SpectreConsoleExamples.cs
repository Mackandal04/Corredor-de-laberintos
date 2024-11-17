// using System;
// using Spectre.Console;

// namespace Project
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             // AnsiConsole.MarkupLine("[blue]!Hello , Spectre.Console World![/]");

//             // var table = new Table();

//             // table.AddColumns("Columna 1", "Columna 2", "Columna 3");
//             // table.AddRow("Row 1", "Row 2", "Row 3");
//             // AnsiConsole.Write(table);

//             // AnsiConsole.MarkupLine("[blue] Esto es un cuadro o tabla[/]");

//             // AnsiConsole.MarkupLine("[bold]Presiona cualquier tecla para salir[/]");
//             // Console.ReadKey(true);

//             // Load an image
//             //var image = new CanvasImage("thunderstorm.png");

//             // Set the max width of the image.
//             // If no max width is set, the image will take
//             // up as much space as there is available.
//             //image.MaxWidth(6);

//             // Render the image to the console
//             //AnsiConsole.Write(image);


//             int alto = 4;
//             int ancho = 4;

//             int[,] matriz = new int[alto,ancho];

//             for (int i = 0; i < matriz.GetLongLength(0); i++)
//             {
//                 for (int j = 0; j < matriz.GetLongLength(1); j++)
//                 {
//                     matriz[i,j] = (i%2==0 && j%2==0) ? 1:0;
//                 }
//             }

//             int n = matriz.GetLength(0);

//             int m = matriz.GetLength(1);

//             for (int y = 0; y < n; y++)
//             {
//                 matriz[0,y] = 1;
//             }

//             for (int l = 0; l < m; l++)
//             {
//                 matriz[l,0] = 1;
//             }

//             for (int x = 0; x < n; x++)
//             {
//                 matriz[matriz.GetLength(0)-1,x] = 1;
//             }

//             for (int v = 0; v < m; v++)
//             {
//                 matriz[v,matriz.GetLength(1)-1] = 1;
//             }

//             for (int k = 0; k < matriz.GetLongLength(0); k++)
//             {
//                 string row = "";

//                 for (int l = 0; l < matriz.GetLongLength(1); l++)
//                 {
//                     if(matriz[k,l] == 1)
//                         row += "█";

//                     else
//                     row += " ";
//                 }
                
//                 AnsiConsole.MarkupLine("[blue]" + row + "[/]");
//             }

//         }
//     }
// }