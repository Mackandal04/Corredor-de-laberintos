using System;
using System.Collections.Generic;
using Spectre.Console;



namespace Project{

    class MazeDone
    {
        public void MazeInstance()
            {            
                Random random = new Random();

                int[]posiblesOrders = new int[]{31,33,35,37,39,41}; //Solo numeros impares

                int value = random.Next(1,6);
                Maze maze = new Maze(posiblesOrders[value]);

                int[,] generatedMaze = maze.GenerateMazeWithBorders();

                maze.PrintMaze(generatedMaze);
            }
    }
    class Maze
    {
        public int highAndWidth {get; set;}
        public Maze(int highAndWidth)
        {
            this.highAndWidth =highAndWidth;
        }
        Random random = new Random();

        public int[,] GenerateMazeWithBorders()
        {
            int mazeOrder = highAndWidth +2; //Annadir una fila y una columna a cada lado del maze 

            int[,]maze = new int[mazeOrder,mazeOrder];

            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    maze[i,j] = 1;// 1=> pared
                }
            }

            int[,] insideMaze = new Maze(highAndWidth).GenerateMaze();

            for (int i = 0; i < highAndWidth; i++)
            {
                for (int j = 0; j < highAndWidth; j++)
                {
                    maze[i+1,j+1] = insideMaze[i,j];//Ubicar matriz chiquita en matriz grande, sin tocar los bordes
                }
            }

            maze[1,0] = 0; //Abrir entrada
            maze[mazeOrder-2, mazeOrder-1] = 0; //Abrir salida

            return maze;
        }
        public int[,] GenerateMaze()
        {
            int mazeOrder = highAndWidth; //Igaul al alto y ancho porque es cuadrada

            int[,] maze = new int[mazeOrder,mazeOrder];

            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    maze[i,j]=1; // creamos todo con paredes para ir liberando caminos
                    //Comenzar con todo paredes ayuda a evitar las islas , pues tienes full control del camino al crearlo
                }
            }

            Backtracking(maze,mazeOrder,0,0);

            maze[0,0] = 0; //Entrada fija

            maze[mazeOrder-1,mazeOrder-1] = 0; //Salida fija

            return maze;
        }

        void Backtracking(int[,] maze,int mazeOrder, int CordX, int CordY)
        {
            maze[CordX,CordY] = 0; // Se marca la casilla actual como camino

            //Array de tuplas de posibles coordenadas
            (int,int)[] destinies = new (int, int)[]{(0,1),(1,0),(0,-1),(-1,0)};

            destinies = destinies.OrderBy(x=>random.Next()).ToArray();//Organizar el array de manera random utilizand LinQ

            foreach (var destiny in destinies)
            {
                //Salto de dos
                int newCordX = CordX + destiny.Item1 *2;

                int newCordY = CordY + destiny.Item2 *2;

                if(IsValid(maze,mazeOrder,newCordX,newCordY))
                {
                    maze[CordX+ destiny.Item1,CordY + destiny.Item2]=0; //Se marca la casilla intermedia 

                    Backtracking(maze,mazeOrder,newCordX,newCordY);
                }
            }
        }

        bool IsValid(int[,] maze, int mazeOrder, int newCordX, int newCordY)
        {
            //Si son coordenadas positivas y si no llegan al maze.GetLenght 
            return newCordX>=0 && newCordY>= 0 && newCordX<mazeOrder && newCordY<mazeOrder && maze[newCordX,newCordY]==1;
        }

        public void PrintMaze(int[,]maze)
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    AnsiConsole.Markup(maze[i,j] == 0 ? "  " : "[bold green on yellow]██[/]");
                }

                AnsiConsole.MarkupLine(" ");//Comando de Spectre, es como el WriteLinea, una linea de codigo por fila
            }
        }
    }
}